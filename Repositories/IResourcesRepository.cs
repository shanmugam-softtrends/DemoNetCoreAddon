using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SFTAddonDemo.Models;

namespace SFTAddonDemo.Repositories
{
    public interface IResourcesRepository
    {
        void Add(Resources item);
        IEnumerable<Resources> GetAll();
        Resources Find(string key);
        void Remove(string id);
        void Update(Resources item);
        void Update(string id, string plan);
    }
}
