using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddonTool.ViewModels.Domins.Concrete;

namespace AddonTool.ViewModels.Domins
{
    class DomainFactory
    {
        public ISettingsManager CreateSettingsManager()
        {
            return new LocalSettingsManager();
        }

        public Command CreateCommand(Action<object> execute)
        {
            return new Command(execute);
        }
    }
}
