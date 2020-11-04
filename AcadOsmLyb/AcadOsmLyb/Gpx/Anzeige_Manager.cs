using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace AcadOsmLyb
{
    public partial class Anzeige_Manager : Form
    {
        public static List<string> Zum_anzeigen = new List<string>();
        public Anzeige_Manager()
        {
            InitializeComponent();
        }





        private void Abbrechen_Click(object sender, EventArgs e)
        {
            Gpx_Load.Manger.Close();
            GPX_class.LoadAnzeige.Visible = true;
        }
      
        private void Vorschau_Click(object sender, EventArgs e)
        {
            if (Anzeige_Manager.Vorschau.Text == "Alles wählen")
            {


                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    checkedListBox1.SetItemChecked(i, true);
                }
                Anzeige_Manager.Vorschau.Text = "Remove All";
            }
            else
            {
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    checkedListBox1.SetItemChecked(i, false);
                }
                Anzeige_Manager.Vorschau.Text = "Alles wählen";
            }



        }

        public void Laden_Click(object sender, EventArgs e)
        {

            AcadZeichner.Zum_anzeigen.Clear();

            if (checkedListBox1.CheckedItems.Count > 0)

            {
                foreach (var item in checkedListBox1.CheckedItems)
                {

                    AcadZeichner.Zum_anzeigen.Add(item.ToString());

                }

                GPX_class._ReadGPX((object)Gpx_Load.Pfad, e);
                Gpx_Load.Manger.Close();
                GPX_class.LoadAnzeige.Close();
            }

            else
            {
                MessageBox.Show("Sorry aber Sie müssen mindesten eine Linienart auswählen");
            }


        }
    }
}
