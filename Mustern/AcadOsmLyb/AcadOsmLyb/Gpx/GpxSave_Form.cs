using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using F = System.Windows.Forms;

namespace AcadOsmLyb
{
    partial class GpxSave_Form : F.Form
    {
        public GpxSave_Form()
        {
            InitializeComponent();
        }
        static public string p = "";
        private void Durchsuchen_Click(object sender, EventArgs e)
        {
            F.OpenFileDialog openFileDialog1 = new F.OpenFileDialog();


            openFileDialog1.Filter = "Gpx_Files (*.gpx)|*.gpx";
            //   openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == F.DialogResult.OK)
            {
                try
                {
                    if (openFileDialog1.FileName != null)
                    {
                        p = openFileDialog1.SafeFileName.Split('.')[0];
                        textBox_DurchsuchenGpxExport.Text = openFileDialog1.SafeFileName;
                        textBox_DurchsuchenGpxExport.Enabled = true;
                        textBox_DurchsuchenGpxExport.ReadOnly = true;
                    }
                }
                catch (System.Exception ex)
                {
                    F.MessageBox.Show(ex.Message);
                    return;
                }


            }
        }

        private void Erzeuge_Click(object sender, EventArgs e)
        {

            if (textBox_Erzeuge.Text.Length < 1) { F.MessageBox.Show("Geben Sie einen Namen!"); }
            else p = textBox_Erzeuge.Text;
        }

        private void Abbrechen_Click(object sender, EventArgs e)
        {
            GPX_class.SaveAnzeige.Close();
        }
        static public string N = "";
        static public string A = "";
        public void Speichern_Click(object sender, EventArgs e)
        {
            if (p.Length < 1) return;
            N = textBox_NameDerRoute.Text;
            A = comboBox_Art.Text;

            GPX_class._save();
        }
    }
}
