using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using SushiBarDatabaseImplement.Models;

namespace SushiBarDatabaseImplement
{
    public class SushiBarDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=RIPZ-PC\SQLEXPRESS;Initial Catalog=SushiBarDatabase;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Sushi> Sushis { set; get; }
        public virtual DbSet<Dish> Dishes { set; get; }
        public virtual DbSet<DishSushi> DishSushis { set; get; }
        public virtual DbSet<Order> Orders { set; get; }

    }
}
