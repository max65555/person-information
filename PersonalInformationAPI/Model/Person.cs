namespace PersonalInformationAPI.Model
{
    public class Person
    {
        public int? personID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public string? gender { get;set; }
        public Person()
        {

        }
        public Person(int personID, string firstName, string lastName, string address, string gender)
        {
            this.personID = personID;
            this.firstName = firstName;
            this.lastName = lastName;
            this.address = address;
            this.gender = gender;
        }
    }
}
