using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Context
{
    public class EFDataContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try
            {
                if (!optionsBuilder.IsConfigured)
                {
                    optionsBuilder.UseSqlServer("server=.\\SQLExpress;Database=DataAccessDB;Trusted_Connection=True;MultipleActiveResultSets=True");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
