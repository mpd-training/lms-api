namespace LmsApi.Models
{
    public class User
    {
        public long Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Email { get; set; }
        public int RoleId { get; set; }

        public ICollection<History>? Histories { get; set; }
    }
}