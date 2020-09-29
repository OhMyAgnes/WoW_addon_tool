using System.Collections.Generic;
using DataIO.Addons.Models;

namespace DataIO.Addons.Foundation
{
    interface IObjectBuilder
    {
        List<IAddonInfo> GetAddonInfo(IEnumerable<Dictionary<string, string>> metaData);
    }
}
