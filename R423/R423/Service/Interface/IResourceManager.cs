using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R423.Service.Interface
{
    public interface IResourceManager
    {
        object GetObject(string name);
        string GetString(string name);
        void ReleaseAllResources();
        int GetInt(string name);
    }
}
