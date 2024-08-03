using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Mobile_StoreAPI.Models;

public partial class MobilePhoneStoreProjectContext : DbContext
{
    public MobilePhoneStoreProjectContext()
    {
    }

    public MobilePhoneStoreProjectContext(DbContextOptions<MobilePhoneStoreProjectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Brand> Brand { get; set; }

    public virtual DbSet<Deals> Deals { get; set; }

    public virtual DbSet<Orders> Orders { get; set; }

    public virtual DbSet<Product> Product { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<OrderProductId> OrderProductId { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-T8OUTPA6;Initial Catalog=MobilePhoneStoreProject;Integrated Security=True;Trust Server Certificate=True;");

}
