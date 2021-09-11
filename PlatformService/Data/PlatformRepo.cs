using System.Collections.Generic;
using PlatformService.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

namespace PlatformService.Data
{
    public class PlatformRepo : IPlatformRepo
    {
        private readonly AppDbContext _ctx;

        public PlatformRepo(AppDbContext ctx)
        {
            this._ctx = ctx;
        }
        public void CreatePlatform(Platform plat)
        {
            if(plat == null) throw new ArgumentNullException(nameof(plat));

            _ctx.Platforms.Add(plat);
        }

        public IEnumerable<Platform> GetAllPlatforms()
        {
            return _ctx.Platforms.ToList();
        }

        public Platform GetPlatformById(int id)
        {
            return _ctx.Find<Platform>(id);
            // return _ctx.Platforms.FirstOrDefault(e => e.Id == id);
        }

        public bool SaveChanges()
        {
            return (_ctx.SaveChanges() >= 0);
        }
    }
}