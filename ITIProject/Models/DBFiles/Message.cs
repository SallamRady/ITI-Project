using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ITIProject.Models.DBFiles
{
    public class Message
    {
        // ID.
        [Required]
        [Key]
        [Display(Name = "Message ID")]
        public int ID { get; set; }

        // Title.
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }
        
        [DataType(DataType.DateTime)]
        [Display(Name = "Message Time")]
        public string Time { get; set; }

        // SubTitle.
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Message Content")]
        public string Content { get; set; }
    }
}