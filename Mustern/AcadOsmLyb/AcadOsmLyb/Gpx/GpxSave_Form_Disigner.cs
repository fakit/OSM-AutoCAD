using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcadOsmLyb
{
    partial class GpxSave_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBox_Art = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_NameDerRoute = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Speichern = new System.Windows.Forms.Button();
            this.Abbrechen = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_DurchsuchenGpxExport = new System.Windows.Forms.TextBox();
            this.textBox_Erzeuge = new System.Windows.Forms.TextBox();
            this.Durchsuchen = new System.Windows.Forms.Button();
            this.Erzeuge = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBox_Art
            // 
            this.comboBox_Art.FormattingEnabled = true;
            this.comboBox_Art.Location = new System.Drawing.Point(118, 12);
            this.comboBox_Art.Name = "comboBox_Art";
            this.comboBox_Art.Size = new System.Drawing.Size(148, 21);
            this.comboBox_Art.TabIndex = 0;
            foreach (var item in AcadZeichner.priori)
            {
                this.comboBox_Art.Items.Add(item.Key);
            }
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Art der Route :";
            // 
            // textBox_NameDerRoute
            // 
            this.textBox_NameDerRoute.Location = new System.Drawing.Point(12, 73);
            this.textBox_NameDerRoute.Multiline = true;
            this.textBox_NameDerRoute.Name = "textBox_NameDerRoute";
            this.textBox_NameDerRoute.Size = new System.Drawing.Size(260, 20);
            this.textBox_NameDerRoute.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Geben sie bitte einen Namen für die Rouute";
            // 
            // Speichern
            // 

            this.Speichern.Location = new System.Drawing.Point(185, 226);
            this.Speichern.Name = "Speichern";
            this.Speichern.Size = new System.Drawing.Size(81, 23);
            this.Speichern.TabIndex = 5;
            this.Speichern.Text = "Speichern";
            this.Speichern.UseVisualStyleBackColor = true;
            this.Speichern.Click += new System.EventHandler(Speichern_Click);
            // 
            // Abbrechen
            // 
            this.Abbrechen.Location = new System.Drawing.Point(12, 226);
            this.Abbrechen.Name = "Abbrechen";
            this.Abbrechen.Size = new System.Drawing.Size(81, 23);
            this.Abbrechen.TabIndex = 6;
            this.Abbrechen.Text = "Abbrechen";
            this.Abbrechen.UseVisualStyleBackColor = true;
            this.Abbrechen.Click += new System.EventHandler(this.Abbrechen_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Geben sie bitte Ihre .gpx File";
            // 
            // textBox_DurchsuchenGpxExport
            // 
            this.textBox_DurchsuchenGpxExport.Enabled = false;
            this.textBox_DurchsuchenGpxExport.Location = new System.Drawing.Point(91, 132);
            this.textBox_DurchsuchenGpxExport.Multiline = true;
            this.textBox_DurchsuchenGpxExport.Name = "textBox_DurchsuchenGpxExport";
            this.textBox_DurchsuchenGpxExport.Size = new System.Drawing.Size(181, 20);
            this.textBox_DurchsuchenGpxExport.TabIndex = 17;
            // 
            // textBox_Erzeuge
            // 
            this.textBox_Erzeuge.Location = new System.Drawing.Point(102, 173);
            this.textBox_Erzeuge.Multiline = true;
            this.textBox_Erzeuge.Name = "textBox_Erzeuge";
            this.textBox_Erzeuge.Size = new System.Drawing.Size(167, 20);
            this.textBox_Erzeuge.TabIndex = 3;
            // 
            // Durchsuchen
            // 
            this.Durchsuchen.Location = new System.Drawing.Point(4, 129);
            this.Durchsuchen.Name = "Durchsuchen";
            this.Durchsuchen.Size = new System.Drawing.Size(81, 23);
            this.Durchsuchen.TabIndex = 2;
            this.Durchsuchen.Text = "Durchsuchen";
            this.Durchsuchen.UseVisualStyleBackColor = true;
            this.Durchsuchen.Click += new System.EventHandler(this.Durchsuchen_Click);
            // 
            // Erzeuge
            // 
            this.Erzeuge.Location = new System.Drawing.Point(4, 170);
            this.Erzeuge.Name = "Erzeuge";
            this.Erzeuge.Size = new System.Drawing.Size(81, 23);
            this.Erzeuge.TabIndex = 4;
            this.Erzeuge.Text = "Erzeuge";
            this.Erzeuge.UseVisualStyleBackColor = true;
            this.Erzeuge.Click += new System.EventHandler(this.Erzeuge_Click);
            // 
            // GpxSave_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.Erzeuge);
            this.Controls.Add(this.textBox_Erzeuge);
            this.Controls.Add(this.Durchsuchen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_DurchsuchenGpxExport);
            this.Controls.Add(this.Speichern);
            this.Controls.Add(this.Abbrechen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_NameDerRoute);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox_Art);
            this.Name = "GpxSave_Form";
            this.Text = "GPX-Export";
            this.ResumeLayout(false);
            this.PerformLayout();


        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_Art;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_NameDerRoute;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Speichern;
        private System.Windows.Forms.Button Abbrechen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_DurchsuchenGpxExport;
        private System.Windows.Forms.TextBox textBox_Erzeuge;
        private System.Windows.Forms.Button Durchsuchen;
        private System.Windows.Forms.Button Erzeuge;


    }
}
