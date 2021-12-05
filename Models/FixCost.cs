using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TodoApi_backend.Data;
namespace TodoApi_backend.Models {
    public class FixCost {
        [Display(Name = "成本編號")]
        public int Id { get; set; }
        [Display(Name = "費用名稱")]
        public string Name { get; set; }
        [Display(Name = "類別")]
        public string Type { get; set; }

        [Display(Name = "費用發生日期")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BeginDate { get; set; }//TODO 改成date
        [Display(Name = "費用結束日期")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }
        [Display(Name = "成本")]
        public int Cost { get; set; }

    }
}
