using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Hosting;

namespace Lab2_BuiNguyenHaiNgan_CSE422.Models
{
    public class Category
    {
        public int Id { get; set; }

        [MaxLength(30)]
        public string Title { get; set; }

        public ICollection<Device> Devices { get; } = new List<Device>(); // Collection navigation containing dependents



        public Category(string title)
        {
            Title = title;
        }
    }
}
