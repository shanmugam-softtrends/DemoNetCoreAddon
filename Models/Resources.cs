using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SFTAddonDemo.Models
{
    public class Resources
    {
        [Key]
        public string uuid { get; set; }
        [DataType(DataType.Text)]
        public string heroku_id { get; set; }
        [DataType(DataType.Text)]
        public string plan { get; set; }
        [DataType(DataType.Text)]
        public string region { get; set; }
        [DataType(DataType.Text)]
        public string callback_url { get; set; }
        [DataType(DataType.Date)]
        public DateTime created_at { get; set; }
        [DataType(DataType.Date)]
        public DateTime updated_at { get; set; }
    }
}
