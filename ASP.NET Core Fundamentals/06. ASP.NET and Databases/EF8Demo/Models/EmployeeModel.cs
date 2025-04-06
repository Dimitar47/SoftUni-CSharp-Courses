using System.ComponentModel.DataAnnotations.Schema;

namespace EF8Demo.Models
{
    internal class EmployeeModel
    {
        [Column("name")]
        public required string Name { get; set; }

        [Column("email")]
        public required string Email { get; set; }

        [Column("room_number")]
        public int RoomNumber { get; set; }
    }
}
