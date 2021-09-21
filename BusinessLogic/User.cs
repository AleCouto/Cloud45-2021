using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusinessLogic
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        public bool AccessLevel { get; set; }

        [Required(ErrorMessage = "Name")]
        [StringLength(60, MinimumLength = 3)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy-}", ApplyFormatInEditMode = true)]
        [Display(Name = "Birthday")]
        public DateTime? Birthday { get; set; }

        [RegularExpression("[0-9]")]
        [Display(Name = "Phone Number")]
        public int PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email")]
        [Display(Name = "Email")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Invalid email")]
        public string Email { get; set; }

        [RegularExpression("[0-9]")]
        [Display(Name = "Indentification")]
        public string Indentification { get; set; }

        [RegularExpression("[0-9]")]
        [Display(Name = "Fiscal Number")]
        public int FiscalNumber { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        [RegularExpression("[0-7]")]
        [Display(Name = "Postal Code")]
        public int PostalCode { get; set; }

        public IList<Order> Order { get; set; }


        public User()
        {
        }

        public User(int userId, string name, string email, bool accesslevel)
        {
            UserId = userId;
            Name = name;
            Email = email;
            AccessLevel = accesslevel;
        }

        public User(int userId, string name, DateTime birthday, int phoneNumber, string email, string address, int postalCode, string indentification, int fiscalNumber)
        {
            UserId = userId;
            Name = name;
            Birthday = birthday;
            PhoneNumber = phoneNumber;
            Email = email;
            Address = address;
            PostalCode = postalCode;
            Indentification = indentification;
            FiscalNumber = fiscalNumber;
        }
    }
}