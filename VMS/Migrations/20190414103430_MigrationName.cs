using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VMS.Migrations
{
    public partial class MigrationName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    VPM = table.Column<decimal>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.VPM);
                });

            migrationBuilder.CreateTable(
                name: "VEHICLE",
                columns: table => new
                {
                    ID = table.Column<decimal>(type: "numeric(18, 0)", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TYPE = table.Column<string>(maxLength: 200, nullable: false),
                    MAKE = table.Column<string>(maxLength: 200, nullable: false),
                    MODEL = table.Column<string>(maxLength: 200, nullable: false),
                    ENGINE = table.Column<string>(maxLength: 200, nullable: false),
                    WHEELS = table.Column<string>(maxLength: 200, nullable: false),
                    DOORS = table.Column<string>(maxLength: 200, nullable: false),
                    BODYTYPE = table.Column<string>(maxLength: 200, nullable: false),
                    COLOURS = table.Column<string>(maxLength: 200, nullable: false),
                    IS_ACTIVE = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    CREATED_BY = table.Column<string>(maxLength: 200, nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "date", nullable: true),
                    MODIFIED_BY = table.Column<string>(maxLength: 200, nullable: true),
                    MODIFIED_DATE = table.Column<DateTime>(type: "date", nullable: true),
                    DESCRIPTION = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VEHICLE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "VEHICLE_MAKE",
                columns: table => new
                {
                    VMAKE_ID = table.Column<decimal>(type: "numeric(18, 0)", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VEHICLEMAKE_NAME = table.Column<string>(maxLength: 200, nullable: false),
                    IS_ACTIVE = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    CREATED_BY = table.Column<string>(maxLength: 200, nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "date", nullable: true),
                    MODIFIED_BY = table.Column<string>(maxLength: 200, nullable: true),
                    MODIFIED_DATE = table.Column<DateTime>(type: "date", nullable: true),
                    DESCRIPTION = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VEHICLE_MAKE", x => x.VMAKE_ID);
                });

            migrationBuilder.CreateTable(
                name: "VEHICLE_MODEL",
                columns: table => new
                {
                    VMODEL_ID = table.Column<decimal>(type: "numeric(18, 0)", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VEHICLEMODEL_NAME = table.Column<string>(maxLength: 200, nullable: false),
                    IS_ACTIVE = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    CREATED_BY = table.Column<string>(maxLength: 200, nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "date", nullable: true),
                    MODIFIED_BY = table.Column<string>(maxLength: 200, nullable: true),
                    MODIFIED_DATE = table.Column<DateTime>(type: "date", nullable: true),
                    DESCRIPTION = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VEHICLE_MODEL", x => x.VMODEL_ID);
                });

            migrationBuilder.CreateTable(
                name: "VEHICLE_PROPERTIES",
                columns: table => new
                {
                    VP_ID = table.Column<decimal>(type: "numeric(18, 0)", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PROPERTY = table.Column<string>(maxLength: 200, nullable: false),
                    IS_ACTIVE = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    CREATED_BY = table.Column<string>(maxLength: 200, nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "date", nullable: true),
                    MODIFIED_BY = table.Column<string>(maxLength: 200, nullable: true),
                    MODIFIED_DATE = table.Column<DateTime>(type: "date", nullable: true),
                    DESCRIPTION = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VEHICLE_PROPERTIES", x => x.VP_ID);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    VRId = table.Column<decimal>(nullable: false),
                    VMMPId = table.Column<decimal>(nullable: false),
                    VtId = table.Column<decimal>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    Make = table.Column<string>(nullable: true),
                    VmakeId = table.Column<decimal>(nullable: false),
                    Model = table.Column<string>(nullable: true),
                    VmodelId = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.VRId);
                });

            migrationBuilder.CreateTable(
                name: "VEHICLETYPE",
                columns: table => new
                {
                    VT_ID = table.Column<decimal>(type: "numeric(18, 0)", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VEHICLETYPE_NAME = table.Column<string>(maxLength: 200, nullable: false),
                    DESCRIPTION = table.Column<string>(maxLength: 100, nullable: true),
                    IS_ACTIVE = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    CREATED_BY = table.Column<string>(maxLength: 200, nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "date", nullable: true),
                    MODIFIED_BY = table.Column<string>(maxLength: 200, nullable: true),
                    MODIFIED_DATE = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VEHICLETYPE", x => x.VT_ID);
                });

            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    VPM = table.Column<decimal>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    VehiclesVRId = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.VPM);
                    table.ForeignKey(
                        name: "FK_Car_Vehicles_VehiclesVRId",
                        column: x => x.VehiclesVRId,
                        principalTable: "Vehicles",
                        principalColumn: "VRId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VEHICLE_MAKEMODEL_MAPPING",
                columns: table => new
                {
                    VMMP_ID = table.Column<decimal>(type: "numeric(18, 0)", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VT_ID = table.Column<decimal>(type: "numeric(18, 0)", nullable: false),
                    VMAKE_ID = table.Column<decimal>(type: "numeric(18, 0)", nullable: false),
                    VMODEL_ID = table.Column<decimal>(type: "numeric(18, 0)", nullable: false),
                    IS_ACTIVE = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    CREATED_BY = table.Column<string>(maxLength: 200, nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "date", nullable: true),
                    MODIFIED_BY = table.Column<string>(maxLength: 200, nullable: true),
                    MODIFIED_DATE = table.Column<DateTime>(type: "date", nullable: true),
                    DESCRIPTION = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VEHICLE_MAKEMODEL_MAPPING", x => x.VMMP_ID);
                    table.ForeignKey(
                        name: "FK__VEHICLE_M__VMAKE__08B54D69",
                        column: x => x.VMAKE_ID,
                        principalTable: "VEHICLE_MAKE",
                        principalColumn: "VMAKE_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__VEHICLE_M__VMODE__09A971A2",
                        column: x => x.VMODEL_ID,
                        principalTable: "VEHICLE_MODEL",
                        principalColumn: "VMODEL_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__VEHICLE_M__VT_ID__07C12930",
                        column: x => x.VT_ID,
                        principalTable: "VEHICLETYPE",
                        principalColumn: "VT_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VEHICLE_PROPERTIES_MAPPING",
                columns: table => new
                {
                    VPM_ID = table.Column<decimal>(type: "numeric(18, 0)", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VT_ID = table.Column<decimal>(type: "numeric(18, 0)", nullable: false),
                    VP_ID = table.Column<decimal>(type: "numeric(18, 0)", nullable: false),
                    IS_ACTIVE = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    CREATED_BY = table.Column<string>(maxLength: 200, nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "date", nullable: true),
                    MODIFIED_BY = table.Column<string>(maxLength: 200, nullable: true),
                    MODIFIED_DATE = table.Column<DateTime>(type: "date", nullable: true),
                    DESCRIPTION = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VEHICLE_PROPERTIES_MAPPING", x => x.VPM_ID);
                    table.ForeignKey(
                        name: "FK__VEHICLE_P__VP_ID__06CD04F7",
                        column: x => x.VP_ID,
                        principalTable: "VEHICLE_PROPERTIES",
                        principalColumn: "VP_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__VEHICLE_P__VT_ID__05D8E0BE",
                        column: x => x.VT_ID,
                        principalTable: "VEHICLETYPE",
                        principalColumn: "VT_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VEHICLE_RECORDS",
                columns: table => new
                {
                    VR_ID = table.Column<decimal>(type: "numeric(18, 0)", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VMMP_ID = table.Column<decimal>(type: "numeric(18, 0)", nullable: false),
                    IS_ACTIVE = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    CREATED_BY = table.Column<string>(maxLength: 200, nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "date", nullable: true),
                    MODIFIED_BY = table.Column<string>(maxLength: 200, nullable: true),
                    MODIFIED_DATE = table.Column<DateTime>(type: "date", nullable: true),
                    DESCRIPTION = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VEHICLE_RECORDS", x => x.VR_ID);
                    table.ForeignKey(
                        name: "FK__VEHICLE_R__VMMP___0A9D95DB",
                        column: x => x.VMMP_ID,
                        principalTable: "VEHICLE_MAKEMODEL_MAPPING",
                        principalColumn: "VMMP_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VEHICLE_RECORDS_PROPERTIES",
                columns: table => new
                {
                    VRP_ID = table.Column<decimal>(type: "numeric(18, 0)", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VR_ID = table.Column<decimal>(type: "numeric(18, 0)", nullable: false),
                    VPM_ID = table.Column<decimal>(type: "numeric(18, 0)", nullable: false),
                    VALUE = table.Column<string>(maxLength: 200, nullable: false),
                    IS_ACTIVE = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    CREATED_BY = table.Column<string>(maxLength: 200, nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "date", nullable: true),
                    MODIFIED_BY = table.Column<string>(maxLength: 200, nullable: true),
                    MODIFIED_DATE = table.Column<DateTime>(type: "date", nullable: true),
                    DESCRIPTION = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VEHICLE_RECORDS_PROPERTIES", x => x.VRP_ID);
                    table.ForeignKey(
                        name: "FK__VEHICLE_R__VPM_I__10566F31",
                        column: x => x.VPM_ID,
                        principalTable: "VEHICLE_PROPERTIES_MAPPING",
                        principalColumn: "VPM_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__VEHICLE_R__VR_ID__114A936A",
                        column: x => x.VR_ID,
                        principalTable: "VEHICLE_RECORDS",
                        principalColumn: "VR_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Car_VehiclesVRId",
                table: "Car",
                column: "VehiclesVRId");

            migrationBuilder.CreateIndex(
                name: "IX_VEHICLE_MAKEMODEL_MAPPING_VMAKE_ID",
                table: "VEHICLE_MAKEMODEL_MAPPING",
                column: "VMAKE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_VEHICLE_MAKEMODEL_MAPPING_VMODEL_ID",
                table: "VEHICLE_MAKEMODEL_MAPPING",
                column: "VMODEL_ID");

            migrationBuilder.CreateIndex(
                name: "IX_VEHICLE_MAKEMODEL_MAPPING_VT_ID",
                table: "VEHICLE_MAKEMODEL_MAPPING",
                column: "VT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_VEHICLE_PROPERTIES_MAPPING_VP_ID",
                table: "VEHICLE_PROPERTIES_MAPPING",
                column: "VP_ID");

            migrationBuilder.CreateIndex(
                name: "IX_VEHICLE_PROPERTIES_MAPPING_VT_ID",
                table: "VEHICLE_PROPERTIES_MAPPING",
                column: "VT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_VEHICLE_RECORDS_VMMP_ID",
                table: "VEHICLE_RECORDS",
                column: "VMMP_ID");

            migrationBuilder.CreateIndex(
                name: "IX_VEHICLE_RECORDS_PROPERTIES_VPM_ID",
                table: "VEHICLE_RECORDS_PROPERTIES",
                column: "VPM_ID");

            migrationBuilder.CreateIndex(
                name: "IX_VEHICLE_RECORDS_PROPERTIES_VR_ID",
                table: "VEHICLE_RECORDS_PROPERTIES",
                column: "VR_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "VEHICLE");

            migrationBuilder.DropTable(
                name: "VEHICLE_RECORDS_PROPERTIES");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "VEHICLE_PROPERTIES_MAPPING");

            migrationBuilder.DropTable(
                name: "VEHICLE_RECORDS");

            migrationBuilder.DropTable(
                name: "VEHICLE_PROPERTIES");

            migrationBuilder.DropTable(
                name: "VEHICLE_MAKEMODEL_MAPPING");

            migrationBuilder.DropTable(
                name: "VEHICLE_MAKE");

            migrationBuilder.DropTable(
                name: "VEHICLE_MODEL");

            migrationBuilder.DropTable(
                name: "VEHICLETYPE");
        }
    }
}
