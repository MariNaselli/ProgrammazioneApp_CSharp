namespace OPPClassLibrary.Fiscal
{
    public class Person

    {
        //private readonly string _firstName; //campi-campo
        //public string FirstName =>
        //    _firstName;

        //public string FirstName
        //{
        //    get
        //    {
        //        return _firstName;
        //    }
        //}


        //private readonly string _lastName;
        //private readonly DateOnly _dateOfBirth;
        //private readonly string _placeOfBirth;
        //private string _fiscalCode;
        //private readonly Gender _gender;
        //private readonly MaritalStatus _maritalStatus;


        
        private static readonly DateOnly MinValidDate = new DateOnly(1900, 1, 1);
        
        //Auto property in solo get.Readonly
        public string FirstName { get; }

        public string LastName { get; }
        public DateOnly DateOfBirth { get; }

        public string PlaceOfBirth { get; }

        public string FiscalCode { get; }

        public Gender Gender { get; }

        public MaritalStatus MaritalStatus { get; }

        public Person
        (
            string firstName,
            string lastName,
            DateOnly dateOfBirth,
            string placeOfBirth,
            string fiscalCode,
            Gender gender,
            MaritalStatus maritalStatus
        )


        {
            //firstNam(firstName, nameof(firstName));
            //ChekName(lastName, nameof(lastName));

            FirstName = SanitizeName(firstName);
            LastName = SanitizeName(lastName);
            DateOfBirth = SanitizeDateOfBirth(dateOfBirth);
            PlaceOfBirth = SanitizeName(placeOfBirth);
            FiscalCode = fiscalCode;
            Gender = gender;
            MaritalStatus = maritalStatus;
        }

        private static string SanitizeName(string name)
        {
            string paramName = nameof(name);
            const int nameMimLen = 2;
            const int nameMaxLen = 255;

            if (name is null)
            {
                //throw new ArgumentNullException("firstName");
                throw new ArgumentNullException(paramName);
            }

            string sanitizedName = name.Trim();

            if (sanitizedName.Length < 2)
            {
                throw new ArgumentException($"{paramName} must be at least {nameMimLen} chars lenght");
            }
            if (sanitizedName.Length > 255)
            {
                throw new ArgumentException($"{paramName} must be less than {nameMaxLen} chars lenght");
            }

            string invalidChars = "0123456789;::!!#$$%%#";

            foreach (var c in invalidChars)
            {
                if (sanitizedName.Contains(c))
                {
                    throw new ArgumentException($"{paramName} cannot contain char {c}");
                }

            }

            return sanitizedName;
        }

        private DateOnly SanitizeDateOfBirth(DateOnly date) =>
            IsDateOfBirthValid(date) ? date : throw new ArgumentException($"Invalid date of birth: {DateOfBirth.ToString("yyyy-mm-dd")}");

        private static bool IsDateOfBirthValid(DateOnly date) =>
            date <= DateOnly.FromDateTime(DateTime.Today)
            && (date >= MinValidDate);

    }





    //nome e congnome no null y due caratteri

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
