using System;
using Microsoft.EntityFrameworkCore;
using PlatformService.Models;

namespace PlatformService.Data
{
    public class AppDbContext: DbContext
    {

    public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
    {
        
    }

    public virtual DbSet<Platform> Platforms {get; set;}

    }

}