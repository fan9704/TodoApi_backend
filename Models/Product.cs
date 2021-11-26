using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApi_backend.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Display(Name = "產品名稱")]
        public string Name { get; set; }
        [Display(Name = "類別")]
        public string Type { get; set; }
        [Display(Name = "數量")]
        public int Quantity { get; set; }
        [Display(Name = "購買日期")]
        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime PurchaseDate { get; set; }


        [Display(Name = "銷售日期")]
        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime SellDate { get; set; }
        [Display(Name = "成本")]
        public int Cost { get; set; }
        [Display(Name = "售價")]
        public int Price { get; set; }
    }
}
