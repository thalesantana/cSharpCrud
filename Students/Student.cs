namespace cSharpCrud.Students
{
    public class Student(string name)
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public string Name { get; private set; } = name;
        public bool Active { get; private set; } = true;
    }
}