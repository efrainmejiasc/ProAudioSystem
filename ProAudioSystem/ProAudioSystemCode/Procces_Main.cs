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
                    result = "Existen conflictos en la configuracion, puede ser que este intentando usar la aplicacion sin los permisos nesesarios";
                }
                else if (existeClave && !existeCarpeta) // crear carpeta
                {
                    var mac = EngineInstall.GetMacAddress();
                    var cveMac = EngineInstall.GetClaveRegister();
                    if (mac == cveMac)
                    {
                        resultado = EngineFile.CreateDirectory(path + @"\WPAS");
                        resultado = EngineFile.CreateAndWriteFile(path + @"\WPAS\wpas.txt", mac);
                    }
                    else
                        result = "Existen conflictos en la configuracion, puede ser que este intentando usar la aplicacion sin los permisos nesesarios";
                }
                else if (existeClave && existeCarpeta) // comparacion
                {
                    var mac = EngineInstall.GetMacAddress();
                    result = (mac == EngineFile.ReadFile(path + @"\WPAS\wpas.txt")) ? string.Empty : "Existen conflictos en la configuracion, puede ser que este intentando usar la aplicacion sin los permisos nesesarios";
                }
            }
            catch(Exception ex)
            {
                result = "Error: " + ex.Message;
            }

            return result;
        }
       
    }
}
