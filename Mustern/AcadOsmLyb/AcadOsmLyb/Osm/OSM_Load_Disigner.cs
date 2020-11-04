using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcadOsmLyb
{
    partial class OSM_Load
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
        internal void InitializeComponent()
        {
            this.Laden = new System.Windows.Forms.Button();
            this.Abbrechen = new System.Windows.Forms.Button();
            this.textBox_DurchsuchenGpxImoprt = new System.Windows.Forms.TextBox();
            this.textBox_Longitude = new System.Windows.Forms.TextBox();
            this.textBox_Latitude = new System.Windows.Forms.TextBox();
            this.textBox_Umfang = new System.Windows.Forms.TextBox();
            this.Durchsuchen = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Laden
            // 
            this.Laden.Location = new System.Drawing.Point(407, 219);
            this.Laden.Name = "Laden";
            this.Laden.Size = new System.Drawing.Size(81, 23);
            this.Laden.TabIndex = 14;
            this.Laden.Text = "Laden";
            this.Laden.UseVisualStyleBackColor = true;
            this.Laden.Click += new System.EventHandler(this.Laden_Click);
            // 
            // Abbrechen
            // 
            this.Abbrechen.Location = new System.Drawing.Point(12, 219);
            this.Abbrechen.Name = "Abbrechen";
            this.Abbrechen.Size = new System.Drawing.Size(81, 23);
            this.Abbrechen.TabIndex = 13;
            this.Abbrechen.Text = "Abbrechen";
            this.Abbrechen.UseVisualStyleBackColor = true;
            this.Abbrechen.Click += new System.EventHandler(this.Abbrechen_Click);
            // 
            // textBox_DurchsuchenGpxImoprt
            // 
            this.textBox_DurchsuchenGpxImoprt.Enabled = false;
            this.textBox_DurchsuchenGpxImoprt.Location = new System.Drawing.Point(105, 55);
            this.textBox_DurchsuchenGpxImoprt.Multiline = true;
            this.textBox_DurchsuchenGpxImoprt.Name = "textBox_DurchsuchenGpxImoprt";
            this.textBox_DurchsuchenGpxImoprt.Size = new System.Drawing.Size(263, 20);
            this.textBox_DurchsuchenGpxImoprt.TabIndex = 12;
            // 
            // textBox_Longitude
            // 
            this.textBox_Longitude.Location = new System.Drawing.Point(105, 109);
            this.textBox_Longitude.Multiline = true;
            this.textBox_Longitude.Name = "textBox_Longitude";
            this.textBox_Longitude.Size = new System.Drawing.Size(136, 20);
            this.textBox_Longitude.TabIndex = 1;
            // 
            // textBox_Latitude
            // 
            this.textBox_Latitude.Location = new System.Drawing.Point(105, 153);
            this.textBox_Latitude.Multiline = true;
            this.textBox_Latitude.Name = "textBox_Latitude";
            this.textBox_Latitude.Size = new System.Drawing.Size(136, 20);
            this.textBox_Latitude.TabIndex = 2;
            // 
            // textBox_Umfang
            // 
            this.textBox_Umfang.Location = new System.Drawing.Point(389, 127);
            this.textBox_Umfang.Multiline = true;
            this.textBox_Umfang.Name = "textBox_Umfang";
            this.textBox_Umfang.Size = new System.Drawing.Size(60, 20);
            this.textBox_Umfang.TabIndex = 3;
            // 
            // Durchsuchen
            // 
            this.Durchsuchen.Location = new System.Drawing.Point(15, 53);
            this.Durchsuchen.Name = "Durchsuchen";
            this.Durchsuchen.Size = new System.Drawing.Size(81, 23);
            this.Durchsuchen.TabIndex = 11;
            this.Durchsuchen.Text = "Durchsuchen";
            this.Durchsuchen.UseVisualStyleBackColor = true;
            this.Durchsuchen.Click += new System.EventHandler(this.Durchsuchen_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(250, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Wälen Sie bitte die .osm Datei aus der geladen wird";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Longitude ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "lattitude";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(294, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Radius in Km";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(152, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "oder direkt aus Openstreetmap";
            // 
            // OSM_Load
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 250);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Laden);
            this.Controls.Add(this.Abbrechen);
            this.Controls.Add(this.textBox_DurchsuchenGpxImoprt);
            this.Controls.Add(this.Durchsuchen);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_Longitude);
            this.Controls.Add(this.textBox_Latitude);
            this.Controls.Add(this.textBox_Umfang);
            this.Name = "OSM_Load";
            this.Text = "OSM-Show ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.Button Laden;
        private System.Windows.Forms.Button Abbrechen;
        public System.Windows.Forms.TextBox textBox_DurchsuchenGpxImoprt;
        public System.Windows.Forms.TextBox textBox_Longitude;
        public System.Windows.Forms.TextBox textBox_Latitude;
        public System.Windows.Forms.TextBox textBox_Umfang;
        private System.Windows.Forms.Button Durchsuchen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;

        
    }
}
