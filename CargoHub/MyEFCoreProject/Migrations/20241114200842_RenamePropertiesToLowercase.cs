using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyEFCoreProject.Migrations
{
    /// <inheritdoc />
    public partial class RenamePropertiesToLowercase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Zip_Code",
                table: "Clients",
                newName: "zip_code");

            migrationBuilder.RenameColumn(
                name: "Updated_At",
                table: "Clients",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "Province",
                table: "Clients",
                newName: "province");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Clients",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Created_At",
                table: "Clients",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Clients",
                newName: "country");

            migrationBuilder.RenameColumn(
                name: "Contact_Phone",
                table: "Clients",
                newName: "contact_phone");

            migrationBuilder.RenameColumn(
                name: "Contact_Name",
                table: "Clients",
                newName: "contact_name");

            migrationBuilder.RenameColumn(
                name: "Contact_Email",
                table: "Clients",
                newName: "contact_email");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Clients",
                newName: "city");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Clients",
                newName: "address");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Clients",
                newName: "id");

            migrationBuilder.AlterColumn<string>(
                name: "zip_code",
                table: "Clients",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "province",
                table: "Clients",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Clients",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "country",
                table: "Clients",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "contact_phone",
                table: "Clients",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "contact_name",
                table: "Clients",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "contact_email",
                table: "Clients",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "city",
                table: "Clients",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "address",
                table: "Clients",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "zip_code",
                table: "Clients",
                newName: "Zip_Code");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "Clients",
                newName: "Updated_At");

            migrationBuilder.RenameColumn(
                name: "province",
                table: "Clients",
                newName: "Province");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Clients",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "Clients",
                newName: "Created_At");

            migrationBuilder.RenameColumn(
                name: "country",
                table: "Clients",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "contact_phone",
                table: "Clients",
                newName: "Contact_Phone");

            migrationBuilder.RenameColumn(
                name: "contact_name",
                table: "Clients",
                newName: "Contact_Name");

            migrationBuilder.RenameColumn(
                name: "contact_email",
                table: "Clients",
                newName: "Contact_Email");

            migrationBuilder.RenameColumn(
                name: "city",
                table: "Clients",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "address",
                table: "Clients",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Clients",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Zip_Code",
                table: "Clients",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Province",
                table: "Clients",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Clients",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "Clients",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Contact_Phone",
                table: "Clients",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Contact_Name",
                table: "Clients",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Contact_Email",
                table: "Clients",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Clients",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Clients",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}
