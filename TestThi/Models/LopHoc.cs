using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Test.Models
{
    public class LopHoc
    {
        [Key]
        public int MaLop { get; set; }
        public string TenLop { get; set; }
    }

}

