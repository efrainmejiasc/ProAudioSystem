using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProAudioSystemCode.Application
{
    public class EngineFile
    {
        #region FILE


        public static bool ExistsDirectory(string path)
        {
            if (!Directory.Exists(path))
                return false;

            return true;
        }

        public static bool CreateDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                return false;
            }

            return true;
        }

        public static bool CreateAndWriteFile(string path, string cadena)
        {
            var resultado = false;
            cadena = cadena + Environment.NewLine + "RUZSQUlORU1JTElPTUVKSUFTQ0FTVElMTE8=";

            if (!File.Exists(path))
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(path, true))
                {
                    file.WriteLine(cadena);
                    resultado = true;
                }
            }
            return resultado;
        }

        public static string ReadFile(string path)
        {
            var lines = new List<string>();
            var line = string.Empty;

            using (var objReader = new StreamReader(path))
            {
                while (line != null)
                {
                    line = objReader.ReadLine();
                    if (line != null)
                        lines.Add(line);
                }

                objReader.Close();
            }

            return lines[0];
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
            var r = false;
            FileAttributes atributos = File.GetAttributes(pathArchivo);
            if ((atributos & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                r = true;
            return r;
        }


        #endregion
    }
}
