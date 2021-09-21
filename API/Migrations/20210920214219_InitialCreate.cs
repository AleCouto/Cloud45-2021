using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AccessLevel = table.Column<bool>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    Birthday = table.Column<DateTime>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Indentification = table.Column<string>(type: "TEXT", nullable: true),
                    FiscalNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    PostalCode = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Amount = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 120, nullable: true),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    ImgFotoProduct = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Product_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: true),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Order_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderProduct",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProduct", x => new { x.OrderId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_OrderProduct_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProduct_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 1, "Plantas" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 2, "Flores" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 3, "Produtos para cultivo" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "AccessLevel", "Address", "Birthday", "Email", "FiscalNumber", "Indentification", "Name", "PhoneNumber", "PostalCode" },
                values: new object[] { 1, true, "Rua Vitimas da Guerra 30", null, "aecmar@hotmail.com", 0, null, "Alexandre Couto", 222222222, 2825420 });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "AccessLevel", "Address", "Birthday", "Email", "FiscalNumber", "Indentification", "Name", "PhoneNumber", "PostalCode" },
                values: new object[] { 2, true, "Rua Lisboa 40", null, "jg@hotmail.com", 0, null, "João Golçalves", 333333333, 1234567 });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "AccessLevel", "Address", "Birthday", "Email", "FiscalNumber", "Indentification", "Name", "PhoneNumber", "PostalCode" },
                values: new object[] { 3, true, "Rua Almirante reis 3", null, "apjose@hotmail.com", 0, null, "Pedro Jose", 444444444, 7654321 });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "OrderId", "Price", "Quantity", "UserId" },
                values: new object[] { 1, 0m, 0, 1 });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "OrderId", "Price", "Quantity", "UserId" },
                values: new object[] { 4, 0m, 0, 1 });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "OrderId", "Price", "Quantity", "UserId" },
                values: new object[] { 2, 0m, 0, 2 });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "OrderId", "Price", "Quantity", "UserId" },
                values: new object[] { 3, 0m, 0, 3 });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "Amount", "CategoryId", "Description", "ImgFotoProduct", "Name", "Price" },
                values: new object[] { 1, 1, 1, "De crescimento rápido e folha persistente, esta planta trepadeira tem o nome Brasil devido às tonalidades verde e amarela das suas folhas.", "/images/PhilodendronBrasil.png", "Philodendron Brasil", 5m });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "Amount", "CategoryId", "Description", "ImgFotoProduct", "Name", "Price" },
                values: new object[] { 2, 1, 1, "Com folhas grandes, verdes e em forma de coração, a Monstera deliciosa ou Costela de Adão ganha aberturas nas folhas à medida que estas amadurecem.", "/images/MonsteraDeliciosa.png", "Monstera Deliciosa", 14m });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "Amount", "CategoryId", "Description", "ImgFotoProduct", "Name", "Price" },
                values: new object[] { 3, 1, 1, "Folhas grandes, redondas, com tonalidades verdes e listas verdes claras.", "/images/Calathea Orbifolia.png", "Calathea Orbifolia", 21m });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "Amount", "CategoryId", "Description", "ImgFotoProduct", "Name", "Price" },
                values: new object[] { 4, 1, 2, "Florescem duas ou três vezes ao ano, precisam de muita luz, mas não luz directa, por isso, é aconselhável usar a luz do final do dia, para que floresçam e sigam radiantes.", "/images/Orquidea.png", "Orquídea", 46m });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "Amount", "CategoryId", "Description", "ImgFotoProduct", "Name", "Price" },
                values: new object[] { 5, 1, 2, "O resultado: fusão perfeita entre pureza, jovialidade e inocência. A combinação ideal, para presentear sem nenhuma razão.", "/images/MargaridasBrancas.png", "Margaridas Brancas", 37m });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "Amount", "CategoryId", "Description", "ImgFotoProduct", "Name", "Price" },
                values: new object[] { 6, 1, 2, "É uma planta de folhas grossas em forma de coração, vistosas e originais flores, que podem ser cor-de-rosa, brancas o amarelas... Mesmo que sem dúvida a cor estrela pelo seu contraste é o vermelho.", "/images/Anthurium.png", "Anthurium", 45m });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "Amount", "CategoryId", "Description", "ImgFotoProduct", "Name", "Price" },
                values: new object[] { 7, 1, 3, "Vaso de cerâmica vitória de qualidade superior indicado para plantas de interior.", "/images/images/vasovitoria.png", "Vaso Vitória", 6m });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "Amount", "CategoryId", "Description", "ImgFotoProduct", "Name", "Price" },
                values: new object[] { 8, 1, 3, "Adubo biológico universal líquido, ideal para plantas de interior e exterior.", "/images/AduboBiologico.png", "Adubo Biológico Universal Líquido 780ml", 7m });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "Amount", "CategoryId", "Description", "ImgFotoProduct", "Name", "Price" },
                values: new object[] { 9, 1, 3, "Substrato universal biológico Siro® Platina feito com matérias primas 100% sustentáveis e indicado para plantação ou transplante de plantas decorativas ou comestíveis.", "/images/SubstratoUniversal.png", "Substrato Universal Biológico 20l", 6m });

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserId",
                table: "Order",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_ProductId",
                table: "OrderProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderProduct");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
