namespace KBS1.Misc
{
    public class EditorObjectRepresentation : ILocatable
    {
        public Vector Location { get; set; }
        public string Id { get; set; }
        public int ZIndex { get; set; }

        public EditorObjectRepresentation(Vector location, string id, int zIndex)
        {
            Location = location;
            Id = id;
            ZIndex = zIndex;
        }
    }
}