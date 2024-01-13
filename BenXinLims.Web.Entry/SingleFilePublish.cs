using System.Reflection;
using Furion;

namespace BenXinLims.Web.Entry
{
    public class SingleFilePublish : ISingleFilePublish
    {
        public Assembly[] IncludeAssemblies()
        {
            return Array.Empty<Assembly>();
        }

        public string[] IncludeAssemblyNames()
        {
            return new[]
            {
                "BenXinLims.Application",
                "BenXinLims.Core",
                "BenXinLims.Web.Core"
            };
        }
    }
}