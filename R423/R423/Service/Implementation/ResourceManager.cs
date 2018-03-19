using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Resources;
using R423.Service.Interface;
using System.Reflection;

namespace R423.Service.Implementation
{
    public class ResourceManager : System.Resources.ResourceManager, IResourceManager
    {
        public ResourceManager(Type resourceSource) : base(resourceSource)
        {
        }
        public ResourceManager(string baseName, Assembly assembly) : base(baseName, assembly)
        {
        }
        public ResourceManager(string baseName, Assembly assembly, Type usingResourceSet)
        {
        }

        public int GetInt(string name)
        {
            return Convert.ToInt32(GetString(name));
        }
    }
}
