namespace LmsApi.Models
{
    public class History
    {
        public long Id { get; set; }
        public long BookId { get; set; }
        public long BorrowerId { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public DateTime? ActualReturnDate { get; set; }

        public Book Book { get; set; }
        public User Borrower { get; set; }
    }
}