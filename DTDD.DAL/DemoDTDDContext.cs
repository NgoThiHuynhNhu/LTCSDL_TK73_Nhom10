using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DTDD.DAL.Models
{
    public partial class DemoDTDDContext : DbContext
    {
        public DemoDTDDContext()
        {
        }

        public DemoDTDDContext(DbContextOptions<DemoDTDDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Deliverer> Deliverer { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderDetail> OrderDetail { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<SalePhones> SalePhones { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-JF5U5OF;Initial Catalog=Demo DTDD;Persist Security Info=True;User ID=sa;Password=123;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CategoryName)
                  
                    .HasColumnName("Category_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ParentId).HasColumnName("Parent_ID");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.Property(e => e.CommentId)
                    .HasColumnName("Comment_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CommentContent)
                    
                    .HasColumnName("Comment_content")
                    .IsUnicode(false);

                entity.Property(e => e.CommentTime)
                    .HasColumnName("Comment_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.Fullname)
                    
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneId).HasColumnName("Phone_ID");

                entity.Property(e => e.PhoneNumber)
                    
                    .HasColumnName("Phone_number")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Phone)
                    .WithMany(p => p.Comment)
                    .HasForeignKey(d => d.PhoneId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comment_Product");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.CustomerId)
                    .HasColumnName("Customer_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CustomerMail)
                    
                    .HasColumnName("Customer_mail")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerName)
                    
                    .HasColumnName("Customer_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerPhone)
                    
                    .HasColumnName("Customer_phone")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Deliverer>(entity =>
            {
                entity.Property(e => e.DelivererId)
                    .HasColumnName("Deliverer_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.DelivererName)
                    .HasColumnName("Deliverer_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DelivererPhone)
                    .HasColumnName("Deliverer_phone")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId)
                    .HasColumnName("Order_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreateDate)
                    .HasColumnName("Create_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.CustomerId).HasColumnName("Customer_ID");

                entity.Property(e => e.DelivererId).HasColumnName("Deliverer_ID");

                entity.Property(e => e.DeliveryAddress)
                    .HasColumnName("Delivery_address")
                    .IsUnicode(false);

                entity.Property(e => e.Note)
                    .IsUnicode(false);

                entity.Property(e => e.StatusId).HasColumnName("Status_ID");

                entity.Property(e => e.TotalPrice).HasColumnName("Total_price");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Customer");

                entity.HasOne(d => d.Deliverer)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.DelivererId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Deliverer");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Status");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("Order_detail");

                entity.Property(e => e.OrderDetailId)
                    .HasColumnName("Order_detail_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.OrderId).HasColumnName("Order_ID");

                entity.Property(e => e.ProductId).HasColumnName("Product_ID");

                entity.Property(e => e.SaleQuantity).HasColumnName("Sale_quantity");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetail)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_detail_Order");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetail)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_detail_Product");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Battery)                   
                    .IsUnicode(false);

                entity.Property(e => e.Bluetooth)
                    .IsUnicode(false);

                entity.Property(e => e.CameraPrimary)                  
                    .HasColumnName("Camera_primary")
                    .IsUnicode(false);

                entity.Property(e => e.Color)
                    .IsUnicode(false);

                entity.Property(e => e.CpuSpeed)
                    .HasColumnName("CPU_speed")
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .IsUnicode(false);

              

                entity.Property(e => e.IdCat).HasColumnName("ID_cat");

                entity.Property(e => e.Image)
                    .IsUnicode(false);

                entity.Property(e => e.Memory)
                    .IsUnicode(false);

                entity.Property(e => e.ProductName)
                    .IsUnicode(false);

                entity.Property(e => e.Os)
                    .HasColumnName("OS")
                    .IsUnicode(false);

                entity.Property(e => e.PromotionPrice).HasColumnName("Promotion_price");

                entity.Property(e => e.Size)
                    .IsUnicode(false);

               

                entity.Property(e => e.Title)
                    .IsUnicode(false);

                entity.Property(e => e.Weight)
                    .IsUnicode(false);

                entity.Property(e => e.Wlan)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCatNavigation)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.IdCat)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Category");
            });

            modelBuilder.Entity<SalePhones>(entity =>
            {
                entity.ToTable("Sale_phones");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreateDate)
                    .HasColumnName("Create_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.PhoneId).HasColumnName("Phone_ID");

                entity.HasOne(d => d.Phone)
                    .WithMany(p => p.SalePhones)
                    .HasForeignKey(d => d.PhoneId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sale_phones_Product");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.Property(e => e.StatusId)
                    .HasColumnName("Status_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Status1)
                    
                    .HasColumnName("Status")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId)
                    .HasColumnName("User_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                   
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
