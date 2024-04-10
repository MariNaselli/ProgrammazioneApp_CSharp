using LibraryApp;
using System.Data;

namespace LibraryAppTests
{
    public class LibraryTest
    {
        [Fact]
        public void DocumentConstructorInitializesCorrectly()
        {
            int id = 1;
            string ubication = "Shelf A";
            string title = "Sample Document";
            int publicationYear = 2024;

            Document document = new Document(id, ubication, title, publicationYear);

            Assert.Equal(id, document.Id);
            Assert.Equal(ubication, document.Ubication);
            Assert.Equal(title, document.Title);
            Assert.Equal(publicationYear, document.PublicationYear);
        }

        [Fact]
        public void BookConstructorInitializesCorrectly()
        {
            int id = 2;
            string ubication = "Shelf A1";
            string title = "Simple Life";
            int publicationYear = 2024;
            Person[] authors = [new Person("Maria Luisa", "Lowis"), new Person("Robert", "Bool")];
            Person editor = new Person ("Mario Loren", "Forest");
            int editionNumber = 23;
            string isbnCode = "12345";
            string[] genres = ["Fantasy", "Mystery"];

            Book book = new Book (id, ubication, title, publicationYear, authors, editor, editionNumber, isbnCode, genres);

            Assert.Equal(id, book.Id);
            Assert.Equal(ubication, book.Ubication);
            Assert.Equal(title, book.Title);
            Assert.Equal(publicationYear, book.PublicationYear);
            Assert.Equal(authors, book.Authors);
            Assert.Equal(editor, book.Editor);
            Assert.Equal(editionNumber, book.EditionNumber);
            Assert.Equal(isbnCode, book.IsbnCode);
            Assert.Equal (genres, book.Genres);
        }

        [Fact]
        public void ScientificPublicationConstructorInitializesCorrectly()
        {
            int id = 67;
            string ubication = "Shelf B1";
            string title = "Dreams";
            int publicationYear = 2021;
            Person[] authors = [new Person("Maria Luisa", "Lowis"), new Person("Robert", "Bool")];
            string universityName = "Columbia University";
            string description = "The meaning of dreams";

            ScientificPublication scientificPublication = new ScientificPublication(id, ubication, title, publicationYear, authors, universityName, description);

            Assert.Equal(id, scientificPublication.Id);
            Assert.Equal(ubication, scientificPublication.Ubication);
            Assert.Equal(title, scientificPublication.Title);
            Assert.Equal(publicationYear, scientificPublication.PublicationYear);
            Assert.Equal(authors, scientificPublication.Authors);
            Assert.Equal(universityName, scientificPublication.UniversityName);
            Assert.Equal(description, scientificPublication.Description);
        }

        [Fact]
            public void PeriodicalConstructorInitializesCorrectly()
            {
                int id = 27;
                string ubication = "Shelf C5";
                string title = "Dogs and cats";
                int publicationYear = 2000;
                string issueNumber = "Weekly";
                string issnCode = "4567";
                string mediaType = "digital";

                Periodical periodical = new Periodical(id, ubication, title, publicationYear, issueNumber, issnCode, mediaType);

                Assert.Equal(id, periodical.Id);
                Assert.Equal(ubication, periodical.Ubication);
                Assert.Equal(title, periodical.Title);
                Assert.Equal(publicationYear, periodical.PublicationYear);
                Assert.Equal(issueNumber, periodical.IssueNumber);
                Assert.Equal(issnCode, periodical.IssnCode);
                Assert.Equal(mediaType, periodical.MediaType);
             }

        [Fact]
        public void PersonConstructorInitializesCorrectly()
        {
            string name = "Luisa";
            string lastName = "Run";

            Person person = new Person (name, lastName);

            Assert.Equal(name, person.Name);
            Assert.Equal(lastName, person.LastName);            
        }

        [Fact]
        public void UserConstructorInitializesCorrectly()
        {
            int cardNumber = 1;

            User user = new User(cardNumber);

            Assert.Equal(cardNumber, user.CardNumber);
        }

        [Fact]
        public void LoanConstructorInitializesCorrectly()
        {
            Document document = new Document(1, "Shelf A", "Free", 2024);
            User user = new User(89);
            DateTime loanDate = DateTime.Now;
            DateTime expectedReturnDate = loanDate.AddDays(7);
            DateTime? returnDate = null;

            Loan loan = new Loan(document, user, loanDate, expectedReturnDate, returnDate);

            Assert.Equal(document, loan.Document);
            Assert.Equal(user, loan.User);
            Assert.Equal(loanDate, loan.LoanDate);
            Assert.Equal(expectedReturnDate, loan.ExpectedReturnDate);
            Assert.Null(loan.ReturnDate);
        }
    }
}