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
using System.Media;
using System.IO;
using WMPLib;


namespace ProAudioSystem
{
    public partial class MainFormApp : Form
    {
        private string exceptionApp = string.Empty;
        private WindowsMediaPlayer player;
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

            LogApp("Inicio de la aplicacion", "No aplica");

            player = new WindowsMediaPlayer();
        }



        private void Baby_Click(object sender, EventArgs e)
        {
            try
            {
                player.controls.stop();
                player.URL = Directory.GetCurrentDirectory() + @"\Audios\NiñoExtraviado.mp3";
                player.controls.play();
                LogApp("Mensaje", "Niño extraviado");
            }
            catch (Exception ex)
            {
                LogApp("ERROR", ex.Message);
            }
  
        }

        private void Wallet_Click(object sender, EventArgs e)
        {
            try
            {
                player.controls.stop();
                player.URL = Directory.GetCurrentDirectory() + @"\Audios\BilleteraExtraviada.mp3";
                player.controls.play();
                LogApp("Mensaje", "Billetera extraviada");
            }
            catch(Exception ex)
            {
                LogApp("ERROR", ex.Message);
            }

        }

        private void Keys_Click(object sender, EventArgs e)
        {
            try
            {
                player.controls.stop();
                player.URL = Directory.GetCurrentDirectory() + @"\Audios\ManojoDeLlaves.mp3";
                player.controls.play();
                LogApp("Mensaje", "Llaves extraviadas");
            }
            catch(Exception ex)
            {
                LogApp("ERROR", ex.Message);
            }
        }

        private void Car_Click(object sender, EventArgs e)
        {
            try
            {
                player.controls.stop();
                player.URL = Directory.GetCurrentDirectory() + @"\Audios\FavorLlegarHastaElVehiculo.mp3";
                player.controls.play();
                LogApp("Mensaje", "Llamado de atencion vehiculo");
            }
            catch (Exception ex)
            {
                LogApp("ERROR", ex.Message);
            }
        }

        private void C9munication_Click(object sender, EventArgs e)
        {
            try
            {
                player.controls.stop();
                player.URL = Directory.GetCurrentDirectory() + @"";
                player.controls.play();
                LogApp("Mensaje", "Comunicacion interna");
            }
            catch (Exception ex)
            {
                LogApp("ERROR", ex.Message);
            }
        }

        private void Warning_Click(object sender, EventArgs e)
        {
            try
            {
                player.controls.stop();
                player.URL = Directory.GetCurrentDirectory() + @"";
                player.controls.play();
                LogApp("Mensaje", "Advertencia");
            }
            catch (Exception ex)
            {
                LogApp("ERROR", ex.Message);
            }
        }

        private void Alarm_Click(object sender, EventArgs e)
        {
            try
            {
                player.controls.stop();
                player.URL = Directory.GetCurrentDirectory() + @"";
                player.controls.play();
                LogApp("Mensaje", "Alarma");
            }
            catch (Exception ex)
            {
                LogApp("ERROR", ex.Message);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            LogApp("Salir de la aplicacion", "No aplica");

            Application.Exit();
        }

        private void LogApp(string suceso, string observacion)
        {
            var process = new Procces_Main();
            process.EscribirLog(suceso, observacion);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var process = new Procces_Main();
                process.AbrirAchivoLog();
            }
            catch (Exception ex)
            {
                LogApp("ERROR", ex.Message);
            }
        }
    }
}
