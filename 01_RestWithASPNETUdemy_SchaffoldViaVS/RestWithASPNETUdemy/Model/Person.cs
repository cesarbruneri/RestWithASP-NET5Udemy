using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASPNETUdemy.Model
{
    [Table("Person")]
    public class Person
    {
        [Column("id")]
        public long Id { get; set; }
        [Column("ADDRESS")]
        public string FirstName { get; set; }
        [Column("first_name")]
        public string LastName { get; set; }
        [Column("last_name")]
        public string Address { get; set; }
        [Column("gender")]
        public string Gender { get; set; }
    }
}
