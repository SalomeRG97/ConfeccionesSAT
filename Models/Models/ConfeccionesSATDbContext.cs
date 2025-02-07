using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Models.Models;

public partial class ConfeccionesSATDbContext : DbContext
{
    public ConfeccionesSATDbContext(DbContextOptions<ConfeccionesSATDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BillingAccount> BillingAccounts { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Input> Inputs { get; set; }

    public virtual DbSet<Machine> Machines { get; set; }

    public virtual DbSet<MaintenancePlan> MaintenancePlans { get; set; }

    public virtual DbSet<MaintenanceTask> MaintenanceTasks { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8_general_ci")
            .HasCharSet("utf8");

        modelBuilder.Entity<BillingAccount>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("billing_account");

            entity.HasIndex(e => e.IdClient, "billing_account_id_client_foreign");

            entity.HasIndex(e => e.IdOrder, "billing_account_id_order_foreign");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Amount)
                .HasPrecision(8, 2)
                .HasColumnName("amount");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.DueDate).HasColumnName("due_date");
            entity.Property(e => e.IdClient)
                .HasColumnType("int(11)")
                .HasColumnName("id_client");
            entity.Property(e => e.IdOrder)
                .HasColumnType("int(11)")
                .HasColumnName("id_order");
            entity.Property(e => e.InvoiceNumber)
                .HasMaxLength(255)
                .HasColumnName("invoice_number");
            entity.Property(e => e.IssueDate).HasColumnName("issue_date");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'Pending'")
                .HasColumnType("enum('Pending','Paid','Cancelled')")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.BillingAccounts)
                .HasForeignKey(d => d.IdClient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("billing_account_id_client_foreign");

            entity.HasOne(d => d.IdOrderNavigation).WithMany(p => p.BillingAccounts)
                .HasForeignKey(d => d.IdOrder)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("billing_account_id_order_foreign");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("city");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("client");

            entity.HasIndex(e => e.IdCity, "client_id_city_foreign");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.ContactName)
                .HasMaxLength(255)
                .HasColumnName("contact_name");
            entity.Property(e => e.IdCity)
                .HasColumnType("int(11)")
                .HasColumnName("id_city");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Nit)
                .HasColumnType("bigint(20)")
                .HasColumnName("nit");
            entity.Property(e => e.Phone)
                .HasColumnType("bigint(20)")
                .HasColumnName("phone");

            entity.HasOne(d => d.IdCityNavigation).WithMany(p => p.Clients)
                .HasForeignKey(d => d.IdCity)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("client_id_city_foreign");
        });

        modelBuilder.Entity<Input>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("input");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(255)
                .HasColumnName("image_url");
            entity.Property(e => e.Lot)
                .HasColumnType("bigint(20)")
                .HasColumnName("lot");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.PurchaseDate).HasColumnName("purchase_date");
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .HasColumnName("type");
        });

        modelBuilder.Entity<Machine>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("machine");

            entity.HasIndex(e => e.IdMaintenancePlan, "machine_inventory_id_maintenance_plan_foreign");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.IdMaintenancePlan)
                .HasColumnType("int(11)")
                .HasColumnName("id_maintenance_plan");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(255)
                .HasColumnName("image_url");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.PurchaseDate).HasColumnName("purchase_date");
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .HasColumnName("type");

            entity.HasOne(d => d.IdMaintenancePlanNavigation).WithMany(p => p.Machines)
                .HasForeignKey(d => d.IdMaintenancePlan)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("machine_inventory_id_maintenance_plan_foreign");
        });

        modelBuilder.Entity<MaintenancePlan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("maintenance_plan");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<MaintenanceTask>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("maintenance_tasks");

            entity.HasIndex(e => e.IdMaintenancePlan, "maintenance_tasks_id_maintenance_plan_foreign");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.IdMaintenancePlan)
                .HasColumnType("int(11)")
                .HasColumnName("id_maintenance_plan");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.NextDate).HasColumnName("next_date");
            entity.Property(e => e.Periodicity)
                .HasColumnType("enum('Daily','Weekly','Monthly','Quarterly','Yearly')")
                .HasColumnName("periodicity");
            entity.Property(e => e.StartDate).HasColumnName("start_date");

            entity.HasOne(d => d.IdMaintenancePlanNavigation).WithMany(p => p.MaintenanceTasks)
                .HasForeignKey(d => d.IdMaintenancePlan)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("maintenance_tasks_id_maintenance_plan_foreign");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("orders");

            entity.HasIndex(e => e.IdClient, "orders_id_client_foreign");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.IdClient)
                .HasColumnType("int(11)")
                .HasColumnName("id_client");
            entity.Property(e => e.OrderDate).HasColumnName("order_date");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'Pending'")
                .HasColumnType("enum('Pending','Shipped','Delivered','Cancelled')")
                .HasColumnName("status");
            entity.Property(e => e.TotalAmount)
                .HasPrecision(8, 2)
                .HasColumnName("total_amount");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdClient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("orders_id_client_foreign");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("order_detail");

            entity.HasIndex(e => e.IdOrder, "order_detail_id_order_foreign");

            entity.HasIndex(e => e.IdProduct, "order_detail_id_product_foreign");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.IdOrder)
                .HasColumnType("int(11)")
                .HasColumnName("id_order");
            entity.Property(e => e.IdProduct)
                .HasColumnType("int(11)")
                .HasColumnName("id_product");
            entity.Property(e => e.Quantity)
                .HasColumnType("int(11)")
                .HasColumnName("quantity");
            entity.Property(e => e.Total)
                .HasPrecision(8, 2)
                .HasComputedColumnSql("`quantity` * `unit_price`", true)
                .HasColumnName("total");
            entity.Property(e => e.UnitPrice)
                .HasPrecision(8, 2)
                .HasColumnName("unit_price");

            entity.HasOne(d => d.IdOrderNavigation).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.IdOrder)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("order_detail_id_order_foreign");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.IdProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("order_detail_id_product_foreign");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("product");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(255)
                .HasColumnName("image_url");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasPrecision(8, 2)
                .HasColumnName("price");
            entity.Property(e => e.QuantityRequested)
                .HasColumnType("int(11)")
                .HasColumnName("quantity_requested");
            entity.Property(e => e.QuantityStock)
                .HasColumnType("int(11)")
                .HasColumnName("quantity_stock");
            entity.Property(e => e.Size)
                .HasMaxLength(255)
                .HasColumnName("size");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
