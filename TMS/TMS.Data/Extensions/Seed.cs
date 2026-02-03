using Microsoft.EntityFrameworkCore;
using TMS.Data.Entities;

namespace TMS.Data.Extensions;

internal static class Seed
{
    public static void SeedData(this ModelBuilder modelBuilder)
    {
        Tasks(modelBuilder);
    }

    private static void Tasks(ModelBuilder modelBuilder)
    {
        var baseDate = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        modelBuilder.Entity<TaskEntity>().HasData(
            new TaskEntity { Id = 1, Subject = "Build more villagers", Description = "The foundation of every strong economy. Gather wood, food, and gold to advance through the ages.", IsCompleted = false, SortOrder = 34, CreatedAt = baseDate.AddDays(34), ModifiedAt = baseDate.AddDays(34) },
            new TaskEntity { Id = 2, Subject = "Research Loom", Description = "Protect your villagers from early raids by researching Loom at the Town Center.", IsCompleted = false, SortOrder = 33, CreatedAt = baseDate.AddDays(33), ModifiedAt = baseDate.AddDays(33) },
            new TaskEntity { Id = 3, Subject = "Train monks at monastery", Description = "Monks can heal units and convert enemy soldiers. A powerful conversion can turn the tide of battle.", IsCompleted = true, SortOrder = 32, CreatedAt = baseDate.AddDays(32), ModifiedAt = baseDate.AddDays(32) },
            new TaskEntity { Id = 4, Subject = "It works on my machine", Description = "Famous last words before production deployment. Docker can't save you now.", IsCompleted = false, SortOrder = 31, CreatedAt = baseDate.AddDays(31), ModifiedAt = baseDate.AddDays(31) },
            new TaskEntity { Id = 5, Subject = "Wololoo", Description = "Converting enemy units since 1997. Your blue soldier is now my red soldier.", IsCompleted = true, SortOrder = 30, CreatedAt = baseDate.AddDays(30), ModifiedAt = baseDate.AddDays(30) },
            new TaskEntity { Id = 6, Subject = "Review documentation", Description = "The documentation is a lie. Just like the cake.", IsCompleted = false, SortOrder = 29, CreatedAt = baseDate.AddDays(29), ModifiedAt = baseDate.AddDays(29) },
            new TaskEntity { Id = 7, Subject = "Fix login bug", Description = "Have you tried turning it off and on again?", IsCompleted = true, SortOrder = 28, CreatedAt = baseDate.AddDays(28), ModifiedAt = baseDate.AddDays(28) },
            new TaskEntity { Id = 8, Subject = "Update NuGet packages", Description = "One does not simply update all packages without breaking something.", IsCompleted = false, SortOrder = 27, CreatedAt = baseDate.AddDays(27), ModifiedAt = baseDate.AddDays(27) },
            new TaskEntity { Id = 9, Subject = "Create unit tests", Description = "Add unit tests for the TaskService class.", IsCompleted = false, SortOrder = 26, CreatedAt = baseDate.AddDays(26), ModifiedAt = baseDate.AddDays(26) },
            new TaskEntity { Id = 10, Subject = "Database optimization", Description = "SELECT * FROM problems WHERE solution = 'more indexes'", IsCompleted = true, SortOrder = 25, CreatedAt = baseDate.AddDays(25), ModifiedAt = baseDate.AddDays(25) },
            new TaskEntity { Id = 11, Subject = "API documentation", Description = "Generate Swagger documentation for all endpoints. Include request/response examples and proper descriptions for each parameter.", IsCompleted = false, SortOrder = 24, CreatedAt = baseDate.AddDays(24), ModifiedAt = baseDate.AddDays(24) },
            new TaskEntity { Id = 12, Subject = "Code review", Description = "LGTM 👍 (I definitely read all 500 lines)", IsCompleted = true, SortOrder = 23, CreatedAt = baseDate.AddDays(23), ModifiedAt = baseDate.AddDays(23) },
            new TaskEntity { Id = 13, Subject = "Setup CI/CD pipeline", Description = "Configure GitHub Actions for automated builds and deployments.", IsCompleted = false, SortOrder = 22, CreatedAt = baseDate.AddDays(22), ModifiedAt = baseDate.AddDays(22) },
            new TaskEntity { Id = 14, Subject = "Implement caching", Description = "There are only two hard things in CS: cache invalidation and naming things.", IsCompleted = false, SortOrder = 21, CreatedAt = baseDate.AddDays(21), ModifiedAt = baseDate.AddDays(21) },
            new TaskEntity { Id = 15, Subject = "Security audit", Description = "Password123 is not a valid password. Neither is Admin123. Stop it.", IsCompleted = true, SortOrder = 20, CreatedAt = baseDate.AddDays(20), ModifiedAt = baseDate.AddDays(20) },
            new TaskEntity { Id = 16, Subject = "Refactor controllers", Description = "This code was written by a developer who mass despises the next person reading it.", IsCompleted = false, SortOrder = 19, CreatedAt = baseDate.AddDays(19), ModifiedAt = baseDate.AddDays(19) },
            new TaskEntity { Id = 17, Subject = "Add logging", Description = "Console.WriteLine('here'); Console.WriteLine('here 2'); Console.WriteLine('why is this not working');", IsCompleted = true, SortOrder = 18, CreatedAt = baseDate.AddDays(18), ModifiedAt = baseDate.AddDays(18) },
            new TaskEntity { Id = 18, Subject = "Performance testing", Description = "Run load tests. Pray to the server gods.", IsCompleted = false, SortOrder = 17, CreatedAt = baseDate.AddDays(17), ModifiedAt = baseDate.AddDays(17) },
            new TaskEntity { Id = 19, Subject = "Mobile responsiveness", Description = "CSS is easy they said. It will be fun they said.", IsCompleted = false, SortOrder = 16, CreatedAt = baseDate.AddDays(16), ModifiedAt = baseDate.AddDays(16) },
            new TaskEntity { Id = 20, Subject = "Backup strategy", Description = "No backup, no sympathy. - Ancient IT Proverb", IsCompleted = true, SortOrder = 15, CreatedAt = baseDate.AddDays(15), ModifiedAt = baseDate.AddDays(15) },
            new TaskEntity { Id = 21, Subject = "Error handling", Description = "catch (Exception ex) { // TODO: handle this later }", IsCompleted = true, SortOrder = 14, CreatedAt = baseDate.AddDays(14), ModifiedAt = baseDate.AddDays(14) },
            new TaskEntity { Id = 22, Subject = "User feedback", Description = "Users: 'Make the logo bigger.' Also users: 'Why is everything so cluttered?'", IsCompleted = false, SortOrder = 13, CreatedAt = baseDate.AddDays(13), ModifiedAt = baseDate.AddDays(13) },
            new TaskEntity { Id = 23, Subject = "Data migration", Description = "Migrate legacy data from the old system to the new database schema. Validate data integrity after migration.", IsCompleted = false, SortOrder = 12, CreatedAt = baseDate.AddDays(12), ModifiedAt = baseDate.AddDays(12) },
            new TaskEntity { Id = 24, Subject = "SSL certificate", Description = "Certificate expired 3 days ago. Nobody noticed until Karen from accounting couldn't access her spreadsheets.", IsCompleted = true, SortOrder = 11, CreatedAt = baseDate.AddDays(11), ModifiedAt = baseDate.AddDays(11) },
            new TaskEntity { Id = 25, Subject = "Accessibility compliance", Description = "Ensure the application meets WCAG 2.1 accessibility standards.", IsCompleted = false, SortOrder = 10, CreatedAt = baseDate.AddDays(10), ModifiedAt = baseDate.AddDays(10) },
            new TaskEntity { Id = 26, Subject = "Email templates", Description = "Design and implement email templates for user notifications including welcome emails, password resets, and task reminders.", IsCompleted = false, SortOrder = 9, CreatedAt = baseDate.AddDays(9), ModifiedAt = baseDate.AddDays(9) },
            new TaskEntity { Id = 27, Subject = "Rate limiting", Description = "Because someone will try to call the API 10,000 times per second. Someone always does.", IsCompleted = true, SortOrder = 8, CreatedAt = baseDate.AddDays(8), ModifiedAt = baseDate.AddDays(8) },
            new TaskEntity { Id = 28, Subject = "Health checks", Description = "Server: 'I'm fine.' Also server: *catches fire*", IsCompleted = true, SortOrder = 7, CreatedAt = baseDate.AddDays(7), ModifiedAt = baseDate.AddDays(7) },
            new TaskEntity { Id = 29, Subject = "Localization", Description = "Add support for multiple languages. Start with English and Spanish translations for all user-facing text.", IsCompleted = false, SortOrder = 6, CreatedAt = baseDate.AddDays(6), ModifiedAt = baseDate.AddDays(6) },
            new TaskEntity { Id = 30, Subject = "Docker setup", Description = "It works in my container ¯\\_(ツ)_/¯", IsCompleted = false, SortOrder = 5, CreatedAt = baseDate.AddDays(5), ModifiedAt = baseDate.AddDays(5) },
            new TaskEntity { Id = 31, Subject = "Input validation", Description = "Bobby Tables would like to have a word with you.", IsCompleted = true, SortOrder = 4, CreatedAt = baseDate.AddDays(4), ModifiedAt = baseDate.AddDays(4) },
            new TaskEntity { Id = 32, Subject = "Session management", Description = "Implement secure session management with proper timeout and refresh mechanisms.", IsCompleted = false, SortOrder = 3, CreatedAt = baseDate.AddDays(3), ModifiedAt = baseDate.AddDays(3) },
            new TaskEntity { Id = 33, Subject = "Audit logging", Description = "Big Brother is watching. And by Big Brother, I mean the compliance team.", IsCompleted = true, SortOrder = 2, CreatedAt = baseDate.AddDays(2), ModifiedAt = baseDate.AddDays(2) },
            new TaskEntity { Id = 34, Subject = "API versioning", Description = "v1, v2, v3, v3-final, v3-final-FINAL, v3-final-FINAL-use-this-one", IsCompleted = false, SortOrder = 1, CreatedAt = baseDate.AddDays(1), ModifiedAt = baseDate.AddDays(1) },
            new TaskEntity { Id = 35, Subject = "Memory profiling", Description = "Why is Chrome using 8GB of RAM? Oh wait, that's our app.", IsCompleted = false, SortOrder = 0, CreatedAt = baseDate.AddDays(0), ModifiedAt = baseDate.AddDays(0) }
        );
    }
}
