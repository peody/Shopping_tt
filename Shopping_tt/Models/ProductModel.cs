using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping_tt.Models
{
    public class ProductModel
    {
        [Key]
        public int Id { get; set; }
        [Required,MinLength(4,ErrorMessage ="Yeu cau nhap ten san pham")]
        public string Name { get; set; }
        public string Slug { get; set; }
        [Required,MinLength(4,ErrorMessage ="Yeu cau nhap mo ta san pham")]
        public string Description { get; set; }
        [Required,MinLength(4,ErrorMessage ="Yeu cau nhap gia san pham")]
        [Column(TypeName = "decimal(18,2)")] // Đặt kiểu SQL Server cho trường Price
        public decimal Price { get; set; }

        public int BrandId { get; set; }
        public int CatagoryId { get; set; }
        public CategoryModel Category { get; set; }
        public BrandModel Brand { get; set; }

    }
}
