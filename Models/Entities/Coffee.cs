using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyPortfolio.Models.Entities
{
    public class Coffee
    {
        public int Id { get; set; }

        [DisplayName("نام محصول")]
        [Required(ErrorMessage = "پر کردن فیلد {0} اجباری است.")]
        public required string Name { get; set; }

        [DisplayName("قیمت")]
        [Required(ErrorMessage = "پر کردن فیلد {0} اجباری است.")]
        public required int Price { get; set; }

        [DisplayName("موجود")]
        [Required(ErrorMessage = "پر کردن فیلد {0} اجباری است.")]
        public required bool Available { get; set; }

        [DisplayName("نوع")]
        [Required(ErrorMessage = "پر کردن فیلد {0} اجباری است.")]
        public required Category Type { get; set; }

        [DisplayName("عکس")]
        [Required(ErrorMessage = "پر کردن فیلد {0} اجباری است.")]
        public required string ImagePath { get; set; }
    }
    public enum Category
    {
        Hot,
        Iced
    }
}
