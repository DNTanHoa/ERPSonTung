using System;
using ERP.Model.DataTransferObjects;
using ERP.Ultilities.Global;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ERP.Model.Models
{
    public partial class SonTungContext : DbContext
    {
        public SonTungContext()
        {
        }

        public SonTungContext(DbContextOptions<SonTungContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<EmployeeCheckInOut> EmployeeCheckInOut { get; set; }
        public virtual DbSet<EmployeeContract> EmployeeContract { get; set; }
        public virtual DbSet<EmployeeDayOff> EmployeeDayOff { get; set; }
        public virtual DbSet<EmployeeDocument> EmployeeDocument { get; set; }
        public virtual DbSet<EmployeeHistory> EmployeeHistory { get; set; }
        public virtual DbSet<EmployeePaper> EmployeePaper { get; set; }
        public virtual DbSet<EmployeePayroll> EmployeePayroll { get; set; }
        public virtual DbSet<EmployeeRelative> EmployeeRelative { get; set; }
        public virtual DbSet<Holiday> Holiday { get; set; }
        public virtual DbSet<Navigation> Navigation { get; set; }
        public virtual DbSet<Post> Post { get; set; }
        public virtual DbSet<RecruitmentPlan> RecruitmentPlan { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<RoleGroup> RoleGroup { get; set; }
        public virtual DbSet<RoleGroupDetail> RoleGroupDetail { get; set; }
        public virtual DbSet<Shift> Shift { get; set; }
        public virtual DbSet<ShiftEmployee> ShiftEmployee { get; set; }
        public virtual DbSet<TrainingCourse> TrainingCourse { get; set; }
        public virtual DbSet<TrainingCourseEmployee> TrainingCourseEmployee { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<EntityCenter> EntityCenter { get; set; }
        public virtual DbSet<CheckInOutDevice> CheckInOutDevice { get; set; }
        public virtual DbSet<Candidate> Candidate { get; set; }
        public virtual DbSet<CandidatePaper> CandidatePaper { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(AppGlobal.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Code });

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.CreateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.CreateUser).HasMaxLength(4000);

                entity.Property(e => e.Entity).HasMaxLength(4000);

                entity.Property(e => e.Name).HasMaxLength(4000);

                entity.Property(e => e.Note).HasMaxLength(4000);

                entity.Property(e => e.ParentCode).HasMaxLength(50);

                entity.Property(e => e.SubCode).HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UpdateUser).HasMaxLength(4000);
            });

            modelBuilder.Entity<EntityCenter>(entity =>
            {
                entity.HasKey(e => new { e.Id });

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.CreateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.CreateUser).HasMaxLength(4000);

                entity.Property(e => e.Entity).HasMaxLength(4000);

                entity.Property(e => e.PrefixCode).HasMaxLength(4000);

                entity.Property(e => e.Note).HasMaxLength(4000);

                entity.Property(e => e.NumberCount).HasMaxLength(4000);

                entity.Property(e => e.UpdateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UpdateUser).HasMaxLength(4000);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => new { e.Id })
                    .HasName("Code");

                entity.HasIndex(e => e.Id)
                    .HasName("IX_Employee");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.BankCode).HasMaxLength(4000);

                entity.Property(e => e.IdentityLicenseDate).HasColumnType("smalldatetime");

                entity.Property(e => e.CompanyEmail).HasMaxLength(4000);

                entity.Property(e => e.CreateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.CreateUser).HasMaxLength(4000);

                entity.Property(e => e.DateOfBirth).HasColumnType("smalldatetime");

                entity.Property(e => e.DepartmentCode).HasMaxLength(4000);

                entity.Property(e => e.FirstName).HasMaxLength(4000);

                entity.Property(e => e.FullName).HasMaxLength(4000);

                entity.Property(e => e.GenderCode).HasMaxLength(4000);

                entity.Property(e => e.GroupCode).HasMaxLength(4000);

                entity.Property(e => e.IdentityNumber).HasMaxLength(4000);

                entity.Property(e => e.Image).HasMaxLength(4000);

                entity.Property(e => e.JobCode).HasMaxLength(4000);

                entity.Property(e => e.LaborGroupCode).HasMaxLength(4000);

                entity.Property(e => e.LastName).HasMaxLength(4000);

                entity.Property(e => e.NationCode).HasMaxLength(4000);

                entity.Property(e => e.NationalityCode).HasMaxLength(4000);

                entity.Property(e => e.Note).HasMaxLength(4000);

                entity.Property(e => e.OriginAddress).HasMaxLength(4000);

                entity.Property(e => e.IdentityLicensePlaceCode).HasMaxLength(4000);

                entity.Property(e => e.PersonalEmail).HasMaxLength(4000);

                entity.Property(e => e.Phone).HasMaxLength(4000);

                entity.Property(e => e.PositionCode).HasMaxLength(4000);

                entity.Property(e => e.ReligionCode).HasMaxLength(4000);

                entity.Property(e => e.StartDate).HasColumnType("smalldatetime");

                entity.Property(e => e.StatusCode).HasMaxLength(4000);

                entity.Property(e => e.SupervisorCode).HasMaxLength(4000);

                entity.Property(e => e.TemporaryAddress).HasMaxLength(4000);

                entity.Property(e => e.TitleCode).HasMaxLength(4000);

                entity.Property(e => e.UpdateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UpdateUser).HasMaxLength(4000);

                entity.Property(e => e.BankNumber).HasMaxLength(4000);
            });

            modelBuilder.Entity<EmployeeCheckInOut>(entity =>
            {
                entity.Property(e => e.CheckTime).HasColumnType("smalldatetime");

                entity.Property(e => e.CheckWay).HasMaxLength(4000);

                entity.Property(e => e.CreateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.CreateUser).HasMaxLength(4000);

                entity.Property(e => e.EmployeeCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Note).HasMaxLength(4000);

                entity.Property(e => e.UpdateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UpdateUser).HasMaxLength(4000);
            });

            modelBuilder.Entity<EmployeeContract>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.NumberCode })
                    .HasName("PK_EmployeeDocumentDetail");

                entity.Property(e => e.NumberCode).HasMaxLength(50);

                entity.Property(e => e.CompanySignPerson).HasMaxLength(50);

                entity.Property(e => e.ContractType).HasMaxLength(50);

                entity.Property(e => e.CreateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.CreateUser).HasMaxLength(4000);

                entity.Property(e => e.EffectiveDate).HasColumnType("smalldatetime");

                entity.Property(e => e.EmployeeSignPerson).HasMaxLength(50);

                entity.Property(e => e.MainContent).HasMaxLength(4000);

                entity.Property(e => e.Note).HasMaxLength(4000);

                entity.Property(e => e.ParentCode).HasMaxLength(50);

                entity.Property(e => e.Path).HasMaxLength(4000);

                entity.Property(e => e.Salary).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.SignDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UpdateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UpdateUser).HasMaxLength(4000);
            });

            modelBuilder.Entity<EmployeeDayOff>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.ApproveStatus).HasMaxLength(4000);

                entity.Property(e => e.CreateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.CreateUser).HasMaxLength(4000);

                entity.Property(e => e.EmployeeCode).HasMaxLength(50);

                entity.Property(e => e.FromTime).HasColumnType("smalldatetime");

                entity.Property(e => e.Note).HasMaxLength(4000);

                entity.Property(e => e.Reason).HasMaxLength(4000);

                entity.Property(e => e.ToTime).HasColumnType("smalldatetime");

                entity.Property(e => e.UpdateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UpdateUser).HasMaxLength(4000);
            });

            modelBuilder.Entity<EmployeeDocument>(entity =>
            {
                entity.Property(e => e.CreateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.CreateUser).HasMaxLength(4000);

                entity.Property(e => e.DocumentType).HasMaxLength(4000);

                entity.Property(e => e.EmployeeCode).HasMaxLength(50);

                entity.Property(e => e.Note).HasMaxLength(4000);

                entity.Property(e => e.NumberCode).HasMaxLength(4000);

                entity.Property(e => e.Path).HasMaxLength(4000);

                entity.Property(e => e.UpdateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UpdateUser).HasMaxLength(4000);
            });

            modelBuilder.Entity<EmployeeHistory>(entity =>
            {
                entity.Property(e => e.ChangeDate).HasColumnType("smalldatetime");

                entity.Property(e => e.ChangeType).HasMaxLength(50);

                entity.Property(e => e.CreateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.CreateUser).HasMaxLength(4000);

                entity.Property(e => e.DestinationCode).HasMaxLength(50);

                entity.Property(e => e.EmployeeCode)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Note).HasMaxLength(4000);

                entity.Property(e => e.SourceCode).HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UpdateUser).HasMaxLength(4000);
            });

            modelBuilder.Entity<EmployeePaper>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Code).HasMaxLength(4000);

                entity.Property(e => e.CreateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.CreateUser).HasMaxLength(4000);

                entity.Property(e => e.Note).HasMaxLength(4000);

                entity.Property(e => e.PaperContent).HasMaxLength(4000);

                entity.Property(e => e.PaperType).HasMaxLength(4000);

                entity.Property(e => e.UpdateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UpdateUser).HasMaxLength(4000);
            });

            modelBuilder.Entity<EmployeePayroll>(entity =>
            {
                entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.CreateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.CreateUser).HasMaxLength(4000);

                entity.Property(e => e.EmployeeCode).HasMaxLength(50);

                entity.Property(e => e.Note).HasMaxLength(4000);

                entity.Property(e => e.PayWayCode).HasMaxLength(4000);

                entity.Property(e => e.PayrollType).HasMaxLength(4000);

                entity.Property(e => e.UpdateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UpdateUser).HasMaxLength(4000);
            });

            modelBuilder.Entity<EmployeeRelative>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.CreateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.CreateUser).HasMaxLength(4000);

                entity.Property(e => e.DateOfBirth).HasColumnType("smalldatetime");

                entity.Property(e => e.EmployeeCode).HasMaxLength(50);

                entity.Property(e => e.Job).HasMaxLength(4000);

                entity.Property(e => e.Note).HasMaxLength(4000);

                entity.Property(e => e.OriginAddress).HasMaxLength(4000);

                entity.Property(e => e.Phone).HasMaxLength(4000);

                entity.Property(e => e.RelativeType).HasMaxLength(4000);

                entity.Property(e => e.UpdateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UpdateUser).HasMaxLength(4000);

                entity.Property(e => e.OriginProvinceCode).IsRequired().IsUnicode(false).HasMaxLength(50);

                entity.Property(e => e.Name).IsRequired().HasMaxLength(256);
            });

            modelBuilder.Entity<Holiday>(entity =>
            {
                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.CreateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.CreateUser).HasMaxLength(4000);

                entity.Property(e => e.EndDate).HasMaxLength(4000);

                entity.Property(e => e.Name).HasMaxLength(4000);

                entity.Property(e => e.Note).HasMaxLength(4000);

                entity.Property(e => e.SalaryIncreasePercent).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.StartDate).HasMaxLength(4000);

                entity.Property(e => e.UpdateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UpdateUser).HasMaxLength(4000);
            });

            modelBuilder.Entity<Navigation>(entity =>
            {
                entity.Property(e => e.ActionName).HasMaxLength(4000);

                entity.Property(e => e.ControllerName).HasMaxLength(4000);

                entity.Property(e => e.CreateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.CreateUser).HasMaxLength(4000);

                entity.Property(e => e.DisplayName).HasMaxLength(4000);

                entity.Property(e => e.Icon).HasMaxLength(4000);

                entity.Property(e => e.Note).HasMaxLength(4000);

                entity.Property(e => e.Type).HasMaxLength(4000);

                entity.Property(e => e.UpdateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UpdateUser).HasMaxLength(4000);
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.Property(e => e.CategoryCode).HasMaxLength(4000);

                entity.Property(e => e.CreateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.CreateUser).HasMaxLength(4000);

                entity.Property(e => e.MateKeywords).HasMaxLength(4000);

                entity.Property(e => e.MetaDescription).HasMaxLength(4000);

                entity.Property(e => e.MetaTitle).HasMaxLength(4000);

                entity.Property(e => e.Note).HasMaxLength(4000);

                entity.Property(e => e.SubTitle).HasMaxLength(4000);

                entity.Property(e => e.Title).HasMaxLength(4000);

                entity.Property(e => e.UpdateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UpdateUser).HasMaxLength(4000);
            });

            modelBuilder.Entity<RecruitmentPlan>(entity =>
            {
                entity.Property(e => e.Code).HasMaxLength(4000);

                entity.Property(e => e.CreateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.CreateUser).HasMaxLength(4000);

                entity.Property(e => e.DepartmentCode).HasMaxLength(4000);

                entity.Property(e => e.EndDate).HasColumnType("smalldatetime");

                entity.Property(e => e.JobCode)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Note).HasMaxLength(4000);

                entity.Property(e => e.Quantity).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.StartDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.Title).HasMaxLength(4000);

                entity.Property(e => e.UpdateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UpdateUser).HasMaxLength(4000);
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.Property(e => e.CreateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.CreateUser).HasMaxLength(4000);

                entity.Property(e => e.Entity).HasMaxLength(4000);

                entity.Property(e => e.NavigationCode).HasMaxLength(50);

                entity.Property(e => e.Note).HasMaxLength(4000);

                entity.Property(e => e.UpdateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UpdateUser).HasMaxLength(4000);

                entity.Property(e => e.Username).HasMaxLength(50);
            });

            modelBuilder.Entity<Shift>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Code });

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.CreateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.CreateUser).HasMaxLength(4000);

                entity.Property(e => e.Name).HasMaxLength(4000);

                entity.Property(e => e.Note).HasMaxLength(4000);

                entity.Property(e => e.UpdateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UpdateUser).HasMaxLength(4000);
            });

            modelBuilder.Entity<ShiftEmployee>(entity =>
            {
                entity.Property(e => e.CreateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.CreateUser).HasMaxLength(4000);

                entity.Property(e => e.EmployeeCode).HasMaxLength(50);

                entity.Property(e => e.Note).HasMaxLength(4000);

                entity.Property(e => e.ShiftCode).HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UpdateUser).HasMaxLength(4000);
            });

            modelBuilder.Entity<TrainingCourse>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Code });

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.CreateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.CreateUser).HasMaxLength(4000);

                entity.Property(e => e.EndDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Location).HasMaxLength(4000);

                entity.Property(e => e.Name).HasMaxLength(4000);

                entity.Property(e => e.Note).HasMaxLength(4000);

                entity.Property(e => e.ParentCode).HasMaxLength(50);

                entity.Property(e => e.PlannedCost).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.RealCost).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.StartDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UpdateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UpdateUser).HasMaxLength(4000);
            });

            modelBuilder.Entity<TrainingCourseEmployee>(entity =>
            {
                entity.Property(e => e.CreateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.CreateUser).HasMaxLength(4000);

                entity.Property(e => e.EmployeeCode).HasMaxLength(50);

                entity.Property(e => e.Note).HasMaxLength(4000);

                entity.Property(e => e.Point).HasMaxLength(4000);

                entity.Property(e => e.ResultType).HasMaxLength(4000);

                entity.Property(e => e.TrainingCourseCode).HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UpdateUser).HasMaxLength(4000);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Username).HasMaxLength(250);

                entity.Property(e => e.CreateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.CreateUser).HasMaxLength(4000);

                entity.Property(e => e.GuidCode).HasMaxLength(4000);

                entity.Property(e => e.Note).HasMaxLength(4000);

                entity.Property(e => e.Password).HasMaxLength(4000);

                entity.Property(e => e.UpdateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UpdateUser).HasMaxLength(4000);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
