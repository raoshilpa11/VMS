using Microsoft.EntityFrameworkCore;

namespace VMS.Models
{
    public partial class VehiclesContext : DbContext
    {
        public readonly string connectionString;
        public VehiclesContext()
        {
        }

        public VehiclesContext(DbContextOptions<VehiclesContext> options, string connectionString)
            : base(options)
        {
            this.connectionString = connectionString;
        }

        public virtual DbSet<Vehicles> Vehicles { get; set; }
        public virtual DbSet<Car> Car { get; set; }
        public virtual DbSet<Cars> Cars { get; set; }
        public virtual DbSet<VehiclePropertiesModel> VehiclePropertiesModel { get; set; }
        public virtual DbSet<Vehicle> Vehicle { get; set; }
        public virtual DbSet<VehicleMake> VehicleMake { get; set; }
        public virtual DbSet<VehicleMakemodelMapping> VehicleMakemodelMapping { get; set; }
        public virtual DbSet<VehicleModel> VehicleModel { get; set; }
        public virtual DbSet<VehicleProperties> VehicleProperties { get; set; }
        public virtual DbSet<VehiclePropertiesMapping> VehiclePropertiesMapping { get; set; }
        public virtual DbSet<VehicleRecords> VehicleRecords { get; set; }
        public virtual DbSet<VehicleRecordsProperties> VehicleRecordsProperties { get; set; }
        public virtual DbSet<Vehicletype> Vehicletype { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-I2G0T9N;Database=Vehicles;Trusted_Connection=True;");                
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.ToTable("VEHICLE");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();


                entity.Property(e => e.Bodytype)
                    .IsRequired()
                    .HasColumnName("BODYTYPE")
                    .HasMaxLength(200);

                entity.Property(e => e.Colours)
                    .IsRequired()
                    .HasColumnName("COLOURS")
                    .HasMaxLength(200);

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("CREATED_DATE")
                    .HasColumnType("date");

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(100);

                entity.Property(e => e.Doors)
                    .IsRequired()
                    .HasColumnName("DOORS")
                    .HasMaxLength(200);

                entity.Property(e => e.Engine)
                    .IsRequired()
                    .HasColumnName("ENGINE")
                    .HasMaxLength(200);

                entity.Property(e => e.IsActive)
                    .HasColumnName("IS_ACTIVE")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Make)
                    .IsRequired()
                    .HasColumnName("MAKE")
                    .HasMaxLength(200);

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasColumnName("MODEL")
                    .HasMaxLength(200);

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("MODIFIED_BY")
                    .HasMaxLength(200);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("MODIFIED_DATE")
                    .HasColumnType("date");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("TYPE")
                    .HasMaxLength(200);

                entity.Property(e => e.Wheels)
                    .IsRequired()
                    .HasColumnName("WHEELS")
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<VehiclePropertiesModel>(entity =>
            {
                entity.ToTable("VehiclePropertiesModel");

                entity.Property(e => e.VpmId)
                    .HasColumnName("VpmId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.VtId)
                    .HasColumnName("VtId")
                    .HasColumnType("numeric(18, 0)");


                entity.Property(e => e.VpId)
                    .HasColumnName("VpId")
                    .HasColumnType("numeric(18, 0)");


                entity.Property(e => e.PropertyName)
                    .HasColumnName("PropertyName")
                    .HasMaxLength(200);

                entity.Property(e => e.PropertyValue)
                    .HasColumnName("PropertyValue")
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<VehicleMake>(entity =>
            {
                entity.HasKey(e => e.VmakeId);

                entity.ToTable("VEHICLE_MAKE");

                entity.Property(e => e.VmakeId)
                    .HasColumnName("VMAKE_ID")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("CREATED_DATE")
                    .HasColumnType("date");

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(100);

                entity.Property(e => e.IsActive)
                    .HasColumnName("IS_ACTIVE")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("MODIFIED_BY")
                    .HasMaxLength(200);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("MODIFIED_DATE")
                    .HasColumnType("date");

                entity.Property(e => e.VehiclemakeName)
                    .IsRequired()
                    .HasColumnName("VEHICLEMAKE_NAME")
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<VehicleMakemodelMapping>(entity =>
            {
                entity.HasKey(e => e.VmmpId);

                entity.ToTable("VEHICLE_MAKEMODEL_MAPPING");

                entity.Property(e => e.VmmpId)
                    .HasColumnName("VMMP_ID")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("CREATED_DATE")
                    .HasColumnType("date");

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(100);

                entity.Property(e => e.IsActive)
                    .HasColumnName("IS_ACTIVE")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("MODIFIED_BY")
                    .HasMaxLength(200);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("MODIFIED_DATE")
                    .HasColumnType("date");

                entity.Property(e => e.VmakeId)
                    .HasColumnName("VMAKE_ID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.VmodelId)
                    .HasColumnName("VMODEL_ID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.VtId)
                    .HasColumnName("VT_ID")
                    .HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.Vmake)
                    .WithMany(p => p.VehicleMakemodelMapping)
                    .HasForeignKey(d => d.VmakeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__VEHICLE_M__VMAKE__08B54D69");

                entity.HasOne(d => d.Vmodel)
                    .WithMany(p => p.VehicleMakemodelMapping)
                    .HasForeignKey(d => d.VmodelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__VEHICLE_M__VMODE__09A971A2");

                entity.HasOne(d => d.Vt)
                    .WithMany(p => p.VehicleMakemodelMapping)
                    .HasForeignKey(d => d.VtId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__VEHICLE_M__VT_ID__07C12930");
            });

            modelBuilder.Entity<VehicleModel>(entity =>
            {
                entity.HasKey(e => e.VmodelId);

                entity.ToTable("VEHICLE_MODEL");

                entity.Property(e => e.VmodelId)
                    .HasColumnName("VMODEL_ID")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("CREATED_DATE")
                    .HasColumnType("date");

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(100);

                entity.Property(e => e.IsActive)
                    .HasColumnName("IS_ACTIVE")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("MODIFIED_BY")
                    .HasMaxLength(200);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("MODIFIED_DATE")
                    .HasColumnType("date");

                entity.Property(e => e.VehiclemodelName)
                    .IsRequired()
                    .HasColumnName("VEHICLEMODEL_NAME")
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<VehicleProperties>(entity =>
            {
                entity.HasKey(e => e.VpId);

                entity.ToTable("VEHICLE_PROPERTIES");

                entity.Property(e => e.VpId)
                    .HasColumnName("VP_ID")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("CREATED_DATE")
                    .HasColumnType("date");

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(100);

                entity.Property(e => e.IsActive)
                    .HasColumnName("IS_ACTIVE")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("MODIFIED_BY")
                    .HasMaxLength(200);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("MODIFIED_DATE")
                    .HasColumnType("date");

                entity.Property(e => e.Property)
                    .IsRequired()
                    .HasColumnName("PROPERTY")
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<VehiclePropertiesMapping>(entity =>
            {
                entity.HasKey(e => e.VpmId);

                entity.ToTable("VEHICLE_PROPERTIES_MAPPING");

                entity.Property(e => e.VpmId)
                    .HasColumnName("VPM_ID")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("CREATED_DATE")
                    .HasColumnType("date");

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(100);

                entity.Property(e => e.IsActive)
                    .HasColumnName("IS_ACTIVE")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("MODIFIED_BY")
                    .HasMaxLength(200);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("MODIFIED_DATE")
                    .HasColumnType("date");

                entity.Property(e => e.VpId)
                    .HasColumnName("VP_ID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.VtId)
                    .HasColumnName("VT_ID")
                    .HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.Vp)
                    .WithMany(p => p.VehiclePropertiesMapping)
                    .HasForeignKey(d => d.VpId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__VEHICLE_P__VP_ID__06CD04F7");

                entity.HasOne(d => d.Vt)
                    .WithMany(p => p.VehiclePropertiesMapping)
                    .HasForeignKey(d => d.VtId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__VEHICLE_P__VT_ID__05D8E0BE");
            });

            modelBuilder.Entity<VehicleRecords>(entity =>
            {
                entity.HasKey(e => e.VrId);

                entity.ToTable("VEHICLE_RECORDS");

                entity.Property(e => e.VrId)
                    .HasColumnName("VR_ID")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("CREATED_DATE")
                    .HasColumnType("date");

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(100);

                entity.Property(e => e.IsActive)
                    .HasColumnName("IS_ACTIVE")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("MODIFIED_BY")
                    .HasMaxLength(200);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("MODIFIED_DATE")
                    .HasColumnType("date");

                entity.Property(e => e.VmmpId)
                    .HasColumnName("VMMP_ID")
                    .HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.Vmmp)
                    .WithMany(p => p.VehicleRecords)
                    .HasForeignKey(d => d.VmmpId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__VEHICLE_R__VMMP___0A9D95DB");
            });

            modelBuilder.Entity<VehicleRecordsProperties>(entity =>
            {
                entity.HasKey(e => e.VrpId);

                entity.ToTable("VEHICLE_RECORDS_PROPERTIES");

                entity.Property(e => e.VrpId)
                    .HasColumnName("VRP_ID")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("CREATED_DATE")
                    .HasColumnType("date");

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(100);

                entity.Property(e => e.IsActive)
                    .HasColumnName("IS_ACTIVE")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("MODIFIED_BY")
                    .HasMaxLength(200);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("MODIFIED_DATE")
                    .HasColumnType("date");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasColumnName("VALUE")
                    .HasMaxLength(200);

                entity.Property(e => e.VpmId)
                    .HasColumnName("VPM_ID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.VrId)
                    .HasColumnName("VR_ID")
                    .HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.Vpm)
                    .WithMany(p => p.VehicleRecordsProperties)
                    .HasForeignKey(d => d.VpmId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__VEHICLE_R__VPM_I__10566F31");

                entity.HasOne(d => d.Vr)
                    .WithMany(p => p.VehicleRecordsProperties)
                    .HasForeignKey(d => d.VrId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__VEHICLE_R__VR_ID__114A936A");
            });

            modelBuilder.Entity<Vehicletype>(entity =>
            {
                entity.HasKey(e => e.VtId);

                entity.ToTable("VEHICLETYPE");

                entity.Property(e => e.VtId)
                    .HasColumnName("VT_ID")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("CREATED_DATE")
                    .HasColumnType("date");

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(100);

                entity.Property(e => e.IsActive)
                    .HasColumnName("IS_ACTIVE")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("MODIFIED_BY")
                    .HasMaxLength(200);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("MODIFIED_DATE")
                    .HasColumnType("date");

                entity.Property(e => e.VehicletypeName)
                    .IsRequired()
                    .HasColumnName("VEHICLETYPE_NAME")
                    .HasMaxLength(200);
            });
        }
    }
}
