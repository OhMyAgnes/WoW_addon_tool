using System;
using System.Collections.Generic;
using System.Text;
using DataIO.Addons.Controller.Concrete;
namespace DataIO.Addons.Controller
{
    public class AddonsControllerFactory
    {
        public AddonController CreateAddonController()
        {
            return new AddonController();
        }
    }
}
