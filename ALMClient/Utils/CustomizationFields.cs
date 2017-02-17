using System.Collections.Generic;
using System.Xml.Serialization;

namespace ALMClient.Utils
{
    [XmlRoot(ElementName = "Fields")]
    public class CustomizationFields
    {
        CustomizationFields()
        {
        }

        [XmlElement(ElementName = "Field")]
        public List<CustomizationField> CustomizationField { get; set; }

        public bool TryFindFieldCustomization(string name, out CustomizationField fieldCust)
        {
            fieldCust = null;
            foreach (var custField in CustomizationField)
                if (custField.Name.Equals(name))
                    fieldCust = custField;
            return fieldCust != null;
        }
    }

    [XmlRoot(ElementName = "Field")]
    public class CustomizationField
    {
        [XmlElement(ElementName = "Size")]
        public string Size { get; set; }
        [XmlElement(ElementName = "History")]
        public string History { get; set; }
        [XmlElement(ElementName = "Required")]
        public string Required { get; set; }
        [XmlElement(ElementName = "System")]
        public string System { get; set; }
        [XmlElement(ElementName = "Type")]
        public string Type { get; set; }
        [XmlElement(ElementName = "isTime")]
        public string IsTime { get; set; }
        [XmlElement(ElementName = "Verify")]
        public string Verify { get; set; }
        [XmlElement(ElementName = "Virtual")]
        public string Virtual { get; set; }
        [XmlElement(ElementName = "Active")]
        public string Active { get; set; }
        [XmlElement(ElementName = "Editable")]
        public string Editable { get; set; }
        [XmlElement(ElementName = "Filterable")]
        public string Filterable { get; set; }
        [XmlElement(ElementName = "Groupable")]
        public string Groupable { get; set; }
        [XmlElement(ElementName = "SupportsMultivalue")]
        public string SupportsMultivalue { get; set; }
        [XmlElement(ElementName = "Visible")]
        public string Visible { get; set; }
        [XmlElement(ElementName = "Searchable")]
        public string Searchable { get; set; }
        [XmlElement(ElementName = "VersionControlled")]
        public string VersionControlled { get; set; }
        [XmlElement(ElementName = "VisibleInWebUI")]
        public string VisibleInWebUI { get; set; }
        [XmlElement(ElementName = "Description")]
        public string Description { get; set; }
        [XmlElement(ElementName = "CanChangeRequired")]
        public string CanChangeRequired { get; set; }
        [XmlAttribute(AttributeName = "PhysicalName")]
        public string PhysicalName { get; set; }
        [XmlAttribute(AttributeName = "Name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "Label")]
        public string Label { get; set; }
        [XmlElement(ElementName = "List-Id")]
        public string ListId { get; set; }
        [XmlElement(ElementName = "References")]
        public References References { get; set; }
    }

    [XmlRoot(ElementName = "RelationReference")]
    public class RelationReference
    {
        [XmlAttribute(AttributeName = "RelationName")]
        public string RelationName { get; set; }
        [XmlAttribute(AttributeName = "ReferencedEntityType")]
        public string ReferencedEntityType { get; set; }
    }

    [XmlRoot(ElementName = "References")]
    public class References
    {
        [XmlElement(ElementName = "RelationReference")]
        public RelationReference RelationReference { get; set; }
    }
    
}
