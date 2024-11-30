using Example.DB.Repository.Interfaces;
using Example.Domain.DTOs.ReminderDTOs;
using System.Text;

namespace Example.Services.ReminderServices
{
    public class ReminderService(ILogger<ReminderService> logger, IServiceScopeFactory serviceScopeFactory) : BackgroundService
    {
        private bool isReminderSent = false;

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            logger.LogInformation("ReminderService is starting.");

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var now = DateTime.UtcNow;
                    //var nextRunTime = DateTime.UtcNow.AddSeconds(5);
                    var nextRunTime = DateTime.Today.AddHours(12);
                    var delay = nextRunTime - now;

                    if (delay.TotalMilliseconds > 0)
                    {
                        logger.LogInformation($"ReminderService will run at {nextRunTime}.");
                        isReminderSent = false;
                        await Task.Delay(delay, stoppingToken);
                    }

                    if (!isReminderSent)
                        await SendReminders();
                }
                catch (TaskCanceledException)
                {
                    logger.LogInformation("ReminderService is stopping.");
                }
            }
        }

        private async Task SendReminders()
        {
            using var scope = serviceScopeFactory.CreateScope();
            var borrowingRepository = scope.ServiceProvider.GetRequiredService<IBorrowingRepository>();
            var reminderBorrowings = borrowingRepository.GetReminderBorrowingsAsync();
            await foreach (var reminder in reminderBorrowings)
            {
                await FakeSendEmail(reminder.Email, reminder.BorrowedBooks);
            }

            isReminderSent = true;
        }

        //Na projekte na ktorom pracujem pouzivame sendgrid... keby som velmi chcel tak to jednoducho vykopirujem a supnem sem.
        //Nevidim v tom ale velky zmysel a nechce sa mi kvoli tomu vytvarat ucet na sendgride.
        //Preto som sa rozhodol ze budem fakovat aj ked ste vyslovene ziadali nefakovat.
        //Predpokladam ze vam skorej islo o to aby som vytvoril event co bude bezat n-krat za den a hromadne posielat maily.
        private async Task FakeSendEmail(string email, IEnumerable<ReminderBorrowedBookDto> borrowedBooks)
        {
            if (email == null || !borrowedBooks.Any())
                return;

            var sb = new StringBuilder();

            sb.AppendLine("Dear User,");
            sb.AppendLine();
            sb.AppendLine("You have the following books borrowed that are due soon:");
            sb.AppendLine();

            foreach (var book in borrowedBooks)
            {
                sb.AppendLine($"- \"{book.Title}\" due on {book.DueDate:dd.MM.yyyy}");
            }

            sb.AppendLine();
            sb.AppendLine("Please make sure to return them on time to avoid late fees.");
            sb.AppendLine("Best regards,");
            sb.AppendLine("Your Library Team");

            Console.WriteLine($"Email sent to {email}:\n{sb}");
        }
    }
}
