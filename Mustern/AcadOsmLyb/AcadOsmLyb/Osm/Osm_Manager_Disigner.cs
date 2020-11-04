using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AcadOsmLyb
{
    partial class Osm_Manager
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
            this.label1 = new System.Windows.Forms.Label();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.Laden = new System.Windows.Forms.Button();
            this.Abbrechen = new System.Windows.Forms.Button();
            this.Vorschau = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(286, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Wälen Sie bitte alle Elemente, die Angezeigt werden sollen.\r\nElemente, die aufgru" +
    "nd der derzeitige Auflösung nicht \r\neingezeigt werden, bleiben weiterhin verstec" +
    "kt!";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(61, 60);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.ScrollAlwaysVisible = true;
            this.checkedListBox1.Size = new System.Drawing.Size(149, 94);
            this.checkedListBox1.TabIndex = 1;
            // 
            // Laden
            // 
            this.Laden.Enabled = true;
            this.Laden.Location = new System.Drawing.Point(180, 216);
            this.Laden.Name = "Laden";
            this.Laden.Size = new System.Drawing.Size(81, 23);
            this.Laden.TabIndex = 16;
            this.Laden.Text = "OK";
            this.Laden.UseVisualStyleBackColor = true;
            this.Laden.Click += new System.EventHandler(this.Laden_Click);
            // 
            // Abbrechen
            // 
            this.Abbrechen.Location = new System.Drawing.Point(12, 216);
            this.Abbrechen.Name = "Abbrechen";
            this.Abbrechen.Size = new System.Drawing.Size(81, 23);
            this.Abbrechen.TabIndex = 15;
            this.Abbrechen.Text = "Abbrechen";
            this.Abbrechen.UseVisualStyleBackColor = true;
            this.Abbrechen.Click += new System.EventHandler(this.Abbrechen_Click);
            // 
            // Vorschau
            // 
            this.Vorschau.Location = new System.Drawing.Point(95, 173);
            this.Vorschau.Name = "Vorschau";
            this.Vorschau.Size = new System.Drawing.Size(81, 23);
            this.Vorschau.TabIndex = 17;
            this.Vorschau.Text = "Alles wählen";
            this.Vorschau.UseVisualStyleBackColor = true;
            this.Vorschau.Click += new System.EventHandler(this.Vorschau_Click);
            // 
            // Anzeige_Manager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.Vorschau);
            this.Controls.Add(this.Laden);
            this.Controls.Add(this.Abbrechen);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.label1);
            this.Name = "Anzeige_Manager";
            this.Text = "Anzeige_Manager";
            this.ResumeLayout(false);
            this.PerformLayout();
            this.o = (object)Gpx_Load.Pfad;
          
        }

        #endregion

        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button Laden;
        private System.Windows.Forms.Button Abbrechen;
        private System.Windows.Forms.Button Vorschau;
        private object o;
    }
}


