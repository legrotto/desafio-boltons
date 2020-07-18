namespace DesafioBoltons.Domain.Entities
{
    public class NFeEntity : BaseEntity<int>
    {
        public string Access_key { get; private set; }
        public string Xml { get; private set; }

        private NFeEntity() { }

        public NFeEntity(string access_key, string xml)
        {
            Access_key = access_key;
            Xml = xml;
        }
    }
}
