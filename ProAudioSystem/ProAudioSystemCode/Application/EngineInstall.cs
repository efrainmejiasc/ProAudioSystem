using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ProAudioSystemCode.Application
{
    public class EngineInstall
    {
        public const string  ClaveRegistroWin = "WPAS";

        public static bool ExistsClaveRegWin()
        {
            RegistryKey key = Registry.CurrentUser;
            string[] subKeys = key.GetSubKeyNames();

            for (int i = 0; i <= subKeys.Length - 1; i++)
                if (subKeys[i].ToString() == ClaveRegistroWin) return true;

            return false;
        }

        public static bool CreateClavRegister(string mac)
        {
            var resultado = false;
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"WPAS");
            key.SetValue("FECHA", DateTime.Now.ToString());
            key.SetValue("MAC", mac);
            key.Close();
            resultado = true;

            return resultado;
        }

        public static string GetClaveRegister()
        {
            var claves = new List<string>();
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"WPAS");

            if (key != null)
            {
               claves.Add(key.GetValue("FECHA").ToString());
               claves.Add(key.GetValue("MAC").ToString());
               key.Close();
            }

            return claves[1];
        }

        public static string GetMacAddress()
        {
            var networkInterface = NetworkInterface.GetAllNetworkInterfaces()
                          .FirstOrDefault(q => q.OperationalStatus == OperationalStatus.Up);

            if (networkInterface == null)
            {
                return string.Empty;
            }

            return BitConverter.ToString(networkInterface.GetPhysicalAddress().GetAddressBytes());

        }
    }
}
