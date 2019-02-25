using System;
using System.IO;
using System.Reflection;
using NServiceBus;

namespace SampleLicenseNuget
{
    public static class LicenseProvider
    {
        public static void ApplyLicense(this EndpointConfiguration configuration)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "SampleLicenseNuget.License.xml";

            using (var stream = assembly.GetManifestResourceStream(resourceName))
            using (var reader = new StreamReader(stream))
            {
                configuration.License(reader.ReadToEnd());
            }
        }
    }
}
