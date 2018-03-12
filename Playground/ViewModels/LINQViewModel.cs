using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Playground.ViewModels
{
    public class LINQViewModel
    {
        public int Id { get; set; }

        [Display(Name = "姓名")]
        public string UserName { get; set; }

        [DisplayFormat(DataFormatString = "{0:N0}")]
        public int Price { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime CreateTime { get; set; }
        public List<int> Items { get; set; }
    }
}