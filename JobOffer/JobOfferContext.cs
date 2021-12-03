using JobOffer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobOffer
{
    public class JobOfferContext:DbContext
    {
        //kak izglejdata bazata danni i kak EF se griji za neq
        public DbSet<User> Users { get; set; }
        public DbSet<JobOfferModel> JobOffers { get; set; }
        public DbSet<UserApplication> UserApplications { get; set; }

        public JobOfferContext(DbContextOptions<JobOfferContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLazyLoadingProxies();
        }

        //vruzki, iztrivaniq i vsichko v DB
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JobOfferModel>()
                .HasOne(jo => jo.Creator);

            modelBuilder.Entity<JobOfferModel>()
                .HasMany(jo => jo.UserApplications)
                .WithOne()
                .HasForeignKey(ua => ua.JobOfferId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasMany(u => u.UserApplications)
                .WithOne()
                .HasForeignKey(ua => ua.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserApplication>()
                .HasOne(ua => ua.User)
                .WithMany(user => user.UserApplications);

            modelBuilder.Entity<UserApplication>()
                .HasOne(ua => ua.JobOffer)
                .WithMany(jo => jo.UserApplications);

        
        }
    }
}
