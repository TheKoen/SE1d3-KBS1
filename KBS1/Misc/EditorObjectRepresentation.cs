namespace KBS1.Misc
{
    public class EditorObjectRepresentation : ILocatable
    {
        public EditorObjectRepresentation(Vector location, string id)
        {
            Location = location;
            Id = id;
        }

        public string Id { get; set; }
        public Vector Location { get; set; }
    }
}