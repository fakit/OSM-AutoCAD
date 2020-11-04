using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace AcadOsmLyb
{
   
        partial class Gpx_Load : Form
        {
            public static string Pfad;
            public Gpx_Load()
            {


                InitializeComponent();
            }

            private void Durchsuchen_Click(object sender, EventArgs e)
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();


                openFileDialog1.Filter = "Gpx_Files (*.gpx)|*.gpx";
                //   openFileDialog1.FilterIndex = 2;
                openFileDialog1.RestoreDirectory = true;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        if (openFileDialog1.FileName != null)
                        {
                            Pfad = openFileDialog1.FileName;
                            textBox_DurchsuchenGpxImoprt.Text = openFileDialog1.SafeFileName;
                            textBox_DurchsuchenGpxImoprt.Enabled = true;
                            textBox_DurchsuchenGpxImoprt.ReadOnly = true;
                        }
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        return;
                    }


                }
            }

            private void Abbrechen_Click(object sender, EventArgs e)
            {
                GPX_class.LoadAnzeige.Close();
            }
            public static Anzeige_Manager Manger;


            private void Laden_Click(object sender, EventArgs e)
            {

                GPX_class.LoadAnzeige.Visible = false;

                Manger = new Anzeige_Manager();
                Manger.Show();
            }

        }
    
}
