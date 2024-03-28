namespace OPPClassLibrary.Fiscal
{
    public class Person
    {
        private readonly string _firstName;
        private readonly string _lastName;
        private readonly DateOnly _dateOfBirth;
        private readonly string _placeOfBirth;
        private string _fiscalCode;
        private readonly Gender _gender;
        private readonly MaritalStatus _maritalStatus;

        //public string FirstName
        //{
        //    get
        //    {
        //        return _firstName;
        //    }
        //}

        public string FirstName =>
            _firstName;

        public string LastName =>
            _lastName;

        public DateOnly DateOfBirth =>
            _dateOfBirth;

        public string PlaceOfBirth =>
            _placeOfBirth;

        public string FiscalCode =>
            _fiscalCode;

        public Gender Gender =>
            _gender;

        public MaritalStatus MaritalStatus =>
            _maritalStatus;

    }

    //[Flags]
    //public enum Options
    //{
    //    Option1 = 0, //00000000000000000000000
    //    Option2 = 1, //00000000000000000000001
    //    Option3 = 2, //00000000000000000000010
    //    Option4 = 3, //00000000000000000000100
    //    Option5 = 8,
    //}



    //public enum MyBool
    //{
    //    True,
    //    False
    //}




}
