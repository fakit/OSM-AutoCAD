using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcadOsmLyb
{
    partial class Gpx_Load
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
            this.Durchsuchen = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Laden
            // 
            this.Laden.Enabled = true;
            this.Laden.Location = new System.Drawing.Point(185, 109);
            this.Laden.Name = "Laden";
            this.Laden.Size = new System.Drawing.Size(81, 23);
            this.Laden.TabIndex = 14;
            this.Laden.Text = "Laden";
            this.Laden.UseVisualStyleBackColor = true;
            this.Laden.Click += new System.EventHandler(this.Laden_Click);
            // 
            // Abbrechen
            // 
            this.Abbrechen.Location = new System.Drawing.Point(12, 109);
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
            this.textBox_DurchsuchenGpxImoprt.Size = new System.Drawing.Size(167, 20);
            this.textBox_DurchsuchenGpxImoprt.TabIndex = 12;
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
            this.label4.Size = new System.Drawing.Size(248, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Wälen Sie bitte die .gpx Datei aus der geladen wird";
            // 
            // Gpx_Load
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 155);
            this.Controls.Add(this.Laden);
            this.Controls.Add(this.Abbrechen);
            this.Controls.Add(this.textBox_DurchsuchenGpxImoprt);
            this.Controls.Add(this.Durchsuchen);
            this.Controls.Add(this.label4);
            this.Name = "Gpx_Load";
            this.Text = "GPX-Import ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.Button Laden;
        private System.Windows.Forms.Button Abbrechen;
        public System.Windows.Forms.TextBox textBox_DurchsuchenGpxImoprt;
        private System.Windows.Forms.Button Durchsuchen;
        private System.Windows.Forms.Label label4;
    }
}
