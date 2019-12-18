using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class ContactUs
    {
        [Required(ErrorMessage = "Please provide valid name to contact you.")]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please provide message with in 50 words."), MaxLength(100)]
        public string Message { get; set; }
    }
}
