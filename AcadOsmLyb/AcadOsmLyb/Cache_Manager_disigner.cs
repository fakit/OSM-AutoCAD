using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcadOsmLyb
{
    partial class Cache_Manager
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
            this.Loeschen = new System.Windows.Forms.Button();
            this.Abbrechen = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hiermit werden alle Ihre Änderungen gelöscht";
            // 
            // Loeschen
            // 
            this.Loeschen.Location = new System.Drawing.Point(64, 101);
            this.Loeschen.Name = "Loeschen";
            this.Loeschen.Size = new System.Drawing.Size(81, 23);
            this.Loeschen.TabIndex = 18;
            this.Loeschen.Text = "Löschen";
            this.Loeschen.UseVisualStyleBackColor = true;
            this.Loeschen.Click += new System.EventHandler(this.Loeschen_Click);
            // 
            // Abbrechen
            // 
            this.Abbrechen.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Abbrechen.Location = new System.Drawing.Point(185, 101);
            this.Abbrechen.Name = "Abbrechen";
            this.Abbrechen.Size = new System.Drawing.Size(91, 23);
            this.Abbrechen.TabIndex = 17;
            this.Abbrechen.Text = "Abbrechen";
            this.Abbrechen.UseVisualStyleBackColor = false;
            this.Abbrechen.Click += new System.EventHandler(this.Abbrechen_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(34, 40);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(251, 17);
            this.checkBox1.TabIndex = 19;
            this.checkBox1.Text = "gezeichnete Way von der Gpx file reinitialisieren";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(34, 63);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(194, 17);
            this.checkBox2.TabIndex = 20;
            this.checkBox2.Text = "gelöschte Element wieder freigeben";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // Cache_Manager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 127);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.Loeschen);
            this.Controls.Add(this.Abbrechen);
            this.Controls.Add(this.label1);
            this.Name = "Cache_Manager";
            this.Text = "Cache_Manager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Loeschen;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Button Abbrechen;
    }
}
