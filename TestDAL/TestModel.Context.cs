﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestDAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class testDBEntities : DbContext
    {
        public testDBEntities()
            : base("name=testDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<PraxellMedia> PraxellMedia { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<T_Customers> T_Customers { get; set; }
        public virtual DbSet<T_Orders> T_Orders { get; set; }
    
        public virtual ObjectResult<SP_GetAllCustomers_Result> SP_GetAllCustomers()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_GetAllCustomers_Result>("SP_GetAllCustomers");
        }
    
        public virtual ObjectResult<GetCustomers_Result> GetCustomers()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetCustomers_Result>("GetCustomers");
        }
    
        public virtual int UpdateCustomer(Nullable<decimal> iD, string name)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(decimal));
    
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateCustomer", iDParameter, nameParameter);
        }
    }
}