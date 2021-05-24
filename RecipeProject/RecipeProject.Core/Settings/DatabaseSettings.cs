using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeProject.Core.Settings
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string RecipeCollectionName { get; set; }
        public string CategoryCollectionName { get; set; }
        public string AppUserCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
