namespace System.ComponentModel.DataAnnotations
{
    public class DataInfoAttribute : Attribute
    {
        public string AreaName { get; set; }

        public string MetaName { get; set; }

        public string SingleName { get; set; }

        public string PluralName { get; set; }
    }
}
