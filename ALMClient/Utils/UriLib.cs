namespace ALMClient.Utils
{
    public class UriLib
    {
        public const string Authenticate = "/authentication-point/authenticate";
        public const string OpenSession = "/rest/site-session";
        public const string Logout = "/authentication-point/logout";
        public const string GetRequirements = "/rest/domains/{0}/projects/{1}/requirements";
        public const string GetCustomizationData = "/rest/domains/{0}/projects/{1}/customization/entities/{2}";
        public const string GetFieldsCustomization = "/rest/domains/{0}/projects/{1}/customization/entities/{2}/fields";
    }
}
