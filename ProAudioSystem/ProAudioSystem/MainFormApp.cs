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
            var mensaje = process.ComprobarInstalacion();
            if (mensaje != string.Empty)
            {
                MessageBox.Show(mensaje, "INFORMACION DEL SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }


        private void Baby_Click(object sender, EventArgs e)
        {

        }

        private void Wallet_Click(object sender, EventArgs e)
        {

        }

        private void Keys_Click(object sender, EventArgs e)
        {

        }

        private void Car_Click(object sender, EventArgs e)
        {

        }

        private void C9munication_Click(object sender, EventArgs e)
        {

        }

        private void Warning_Click(object sender, EventArgs e)
        {

        }

        private void Alarm_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
