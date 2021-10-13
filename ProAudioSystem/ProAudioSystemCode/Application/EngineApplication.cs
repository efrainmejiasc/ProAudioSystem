using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ProAudioSystemCode.Application
{
    public class EngineApplication
    {

        #region FILE
        public static bool CreateDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                return false;
            }

            return true;
        }

        public static void CreateFile(string path)
        {
            string vIngresado = string.Empty;
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(path, true))
            {
                for (int i = 0; i <= 2; i++)
                {
                    bool Estatus = true;
                    vIngresado = "ID" + Environment.NewLine;
                    vIngresado = vIngresado + "Descripcion" + Environment.NewLine;
                    vIngresado = vIngresado + "3000" + Environment.NewLine;
                    vIngresado = vIngresado + DateTime.Now.ToString() + Environment.NewLine;
                    vIngresado = vIngresado + "AABCDF·$%5875674" + Environment.NewLine;
                    vIngresado = vIngresado + Estatus.ToString() + Environment.NewLine + Environment.NewLine;
                    file.WriteLine(vIngresado);
                    vIngresado = string.Empty;
                }

            }
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

        public void ReadWriteTxt(string pathArchivo)
        {
            FileAttributes atributosAnteriores = File.GetAttributes(pathArchivo);
            File.SetAttributes(pathArchivo, atributosAnteriores & ~FileAttributes.ReadOnly);
        }

        public void OnlyReadTxt(string pathArchivo)
        {
            FileAttributes atributosAnteriores = File.GetAttributes(pathArchivo);
            File.SetAttributes(pathArchivo, atributosAnteriores | FileAttributes.ReadOnly);
        }

        public bool StatusOnlyReadTxt(string pathArchivo)
        {
            bool r = false;
            FileAttributes atributos = File.GetAttributes(pathArchivo);
            if ((atributos & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
            {
                r = true;
            }
            return r;
        }

        #endregion

        public static string MD5Hash(string text)
        {
            System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();

            //compute hash from the bytes of text  
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

            //get hash result after compute it  
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //change it into 2 hexadecimal digits  
                //for each byte  
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }

    }
}
