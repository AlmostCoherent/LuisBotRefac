using LuisBot.Dialogs;
using LuisBot.Factories.Implementations;
using LuisBot.Factories.Interfaces;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace LuisBot.App_Start
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            container.RegisterType<IDialog<IMessageActivity>, InitialDialog>("1");
            container.RegisterType<IDialogFactory, DialogFactory>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);

        }
    }
}