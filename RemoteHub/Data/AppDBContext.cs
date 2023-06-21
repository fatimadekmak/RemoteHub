﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using RemoteHub.Models;

namespace RemoteHub.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

        public DbSet<Resume> Resumes { get; set; }
        public DbSet<Skill> Skills { get; set; }


    }
}
