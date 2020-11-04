using System;

using System.Windows.Forms;

namespace AcadOsmLyb
{
   

   
    partial class OSM_Load : Form
    {

        public static string Pfad="";
        public OSM_Load()
        {


            InitializeComponent();
        }

        private void Durchsuchen_Click(object sender, EventArgs e)
        {
            OSM_Load OSM = new OSM_Load();
            OSM.textBox_Longitude.Enabled = false;

            OSM.textBox_Latitude.Enabled = false;
            OSM.textBox_Umfang.Enabled = false;

            OpenFileDialog openFileDialog1 = new OpenFileDialog();


            openFileDialog1.Filter = "Osm File (*.osm)|*.osm|Osm_Pbf File (*.pbf*)|*.pbf*";
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
            OSM_Read.LoadAnzeige.Close();
        }
        public static Osm_Manager Manger;


        private void Laden_Click(object sender, EventArgs e)
        {
            OSM_Read.LoadAnzeige.Visible = false;

            Manger = new Osm_Manager();
            Manger.Show();
        }

    }
}
