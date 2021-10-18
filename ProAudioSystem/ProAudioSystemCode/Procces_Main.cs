using ProAudioSystemCode.Application;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProAudioSystemCode
{
    public class Procces_Main
    {
        public string ComprobarInstalacion()
        {
            var result = string.Empty;
            var noPermitido = "Existen conflictos en la configuracion de Pro Audio System, puede ser que este intentando usar la aplicacion sin los permisos nesesarios";
            var resultado = false;

            try
            {
                var existeClave = EngineInstall.ExistsClaveRegWin();
                var path = Directory.GetCurrentDirectory();
                var existeCarpeta = EngineFile.ExistsDirectory(path + @"\WPAS");

                if (!existeClave && !existeCarpeta)//nueva instalacion
                {
                    var mac = EngineInstall.GetMacAddress();
                    resultado = EngineInstall.CreateClavRegister(mac) ;
                    resultado = EngineFile.CreateDirectory(path + @"\WPAS");
                    resultado = EngineFile.CreateAndWriteFile(path + @"\WPAS\wpas.txt", mac);

                }
                else if (!existeClave && existeCarpeta) // no permitido
                {
                    result = noPermitido;
                }
                else if (existeClave && !existeCarpeta) // crear carpeta
                {
                    var mac = EngineInstall.GetMacAddress();
                    var cveMac = EngineInstall.GetClaveRegister();
                    if (mac == cveMac)
                    {
                        resultado = EngineFile.CreateDirectory(path + @"\WPAS");
                        resultado = EngineFile.CreateAndWriteFile(path + @"\WPAS\wpas.txt", mac);
                        result = string.Empty;
                    }
                    else
                        result = noPermitido;
                }
                else if (existeClave && existeCarpeta) // comparacion
                {
                    var mac = EngineInstall.GetMacAddress();
                    var macFile = EngineFile.ReadFile(path + @"\WPAS\wpas.txt");
                    result = (mac == macFile) ? string.Empty : noPermitido;
                }
            }
            catch(Exception ex)
            {
                result = "Error: " + ex.Message;
            }

            return result;
        }


        public void  EscribirLog(string suceso, string observacion)
        {
            var path = Directory.GetCurrentDirectory() + @"\WPAS";
            EngineFile.CreateDirectory(path);
            EngineFile.CreateAndWriteFile(path + @"\logwpas.txt", suceso, observacion);
        }

        public void AbrirAchivoLog()
        {
            var path = Directory.GetCurrentDirectory() + @"\WPAS\logwpas.txt";
            EngineFile.OpenFileLog(path);
        }

    }
}
