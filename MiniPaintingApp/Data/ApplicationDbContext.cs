using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MiniPaintingApp.Models;

namespace MiniPaintingApp.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<PaintModel> Paints { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=MiniPaintingApp.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // modelBuilder.Entity<PaintModel>()
        //TODO: Read up on this
    }
    
    
}