using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Test.Models
{
    public class SinhVien
    {
        [Key]
        public int MaSinhVien { get; set; }
        public string HoTen { get; set; }
        public string MaLop { get; set; }
    }

}