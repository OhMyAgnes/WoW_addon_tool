using System;
using System.Collections.Generic;
using System.Text;
using DataIO.Addons.Foundation.Concrete;

namespace DataIO.Addons.Foundation
{
    class FoundationFactory
    {
        public AddonIO CreateAddonIO()
        {
            return new AddonIO();
        }

        public ObjectBuilder CreateObjectBuilder()
        {
            return new ObjectBuilder();
        }
    }
}
