using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProAudioSystemCode;

namespace ProAudioSystem
{
    public partial class MainFormApp : Form
    {
        public MainFormApp()
        {
            InitializeComponent();
        }

        private void MainFormApp_Load(object sender, EventArgs e)
        {
            var process = new Procces_Main();
            process.CreateDirectoryPublic();
            process.CreateFilePublic();
            process.GetMacAddress();
        }
    }
}
