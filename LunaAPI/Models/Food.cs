
using System.ComponentModel.DataAnnotations;

namespace LunaAPI.Models {

    public class Food {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string ImageSrc { get; set; }
        public int Rating { get; set; }
    }
}