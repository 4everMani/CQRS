namespace Domain
{
    public class Image
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Path { get; set; }

        public bool IsUploaded { get; set; }

        public int PropertyId { get; set; }

        public Property Property { get; set; }
    }
}
