using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System.Collections;
using LuisBot.Shared.Enums;
using System.Collections.Generic;
using System.Threading;

namespace LuisBot.Dialogs
{
    [Serializable]
    public class InitialDialog : IDialog<IMessageActivity>
    {
        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);

            return Task.CompletedTask;
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {

            var message = await result;

            await context.Forward(new CreateUserDialog(), this.ResumeAfterCreateUser, message, CancellationToken.None);

            //await context.PostAsync(reply);

            //var activity = await result as IMessageActivity;

            ////var returnLuis = Utilities.LuisProcessor.GetLuisIntent(activity.Text);

            //// calculate something for us to return
            //int length = (activity.Text ?? string.Empty).Length;

            //// return our reply to the user
            //await context.PostAsync($"You sent {activity.Text} which was {length} characters");

            //context.Wait(MessageReceivedAsync);
        }

        private async Task ResumeAfterCreateUser(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var returnValue = await result;

            await context.PostAsync($"Return value: { returnValue.Text }");

            context.Wait(this.MessageReceivedAsync);
        }
    }
}