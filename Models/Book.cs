namespace LmsApi.Models
{
    public enum ShelfLocation
    {
        // TODO: change enum values
        Loc1, Loc2, Loc3
    }

    public class Book
    {
        public long Id { get; set; }
        public String Name { get; set; }
        public String Author { get; set; }
        public String Genre { get; set; }
        public int Quantity { get; set; }
        public ShelfLocation ShelfLocation { get; set; }

        public ICollection<History>? Histories { get; set; }
    }
}