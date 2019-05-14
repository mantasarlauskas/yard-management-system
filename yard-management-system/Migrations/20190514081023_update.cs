using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace yard_management_system.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CargoTimeSlot",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CargoID = table.Column<int>(nullable: false),
                    TimeSlotID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CargoTimeSlot", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Text = table.Column<string>(nullable: true),
                    CargoID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OrderContract",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CargoID = table.Column<int>(nullable: false),
                    ContractorID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderContract", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MessageReceiver",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MessageID = table.Column<int>(nullable: false),
                    ContractorID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageReceiver", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MessageReceiver_Message_MessageID",
                        column: x => x.MessageID,
                        principalTable: "Message",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cargo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RegistrationNumber = table.Column<string>(nullable: true),
                    Weight = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    State = table.Column<int>(nullable: false),
                    RampID = table.Column<int>(nullable: false),
                    EntryID = table.Column<int>(nullable: false),
                    OrderID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargo", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TimeSlot",
                columns: table => new
                {
                    TimeSlotID = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    TimeFrom = table.Column<string>(nullable: true),
                    TimeDuration = table.Column<string>(nullable: true),
                    TypeOfTimeSlot = table.Column<int>(nullable: false),
                    Reserved = table.Column<bool>(nullable: false),
                    Blocked = table.Column<bool>(nullable: false),
                    RampID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSlot", x => x.TimeSlotID);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Read = table.Column<bool>(nullable: false),
                    Create = table.Column<bool>(nullable: false),
                    Modify = table.Column<bool>(nullable: false),
                    Delete = table.Column<bool>(nullable: false),
                    PermissionName = table.Column<int>(nullable: false),
                    PermissionsSetID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Contractor",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TypeOfContractor = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    OrderContractID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contractor", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ObjectChanges",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    UserCreatorID = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    EntryID = table.Column<int>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Blocked = table.Column<bool>(nullable: true),
                    BlockedFrom = table.Column<DateTime>(nullable: true),
                    BlockedTo = table.Column<DateTime>(nullable: true),
                    OrderID = table.Column<int>(nullable: true),
                    State = table.Column<int>(nullable: true),
                    Ramp_Code = table.Column<string>(nullable: true),
                    CategoryOfRamp = table.Column<int>(nullable: true),
                    Ramp_Blocked = table.Column<bool>(nullable: true),
                    Ramp_BlockedFrom = table.Column<DateTime>(nullable: true),
                    Ramp_BlockedTo = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjectChanges", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UserRight",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRight", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PermissionsSet",
                columns: table => new
                {
                    PermissionsSetID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    UserRightID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionsSet", x => x.PermissionsSetID);
                    table.ForeignKey(
                        name: "FK_PermissionsSet_UserRight_UserRightID",
                        column: x => x.UserRightID,
                        principalTable: "UserRight",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    EMail = table.Column<string>(nullable: true),
                    PhoneNo = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    SecondName = table.Column<string>(nullable: true),
                    Blocked = table.Column<bool>(nullable: false),
                    UserRightID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_User_UserRight_UserRightID",
                        column: x => x.UserRightID,
                        principalTable: "UserRight",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cargo_EntryID",
                table: "Cargo",
                column: "EntryID");

            migrationBuilder.CreateIndex(
                name: "IX_Cargo_OrderID",
                table: "Cargo",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Cargo_RampID",
                table: "Cargo",
                column: "RampID");

            migrationBuilder.CreateIndex(
                name: "IX_CargoTimeSlot_CargoID",
                table: "CargoTimeSlot",
                column: "CargoID");

            migrationBuilder.CreateIndex(
                name: "IX_CargoTimeSlot_TimeSlotID",
                table: "CargoTimeSlot",
                column: "TimeSlotID");

            migrationBuilder.CreateIndex(
                name: "IX_Contractor_UserID",
                table: "Contractor",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Message_CargoID",
                table: "Message",
                column: "CargoID");

            migrationBuilder.CreateIndex(
                name: "IX_MessageReceiver_ContractorID",
                table: "MessageReceiver",
                column: "ContractorID");

            migrationBuilder.CreateIndex(
                name: "IX_MessageReceiver_MessageID",
                table: "MessageReceiver",
                column: "MessageID");

            migrationBuilder.CreateIndex(
                name: "IX_ObjectChanges_UserCreatorID",
                table: "ObjectChanges",
                column: "UserCreatorID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderContract_CargoID",
                table: "OrderContract",
                column: "CargoID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderContract_ContractorID",
                table: "OrderContract",
                column: "ContractorID");

            migrationBuilder.CreateIndex(
                name: "IX_Permission_PermissionsSetID",
                table: "Permission",
                column: "PermissionsSetID");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionsSet_UserRightID",
                table: "PermissionsSet",
                column: "UserRightID");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSlot_RampID",
                table: "TimeSlot",
                column: "RampID");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserRightID",
                table: "User",
                column: "UserRightID");

            migrationBuilder.CreateIndex(
                name: "IX_UserRight_UserID",
                table: "UserRight",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_CargoTimeSlot_Cargo_CargoID",
                table: "CargoTimeSlot",
                column: "CargoID",
                principalTable: "Cargo",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CargoTimeSlot_TimeSlot_TimeSlotID",
                table: "CargoTimeSlot",
                column: "TimeSlotID",
                principalTable: "TimeSlot",
                principalColumn: "TimeSlotID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Cargo_CargoID",
                table: "Message",
                column: "CargoID",
                principalTable: "Cargo",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderContract_Cargo_CargoID",
                table: "OrderContract",
                column: "CargoID",
                principalTable: "Cargo",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderContract_Contractor_ContractorID",
                table: "OrderContract",
                column: "ContractorID",
                principalTable: "Contractor",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MessageReceiver_Contractor_ContractorID",
                table: "MessageReceiver",
                column: "ContractorID",
                principalTable: "Contractor",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cargo_ObjectChanges_EntryID",
                table: "Cargo",
                column: "EntryID",
                principalTable: "ObjectChanges",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cargo_ObjectChanges_OrderID",
                table: "Cargo",
                column: "OrderID",
                principalTable: "ObjectChanges",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Cargo_ObjectChanges_RampID",
                table: "Cargo",
                column: "RampID",
                principalTable: "ObjectChanges",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeSlot_ObjectChanges_RampID",
                table: "TimeSlot",
                column: "RampID",
                principalTable: "ObjectChanges",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Permission_PermissionsSet_PermissionsSetID",
                table: "Permission",
                column: "PermissionsSetID",
                principalTable: "PermissionsSet",
                principalColumn: "PermissionsSetID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contractor_User_UserID",
                table: "Contractor",
                column: "UserID",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ObjectChanges_User_UserCreatorID",
                table: "ObjectChanges",
                column: "UserCreatorID",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRight_User_UserID",
                table: "UserRight",
                column: "UserID",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRight_User_UserID",
                table: "UserRight");

            migrationBuilder.DropTable(
                name: "CargoTimeSlot");

            migrationBuilder.DropTable(
                name: "MessageReceiver");

            migrationBuilder.DropTable(
                name: "OrderContract");

            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropTable(
                name: "TimeSlot");

            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.DropTable(
                name: "Contractor");

            migrationBuilder.DropTable(
                name: "PermissionsSet");

            migrationBuilder.DropTable(
                name: "Cargo");

            migrationBuilder.DropTable(
                name: "ObjectChanges");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "UserRight");
        }
    }
}
