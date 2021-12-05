using System;
using System.ComponentModel.DataAnnotations;
namespace TodoApi_backend.Models
{
    public class User
    {
        public int Id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public bool is_superuser { get; set; }
        [Display(Name = "註冊日期")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime RegisterDate { get; set; }

    }
}
