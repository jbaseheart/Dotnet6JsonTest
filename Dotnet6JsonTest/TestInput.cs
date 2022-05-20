namespace Dotnet6JsonTest
{
    public class TestInput
    {
        public string Name { get; set; }
        public GenderType Gender { get; set; }

        public int Age { get; set; }
    }


    public enum GenderType
    {
        Male,
        Female
    }
}
