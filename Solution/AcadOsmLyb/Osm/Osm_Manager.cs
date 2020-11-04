using System;
using System.Collections.Generic;

using System.Windows.Forms;

namespace AcadOsmLyb
{
    public partial class Osm_Manager : Form
    {
        
        public Osm_Manager()
        {
            InitializeComponent();
            foreach (var item in AcadZeichner.priori)
            {
                checkedListBox1.Items.Add(item.Key);

            }
        }





         void Abbrechen_Click(object sender, EventArgs e)
        {
            OSM_Load.Manger.Close();
            OSM_Read.LoadAnzeige.Visible = true;
        }
        //  static bool checkt = false;
        static public double lon = 0.00;
        static public double lat = 0.00;
        static public double Umf =0.00;
        public void Vorschau_Click(object sender, EventArgs e)
        {
            if (Osm_Manager.Vorschau.Text == "Alles wählen")
            {


                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    checkedListBox1.SetItemChecked(i, true);
                   
                }
                Osm_Manager.Vorschau.Text = "Remove All";
            }
            else
            {
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    checkedListBox1.SetItemChecked(i, false);
                    
                }
                AcadZeichner.Zum_anzeigen.Clear();
                Osm_Manager.Vorschau.Text = "Alles wählen";
            }
        }

        public void Laden_Click(object sender, EventArgs e)
        {
          

            AcadZeichner.Zum_anzeigen.Clear(); 
               
                if (checkedListBox1.CheckedItems.Count> 0)

            {
                    foreach (var item in checkedListBox1.CheckedItems)
                    {

                        AcadZeichner.Zum_anzeigen.Add(item.ToString());

                    }
                    


                
            if (OSM_Read.LoadAnzeige.textBox_Longitude.Text.Length>0&& OSM_Read.LoadAnzeige.textBox_Latitude.Text.Length>0&& OSM_Read.LoadAnzeige.textBox_Umfang.Text.Length>0)
                {
                    lon = double.Parse(OSM_Read.LoadAnzeige.textBox_Longitude.Text);
                    lat = double.Parse(OSM_Read.LoadAnzeige.textBox_Latitude.Text);
                    Umf = double.Parse(OSM_Read.LoadAnzeige.textBox_Umfang.Text);
                }
               
                    OSM_Load.Manger.Close();
                    OSM_Read.LoadAnzeige.Close();

                    OSM_Read.Load_Map_OSM();
                
               
               

            }
           

            else
            {
                MessageBox.Show("Sorry aber Sie müssen mindesten eine Linienart auswählen");
            }




        }
    }
}


