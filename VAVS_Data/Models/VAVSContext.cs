using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace VAVS_Data.Models;

public partial class VAVSContext : DbContext
{
    public VAVSContext()
    {
    }

    public VAVSContext(DbContextOptions<VAVSContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbFuelType> TbFuelTypes { get; set; }

    public virtual DbSet<TbPersonalDetail> TbPersonalDetails { get; set; }

    public virtual DbSet<TbStateDivision> TbStateDivisions { get; set; }

    public virtual DbSet<TbTaxValidation> TbTaxValidations { get; set; }

    public virtual DbSet<TbTownship> TbTownships { get; set; }

    public virtual DbSet<TbUser> TbUsers { get; set; }

    public virtual DbSet<TbVehicleStandardValue> TbVehicleStandardValues { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=203.81.89.218; Database=VAVS_Client; User Id=madbadmin; Password=@dmin123;Trust Server Certificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbFuelType>(entity =>
        {
            entity.HasKey(e => e.FuelTypePkid);

            entity.ToTable("TB_FuelType");

            entity.Property(e => e.FuelType).HasMaxLength(20);
        });

        modelBuilder.Entity<TbPersonalDetail>(entity =>
        {
            entity.HasKey(e => e.PersonalPkid);

            entity.ToTable("TB_PersonalDetail");

            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.HousingNumber).HasMaxLength(200);
            entity.Property(e => e.Name).HasMaxLength(200);
            entity.Property(e => e.NrcbackImagePath)
                .HasMaxLength(200)
                .HasDefaultValueSql("(N'')")
                .HasColumnName("NRCBackImagePath");
            entity.Property(e => e.NrcfrontImagePath)
                .HasMaxLength(200)
                .HasDefaultValueSql("(N'')")
                .HasColumnName("NRCFrontImagePath");
            entity.Property(e => e.Nrcnumber)
                .HasMaxLength(50)
                .HasColumnName("NRCNumber");
            entity.Property(e => e.NrctownshipInitial)
                .HasMaxLength(50)
                .HasColumnName("NRCTownshipInitial");
            entity.Property(e => e.NrctownshipNumber)
                .HasMaxLength(50)
                .HasColumnName("NRCTownshipNumber");
            entity.Property(e => e.Nrctype)
                .HasMaxLength(50)
                .HasColumnName("NRCType");
            entity.Property(e => e.PersonTinnumber)
                .HasMaxLength(30)
                .HasColumnName("PersonTINNumber");
            entity.Property(e => e.PhoneNumber).HasMaxLength(50);
            entity.Property(e => e.Quarter).HasMaxLength(100);
            entity.Property(e => e.RegistrationStatus).HasMaxLength(15);
            entity.Property(e => e.Street).HasMaxLength(200);
            entity.Property(e => e.TransactionId).HasColumnName("TransactionID");

            entity.HasOne(d => d.StateDivisionPk).WithMany(p => p.TbPersonalDetails)
                .HasForeignKey(d => d.StateDivisionPkid)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.TownshipPk).WithMany(p => p.TbPersonalDetails)
                .HasForeignKey(d => d.TownshipPkid)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<TbStateDivision>(entity =>
        {
            entity.HasKey(e => e.StateDivisionPkid);

            entity.ToTable("TB_StateDivision");

            entity.Property(e => e.CityOfRegion).HasMaxLength(100);
            entity.Property(e => e.EngShortCode).HasMaxLength(10);
            entity.Property(e => e.MynShortCode).HasMaxLength(10);
            entity.Property(e => e.StateDivisionCode).HasMaxLength(2);
            entity.Property(e => e.StateDivisionName).HasMaxLength(100);
        });

        modelBuilder.Entity<TbTaxValidation>(entity =>
        {
            entity.HasKey(e => e.TaxValidationPkid);

            entity.ToTable("TB_TaxValidation");

            entity.Property(e => e.AttachFileName).HasMaxLength(50);
            entity.Property(e => e.BuildType).HasMaxLength(200);
            entity.Property(e => e.ContractValue).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CountryOfMade).HasMaxLength(50);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DemandNumber).HasMaxLength(50);
            entity.Property(e => e.EnginePower).HasMaxLength(30);
            entity.Property(e => e.EntryDate).HasColumnType("datetime");
            entity.Property(e => e.FormNumber).HasMaxLength(50);
            entity.Property(e => e.FuelType).HasMaxLength(50);
            entity.Property(e => e.Manufacturer).HasMaxLength(200);
            entity.Property(e => e.ModelYear).HasMaxLength(4);
            entity.Property(e => e.OfficeLetterNo).HasMaxLength(50);
            entity.Property(e => e.PaymentRefId)
                .HasMaxLength(50)
                .HasColumnName("PaymentRefID");
            entity.Property(e => e.PersonNrc)
                .HasMaxLength(50)
                .HasColumnName("PersonNRC");
            entity.Property(e => e.PersonTinnumber)
                .HasMaxLength(50)
                .HasColumnName("PersonTINNumber");
            entity.Property(e => e.QrcodeNumber)
                .HasMaxLength(50)
                .HasColumnName("QRCodeNumber");
            entity.Property(e => e.StandardValue).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TaxAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.VehicleBrand).HasMaxLength(200);
            entity.Property(e => e.VehicleNumber).HasMaxLength(10);
        });

        modelBuilder.Entity<TbTownship>(entity =>
        {
            entity.HasKey(e => e.TownshipPkid);

            entity.ToTable("TB_Township");

            entity.Property(e => e.DistrictCode).HasMaxLength(5);
            entity.Property(e => e.TownshipCode).HasMaxLength(15);
            entity.Property(e => e.TownshipName).HasMaxLength(100);
        });

        modelBuilder.Entity<TbUser>(entity =>
        {
            entity.HasKey(e => e.UserPkid);

            entity.ToTable("TB_User");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DepartmentType).HasMaxLength(50);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Password).HasMaxLength(300);
            entity.Property(e => e.UserDisplayName).HasMaxLength(50);
            entity.Property(e => e.UserId)
                .HasMaxLength(50)
                .HasColumnName("UserID");
            entity.Property(e => e.UserRole).HasMaxLength(50);
        });

        modelBuilder.Entity<TbVehicleStandardValue>(entity =>
        {
            entity.HasKey(e => e.VehicleStandardValuePkid);

            entity.ToTable("TB_VehicleStandardValue");

            entity.Property(e => e.AttachFileName).HasMaxLength(50);
            entity.Property(e => e.BuildType).HasMaxLength(200);
            entity.Property(e => e.CountryOfMade).HasMaxLength(50);
            entity.Property(e => e.CreatedBy).HasMaxLength(10);
            entity.Property(e => e.EnginePower).HasMaxLength(30);
            entity.Property(e => e.Manufacturer).HasMaxLength(200);
            entity.Property(e => e.ModelYear).HasMaxLength(4);
            entity.Property(e => e.OfficeLetterNo).HasMaxLength(50);
            entity.Property(e => e.Remarks).HasMaxLength(200);
            entity.Property(e => e.StandardValue).HasMaxLength(10);
            entity.Property(e => e.VehicleBrand).HasMaxLength(200);
            entity.Property(e => e.VehicleNumber)
                .HasMaxLength(10)
                .HasDefaultValueSql("(N'')");

            entity.HasOne(d => d.FuelTypePk).WithMany(p => p.TbVehicleStandardValues)
                .HasForeignKey(d => d.FuelTypePkid)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.StateDivisionPk).WithMany(p => p.TbVehicleStandardValues)
                .HasForeignKey(d => d.StateDivisionPkid)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
