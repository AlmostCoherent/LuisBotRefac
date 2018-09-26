using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using LuisBot.Shared.Enums;
using LuisBot.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using LuisBot.Shared.Models;

namespace LuisBot.Dialogs
{
    [Serializable]
    public class CreateUserDialog : IDialog<IMessageActivity>, ICreateUserDialog
    {
        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(CreateNewChatUserAsync);
        }
        public virtual async Task CreateNewChatUserAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var message = await result;

                PromptDialog.Choice(
                context: context,
                resume: ChoiceReceived,
                options: (IEnumerable<UserRegistered>)Enum.GetValues(typeof(UserRegistered)),
                prompt: "Please select user type:"
                );

        }
        public async Task ChoiceReceived(IDialogContext context, IAwaitable<UserRegistered> result)
        {
            var message = await result;

            var form = new FormDialog<FlightInfo>(new FlightInfo(), BuildForm, FormOptions.None);

            context.Call(form, UserFormComplete);

        }

        private async Task UserFormComplete(IDialogContext context, IAwaitable<FlightInfo> result)
        {
            var flight = await result;

        }

        private static IForm<FlightInfo> BuildForm()
        {
            return new FormBuilder<FlightInfo>()
                .Message("Please fill user details:")
                .Build();

        }
    }
}