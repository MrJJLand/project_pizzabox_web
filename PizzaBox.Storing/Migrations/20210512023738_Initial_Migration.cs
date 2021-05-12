using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PizzaBox.Storing.Migrations
{
    public partial class Initial_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cheeses",
                columns: table => new
                {
                    EntityID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cheeses", x => x.EntityID);
                });

            migrationBuilder.CreateTable(
                name: "Crusts",
                columns: table => new
                {
                    EntityID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crusts", x => x.EntityID);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    EntityID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.EntityID);
                });

            migrationBuilder.CreateTable(
                name: "Sauces",
                columns: table => new
                {
                    EntityID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sauces", x => x.EntityID);
                });

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    EntityID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.EntityID);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    EntityID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Discriminator = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.EntityID);
                });

            migrationBuilder.CreateTable(
                name: "Pizzas",
                columns: table => new
                {
                    EntityID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CheeseEntityID1 = table.Column<long>(type: "bigint", nullable: true),
                    CheeseEntityID2 = table.Column<long>(type: "bigint", nullable: true),
                    CrustEntityID1 = table.Column<long>(type: "bigint", nullable: true),
                    CrustEntityID2 = table.Column<long>(type: "bigint", nullable: true),
                    SauceEntityID1 = table.Column<long>(type: "bigint", nullable: true),
                    SauceEntityID2 = table.Column<long>(type: "bigint", nullable: true),
                    SizeEntityID1 = table.Column<long>(type: "bigint", nullable: true),
                    SizeEntityID2 = table.Column<long>(type: "bigint", nullable: true),
                    ToppingEntityID1 = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizzas", x => x.EntityID);
                    table.ForeignKey(
                        name: "FK_Pizzas_Cheeses_CheeseEntityID1",
                        column: x => x.CheeseEntityID1,
                        principalTable: "Cheeses",
                        principalColumn: "EntityID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pizzas_Cheeses_CheeseEntityID2",
                        column: x => x.CheeseEntityID2,
                        principalTable: "Cheeses",
                        principalColumn: "EntityID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pizzas_Crusts_CrustEntityID1",
                        column: x => x.CrustEntityID1,
                        principalTable: "Crusts",
                        principalColumn: "EntityID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pizzas_Crusts_CrustEntityID2",
                        column: x => x.CrustEntityID2,
                        principalTable: "Crusts",
                        principalColumn: "EntityID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pizzas_Sauces_SauceEntityID1",
                        column: x => x.SauceEntityID1,
                        principalTable: "Sauces",
                        principalColumn: "EntityID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pizzas_Sauces_SauceEntityID2",
                        column: x => x.SauceEntityID2,
                        principalTable: "Sauces",
                        principalColumn: "EntityID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pizzas_Sizes_SizeEntityID1",
                        column: x => x.SizeEntityID1,
                        principalTable: "Sizes",
                        principalColumn: "EntityID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pizzas_Sizes_SizeEntityID2",
                        column: x => x.SizeEntityID2,
                        principalTable: "Sizes",
                        principalColumn: "EntityID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    EntityID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CustomerEntityID = table.Column<long>(type: "bigint", nullable: true),
                    PizzaEntityID = table.Column<long>(type: "bigint", nullable: true),
                    StoreEntityID = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.EntityID);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerEntityID",
                        column: x => x.CustomerEntityID,
                        principalTable: "Customers",
                        principalColumn: "EntityID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Pizzas_PizzaEntityID",
                        column: x => x.PizzaEntityID,
                        principalTable: "Pizzas",
                        principalColumn: "EntityID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Stores_StoreEntityID",
                        column: x => x.StoreEntityID,
                        principalTable: "Stores",
                        principalColumn: "EntityID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Toppings",
                columns: table => new
                {
                    EntityID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PizzaEntityID = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Toppings", x => x.EntityID);
                    table.ForeignKey(
                        name: "FK_Toppings_Pizzas_PizzaEntityID",
                        column: x => x.PizzaEntityID,
                        principalTable: "Pizzas",
                        principalColumn: "EntityID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Cheeses",
                columns: new[] { "EntityID", "Name", "Price" },
                values: new object[,]
                {
                    { 1L, "Mozzerella", 0.0m },
                    { 2L, "Brie", 0.0m },
                    { 3L, "Cheddar", 0.0m },
                    { 4L, "Feta", 0.0m },
                    { 5L, "Swiss", 0.0m },
                    { 6L, "No Cheese", 0.0m }
                });

            migrationBuilder.InsertData(
                table: "Crusts",
                columns: new[] { "EntityID", "Name", "Price" },
                values: new object[,]
                {
                    { 6L, "Stuffed Crust", 3.0m },
                    { 5L, "Deep Dish", 2.0m },
                    { 4L, "Pretzel", 1.50m },
                    { 2L, "Thin", 1.0m },
                    { 1L, "Original", 0.0m },
                    { 3L, "Gluten-Free", 1.50m }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "EntityID", "Name" },
                values: new object[,]
                {
                    { 1L, "Elizabeth Gainor" },
                    { 2L, "Darth Plagueis" },
                    { 3L, "Just Monika" },
                    { 4L, "Calli Dream" },
                    { 5L, "Kenneth Burtch" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "EntityID", "CustomerEntityID", "PizzaEntityID", "StoreEntityID" },
                values: new object[] { 1L, null, null, null });

            migrationBuilder.InsertData(
                table: "Sauces",
                columns: new[] { "EntityID", "Name", "Price" },
                values: new object[,]
                {
                    { 7L, "Riggie Sauce", 0.0m },
                    { 1L, "Pizza Sauce - Classic", 0.0m },
                    { 8L, "Sweet BBQ", 0.0m },
                    { 9L, "Tangy BBQ", 0.0m },
                    { 10L, "White Garlic", 0.0m },
                    { 4L, "Garlic Ranch", 0.0m },
                    { 3L, "Buffalo", 0.0m },
                    { 2L, "Pizza Sauce - Exotic", 0.0m },
                    { 5L, "Marinara", 0.0m },
                    { 6L, "Pesto", 0.0m }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "EntityID", "Name", "Price" },
                values: new object[,]
                {
                    { 3L, "Large", 15.0m },
                    { 4L, "XL", 20.0m },
                    { 2L, "Medium", 13.0m },
                    { 1L, "Small", 10.0m }
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "EntityID", "Discriminator", "Name" },
                values: new object[,]
                {
                    { 10L, "NewYorkStore", "Artist Ln." },
                    { 1L, "ChicagoStore", "Main St." },
                    { 2L, "ChicagoStore", "West Rd." },
                    { 9L, "NewYorkStore", "Name_Pending Rd." },
                    { 4L, "ChicagoStore", "East St." },
                    { 5L, "ChicagoStore", "South Cir." },
                    { 6L, "NewYorkStore", "South James St." },
                    { 7L, "NewYorkStore", "Erie Blvd." },
                    { 8L, "NewYorkStore", "Black River Blvd." },
                    { 3L, "ChicagoStore", "North Ave." }
                });

            migrationBuilder.InsertData(
                table: "Toppings",
                columns: new[] { "EntityID", "Name", "PizzaEntityID", "Price" },
                values: new object[,]
                {
                    { 37L, "Pulled Pork", null, 1.50m },
                    { 36L, "Prosciutto", null, 2.00m },
                    { 35L, "Pineapple", null, 1.00m },
                    { 34L, "Pesto", null, 0.50m },
                    { 32L, "Pemeal Bacon", null, 2.00m },
                    { 31L, "Mushrooms", null, 1.00m },
                    { 30L, "Meatball", null, 1.50m },
                    { 38L, "Ranch", null, 0.50m },
                    { 29L, "Lobster", null, 3.00m },
                    { 33L, "Pepperoni", null, 1.00m },
                    { 39L, "Red Onion", null, 1.00m },
                    { 46L, "Shrimp", null, 1.50m },
                    { 41L, "Salami", null, 1.50m },
                    { 42L, "Sausage", null, 1.50m },
                    { 43L, "Scallions", null, 1.00m },
                    { 44L, "Scallops", null, 1.50m },
                    { 45L, "Shaved Beef", null, 1.50m },
                    { 47L, "Spinach", null, 1.00m },
                    { 48L, "Sun Dried Tomatoes", null, 1.00m },
                    { 49L, "Sweet BBQ Sauce", null, 0.50m },
                    { 50L, "Tangy BBQ Sauce", null, 0.50m },
                    { 51L, "Tomatoes", null, 1.00m },
                    { 28L, "Lamb", null, 2.50m },
                    { 40L, "Riggie Sauce", null, 0.50m },
                    { 27L, "Jalepeños", null, 1.00m },
                    { 6L, "Bison", null, 2.50m },
                    { 25L, "Ham", null, 1.50m },
                    { 1L, "American Bacon", null, 1.50m },
                    { 2L, "Anchovies", null, 1.50m },
                    { 3L, "Avocado", null, 1.50m },
                    { 4L, "Banana Peppers", null, 1.00m },
                    { 5L, "Basil", null, 0.50m },
                    { 52L, "Venison", null, 3.00m },
                    { 7L, "Black Olives", null, 1.00m },
                    { 8L, "Breakfast Sausage", null, 1.50m },
                    { 9L, "Broccoli", null, 1.00m },
                    { 10L, "Buffalo Chicken", null, 1.50m },
                    { 11L, "Buffalo Sauce", null, 0.50m },
                    { 26L, "Italian Greens", null, 1.50m },
                    { 12L, "Canadian Bacon", null, 2.00m },
                    { 14L, "Chicken", null, 1.50m },
                    { 15L, "Crab", null, 2.00m },
                    { 16L, "Dill Pickles", null, 0.50m },
                    { 17L, "Eggs", null, 1.00m },
                    { 18L, "Elbows", null, 1.00m },
                    { 19L, "Elk", null, 2.50m },
                    { 20L, "Extra Cheese", null, 0.50m },
                    { 21L, "Feta", null, 1.00m },
                    { 22L, "Garlic", null, 0.50m },
                    { 23L, "Green Peppers", null, 1.00m },
                    { 24L, "Ground Beef", null, 1.50m },
                    { 13L, "Carmalized Onions", null, 1.00m },
                    { 53L, "Yellow Onion", null, 1.00m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerEntityID",
                table: "Orders",
                column: "CustomerEntityID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PizzaEntityID",
                table: "Orders",
                column: "PizzaEntityID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StoreEntityID",
                table: "Orders",
                column: "StoreEntityID");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_CheeseEntityID1",
                table: "Pizzas",
                column: "CheeseEntityID1");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_CheeseEntityID2",
                table: "Pizzas",
                column: "CheeseEntityID2");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_CrustEntityID1",
                table: "Pizzas",
                column: "CrustEntityID1");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_CrustEntityID2",
                table: "Pizzas",
                column: "CrustEntityID2");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_SauceEntityID1",
                table: "Pizzas",
                column: "SauceEntityID1");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_SauceEntityID2",
                table: "Pizzas",
                column: "SauceEntityID2");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_SizeEntityID1",
                table: "Pizzas",
                column: "SizeEntityID1");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_SizeEntityID2",
                table: "Pizzas",
                column: "SizeEntityID2");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_ToppingEntityID1",
                table: "Pizzas",
                column: "ToppingEntityID1");

            migrationBuilder.CreateIndex(
                name: "IX_Toppings_PizzaEntityID",
                table: "Toppings",
                column: "PizzaEntityID");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Toppings_ToppingEntityID1",
                table: "Pizzas",
                column: "ToppingEntityID1",
                principalTable: "Toppings",
                principalColumn: "EntityID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Toppings_Pizzas_PizzaEntityID",
                table: "Toppings");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Stores");

            migrationBuilder.DropTable(
                name: "Pizzas");

            migrationBuilder.DropTable(
                name: "Cheeses");

            migrationBuilder.DropTable(
                name: "Crusts");

            migrationBuilder.DropTable(
                name: "Sauces");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropTable(
                name: "Toppings");
        }
    }
}
