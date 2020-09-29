using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddonTool.ViewModels.Domins
{
    interface ISettingsManager
    {
        string AddonsFolder { get; set; }

        //bool UninstallConfirmation { get; set; }
    }
}
