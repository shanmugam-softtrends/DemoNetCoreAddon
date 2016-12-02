using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SFTAddonDemo.Models;
using SFTAddonDemo.ViewModels;

namespace SFTAddonDemo.Extensions
{
    public static class ResourcesExtensions
    {
        public static Resources ToResources(this Resource resource)
        {
            return new Resources()
            {
                uuid = (resource.uuid == null || resource.uuid == Guid.Empty ? Guid.NewGuid().ToString() : resource.uuid.ToString()),
                heroku_id = resource.heroku_id,
                plan = resource.plan,
                callback_url = resource.callback_url,
                region = resource.region,
                created_at = resource.created_at == null ? DateTime.Now : (DateTime)resource.created_at
            };
        }
    }
}
