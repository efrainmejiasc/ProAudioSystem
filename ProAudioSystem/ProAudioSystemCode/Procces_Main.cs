using ProAudioSystemCode.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProAudioSystemCode
{
    public class Procces_Main
    {
        public void CreateDirectoryPublic()
        {
            var directoryPublic = @"C:\Users\Public\Documents\WPAS";
            EngineApplication.CreateDirectory(directoryPublic);
        }

        public void CreateFilePublic()
        {
            var filePublic = @"C:\Users\Public\Documents\WPAS\wpas.txt";
            EngineApplication.CreateFile(filePublic);
        }

        public void GetMacAddress()
        {
            var mac = EngineApplication.GetMacAddress();
        }
    }
}
