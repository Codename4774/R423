using R423.Service.Implementation;
using R423.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R423.Service
{
    public static class ServiceProvider
    {
        private static ICoordsConverter _coordsConverter;
        private static IDrawManager _drawManager;
        private static IResourceManager _resourceManager;

        public static ICoordsConverter CoordsConverter
        {
            get
            {
                return _coordsConverter;
            }
        }
        public static IDrawManager DrawManager
        {
            get
            {
                return _drawManager;
            }
        }

        public static IResourceManager ResourceManager
        {
            get
            {
                return _resourceManager;
            }
        }


        public static void Initialize()
        {
            _resourceManager = new ResourceManager("R423.Resources", typeof(Resources).Assembly);
            _coordsConverter = new CoordsConverter(ResourceManager);
            _coordsConverter.SetNewCompression(_resourceManager.GetInt("xDisplayed"), _resourceManager.GetInt("yDisplayed"));
            _drawManager = new DrawManager(_coordsConverter, _resourceManager);
        }
    }
}
