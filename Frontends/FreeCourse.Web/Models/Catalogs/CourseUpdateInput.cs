using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace FreeCourse.Web.Models.Catalogs
{
    public class CourseUpdateInput
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        [Display(Name = "Kurs İsim")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "Kurs Ücret")]
        [Required]
        public decimal Price { get; set; }
        public string Picture { get; set; }
        [Display(Name = "Kurs Açıklama")]
        [Required]
        public string Description { get; set; }
        public FeatureViewModel Feature { get; set; }
        [Display(Name = "Kurs Kategori")]
        [Required]
        public string CategoryId { get; set; }
        public CategoryViewModel Category { get; set; }
        [Display(Name = "Kurs Resim")]
        public IFormFile PhotoFormFile { get; set; }
    }
}
