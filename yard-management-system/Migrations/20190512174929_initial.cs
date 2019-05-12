using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace yard_management_system.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CargoTimeSlot",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CargoTimeSlot", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MessageReceiver",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageReceiver", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OrderContract",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderContract", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UserRight",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRight", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    EMail = table.Column<string>(nullable: true),
                    PhoneNo = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    SecondName = table.Column<string>(nullable: true),
                    Blocked = table.Column<bool>(nullable: false),
                    UserRightID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_User_UserRight_UserRightID",
                        column: x => x.UserRightID,
                        principalTable: "UserRight",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contractor",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TypeOfContractor = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    OrderContractID = table.Column<int>(nullable: false),
                    MessageReceiverID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contractor", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Contractor_MessageReceiver_MessageReceiverID",
                        column: x => x.MessageReceiverID,
                        principalTable: "MessageReceiver",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contractor_OrderContract_OrderContractID",
                        column: x => x.OrderContractID,
                        principalTable: "OrderContract",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contractor_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ObjectChange",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    UserCreatorId = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    EntryID = table.Column<int>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Blocked = table.Column<bool>(nullable: true),
                    BlockedFrom = table.Column<DateTime>(nullable: true),
                    BlockedTo = table.Column<DateTime>(nullable: true),
                    OrderID = table.Column<int>(nullable: true),
                    State = table.Column<int>(nullable: true),
                    PermissionsSetID = table.Column<int>(nullable: true),
                    PermissionsSet_Code = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    UserRightID = table.Column<int>(nullable: true),
                    RampID = table.Column<int>(nullable: true),
                    Ramp_Code = table.Column<string>(nullable: true),
                    CategoryOfRamp = table.Column<int>(nullable: true),
                    Ramp_Blocked = table.Column<bool>(nullable: true),
                    Ramp_BlockedFrom = table.Column<DateTime>(nullable: true),
                    Ramp_BlockedTo = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjectChange", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ObjectChange_User_UserCreatorId",
                        column: x => x.UserCreatorId,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ObjectChange_UserRight_UserRightID",
                        column: x => x.UserRightID,
                        principalTable: "UserRight",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
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
                    OrderID = table.Column<int>(nullable: false),
                    OrderContractID = table.Column<int>(nullable: false),
                    CargoTimeSlotID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargo", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Cargo_CargoTimeSlot_CargoTimeSlotID",
                        column: x => x.CargoTimeSlotID,
                        principalTable: "CargoTimeSlot",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cargo_ObjectChange_EntryID",
                        column: x => x.EntryID,
                        principalTable: "ObjectChange",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cargo_OrderContract_OrderContractID",
                        column: x => x.OrderContractID,
                        principalTable: "OrderContract",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cargo_ObjectChange_OrderID",
                        column: x => x.OrderID,
                        principalTable: "ObjectChange",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Cargo_ObjectChange_RampID",
                        column: x => x.RampID,
                        principalTable: "ObjectChange",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
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
                    table.ForeignKey(
                        name: "FK_Permission_ObjectChange_PermissionsSetID",
                        column: x => x.PermissionsSetID,
                        principalTable: "ObjectChange",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TimeSlot",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    TimeFrom = table.Column<string>(nullable: true),
                    TimeDuration = table.Column<string>(nullable: true),
                    TypeOfTimeSlot = table.Column<int>(nullable: false),
                    Reserved = table.Column<bool>(nullable: false),
                    Blocked = table.Column<bool>(nullable: false),
                    RampID = table.Column<int>(nullable: false),
                    CargoTimeSlotID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSlot", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TimeSlot_CargoTimeSlot_CargoTimeSlotID",
                        column: x => x.CargoTimeSlotID,
                        principalTable: "CargoTimeSlot",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TimeSlot_ObjectChange_RampID",
                        column: x => x.RampID,
                        principalTable: "ObjectChange",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Text = table.Column<string>(nullable: true),
                    CargoID = table.Column<int>(nullable: false),
                    MessageReceiverID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Message_Cargo_CargoID",
                        column: x => x.CargoID,
                        principalTable: "Cargo",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Message_MessageReceiver_MessageReceiverID",
                        column: x => x.MessageReceiverID,
                        principalTable: "MessageReceiver",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cargo_CargoTimeSlotID",
                table: "Cargo",
                column: "CargoTimeSlotID");

            migrationBuilder.CreateIndex(
                name: "IX_Cargo_EntryID",
                table: "Cargo",
                column: "EntryID");

            migrationBuilder.CreateIndex(
                name: "IX_Cargo_OrderContractID",
                table: "Cargo",
                column: "OrderContractID");

            migrationBuilder.CreateIndex(
                name: "IX_Cargo_OrderID",
                table: "Cargo",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Cargo_RampID",
                table: "Cargo",
                column: "RampID");

            migrationBuilder.CreateIndex(
                name: "IX_Contractor_MessageReceiverID",
                table: "Contractor",
                column: "MessageReceiverID");

            migrationBuilder.CreateIndex(
                name: "IX_Contractor_OrderContractID",
                table: "Contractor",
                column: "OrderContractID");

            migrationBuilder.CreateIndex(
                name: "IX_Contractor_UserID",
                table: "Contractor",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Message_CargoID",
                table: "Message",
                column: "CargoID");

            migrationBuilder.CreateIndex(
                name: "IX_Message_MessageReceiverID",
                table: "Message",
                column: "MessageReceiverID");

            migrationBuilder.CreateIndex(
                name: "IX_ObjectChange_UserCreatorId",
                table: "ObjectChange",
                column: "UserCreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ObjectChange_UserRightID",
                table: "ObjectChange",
                column: "UserRightID");

            migrationBuilder.CreateIndex(
                name: "IX_Permission_PermissionsSetID",
                table: "Permission",
                column: "PermissionsSetID");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSlot_CargoTimeSlotID",
                table: "TimeSlot",
                column: "CargoTimeSlotID");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSlot_RampID",
                table: "TimeSlot",
                column: "RampID");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserRightID",
                table: "User",
                column: "UserRightID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contractor");

            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropTable(
                name: "TimeSlot");

            migrationBuilder.DropTable(
                name: "Cargo");

            migrationBuilder.DropTable(
                name: "MessageReceiver");

            migrationBuilder.DropTable(
                name: "CargoTimeSlot");

            migrationBuilder.DropTable(
                name: "ObjectChange");

            migrationBuilder.DropTable(
                name: "OrderContract");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "UserRight");
        }
    }
}
