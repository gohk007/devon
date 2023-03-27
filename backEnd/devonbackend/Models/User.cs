using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Xml.Linq;

namespace devonbackend.Models
{
    public class User
    {
        public int ID { get; set; }

        [Required]
        public string NAME { get; set; }

        [Required]
        public string EMAIL { get; set; }

        
        public string PHONE { get; set; }

        [Required]
        public string ADDRESS { get; set; }

        [Required]
        public string COMPANY { get; set; }

        
    }
}
