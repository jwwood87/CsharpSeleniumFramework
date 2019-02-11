namespace UdemyFramework
{
    internal class TestUser
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public Gender gender { get; set; }
    }

    internal enum Gender
    {
        Male,
        Female,
        Other
    }

}