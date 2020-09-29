﻿using System;
using System.Collections.Generic;
using System.Text;
using DataIO.Addons.Models.Concrete;

namespace DataIO.Addons.Models
{
    class ModelFactory
    {
        public AddonInfo CreateAddonInfo(string title, string description, string author, Version @interface, string version, string defaultState, string[] requiredDependencies, string[] savedVariables, Uri website, string email, string category, string directoryPath)
        {
            return new AddonInfo()
            {
                Title = title,
                Description = description,
                Author = author,
                Interface = @interface,
                Version = version,
                DefaultState = defaultState,
                RequiredDependencies = requiredDependencies,
                SavedVariables = savedVariables,
                Website = website,
                Email = email,
                Category = category,
                DirectoryPath = directoryPath
            };
        }
    }
}
