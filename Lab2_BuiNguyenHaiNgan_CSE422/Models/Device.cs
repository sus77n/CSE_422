using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;


namespace Lab2_BuiNguyenHaiNgan_CSE422.Models
{
    public class Device
    {
        public int Id { get; set; }
        public string Code { get; set; }

        public string Name { get; set; }

        public int CategoryId { get; set; } //// Required foreign key property
        [ForeignKey("CategoryId")]
        public Category Category { get; set; } = null!; // Required reference navigation to principal


        public string Status {  get; set; }
        public DateTime DateOfEntry { get; set; }

        public Device() { }
        public Device(string code, string name, Category c, string status, DateTime dt)
        {
            Code = code;
            Name = name;
            Category = c;
            Status = status;
            DateOfEntry = dt;
        }
    }
}
