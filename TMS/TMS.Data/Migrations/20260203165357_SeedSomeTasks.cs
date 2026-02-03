using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TMS.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedSomeTasks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "Description", "IsCompleted", "Subject" },
                values: new object[,]
                {
                    { 1, "The foundation of every strong economy. Gather wood, food, and gold to advance through the ages.", false, "Build more villagers" },
                    { 2, "Protect your villagers from early raids by researching Loom at the Town Center.", false, "Research Loom" },
                    { 3, "Monks can heal units and convert enemy soldiers. A powerful conversion can turn the tide of battle.", true, "Train monks at monastery" },
                    { 4, "Famous last words before production deployment. Docker can't save you now.", false, "It works on my machine" },
                    { 5, "Converting enemy units since 1997. Your blue soldier is now my red soldier.", true, "Wololoo" },
                    { 6, "The documentation is a lie. Just like the cake.", false, "Review documentation" },
                    { 7, "Have you tried turning it off and on again?", true, "Fix login bug" },
                    { 8, "One does not simply update all packages without breaking something.", false, "Update NuGet packages" },
                    { 9, "Add unit tests for the TaskService class.", false, "Create unit tests" },
                    { 10, "SELECT * FROM problems WHERE solution = 'more indexes'", true, "Database optimization" },
                    { 11, "Generate Swagger documentation for all endpoints. Include request/response examples and proper descriptions for each parameter.", false, "API documentation" },
                    { 12, "LGTM 👍 (I definitely read all 500 lines)", true, "Code review" },
                    { 13, "Configure GitHub Actions for automated builds and deployments.", false, "Setup CI/CD pipeline" },
                    { 14, "There are only two hard things in CS: cache invalidation and naming things.", false, "Implement caching" },
                    { 15, "Password123 is not a valid password. Neither is Admin123. Stop it.", true, "Security audit" },
                    { 16, "This code was written by a developer who mass despises the next person reading it.", false, "Refactor controllers" },
                    { 17, "Console.WriteLine('here'); Console.WriteLine('here 2'); Console.WriteLine('why is this not working');", true, "Add logging" },
                    { 18, "Run load tests. Pray to the server gods.", false, "Performance testing" },
                    { 19, "CSS is easy they said. It will be fun they said.", false, "Mobile responsiveness" },
                    { 20, "No backup, no sympathy. - Ancient IT Proverb", true, "Backup strategy" },
                    { 21, "catch (Exception ex) { // TODO: handle this later }", true, "Error handling" },
                    { 22, "Users: 'Make the logo bigger.' Also users: 'Why is everything so cluttered?'", false, "User feedback" },
                    { 23, "Migrate legacy data from the old system to the new database schema. Validate data integrity after migration.", false, "Data migration" },
                    { 24, "Certificate expired 3 days ago. Nobody noticed until Karen from accounting couldn't access her spreadsheets.", true, "SSL certificate" },
                    { 25, "Ensure the application meets WCAG 2.1 accessibility standards.", false, "Accessibility compliance" },
                    { 26, "Design and implement email templates for user notifications including welcome emails, password resets, and task reminders.", false, "Email templates" },
                    { 27, "Because someone will try to call the API 10,000 times per second. Someone always does.", true, "Rate limiting" },
                    { 28, "Server: 'I'm fine.' Also server: *catches fire*", true, "Health checks" },
                    { 29, "Add support for multiple languages. Start with English and Spanish translations for all user-facing text.", false, "Localization" },
                    { 30, "It works in my container ¯\\_(ツ)_/¯", false, "Docker setup" },
                    { 31, "Bobby Tables would like to have a word with you.", true, "Input validation" },
                    { 32, "Implement secure session management with proper timeout and refresh mechanisms.", false, "Session management" },
                    { 33, "Big Brother is watching. And by Big Brother, I mean the compliance team.", true, "Audit logging" },
                    { 34, "v1, v2, v3, v3-final, v3-final-FINAL, v3-final-FINAL-use-this-one", false, "API versioning" },
                    { 35, "Why is Chrome using 8GB of RAM? Oh wait, that's our app.", false, "Memory profiling" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 35);
        }
    }
}
