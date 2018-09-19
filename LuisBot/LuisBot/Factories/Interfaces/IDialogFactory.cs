using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuisBot.Factories.Interfaces
{
    public interface IDialogFactory
    {
        dynamic Create(int typeOfDialogue);
    }
}
