using System;
using System.ComponentModel.DataAnnotations;

namespace WebMessengerMVC.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(1),MaxLength(300)]
        public string Content { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime SendDateTime { get; set; }


        [Required]
        public virtual User FromUser { get; set; }
        [Required]
        public virtual User ToUser { get; set; }
    }
}
