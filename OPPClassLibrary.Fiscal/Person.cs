using System.Linq;
using System.Reflection;

namespace OPPClassLibrary.Fiscal
{
    public class Person
    {

        string firstName = string.Empty;
        string lastName = string.Empty;
        DateOnly dateOfBirth = new DateOnly();
        string placeOfBirth = string.Empty;
        Gender gender;
        MaritalStatus maritalStatus;

        public Person(string firstName, string lastName, DateOnly dateOfBirth, string placeOfBirth, Gender gender, MaritalStatus maritalStatus)
        {
            this.FirstName = SanitizeName(firstName);
            this.LastName = SanitizeName(lastName);
            this.DateOfBirth = SanitizeDateOfBirth(dateOfBirth);
            this.PlaceOfBirth = placeOfBirth;
            this.Gender = gender;
            this.MaritalStatus = maritalStatus;
        }

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public DateOnly DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }
        public string PlaceOfBirth { get => placeOfBirth; set => placeOfBirth = value; }
        public Gender Gender { get => gender; set => gender = value; }
        public MaritalStatus MaritalStatus { get => maritalStatus; set => maritalStatus = value; }

        private string SanitizeName(string name)
        {
            string paramName = nameof(name);
            const int nameMimLen = 2;
            const int nameMaxLen = 255;

            if (name is null)
            {
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

        private DateOnly SanitizeDateOfBirth(DateOnly date)
        {
            DateOnly minValidDate = new DateOnly(1900, 1, 1);
            if(date <= DateOnly.FromDateTime(DateTime.Today) && 
                date > minValidDate)
            {
                return date;
            }
            else
            {
                throw new ArgumentException($"Invalid date of birth: {DateOfBirth.ToString("yyyy-mm-dd")}");
            }
        }

        public string Saludar()
        {
            return $"Hola {FirstName}";
        }

        public string SaludarFormalmente()
        {
            return $"Salve {LastName} {FirstName}";
        }

        public override string ToString()
        {
            return $"Hi, I'm {LastName}, {FirstName} {LastName}";
        }

    }


}
