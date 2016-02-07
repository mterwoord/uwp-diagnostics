using System;
using System.Threading.Tasks;
using Windows.Devices.Enumeration;

namespace UwpDiagnostics.Collectors
{
    public class DeviceInformationCollector
    {
        public static async Task Execute(BaseOutputWriter output)
        {
            using (output.StartSection("Device information"))
            {
                var xDeviceInfo = await DeviceInformation.FindAllAsync().AsTask();
                if (xDeviceInfo == null)
                {
                    output.WriteLine("No device info found.");
                }
                foreach (var xItem in xDeviceInfo)
                {
                    using (output.StartSection(xItem.Name))
                    {
                        output.WriteLine($"Id: '{xItem.Id}'");
                        output.WriteLine($"IsDefault: {xItem.IsDefault}");
                        output.WriteLine($"IsEnabled: {xItem.IsEnabled}");
                        output.WriteLine($"Kind: {xItem.Kind}");
                        if (xItem.EnclosureLocation != null)
                        {
                            using (output.StartSection("Enclosure information"))
                            {
                                output.WriteLine($"InDock: {xItem.EnclosureLocation.InDock}");
                                output.WriteLine($"InLid: {xItem.EnclosureLocation.InLid}");
                                output.WriteLine($"Panel: {xItem.EnclosureLocation.Panel}");
                            }
                        }
                        if (xItem.Pairing != null)
                        {
                            using (output.StartSection("Pairing"))
                            {
                                output.WriteLine($"CanPair: {xItem.Pairing.CanPair}");
                                output.WriteLine($"IsPaired: {xItem.Pairing.IsPaired}");
                                output.WriteLine($"ProtectionLevel: {xItem.Pairing.ProtectionLevel}");
                            }
                        }
                    }
                }
            }
        }
    }
}