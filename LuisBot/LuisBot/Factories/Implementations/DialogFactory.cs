using LuisBot.Factories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LuisBot.Shared.Enums;
using LuisBot.Dialogs;

namespace LuisBot.Factories.Implementations
{
    public class DialogFactory : IDialogFactory
    {
        public dynamic Create(int typeOfDialogue)
        {
            switch(typeOfDialogue)
            {
                case (int)DialogueType.InitialDialog:
                    return new InitialDialog();
                default:
                    return new InitialDialog();
            }
        }
    }
}