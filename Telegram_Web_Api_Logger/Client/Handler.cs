using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types;

namespace Telegram_Web_Api_Logger.Client
{
    public class Handler
    {
        public static void StartUp()
        {
            TelegramBotClient botClient = new TelegramBotClient("5997104590:AAFkHASbEKVVIkE_aQlTkpWc5BnXTVFI4kI");
            botClient.StartReceiving<UpdateHandler>();

            Console.ReadKey();
        }
    }
    public class UpdateHandler : IUpdateHandler
    {
        string InnerCommand = "";
        private readonly FriendsDbContext context = new();


        public async Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            await botClient.SendTextMessageAsync(botClient.BotId, "Error occured!");
        }

        public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            await Console.Out.WriteLineAsync(update.Message.Text);
            long chatId = update.Message.Chat.Id;
            string command = update.Message.Text;

            KeyboardButton StartButton = new KeyboardButton("Start");
            KeyboardButton AddButton = new KeyboardButton("Add");
            KeyboardButton GetButton = new KeyboardButton("GetAll");
            KeyboardButton DeleteButton = new KeyboardButton("Delete");
            KeyboardButton UpdateButton = new KeyboardButton("Update");
            KeyboardButton GetAdminContactButton = new KeyboardButton("GetAdminContact");
            KeyboardButton SendContactButton = new KeyboardButton("SendConact")
            {
                RequestContact = true,
                RequestLocation = true,
            };

            ReplyKeyboardMarkup markup = new(StartButton);

            var keyboard2 = new ReplyKeyboardMarkup(new[]
           {
                new []
                {
                    GetButton, AddButton
                },
                new []
                {
                    UpdateButton, DeleteButton
                },
                new []
                {
                    GetAdminContactButton, SendContactButton
                }
            });

            if (command.StartsWith("/start"))
            {
                await botClient.SendPhotoAsync(chatId, new InputOnlineFile(""));
                await botClient.SendTextMessageAsync(chatId, "", replyMarkup: keyboard2);
            }

            switch (command)
            {
                case "GetAll":
                    foreach (var user in context.Friends.ToList())
                    {
                        await botClient.SendContactAsync(chatId, user.Name, user.Number);
                    }
                    break;
                case "GetAdmitContact":
                    {
                        await botClient.SendContactAsync(chatId, "+998-99-999-99-99", "AdmitContact");
                    }
                    break;
                case "Delete":
                    {
                        InnerCommand = "Delete";
                        Console.WriteLine("Delete: " + update.Message.Text);
                        await botClient.SendTextMessageAsync(chatId, "Send Number");
                    }
                    break;
                case "Add":
                    {
                        InnerCommand = "AddContactName";
                        await botClient.SendTextMessageAsync(chatId, "Send Contact Name");
                    }
                    break;
                case "Update":
                    {
                        InnerCommand = "Update";
                        await botClient.SendTextMessageAsync(chatId, "Send NewPhoneNumber");
                    }
                    break;

            }
        }
    }
}