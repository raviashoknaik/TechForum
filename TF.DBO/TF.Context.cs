﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TF.DBO
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TechForumEntities : DbContext
    {
        public TechForumEntities()
            : base("name=TechForumEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Area> Areas { get; set; }
        public DbSet<Follower> Followers { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ThreadMaster> ThreadMasters { get; set; }
    }
}
