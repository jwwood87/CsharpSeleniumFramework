namespace UdemyFramework
{
    internal class TestUser
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public Gender gender { get; set; }
        public string emergencyFirstName { get; set; }
        public string emergencyLastName { get; set; }
        public Gender EmergencyGender { get; set; }
    }

    internal enum Gender
    {
        Male,
        Female,
        Other
    }

}