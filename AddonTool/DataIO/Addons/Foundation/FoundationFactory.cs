using System;
using System.Collections.Generic;
using System.Text;
using DataIO.Addons.Foundation.Concrete;

namespace DataIO.Addons.Foundation
{
    class FoundationFactory
    {
        public IAddonIO CreateAddonIO()
        {
            return new AddonIO();
        }

        public IObjectBuilder CreateObjectBuilder()
        {
            return new ObjectBuilder();
        }
    }
}
