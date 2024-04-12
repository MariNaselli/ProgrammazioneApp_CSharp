namespace LibraryApp
{
    public class Document
    {
        public Document
            (
            int id,
            string ubication,
            string title,
            int publicationYear
            )
        {
            Id = id;
            Ubication = ubication;
            Title = title;
            PublicationYear = publicationYear;
            IsAvailableForLoan = true;
        }

        public int Id { get; set; }
        public string Ubication { get; set; }
        public string Title { get; set; }
        public int PublicationYear { get; set; }

        public bool IsAvailableForLoan { get; private set; }

        public void LoanOut()
        {
            if (!IsAvailableForLoan)
            {
                throw new InvalidOperationException("This document is already on loan.");
            }
            IsAvailableForLoan = false;
        }

        public void Return()
        {
            if (IsAvailableForLoan)
            {
                throw new InvalidOperationException("This document is not currently on loan.");
            }
            IsAvailableForLoan = true;
        }
    }

}
