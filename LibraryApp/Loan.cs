namespace LibraryApp
{
    public class Loan
    {
        public Loan
            (
            Document document, 
            User user, 
            DateTime loanDate, 
            DateTime expectedReturnDate, 
            DateTime? returnDate
            )
        {
            Document = document;
            User = user;
            LoanDate = loanDate;
            ExpectedReturnDate = expectedReturnDate;
            ReturnDate = returnDate;
        }

        public Document Document { get; set; }
        public User User { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime ExpectedReturnDate { get; private set; }
        public DateTime? ReturnDate { get; set; }

        public bool IsOverdue()
        {
            return DateTime.Today > ExpectedReturnDate && ReturnDate == null;
        }

        public bool IsReturned()
        {
            return ReturnDate != null;
        }

    }
}
