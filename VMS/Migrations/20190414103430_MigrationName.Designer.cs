﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VMS.Models;

namespace VMS.Migrations
{
    [DbContext(typeof(VehiclesContext))]
    [Migration("20190414103430_MigrationName")]
    partial class MigrationName
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VMS.Models.Car", b =>
                {
                    b.Property<decimal>("VPM");

                    b.Property<string>("Value");

                    b.Property<decimal?>("VehiclesVRId");

                    b.HasKey("VPM");

                    b.HasIndex("VehiclesVRId");

                    b.ToTable("Car");
                });

            modelBuilder.Entity("VMS.Models.Cars", b =>
                {
                    b.Property<decimal>("VPM");

                    b.Property<string>("Value");

                    b.HasKey("VPM");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("VMS.Models.Vehicle", b =>
                {
                    b.Property<decimal>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("numeric(18, 0)")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bodytype")
                        .IsRequired()
                        .HasColumnName("BODYTYPE")
                        .HasMaxLength(200);

                    b.Property<string>("Colours")
                        .IsRequired()
                        .HasColumnName("COLOURS")
                        .HasMaxLength(200);

                    b.Property<string>("CreatedBy")
                        .HasColumnName("CREATED_BY")
                        .HasMaxLength(200);

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnName("CREATED_DATE")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .HasColumnName("DESCRIPTION")
                        .HasMaxLength(100);

                    b.Property<string>("Doors")
                        .IsRequired()
                        .HasColumnName("DOORS")
                        .HasMaxLength(200);

                    b.Property<string>("Engine")
                        .IsRequired()
                        .HasColumnName("ENGINE")
                        .HasMaxLength(200);

                    b.Property<string>("IsActive")
                        .HasColumnName("IS_ACTIVE")
                        .HasMaxLength(10)
                        .IsUnicode(false);

                    b.Property<string>("Make")
                        .IsRequired()
                        .HasColumnName("MAKE")
                        .HasMaxLength(200);

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnName("MODEL")
                        .HasMaxLength(200);

                    b.Property<string>("ModifiedBy")
                        .HasColumnName("MODIFIED_BY")
                        .HasMaxLength(200);

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnName("MODIFIED_DATE")
                        .HasColumnType("date");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnName("TYPE")
                        .HasMaxLength(200);

                    b.Property<string>("Wheels")
                        .IsRequired()
                        .HasColumnName("WHEELS")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("VEHICLE");
                });

            modelBuilder.Entity("VMS.Models.VehicleMake", b =>
                {
                    b.Property<decimal>("VmakeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("VMAKE_ID")
                        .HasColumnType("numeric(18, 0)")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasColumnName("CREATED_BY")
                        .HasMaxLength(200);

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnName("CREATED_DATE")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .HasColumnName("DESCRIPTION")
                        .HasMaxLength(100);

                    b.Property<string>("IsActive")
                        .HasColumnName("IS_ACTIVE")
                        .HasMaxLength(10)
                        .IsUnicode(false);

                    b.Property<string>("ModifiedBy")
                        .HasColumnName("MODIFIED_BY")
                        .HasMaxLength(200);

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnName("MODIFIED_DATE")
                        .HasColumnType("date");

                    b.Property<string>("VehiclemakeName")
                        .IsRequired()
                        .HasColumnName("VEHICLEMAKE_NAME")
                        .HasMaxLength(200);

                    b.HasKey("VmakeId");

                    b.ToTable("VEHICLE_MAKE");
                });

            modelBuilder.Entity("VMS.Models.VehicleMakemodelMapping", b =>
                {
                    b.Property<decimal>("VmmpId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("VMMP_ID")
                        .HasColumnType("numeric(18, 0)")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasColumnName("CREATED_BY")
                        .HasMaxLength(200);

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnName("CREATED_DATE")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .HasColumnName("DESCRIPTION")
                        .HasMaxLength(100);

                    b.Property<string>("IsActive")
                        .IsRequired()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 1)))
                        .HasColumnName("IS_ACTIVE")
                        .HasMaxLength(10)
                        .IsUnicode(false);

                    b.Property<string>("ModifiedBy")
                        .HasColumnName("MODIFIED_BY")
                        .HasMaxLength(200);

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnName("MODIFIED_DATE")
                        .HasColumnType("date");

                    b.Property<decimal>("VmakeId")
                        .HasColumnName("VMAKE_ID")
                        .HasColumnType("numeric(18, 0)");

                    b.Property<decimal>("VmodelId")
                        .HasColumnName("VMODEL_ID")
                        .HasColumnType("numeric(18, 0)");

                    b.Property<decimal>("VtId")
                        .HasColumnName("VT_ID")
                        .HasColumnType("numeric(18, 0)");

                    b.HasKey("VmmpId");

                    b.HasIndex("VmakeId");

                    b.HasIndex("VmodelId");

                    b.HasIndex("VtId");

                    b.ToTable("VEHICLE_MAKEMODEL_MAPPING");
                });

            modelBuilder.Entity("VMS.Models.VehicleModel", b =>
                {
                    b.Property<decimal>("VmodelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("VMODEL_ID")
                        .HasColumnType("numeric(18, 0)")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasColumnName("CREATED_BY")
                        .HasMaxLength(200);

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnName("CREATED_DATE")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .HasColumnName("DESCRIPTION")
                        .HasMaxLength(100);

                    b.Property<string>("IsActive")
                        .HasColumnName("IS_ACTIVE")
                        .HasMaxLength(10)
                        .IsUnicode(false);

                    b.Property<string>("ModifiedBy")
                        .HasColumnName("MODIFIED_BY")
                        .HasMaxLength(200);

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnName("MODIFIED_DATE")
                        .HasColumnType("date");

                    b.Property<string>("VehiclemodelName")
                        .IsRequired()
                        .HasColumnName("VEHICLEMODEL_NAME")
                        .HasMaxLength(200);

                    b.HasKey("VmodelId");

                    b.ToTable("VEHICLE_MODEL");
                });

            modelBuilder.Entity("VMS.Models.VehicleProperties", b =>
                {
                    b.Property<decimal>("VpId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("VP_ID")
                        .HasColumnType("numeric(18, 0)")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasColumnName("CREATED_BY")
                        .HasMaxLength(200);

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnName("CREATED_DATE")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .HasColumnName("DESCRIPTION")
                        .HasMaxLength(100);

                    b.Property<string>("IsActive")
                        .HasColumnName("IS_ACTIVE")
                        .HasMaxLength(10)
                        .IsUnicode(false);

                    b.Property<string>("ModifiedBy")
                        .HasColumnName("MODIFIED_BY")
                        .HasMaxLength(200);

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnName("MODIFIED_DATE")
                        .HasColumnType("date");

                    b.Property<string>("Property")
                        .IsRequired()
                        .HasColumnName("PROPERTY")
                        .HasMaxLength(200);

                    b.HasKey("VpId");

                    b.ToTable("VEHICLE_PROPERTIES");
                });

            modelBuilder.Entity("VMS.Models.VehiclePropertiesMapping", b =>
                {
                    b.Property<decimal>("VpmId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("VPM_ID")
                        .HasColumnType("numeric(18, 0)")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasColumnName("CREATED_BY")
                        .HasMaxLength(200);

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnName("CREATED_DATE")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .HasColumnName("DESCRIPTION")
                        .HasMaxLength(100);

                    b.Property<string>("IsActive")
                        .IsRequired()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 1)))
                        .HasColumnName("IS_ACTIVE")
                        .HasMaxLength(10)
                        .IsUnicode(false);

                    b.Property<string>("ModifiedBy")
                        .HasColumnName("MODIFIED_BY")
                        .HasMaxLength(200);

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnName("MODIFIED_DATE")
                        .HasColumnType("date");

                    b.Property<decimal>("VpId")
                        .HasColumnName("VP_ID")
                        .HasColumnType("numeric(18, 0)");

                    b.Property<decimal>("VtId")
                        .HasColumnName("VT_ID")
                        .HasColumnType("numeric(18, 0)");

                    b.HasKey("VpmId");

                    b.HasIndex("VpId");

                    b.HasIndex("VtId");

                    b.ToTable("VEHICLE_PROPERTIES_MAPPING");
                });

            modelBuilder.Entity("VMS.Models.VehicleRecords", b =>
                {
                    b.Property<decimal>("VrId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("VR_ID")
                        .HasColumnType("numeric(18, 0)")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasColumnName("CREATED_BY")
                        .HasMaxLength(200);

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnName("CREATED_DATE")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .HasColumnName("DESCRIPTION")
                        .HasMaxLength(100);

                    b.Property<string>("IsActive")
                        .HasColumnName("IS_ACTIVE")
                        .HasMaxLength(10)
                        .IsUnicode(false);

                    b.Property<string>("ModifiedBy")
                        .HasColumnName("MODIFIED_BY")
                        .HasMaxLength(200);

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnName("MODIFIED_DATE")
                        .HasColumnType("date");

                    b.Property<decimal>("VmmpId")
                        .HasColumnName("VMMP_ID")
                        .HasColumnType("numeric(18, 0)");

                    b.HasKey("VrId");

                    b.HasIndex("VmmpId");

                    b.ToTable("VEHICLE_RECORDS");
                });

            modelBuilder.Entity("VMS.Models.VehicleRecordsProperties", b =>
                {
                    b.Property<decimal>("VrpId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("VRP_ID")
                        .HasColumnType("numeric(18, 0)")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasColumnName("CREATED_BY")
                        .HasMaxLength(200);

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnName("CREATED_DATE")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .HasColumnName("DESCRIPTION")
                        .HasMaxLength(100);

                    b.Property<string>("IsActive")
                        .HasColumnName("IS_ACTIVE")
                        .HasMaxLength(10)
                        .IsUnicode(false);

                    b.Property<string>("ModifiedBy")
                        .HasColumnName("MODIFIED_BY")
                        .HasMaxLength(200);

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnName("MODIFIED_DATE")
                        .HasColumnType("date");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnName("VALUE")
                        .HasMaxLength(200);

                    b.Property<decimal>("VpmId")
                        .HasColumnName("VPM_ID")
                        .HasColumnType("numeric(18, 0)");

                    b.Property<decimal>("VrId")
                        .HasColumnName("VR_ID")
                        .HasColumnType("numeric(18, 0)");

                    b.HasKey("VrpId");

                    b.HasIndex("VpmId");

                    b.HasIndex("VrId");

                    b.ToTable("VEHICLE_RECORDS_PROPERTIES");
                });

            modelBuilder.Entity("VMS.Models.Vehicles", b =>
                {
                    b.Property<decimal>("VRId");

                    b.Property<string>("Make");

                    b.Property<string>("Model");

                    b.Property<string>("Type");

                    b.Property<decimal>("VMMPId");

                    b.Property<decimal>("VmakeId");

                    b.Property<decimal>("VmodelId");

                    b.Property<decimal>("VtId");

                    b.HasKey("VRId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("VMS.Models.Vehicletype", b =>
                {
                    b.Property<decimal>("VtId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("VT_ID")
                        .HasColumnType("numeric(18, 0)")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasColumnName("CREATED_BY")
                        .HasMaxLength(200);

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnName("CREATED_DATE")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .HasColumnName("DESCRIPTION")
                        .HasMaxLength(100);

                    b.Property<string>("IsActive")
                        .IsRequired()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 1)))
                        .HasColumnName("IS_ACTIVE")
                        .HasMaxLength(10)
                        .IsUnicode(false);

                    b.Property<string>("ModifiedBy")
                        .HasColumnName("MODIFIED_BY")
                        .HasMaxLength(200);

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnName("MODIFIED_DATE")
                        .HasColumnType("date");

                    b.Property<string>("VehicletypeName")
                        .IsRequired()
                        .HasColumnName("VEHICLETYPE_NAME")
                        .HasMaxLength(200);

                    b.HasKey("VtId");

                    b.ToTable("VEHICLETYPE");
                });

            modelBuilder.Entity("VMS.Models.Car", b =>
                {
                    b.HasOne("VMS.Models.Vehicles")
                        .WithMany("Car")
                        .HasForeignKey("VehiclesVRId");
                });

            modelBuilder.Entity("VMS.Models.VehicleMakemodelMapping", b =>
                {
                    b.HasOne("VMS.Models.VehicleMake", "Vmake")
                        .WithMany("VehicleMakemodelMapping")
                        .HasForeignKey("VmakeId")
                        .HasConstraintName("FK__VEHICLE_M__VMAKE__08B54D69");

                    b.HasOne("VMS.Models.VehicleModel", "Vmodel")
                        .WithMany("VehicleMakemodelMapping")
                        .HasForeignKey("VmodelId")
                        .HasConstraintName("FK__VEHICLE_M__VMODE__09A971A2");

                    b.HasOne("VMS.Models.Vehicletype", "Vt")
                        .WithMany("VehicleMakemodelMapping")
                        .HasForeignKey("VtId")
                        .HasConstraintName("FK__VEHICLE_M__VT_ID__07C12930");
                });

            modelBuilder.Entity("VMS.Models.VehiclePropertiesMapping", b =>
                {
                    b.HasOne("VMS.Models.VehicleProperties", "Vp")
                        .WithMany("VehiclePropertiesMapping")
                        .HasForeignKey("VpId")
                        .HasConstraintName("FK__VEHICLE_P__VP_ID__06CD04F7");

                    b.HasOne("VMS.Models.Vehicletype", "Vt")
                        .WithMany("VehiclePropertiesMapping")
                        .HasForeignKey("VtId")
                        .HasConstraintName("FK__VEHICLE_P__VT_ID__05D8E0BE");
                });

            modelBuilder.Entity("VMS.Models.VehicleRecords", b =>
                {
                    b.HasOne("VMS.Models.VehicleMakemodelMapping", "Vmmp")
                        .WithMany("VehicleRecords")
                        .HasForeignKey("VmmpId")
                        .HasConstraintName("FK__VEHICLE_R__VMMP___0A9D95DB");
                });

            modelBuilder.Entity("VMS.Models.VehicleRecordsProperties", b =>
                {
                    b.HasOne("VMS.Models.VehiclePropertiesMapping", "Vpm")
                        .WithMany("VehicleRecordsProperties")
                        .HasForeignKey("VpmId")
                        .HasConstraintName("FK__VEHICLE_R__VPM_I__10566F31");

                    b.HasOne("VMS.Models.VehicleRecords", "Vr")
                        .WithMany("VehicleRecordsProperties")
                        .HasForeignKey("VrId")
                        .HasConstraintName("FK__VEHICLE_R__VR_ID__114A936A")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
