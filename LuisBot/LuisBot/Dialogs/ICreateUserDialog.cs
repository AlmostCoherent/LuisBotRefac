using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System.Threading.Tasks;

namespace LuisBot.Dialogs
{
    public interface ICreateUserDialog
    {
        Task CreateNewChatUserAsync(IDialogContext context, IAwaitable<IMessageActivity> result);

    }
}
