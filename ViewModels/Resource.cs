using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SFTAddonDemo.ViewModels
{
    public class Resource
    {
        public Guid? uuid { get; set; }
        public string heroku_id { get; set; }
        public string plan { get; set; }
        public string region { get; set; }
        public string callback_url { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
}
