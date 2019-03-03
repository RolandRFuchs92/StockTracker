using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StockTracker.API.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClientName = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR(250)", maxLength: 250, nullable: false),
                    ContactNumber = table.Column<string>(type: "NVARCHAR(20)", maxLength: 20, nullable: false),
                    Address = table.Column<string>(type: "NVARCHAR(250)", maxLength: 250, nullable: true),
                    LastCheckup = table.Column<DateTime>(type: "DateTime", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "DateTime", nullable: false, defaultValueSql: "GetDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientId);
                });

            migrationBuilder.CreateTable(
                name: "CommError",
                columns: table => new
                {
                    CommErrorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StackTrace = table.Column<string>(nullable: true),
                    Exception = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommError", x => x.CommErrorId);
                });

            migrationBuilder.CreateTable(
                name: "CommSendStatusType",
                columns: table => new
                {
                    CommSendStatusTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CommSendStatusName = table.Column<string>(type: "NVARCHAR(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommSendStatusType", x => x.CommSendStatusTypeId);
                });

            migrationBuilder.CreateTable(
                name: "CommType",
                columns: table => new
                {
                    CommTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CommName = table.Column<string>(type: "NVARCHAR(256)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommType", x => x.CommTypeId);
                });

            migrationBuilder.CreateTable(
                name: "MemberRoles",
                columns: table => new
                {
                    MemberRoleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MemberRoleName = table.Column<string>(type: "NVARCHAR(256)", nullable: false),
                    IsActive = table.Column<bool>(type: "BIT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberRoles", x => x.MemberRoleId);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    PersonId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PersonName = table.Column<string>(type: "NVARCHAR(256)", nullable: false),
                    PersonSurname = table.Column<string>(type: "NVARCHAR(256)", nullable: false),
                    Mobile = table.Column<string>(type: "NVARCHAR(20)", nullable: false),
                    WhatsApp = table.Column<string>(type: "NVARCHAR(20)", nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR(256)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "StockCategories",
                columns: table => new
                {
                    StockCategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StockCategoryName = table.Column<string>(type: "NVARCHAR(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockCategories", x => x.StockCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "StockTypes",
                columns: table => new
                {
                    StockTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StockTypeName = table.Column<string>(type: "NVARCHAR(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockTypes", x => x.StockTypeId);
                });

            migrationBuilder.CreateTable(
                name: "SupplierTypes",
                columns: table => new
                {
                    SupplierTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SupplierTypeName = table.Column<string>(type: "NVARCHAR(256)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierTypes", x => x.SupplierTypeId);
                });

            migrationBuilder.CreateTable(
                name: "UnitTypes",
                columns: table => new
                {
                    UnitTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "NVARCHAR(64)", nullable: false),
                    Symbol = table.Column<string>(type: "NVARCHAR(8)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitTypes", x => x.UnitTypeId);
                });

            migrationBuilder.CreateTable(
                name: "ClientSettings",
                columns: table => new
                {
                    ClientSettingsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClientId = table.Column<int>(type: "Int", nullable: false),
                    CanAnyoneAddStock = table.Column<bool>(type: "Bit", nullable: false),
                    CanEmailManagers = table.Column<bool>(type: "Bit", nullable: false),
                    OpenTime = table.Column<DateTime>(type: "DateTime", nullable: false),
                    CloseTime = table.Column<DateTime>(type: "DateTime", nullable: false),
                    TotalUsers = table.Column<int>(type: "Int", nullable: false),
                    IsActive = table.Column<bool>(type: "BIT", nullable: false),
                    IsDeleted = table.Column<bool>(nullable: true),
                    DateDeleted = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientSettings", x => x.ClientSettingsId);
                    table.ForeignKey(
                        name: "FK_ClientSettings_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    MemberId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PersonId = table.Column<int>(nullable: false),
                    ClientId = table.Column<int>(type: "INT", nullable: false),
                    MemberRoleId = table.Column<int>(type: "INT", nullable: false),
                    IsActive = table.Column<bool>(type: "BIT", nullable: false),
                    LastActiveDate = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.MemberId);
                    table.ForeignKey(
                        name: "FK_Members_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Members_MemberRoles_MemberRoleId",
                        column: x => x.MemberRoleId,
                        principalTable: "MemberRoles",
                        principalColumn: "MemberRoleId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Members_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SupplierId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SupplierTypeId = table.Column<int>(type: "INT", nullable: false),
                    SupplierName = table.Column<string>(type: "NVARCHAR(256)", nullable: false),
                    SupplierLocation = table.Column<string>(type: "NVARCHAR(256)", nullable: true),
                    ContactNumber = table.Column<string>(type: "NVARCHAR(256)", nullable: true),
                    Email = table.Column<string>(type: "NVARCHAR(256)", nullable: true),
                    Address = table.Column<string>(type: "NVARCHAR(1024)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SupplierId);
                    table.ForeignKey(
                        name: "FK_Suppliers_SupplierTypes_SupplierTypeId",
                        column: x => x.SupplierTypeId,
                        principalTable: "SupplierTypes",
                        principalColumn: "SupplierTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommDetail",
                columns: table => new
                {
                    CommDetailId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CommErrorId = table.Column<int>(nullable: false),
                    MemberId = table.Column<int>(nullable: false),
                    Response = table.Column<string>(nullable: true),
                    Subject = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    Recipients = table.Column<string>(nullable: true),
                    Sender = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommDetail", x => x.CommDetailId);
                    table.ForeignKey(
                        name: "FK_CommDetail_CommError_CommErrorId",
                        column: x => x.CommErrorId,
                        principalTable: "CommError",
                        principalColumn: "CommErrorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommDetail_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingLists",
                columns: table => new
                {
                    ShoppingListId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MemberId = table.Column<int>(type: "INT", nullable: false),
                    HasNotified = table.Column<bool>(type: "BIT", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "GetDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingLists", x => x.ShoppingListId);
                    table.ForeignKey(
                        name: "FK_ShoppingLists_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StockSupplierDetails",
                columns: table => new
                {
                    StockSupplierDetailId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SupplierId = table.Column<int>(type: "INT", nullable: false),
                    MemberId = table.Column<int>(type: "INT", nullable: false),
                    Price = table.Column<decimal>(type: "DECIMAL", nullable: false),
                    UnitTypeId = table.Column<int>(type: "INT", nullable: false),
                    Unit = table.Column<int>(type: "INT", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockSupplierDetails", x => x.StockSupplierDetailId);
                    table.ForeignKey(
                        name: "FK_StockSupplierDetails_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StockSupplierDetails_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StockSupplierDetails_UnitTypes_UnitTypeId",
                        column: x => x.UnitTypeId,
                        principalTable: "UnitTypes",
                        principalColumn: "UnitTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CommCore",
                columns: table => new
                {
                    CommCoreId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CommTypeId = table.Column<int>(type: "Int", nullable: false),
                    CommSendStatusTypeId = table.Column<int>(type: "Int", nullable: false),
                    CommDetailId = table.Column<int>(type: "Int", nullable: false),
                    ChangedOn = table.Column<DateTime>(type: "DateTime", nullable: false, defaultValueSql: "GetDate()"),
                    CreatedOn = table.Column<DateTime>(type: "DateTime", nullable: false, defaultValueSql: "GetDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommCore", x => x.CommCoreId);
                    table.ForeignKey(
                        name: "FK_CommCore_CommDetail_CommDetailId",
                        column: x => x.CommDetailId,
                        principalTable: "CommDetail",
                        principalColumn: "CommDetailId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommCore_CommSendStatusType_CommSendStatusTypeId",
                        column: x => x.CommSendStatusTypeId,
                        principalTable: "CommSendStatusType",
                        principalColumn: "CommSendStatusTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StockCores",
                columns: table => new
                {
                    StockCoreId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StockCategoryId = table.Column<int>(type: "INT", nullable: false),
                    StockSupplierDetailId = table.Column<int>(type: "INT", nullable: false),
                    StockTypeId = table.Column<int>(type: "INT", nullable: false),
                    StockCoreName = table.Column<string>(type: "NVARCHAR(250)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockCores", x => x.StockCoreId);
                    table.ForeignKey(
                        name: "FK_StockCores_StockCategories_StockCategoryId",
                        column: x => x.StockCategoryId,
                        principalTable: "StockCategories",
                        principalColumn: "StockCategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StockCores_StockSupplierDetails_StockSupplierDetailId",
                        column: x => x.StockSupplierDetailId,
                        principalTable: "StockSupplierDetails",
                        principalColumn: "StockSupplierDetailId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StockCores_StockTypes_StockTypeId",
                        column: x => x.StockTypeId,
                        principalTable: "StockTypes",
                        principalColumn: "StockTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClientStockItem",
                columns: table => new
                {
                    ClientStockItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StockCoreId = table.Column<int>(type: "Int", nullable: false),
                    ClientId = table.Column<int>(type: "Int", nullable: false),
                    StockMax = table.Column<int>(type: "Int", nullable: false),
                    StockMin = table.Column<int>(type: "Int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "DateTime", nullable: false, defaultValueSql: "GetDate()"),
                    IsActive = table.Column<bool>(type: "Bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientStockItem", x => x.ClientStockItemId);
                    table.ForeignKey(
                        name: "FK_ClientStockItem_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientStockItem_StockCores_StockCoreId",
                        column: x => x.StockCoreId,
                        principalTable: "StockCores",
                        principalColumn: "StockCoreId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingListItems",
                columns: table => new
                {
                    ShoppingListItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ShoppingListId = table.Column<int>(type: "INT", nullable: false),
                    StockCoreId = table.Column<int>(type: "INT", nullable: false),
                    Quantity = table.Column<int>(type: "INT", nullable: false),
                    IsCollected = table.Column<bool>(type: "BIT", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingListItems", x => x.ShoppingListItemId);
                    table.ForeignKey(
                        name: "FK_ShoppingListItems_ShoppingLists_ShoppingListId",
                        column: x => x.ShoppingListId,
                        principalTable: "ShoppingLists",
                        principalColumn: "ShoppingListId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShoppingListItems_StockCores_StockCoreId",
                        column: x => x.StockCoreId,
                        principalTable: "StockCores",
                        principalColumn: "StockCoreId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClientStockLevel",
                columns: table => new
                {
                    ClientStockLevelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClientStockItemId = table.Column<int>(type: "Int", nullable: false),
                    MemberId = table.Column<int>(type: "Int", nullable: false),
                    Quantity = table.Column<int>(type: "Int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "DateTime", nullable: false, defaultValueSql: "GETDATE()"),
                    IsActive = table.Column<bool>(type: "Bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientStockLevel", x => x.ClientStockLevelId);
                    table.ForeignKey(
                        name: "FK_ClientStockLevel_ClientStockItem_ClientStockItemId",
                        column: x => x.ClientStockItemId,
                        principalTable: "ClientStockItem",
                        principalColumn: "ClientStockItemId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientStockLevel_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "CommSendStatusType",
                columns: new[] { "CommSendStatusTypeId", "CommSendStatusName" },
                values: new object[,]
                {
                    { 1, "Qued" },
                    { 2, "Processing" },
                    { 3, "Sent" },
                    { 4, "Failed" },
                    { 5, "Pending" }
                });

            migrationBuilder.InsertData(
                table: "CommType",
                columns: new[] { "CommTypeId", "CommName" },
                values: new object[,]
                {
                    { 1, "SMS" },
                    { 2, "Email" },
                    { 3, "App" },
                    { 4, "WhatsApp" }
                });

            migrationBuilder.InsertData(
                table: "MemberRoles",
                columns: new[] { "MemberRoleId", "IsActive", "MemberRoleName" },
                values: new object[,]
                {
                    { 8, true, "Staff" },
                    { 7, true, "Sculler" },
                    { 6, true, "Chef" },
                    { 5, true, "Waiter" },
                    { 2, true, "Admin" },
                    { 3, true, "Team Leader" },
                    { 1, true, "Managing Director" },
                    { 4, true, "Manager" }
                });

            migrationBuilder.InsertData(
                table: "StockCategories",
                columns: new[] { "StockCategoryId", "StockCategoryName" },
                values: new object[,]
                {
                    { 6, "Fruit" },
                    { 8, "Edible Liquid" },
                    { 7, "Oil" },
                    { 5, "Canned Good" },
                    { 1, "Meat" },
                    { 3, "Vegetable" },
                    { 2, "Pasta" },
                    { 4, "Powder" }
                });

            migrationBuilder.InsertData(
                table: "StockTypes",
                columns: new[] { "StockTypeId", "StockTypeName" },
                values: new object[,]
                {
                    { 13, "Canned Meat" },
                    { 21, "Cream" },
                    { 20, "Yogurt" },
                    { 19, "Water" },
                    { 18, "Cider" },
                    { 17, "Wine" },
                    { 16, "Beer" },
                    { 15, "Fruit Juice" },
                    { 14, "Soda" },
                    { 12, "Canned Vegetable" },
                    { 6, "Fish" },
                    { 10, "Spice" },
                    { 9, "Sauce" },
                    { 8, "Beef" },
                    { 7, "Pork" },
                    { 5, "Chicken" },
                    { 4, "Cooking Oil" },
                    { 3, "Sugar" },
                    { 2, "Raw Fruit" },
                    { 1, "Frozen Treat" },
                    { 11, "Canned Fruit" }
                });

            migrationBuilder.InsertData(
                table: "SupplierTypes",
                columns: new[] { "SupplierTypeId", "SupplierTypeName" },
                values: new object[,]
                {
                    { 5, "Farmer" },
                    { 4, "Super Market" },
                    { 3, "Caterer" },
                    { 1, "Grocer" },
                    { 2, "Butcher" }
                });

            migrationBuilder.InsertData(
                table: "UnitTypes",
                columns: new[] { "UnitTypeId", "Name", "Symbol" },
                values: new object[,]
                {
                    { 10, "Gallon", "g" },
                    { 1, "Kilo gram", "Kg" },
                    { 2, "Gram", "g" },
                    { 3, "Milligram", "Mg" },
                    { 4, "Unit", "U" },
                    { 5, "Liter", "l" },
                    { 6, "Milliliter", "Ml" },
                    { 7, "Ounce", "Oz" },
                    { 8, "Pint", "pt" },
                    { 9, "Quart", "qt" },
                    { 11, "Pound", "lb" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientSettings_ClientId",
                table: "ClientSettings",
                column: "ClientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClientStockItem_ClientId",
                table: "ClientStockItem",
                column: "ClientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClientStockItem_StockCoreId",
                table: "ClientStockItem",
                column: "StockCoreId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClientStockLevel_ClientStockItemId",
                table: "ClientStockLevel",
                column: "ClientStockItemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClientStockLevel_MemberId",
                table: "ClientStockLevel",
                column: "MemberId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CommCore_CommDetailId",
                table: "CommCore",
                column: "CommDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_CommCore_CommSendStatusTypeId",
                table: "CommCore",
                column: "CommSendStatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CommDetail_CommErrorId",
                table: "CommDetail",
                column: "CommErrorId");

            migrationBuilder.CreateIndex(
                name: "IX_CommDetail_MemberId",
                table: "CommDetail",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_ClientId",
                table: "Members",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_MemberRoleId",
                table: "Members",
                column: "MemberRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_PersonId",
                table: "Members",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingListItems_ShoppingListId",
                table: "ShoppingListItems",
                column: "ShoppingListId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingListItems_StockCoreId",
                table: "ShoppingListItems",
                column: "StockCoreId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingLists_MemberId",
                table: "ShoppingLists",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_StockCores_StockCategoryId",
                table: "StockCores",
                column: "StockCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_StockCores_StockSupplierDetailId",
                table: "StockCores",
                column: "StockSupplierDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_StockCores_StockTypeId",
                table: "StockCores",
                column: "StockTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_StockSupplierDetails_MemberId",
                table: "StockSupplierDetails",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_StockSupplierDetails_SupplierId",
                table: "StockSupplierDetails",
                column: "SupplierId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StockSupplierDetails_UnitTypeId",
                table: "StockSupplierDetails",
                column: "UnitTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_SupplierTypeId",
                table: "Suppliers",
                column: "SupplierTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientSettings");

            migrationBuilder.DropTable(
                name: "ClientStockLevel");

            migrationBuilder.DropTable(
                name: "CommCore");

            migrationBuilder.DropTable(
                name: "CommType");

            migrationBuilder.DropTable(
                name: "ShoppingListItems");

            migrationBuilder.DropTable(
                name: "ClientStockItem");

            migrationBuilder.DropTable(
                name: "CommDetail");

            migrationBuilder.DropTable(
                name: "CommSendStatusType");

            migrationBuilder.DropTable(
                name: "ShoppingLists");

            migrationBuilder.DropTable(
                name: "StockCores");

            migrationBuilder.DropTable(
                name: "CommError");

            migrationBuilder.DropTable(
                name: "StockCategories");

            migrationBuilder.DropTable(
                name: "StockSupplierDetails");

            migrationBuilder.DropTable(
                name: "StockTypes");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "UnitTypes");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "MemberRoles");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "SupplierTypes");
        }
    }
}
