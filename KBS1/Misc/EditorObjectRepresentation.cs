namespace KBS1.Misc
{
    public class EditorObjectRepresentation : ILocatable
    {
        public EditorObjectRepresentation(Vector location, string id, int zIndex)
        {
            Location = location;
            Id = id;
            ZIndex = zIndex;
        }
        
        public string Id { get; set; }
        public Vector Location { get; set; }
        public int ZIndex { get; set; }
    }
}