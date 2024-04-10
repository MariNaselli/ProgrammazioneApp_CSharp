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
        }

        public int Id { get; set; }
        public string Ubication { get; set; }
        public string Title { get; set; }
        public int PublicationYear { get; set; }

    }

}
