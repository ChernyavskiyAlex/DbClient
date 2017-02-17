using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using ALMClient.Utils;
using Utils;

namespace ALMClient
{
    public class AlmConnector : RestClient
    {
        protected string ServerName;
        protected string UserName;
        protected string UserPass;
        protected string Domain;
        protected string Project;
        private List<string> EntitiesNameForCustomization;
        public Dictionary<string, CustomizationFields> CustomizationData;

        private static AlmConnector _instance;

        private AlmConnector()
        {
            EntitiesNameForCustomization = new List<string>()
            {
                Const.RequirementCustomizationName,
                Const.DefectCustomizationName
            };
            CustomizationData = new Dictionary<string, CustomizationFields>();
        }

        public static AlmConnector Instance
        {
            get { return _instance ?? (_instance = new AlmConnector()); }
        }

        public void Init(AlmProperies prop)
        {
            //ServerName = prop.IsHttps ? "https://" : "http://";
            ServerName = new StringBuilder(prop.IsHttps ? "https://" : "http://")
                .Append(prop.AlmServer)
                //.Append(prop.AlmPort == 0 ? "" : $":{prop.AlmPort}")
                .Append(prop.AlmPort == 0 ? "" : ":"+prop.AlmPort)
                .Append("/qcbin")
                .ToString();
            //ServerName += prop.AlmServer + ":" + prop.AlmPort + "/qcbin";
            UserName = prop.AlmAdminName;
            UserPass = prop.AlmAdminPassword;
            Domain = prop.Domain;
            Project = prop.Project;
        }


        public void GetCustomizationData()
        {
            LoginAlm();
            foreach (var type in EntitiesNameForCustomization)
            {
                try
                {
                    var cust = GetEntityMetadata(type);
                    CustomizationData.Add(type, cust);
                }
                catch (Exception e)
                {
                    //throw new Exception($"Cannot get CustomizationData for: {type}, stacktrace: {e}");
                    throw new Exception(string.Format("Cannot get CustomizationData for: {0}, stacktrace: {1}",type, e));
                }
            }
            LogoutAlm();
        }

        private CustomizationFields GetEntityMetadata(string type)
        {
            var url = new StringBuilder(ServerName)
                .Append(string.Format(UriLib.GetFieldsCustomization, Domain, Project, type)).ToString();
            return DeserializeFromXml<CustomizationFields>(url);
        }

        public void LoginAlm()
        {
            //Helper.WriteInfo($"Trying to login to {ServerName} with user: \"{UserName}\" and password: \"{UserPass}\"");
            Helper.WriteInfo(string.Format("Trying to login to {0} with user: \"{1}\" and password: \"{2}\"", ServerName, UserName, UserPass));
            Authenticate(ServerName, UserName, UserPass);
            OpenSession(ServerName);
        }

        public void LogoutAlm()
        {
            //Helper.WriteInfo($"Trying to logout from {ServerName}");
            Helper.WriteInfo(string.Format("Trying to logout from {0}", ServerName));
            CloseSession(ServerName);
            Logout(ServerName);
        }
        public HttpWebResponse Authenticate(string serverName, string userName, string password)
        {
            var url = serverName + UriLib.Authenticate;
            HttpWebResponse response = null;
            Dictionary<string, string> authHeader = new Dictionary<string, string>();
            //Adding auth header with username:password string encoded to base64
            authHeader.Add("Authorization",
                "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(userName + ":" + password)));
            try
            {
                response = GET(url, "", "", cookies, authHeader);
                Helper.WriteChild("Authenticated");
            }
            catch (Exception)
            {
                var statusCode = "";
                if (response != null)
                    statusCode = response.StatusCode.ToString();
                //throw new Exception($"Could not authenticate to server {serverName} with UserName {userName} and Password {password}, server response: {statusCode}");
                throw new Exception(string.Format("Could not authenticate to server {0} with UserName {1} and Password {2}, server response: {3}", serverName, userName, password, statusCode));
            }
            return response;
        }

        public HttpWebResponse OpenSession(string serverName)
        {
            string url = serverName + UriLib.OpenSession;
            HttpWebResponse response = null;

            try
            {
                response = POST(url, "", "", cookies, null, null);
                Helper.WriteChild("Session created");
            }
            catch (Exception)
            {
                var statusCode = "";
                if (response != null)
                    statusCode = response.StatusCode.ToString();
                //throw new Exception($"Could not open session to server {serverName}, server response: {statusCode}");
                throw new Exception(string.Format("Could not open session to server {0}, server response: {1}", serverName, statusCode));
            }
            return response;
        }

        public HttpWebResponse CloseSession(string serverName)
        {
            string url = serverName + UriLib.OpenSession;
            HttpWebResponse response = null;

            try
            {
                response = DELETE(url, "", "", cookies, null);
                Helper.WriteChild("Session closed");
            }
            catch (Exception)
            {
                var statusCode = "";
                if (response != null)
                    statusCode = response.StatusCode.ToString();
                //throw new Exception($"Could not close session to server {serverName}, server response: {statusCode}");
                throw new Exception(string.Format("Could not close session to server {0}, server response: {1}", serverName, statusCode));
            }
            return response;
        }

        public HttpWebResponse Logout(string serverName)
        {
            string url = serverName + UriLib.Logout;
            HttpWebResponse response = null;
            try
            {
                response = GET(url, "", "", cookies, null);
                Helper.WriteChild("log out");
            }
            catch (Exception)
            {
                var statusCode = "";
                if (response != null)
                    statusCode = response.StatusCode.ToString();
                //throw new Exception($"Could not logout from server {serverName}, server response: {statusCode}");
                throw new Exception(string.Format("Could not logout from server {0}, server response: {1}", serverName, statusCode));
            }
            return response;
        }

        public XDocument GetXdoc(string url)
        {
            XDocument xdoc;
            string serverResponseCode = "";
            try
            {
                using (var httpResponse = GET(url, MimeTypes.ApplicationXml, "", cookies, null))
                {
                    serverResponseCode = httpResponse.StatusCode.ToString();
                    using (var responseStream = httpResponse.GetResponseStream())
                    {
                        if (responseStream == null)
                        {
                            return null;
                        }
                        xdoc = XDocument.Load(responseStream);
                    }
                }
            }
            catch (Exception)
            {
                //throw new Exception($"Could not get xml from url: {url}, sever respond {serverResponseCode}");
                throw new Exception(string.Format("Could not get xml from url: {0}, sever respond {1}", url, serverResponseCode));
            }
            return xdoc;
        }

        public StringWriter SerializeToXml<T>(T obj)
        {
            var encoding = Encoding.GetEncoding("UTF-8");
            try
            {
                using (StringWriter stringWriter = new StringWriter())
                {
                    XmlWriterSettings xmlWrSet = new XmlWriterSettings()
                    {
                        CloseOutput = false,
                        Encoding = encoding,
                        OmitXmlDeclaration = false,
                        Indent = true
                    };
                    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                    ns.Add("", "");
                    using (XmlWriter xw = XmlWriter.Create(stringWriter, xmlWrSet))
                    {
                        xw.WriteProcessingInstruction("xml", "version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"");
                        XmlSerializer s = new XmlSerializer(typeof(T));
                        s.Serialize(xw, obj, ns);
                    }
                    return stringWriter;
                }
            }
            catch (Exception)
            {
                //throw new Exception($"Could not serialize {obj} to xml");
                throw new Exception("Could not serialize object to xml");
            }
        }

        public T DeserializeFromXml<T>(string url)
        {
            var xdoc = GetXdoc(url);
            if (xdoc != null)
            {
                if (xdoc.Root != null)
                {
                    var s = new XmlSerializer(typeof(T));
                    return (T)s.Deserialize(xdoc.CreateReader());
                }
            }
           
            //throw new Exception($"Could not deserialize xml from {url}");
            throw new Exception(string.Format("Could not deserialize xml from {0}", url));
        }

        public Entity GetRequirement(int id)
        {
            //Helper.WriteInfo($"Trying to get reqirement by id: {id}");
            Helper.WriteInfo(string.Format("Trying to get reqirement by id: {0}", id));
            var url = new StringBuilder(ServerName)
                .Append(string.Format(UriLib.GetRequirements, Domain, Project))
                .Append("/")
                .Append(id)
                .ToString();

            return DeserializeFromXml<Entity>(url);
        }

        public Entities GetRequirements(EntityFilter filter)
        {
            throw new NotImplementedException();
            Helper.WriteInfo("Trying to get reqirements using filter");
            var url = new StringBuilder(ServerName)
                .Append(string.Format(UriLib.GetRequirements, Domain, Project))
                .Append("?")
                .Append(filter)
                .ToString();
            return DeserializeFromXml<Entities>(url);
        }

        public Entities GetRequirements()
        {
            Helper.WriteInfo("Trying to get all reqirements");
            var url = new StringBuilder(ServerName)
                .Append(string.Format(UriLib.GetRequirements, Domain, Project))
                .ToString();
            return DeserializeFromXml<Entities>(url);
        }

        public bool CompareRequired(Entity obj1, Entity obj2)
        {
            if (obj1 == null || obj2 == null)
            {
                Helper.WriteError("Object could not be null");
                return false;
            }
            if (obj1.Fields == null || obj2.Fields == null)
            {
                Helper.WriteError("Object fields could not be null");
                return false;
            }
            if (obj1.Fields.Field.Count < 1 || obj2.Fields.Field.Count < 1)
            {
                Helper.WriteError("Object fields are empty");
                return false;
            }
            if (!obj1.Type.Equals(obj2.Type))
            {
                Helper.WriteError("Objects types not equal");
                return false;
            }

            var reqObj1 = obj1.GetRequired();
            var reqObj2 = obj2.GetRequired();

            IEnumerable<Field> t = reqObj1.Except(reqObj2, new FieldComparer());
            IEnumerable<Field> t1 = reqObj2.Except(reqObj1, new FieldComparer());

            if (t.Any() || t1.Any())
            {
                Helper.WriteError("Objects are not equals");
                if (t.Any())
                    Helper.WriteChild("Obj1 has unique required fields:");
                foreach (var field in t)
                    Helper.WriteChild(string.Format("Field name:   {0};   Value:   {1};   ", field.Name,field.Value));
                    //Helper.WriteChild($"Field name:   {field.Name};   Value:   {field.Value};   ");
                if (t1.Any())
                    Helper.WriteChild("Obj2 has unique required fields:");
                foreach (var field in t1)
                    Helper.WriteChild(string.Format("Field name:   {0};   Value:   {1};   ", field.Name, field.Value));
                    //Helper.WriteChild($"Field name:   {field.Name};   Value:   {field.Value};   ");
                return false;
            }
            return true;
        }
    }
}

