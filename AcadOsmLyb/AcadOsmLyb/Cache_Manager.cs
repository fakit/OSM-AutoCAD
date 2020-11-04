using System;
using System.IO;
using  System.Windows.Forms;
namespace AcadOsmLyb
{
   
        public partial class Cache_Manager : Form
        {
            public Cache_Manager()
            {
                InitializeComponent();
            }

            private void Abbrechen_Click(object sender, EventArgs e)
            {
                AcadZeichner.Cache.Close();
            }

            private void Loeschen_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                for (int i = 0; i < AcadZeichner.BereitsDa.Count; i++)
                {

               
                    if (AcadZeichner.BereitsDa[i].StartsWith("f")) AcadZeichner.BereitsDa.Remove(AcadZeichner.BereitsDa[i]);
                   
                }
              
            }
            if (checkBox2.Checked)
            {
                if (File.Exists("geloescht.txt"))
                    File.WriteAllLines("geloescht.txt", new string[] { });
                else File.Create("geloescht.txt");
                AcadZeichner.Cache.Close();
            }
                
            }
        }
    
}
