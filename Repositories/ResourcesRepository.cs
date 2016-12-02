using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SFTAddonDemo.Models;
using SFTAddonDemo.Data;
using Microsoft.EntityFrameworkCore;

namespace SFTAddonDemo.Repositories
{
    public class ResourcesRepository : IResourcesRepository
    {
        protected readonly SFTAddonContext _context;
        public ResourcesRepository(SFTAddonContext context)
        {
            _context = context;
        }

        public void Add(Resources item)
        {
            item.created_at = DateTime.UtcNow;
            _context.Resources.Add(item);
            _context.SaveChanges();
        }

        public Resources Find(string key)
        {
           return _context.Resources.Where(r => r.uuid == key).FirstOrDefault();
        }

        public IEnumerable<Resources> GetAll()
        {
            return _context.Resources.ToList();
        }

        public void Remove(string id)
        {
            var entity = Find(id);
            _context.Entry(entity).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public void Update(Resources item)
        {
            var entity = Find(item.uuid);
            entity.plan = item.plan;
            entity.updated_at = DateTime.UtcNow;
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Update(string id, string plan)
        {
            var entity = Find(id);
            entity.plan = plan;
            entity.updated_at = DateTime.UtcNow;
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
