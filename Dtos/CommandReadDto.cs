namespace Commander.Dtos
{
    public class CommandReadDto
    {
        public int Id { get; set; }
        public string HowTo { get; set; }
        public string Line { get; set; }

        // This is an example to how to hide some properties in the result set
        // public string Platform { get; set; }
    }
}