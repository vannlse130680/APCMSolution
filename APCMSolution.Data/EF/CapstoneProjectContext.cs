using System;
using System.IO;
using APCMSolution.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace APCMSolution.Data.EF
{
    public partial class CapstoneProjectContext : DbContext
    {
        public CapstoneProjectContext()
        {
        }

        public CapstoneProjectContext(DbContextOptions<CapstoneProjectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Activity> Activities { get; set; }
        public virtual DbSet<ActivityLevel> ActivityLevels { get; set; }
        public virtual DbSet<ActivityResult> ActivityResults { get; set; }
        public virtual DbSet<ActivityResultDetail> ActivityResultDetails { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<BrandProductCategory> BrandProductCategories { get; set; }
        public virtual DbSet<BrandStoreGroup> BrandStoreGroups { get; set; }
        public virtual DbSet<Campaign> Campaigns { get; set; }
        public virtual DbSet<CampainTeam> CampainTeams { get; set; }
        public virtual DbSet<ChainStore> ChainStores { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeGroup> EmployeeGroups { get; set; }
        public virtual DbSet<EmployeeGroupDetail> EmployeeGroupDetails { get; set; }
        public virtual DbSet<EmployeepPopupSession> EmployeepPopupSessions { get; set; }
        public virtual DbSet<Form> Forms { get; set; }
        public virtual DbSet<FormQuestionDetail> FormQuestionDetails { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<PopUpStore> PopUpStores { get; set; }
        public virtual DbSet<PopupActivity> PopupActivities { get; set; }
        public virtual DbSet<PopupStoreSession> PopupStoreSessions { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCampaign> ProductCampaigns { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<PromotionCompany> PromotionCompanies { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<StoreProductCategory> StoreProductCategories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder() // tạo đối tượng conf
                .SetBasePath(Directory.GetCurrentDirectory()) //FileExtensions // add thư mục hiện tại .data làm thư mục gốc
                .AddJsonFile("appsettings.json") // Json
                .Build();
                var connectionStrings = configuration.GetConnectionString("APCMSolutionDb");
                
                optionsBuilder.UseSqlServer(connectionStrings);
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //optionsBuilder.UseSqlServer("Server=.;Database=CapstoneProject;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Activity>(entity =>
            {
                entity.ToTable("Activity");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.Campaign)
                    .WithMany(p => p.Activities)
                    .HasForeignKey(d => d.CampaignId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Activity_Campaign");

                entity.HasOne(d => d.Form)
                    .WithMany(p => p.Activities)
                    .HasForeignKey(d => d.FormId)
                    .HasConstraintName("FK_Activity_Form");
            });

            modelBuilder.Entity<ActivityLevel>(entity =>
            {
                entity.ToTable("ActivityLevel");

                entity.Property(e => e.Detail).HasMaxLength(250);
            });

            modelBuilder.Entity<ActivityResult>(entity =>
            {
                entity.ToTable("ActivityResult");

                entity.HasOne(d => d.PopupActivity)
                    .WithMany(p => p.ActivityResults)
                    .HasForeignKey(d => new { d.ActivityId, d.PopupStoreSessionId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActivityResult_PopupActivity");
            });

            modelBuilder.Entity<ActivityResultDetail>(entity =>
            {
                entity.ToTable("ActivityResultDetail");

                entity.HasOne(d => d.ActivityResult)
                    .WithMany(p => p.ActivityResultDetails)
                    .HasForeignKey(d => d.ActivityResultId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActivityResultDetail_ActivityResult");
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("Brand");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Brands)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Brand_Company");
            });

            modelBuilder.Entity<BrandProductCategory>(entity =>
            {
                entity.ToTable("BrandProductCategory");

                entity.Property(e => e.BrandProductCategoryId)
                    .ValueGeneratedNever()
                    .HasColumnName("brand_product_category_id");

                entity.Property(e => e.BrandId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("brand_id")
                    .IsFixedLength(true);

                entity.Property(e => e.ProductCategoryId).HasColumnName("product_category_id");
            });

            modelBuilder.Entity<BrandStoreGroup>(entity =>
            {
                entity.HasKey(e => new { e.BrandId, e.StoreId })
                    .HasName("PK_Brand Store Group");

                entity.ToTable("BrandStoreGroup");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.BrandStoreGroups)
                    .HasForeignKey(d => d.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BrandStoreGroup_Brand1");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.BrandStoreGroups)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BrandStoreGroup_Store");
            });

            modelBuilder.Entity<Campaign>(entity =>
            {
                entity.ToTable("Campaign");

                entity.Property(e => e.ActualCost).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.ActualRevenue).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.BudgetedCost).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Currency)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.ExpectedRevenue).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.LastModifiedTime).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<CampainTeam>(entity =>
            {
                entity.HasKey(e => e.CtId);

                entity.ToTable("CampainTeam");

                entity.Property(e => e.CtId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ct_id")
                    .IsFixedLength(true);

                entity.Property(e => e.CampainId).HasColumnName("campain_id");

                entity.Property(e => e.EmpGroupId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("emp_group_id")
                    .IsFixedLength(true);

                entity.Property(e => e.StartedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("started_date");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<ChainStore>(entity =>
            {
                entity.ToTable("ChainStore");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.WebsiteUrl)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("Company");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Hotline)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Nation).HasMaxLength(50);

                entity.Property(e => e.Type).HasMaxLength(100);

                entity.Property(e => e.WebsiteUrl)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Gender)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Image).HasMaxLength(300);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.StartedDate).HasColumnType("date");

                entity.HasOne(d => d.PromotionCompany)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.PromotionCompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_PromotionCompany");
            });

            modelBuilder.Entity<EmployeeGroup>(entity =>
            {
                entity.ToTable("EmployeeGroup");

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.PromotionCompany)
                    .WithMany(p => p.EmployeeGroups)
                    .HasForeignKey(d => d.PromotionCompanyId)
                    .HasConstraintName("FK_EmployeeGroup_PromotionCompany");
            });

            modelBuilder.Entity<EmployeeGroupDetail>(entity =>
            {
                entity.HasKey(e => new { e.EmployeeGroupId, e.EmployeeId });

                entity.ToTable("EmployeeGroupDetail");

                entity.Property(e => e.JoinedDate).HasColumnType("datetime");

                entity.Property(e => e.LastModified).HasColumnType("datetime");

                entity.HasOne(d => d.EmployeeGroup)
                    .WithMany(p => p.EmployeeGroupDetails)
                    .HasForeignKey(d => d.EmployeeGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeGroupDetail_EmployeeGroup");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeGroupDetails)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeGroupDetail_Employee");
            });

            modelBuilder.Entity<EmployeepPopupSession>(entity =>
            {
                entity.HasKey(e => new { e.PopupStoreSessionId, e.EmployeeId })
                    .HasName("PK_EmployeeCampainSession_1");

                entity.ToTable("EmployeepPopupSession");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeepPopupSessions)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeepPopupSession_Employee");

                entity.HasOne(d => d.PopupStoreSession)
                    .WithMany(p => p.EmployeepPopupSessions)
                    .HasForeignKey(d => d.PopupStoreSessionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeepPopupSession_PopupStoreSession");
            });

            modelBuilder.Entity<Form>(entity =>
            {
                entity.ToTable("Form");

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Forms)
                    .HasForeignKey(d => d.BrandId)
                    .HasConstraintName("FK_Form_Brand");
            });

            modelBuilder.Entity<FormQuestionDetail>(entity =>
            {
                entity.HasKey(e => new { e.QuestionId, e.FormId })
                    .HasName("PK_FormQuestionDetail_1");

                entity.ToTable("FormQuestionDetail");

                entity.HasOne(d => d.Form)
                    .WithMany(p => p.FormQuestionDetails)
                    .HasForeignKey(d => d.FormId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FormQuestionDetail_Form");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("Location");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Latitude).HasColumnType("decimal(11, 8)");

                entity.Property(e => e.Longitude).HasColumnType("decimal(11, 8)");

                entity.Property(e => e.Type).HasMaxLength(50);
            });

            modelBuilder.Entity<PopUpStore>(entity =>
            {
                entity.HasKey(e => new { e.CampaignId, e.LocationId });

                entity.ToTable("PopUpStore");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.DecorativePhotoTemplate).HasMaxLength(250);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.StoreId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.Campaign)
                    .WithMany(p => p.PopUpStores)
                    .HasForeignKey(d => d.CampaignId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PopUpStore_Campaign");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.PopUpStores)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PopUpStore_Location");
            });

            modelBuilder.Entity<PopupActivity>(entity =>
            {
                entity.HasKey(e => new { e.ActivityId, e.PopupStoreSessionId })
                    .HasName("PK_ActivityResult");

                entity.ToTable("PopupActivity");

                entity.HasOne(d => d.Activity)
                    .WithMany(p => p.PopupActivities)
                    .HasForeignKey(d => d.ActivityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PopupActivity_Activity");

                entity.HasOne(d => d.PopupStoreSession)
                    .WithMany(p => p.PopupActivities)
                    .HasForeignKey(d => d.PopupStoreSessionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PopupActivity_PopupStoreSession1");
            });

            modelBuilder.Entity<PopupStoreSession>(entity =>
            {
                entity.ToTable("PopupStoreSession");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasColumnName("last_modified_by");

                entity.Property(e => e.LastModifiedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("last_modified_time");

                entity.Property(e => e.PictureCheckin)
                    .HasMaxLength(300)
                    .HasColumnName("picture_checkin");

                entity.Property(e => e.PictureCheckout)
                    .HasMaxLength(300)
                    .HasColumnName("picture_checkout");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.PopUpStore)
                    .WithMany(p => p.PopupStoreSessions)
                    .HasForeignKey(d => new { d.CampaignId, d.LocationId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PopupStoreSession_PopUpStore1");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.Currency)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.ImageUrl).HasMaxLength(500);

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Brand");

                entity.HasOne(d => d.ProductCategory)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProductCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_ProductCategory");
            });

            modelBuilder.Entity<ProductCampaign>(entity =>
            {
                entity.HasKey(e => new { e.CampaignId, e.ProductId });

                entity.ToTable("ProductCampaign");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.Campaign)
                    .WithMany(p => p.ProductCampaigns)
                    .HasForeignKey(d => d.CampaignId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductCampaign_Campaign");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductCampaigns)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductCampaign_Product");
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.ToTable("ProductCategory");

                entity.Property(e => e.Discription).HasMaxLength(250);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<PromotionCompany>(entity =>
            {
                entity.ToTable("PromotionCompany");

                entity.Property(e => e.EstablishedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(20);
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.ToTable("Question");

                entity.Property(e => e.DirectAttribute).HasMaxLength(100);

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Form)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.FormId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Question_Form");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.ToTable("Store");

                entity.Property(e => e.Hotline)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Type).HasMaxLength(30);

                entity.HasOne(d => d.ChainStore)
                    .WithMany(p => p.Stores)
                    .HasForeignKey(d => d.ChainStoreId)
                    .HasConstraintName("FK_Store_ChainStore");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Stores)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Store_Location");
            });

            modelBuilder.Entity<StoreProductCategory>(entity =>
            {
                entity.HasKey(e => new { e.ProductCategoryId, e.StoreId });

                entity.ToTable("StoreProductCategory");

                entity.HasOne(d => d.ProductCategory)
                    .WithMany(p => p.StoreProductCategories)
                    .HasForeignKey(d => d.ProductCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StoreProductCategory_ProductCategory");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.StoreProductCategories)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StoreProductCategory_Store");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
