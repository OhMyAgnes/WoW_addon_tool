﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataIO.Addons.Foundation.Concrete;
using DataIO.Addons.Models.Concrete;
using DataIO.Addons.Foundation;
using DataIO.General;
using DataIO.General.Concrete;

namespace DataIO.Addons.Controller.Concrete
{
    public class AddonController
    {
        private FoundationFactory foundationFactory;
        private ObjectBuilder objectBuilder;
        private AddonIO addonIO;
        private FileSystem fileSystem;

        public AddonController()
        {
            foundationFactory = new FoundationFactory();
            objectBuilder = foundationFactory.CreateObjectBuilder();
            addonIO = foundationFactory.CreateAddonIO();
            fileSystem = new GeneralFactory().CreateFileSystem();
        }

        public string GetAddonsFolderPath(string rootFolder)
        {
            string addonsPath = $"{rootFolder}\\Interface\\Addons";

            if (fileSystem.DirectoryIsValid(addonsPath) && fileSystem.DirectoryExists(addonsPath))
                return addonsPath;
            else
                return null;
        }

        public List<AddonInfo> GetAddons(string folderPath)
        {
            try
            {
                var metadata = addonIO.GetMetaData(folderPath);
                return objectBuilder.GetAddonInfo(metadata);
            }
            catch (Exception ex)
            {
                throw new Exception($"The provided folder: {folderPath} is invalid", ex);
            }
        }

        public void RemoveAddon(AddonInfo addon)
        {
            fileSystem.DeleteDirectory(addon.DirectoryPath);
        }

        public void RemoveAddons(IEnumerable<AddonInfo> addons)
        {
            foreach (AddonInfo addon in addons)
            {
                fileSystem.DeleteDirectory(addon.DirectoryPath);
            }
        }

        public async Task InstallAddon(string addonPath, string folderPath)
        {
            string tempAddonPath = folderPath + @"\newAddon";
            bool correctlyInstalled = false;

            if (fileSystem.DirectoryExists(tempAddonPath))
                fileSystem.DeleteDirectory(tempAddonPath);


            //if the addonPath is a folder, copy it to the temp directory.
            //if it is not a folder it should be a zip archive. Try to extract it.
            try
            {
                if (fileSystem.DirectoryExists(addonPath))
                {
                    fileSystem.CopyDirectory(addonPath, tempAddonPath);
                }
                else
                {
                    await fileSystem.ExtractZipToPath(addonPath, tempAddonPath);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"The provided file or folder {addonPath} is not a valid addon", ex);
            }


            try
            {
                correctlyInstalled = await addonIO.InstallAddon(folderPath, tempAddonPath);
            }
            catch (Exception ex)
            {
                throw new Exception("The addon is allready installed", ex);
            }
            finally
            {
                fileSystem.DeleteDirectory(tempAddonPath);

                if (!correctlyInstalled)
                    throw new Exception("The provided file or folder is not a valid addon");
            }

        }
    }
}
