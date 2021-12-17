using System;
using System.ComponentModel.DataAnnotations;
namespace TodoApi_backend.Models
{
    public class User
    {


        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Superuser { get; set; }
        [Display(Name = "註冊日期")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime RegisterDate { get; set; }

    }
}
