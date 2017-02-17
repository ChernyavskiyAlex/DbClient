using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Utils;


namespace ALMClient.Utils
{
    [XmlRoot(ElementName = "Entities")]
    public class Entities : IEquatable<Entities>
    {
        public Entities()
        {
            TotalResults = 0;
            Entity = new List<Entity>();
        }

        public Entities(int count) : this()
        {
            TotalResults = count;
        }

        [XmlElement(ElementName = "Entity")]
        public List<Entity> Entity { get; set; }
        [XmlElement(ElementName = "singleElementCollection")]
        public string SingleElementCollection { get; set; }
        [XmlAttribute(AttributeName = "TotalResults")]
        public int TotalResults { get; set; }

        public override bool Equals(object other)
        {
            if (other == null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            Entities tmp = other as Entities;
            if (tmp == null)
                return false;

            if (GetType() != other.GetType())
                return false;

            return Equals(other as Entities);
        }
        public bool Equals(Entities other)
        {
            if (other == null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (GetType() != other.GetType())
                return false;

            /*if (string.Compare(TotalResults, other.TotalResults, StringComparison.CurrentCulture) == 0 && Entity.Equals(other.Entity))
                return true;*/
            if (TotalResults == other.TotalResults && Entity.Equals(other.Entity))
                return true;

            return false;
        }

        public bool Add(Entity entity)
        {
            if (entity == null)
                return false;
            Entity.Add(entity);
            TotalResults++;
            return true;
        }
    }

    [XmlRoot(ElementName = "Entity")]
    public class Entity
    {
        private Fields _fields = null;
        private Entity()
        {
        }

        public Entity(string entityType)
        {
            Type = entityType;
        }

        [XmlElement(ElementName = "ChildrenCount")]
        public ChildrenCount ChildrenCount { get; set; }
        [XmlElement(ElementName = "Fields")]
        public Fields Fields { get; set; }
        [XmlElement(ElementName = "RelatedEntities")]
        public string RelatedEntities { get; set; }
        [XmlAttribute(AttributeName = "Type")]
        public string Type { get; set; }

        public override bool Equals(object other)
        {
            if (other == null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            Entity tmp = other as Entity;
            if (tmp == null)
                return false;

            if (GetType() != other.GetType())
                return false;

            return Equals(other as Entity);
        }
        public bool Equals(Entity other)
        {
            if (other == null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (GetType() != other.GetType())
                return false;

            //if (string.Compare(this.Type, other.Type, StringComparison.CurrentCulture) == 0 && this.Fields.Equals(other.Fields) && this.ChildrenCount.Equals(other.ChildrenCount) && this.RelatedEntities.Equals(other.RelatedEntities))
            if (string.Compare(Type, other.Type, StringComparison.CurrentCulture) == 0 && Fields.Equals(other.Fields))
                return true;
            return false;
        }

        public void Add(string fieldName, string fieldType, string value)
        {
            if (Fields == null)
                Fields = new Fields(fieldName, fieldType, value);
            Fields.Add(fieldName, fieldType, value);
        }

        public List<Field> GetRequired()
        {
            List<Field> reqList = new List<Field>();
            foreach (var field in Fields.Field)
            {
                if (AlmConnector.Instance.CustomizationData.ContainsKey(Type))
                {
                    CustomizationField fieldCust;
                    if (AlmConnector.Instance.CustomizationData[Type].TryFindFieldCustomization(field.Name, out fieldCust))
                    {
                        if (fieldCust.Required.ToLower().Equals("true"))
                        {
                            reqList.Add(field);
                        }
                    }
                }
            }
            return reqList;
        }


    }

    [XmlRoot(ElementName = "Fields")]
    public class Fields
    {
        private Fields()
        {
        }

        public Fields(string fieldName, string fieldType, string value)
        {
            Field = new List<Field> { new Field(fieldName, fieldType, value) };
        }

        [XmlElement(ElementName = "Field")]
        public List<Field> Field { get; set; }

        public override bool Equals(object other)
        {
            if (other == null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            Fields tmp = other as Fields;
            if (tmp == null)
                return false;

            if (GetType() != other.GetType())
                return false;

            return Equals(other as Fields);
        }
        public bool Equals(Fields other)
        {
            if (other == null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (GetType() != other.GetType())
                return false;

            if (Field.Count != other.Field.Count)
            {
                //Helper.WriteError($"Different amount of fields obj1: {Field.Count} and obj2: {other.Field.Count}");
                Helper.WriteError(string.Format("Different amount of fields obj1: {0} and obj2: {1}", Field.Count, other.Field.Count));
                if (Field.Count > other.Field.Count)
                    PrintDifference(this, other);
                else
                    PrintDifference(other, this);
                return false;
            }
            if (Field != null && other.Field != null)
                //TODO
                return false;

            return false;
        }
        public void Add(string fieldName, string fieldType, string value)
        {
            if (Field == null)
                Field = new List<Field>();
            Field.Add(new Field(fieldName, fieldType, value));
        }

        public void PrintDifference(Fields obj1, Fields obj2)
        {
            IEnumerable<Field> t = obj1.Field.Except(obj2.Field, new FieldComparer());
            IEnumerable<Field> t1 = obj2.Field.Except(obj1.Field, new FieldComparer());

            Helper.WriteChild("obj1 unique fields");
            foreach (var field in t)
            {
                Helper.WriteChild(field.Name);
            }
            Helper.WriteChild("obj2 unique fields");
            foreach (var field in t1)
            {
                Helper.WriteChild(field.Name);
            }
        }
    }

    [XmlRoot(ElementName = "Field")]
    public class Field
    {
        private string _name;
        Field()
        {
            Name = "";
            Value = "";
            FieldType = "";
        }

        public Field(string fieldName, string fieldType, string value)
        {
            FieldType = fieldType;
            Name = fieldName;
            Value = value;
        }

        [XmlElement(ElementName = "Value")]
        public string Value { get; set; }
        [XmlAttribute(AttributeName = "Name")]
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                if (string.IsNullOrEmpty(FieldType))
                    FieldType = FindFieldType(value);
            }
        }
        [XmlIgnore]
        public string FieldType { get; set; }

        public override bool Equals(object other)
        {
            if (other == null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            Field tmp = other as Field;
            if (tmp == null)
                return false;

            if (GetType() != other.GetType())
                return false;

            return Equals(other as Field);
        }
        public bool Equals(Field other)
        {
            if (other == null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (GetType() != other.GetType())
                return false;

            if (Name.Equals(other.Name) && Value.Equals(other.Value) && FieldType.Equals(other.FieldType))
                return true;
            return false;
        }

        private string FindFieldType(string fieldName)
        {
            var customizationDict = AlmConnector.Instance.CustomizationData;
            foreach (var entityType in customizationDict)
            {
                foreach (var field in entityType.Value.CustomizationField)
                {
                    if (fieldName.Equals(field.Name))
                    {
                        return field.Type;
                    }
                }
            }
            return null;
        }



    }

    [XmlRoot(ElementName = "ChildrenCount")]
    public class ChildrenCount
    {
        ChildrenCount()
        {
        }

        [XmlElement(ElementName = "Value")]
        public string Value { get; set; }
    }


    public class NoNamespaceXmlWriter : XmlTextWriter
    {
        //Provide as many contructors as you need
        public NoNamespaceXmlWriter(System.IO.TextWriter output)
            : base(output) { Formatting = System.Xml.Formatting.Indented; }

        public override void WriteStartDocument() { }

        public override void WriteStartElement(string prefix, string localName, string ns)
        {
            base.WriteStartElement("", localName, "");
        }
    }

    public class FieldComparer : IEqualityComparer<Field>
    {
        public bool Equals(Field x, Field y)
        {
            return x.Equals(y);
        }

        public int GetHashCode(Field obj)
        {
            return obj.Name.GetHashCode();
        }
        //public int GetHashCode(Field obj) => 0;
        //new StringBuilder(obj.Name).GetHashCode();
        /*.Append(obj.FieldType)
                .Append(obj.Value).GetHashCode();*/
    }
}