﻿namespace Dziennik_nauczyciela
{
    partial class fWidokPrzedmiotu
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
            this.label3 = new System.Windows.Forms.Label();
            this.t_edytujNazwaPrzedmiotu = new System.Windows.Forms.TextBox();
            this.b_zapiszZmiany = new System.Windows.Forms.Button();
            this.b_dodajPrzedmiot = new System.Windows.Forms.Button();
            this.t_nazwaPrzedmiotu = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tc_widok.SuspendLayout();
            this.tp_dodaj.SuspendLayout();
            this.tp_edytuj.SuspendLayout();
            this.SuspendLayout();
            // 
            // tc_widok
            // 
            this.tc_widok.Location = new System.Drawing.Point(184, 0);
            this.tc_widok.Size = new System.Drawing.Size(236, 229);
            // 
            // tp_dodaj
            // 
            this.tp_dodaj.Controls.Add(this.b_dodajPrzedmiot);
            this.tp_dodaj.Controls.Add(this.label1);
            this.tp_dodaj.Controls.Add(this.t_nazwaPrzedmiotu);
            this.tp_dodaj.Size = new System.Drawing.Size(228, 203);
            // 
            // tp_edytuj
            // 
            this.tp_edytuj.Controls.Add(this.b_zapiszZmiany);
            this.tp_edytuj.Controls.Add(this.t_edytujNazwaPrzedmiotu);
            this.tp_edytuj.Controls.Add(this.label3);
            this.tp_edytuj.Size = new System.Drawing.Size(228, 277);
            // 
            // tp_usun
            // 
            this.tp_usun.Size = new System.Drawing.Size(228, 277);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Nazwa przedmiotu:";
            // 
            // t_edytujNazwaPrzedmiotu
            // 
            this.t_edytujNazwaPrzedmiotu.Location = new System.Drawing.Point(9, 19);
            this.t_edytujNazwaPrzedmiotu.Name = "t_edytujNazwaPrzedmiotu";
            this.t_edytujNazwaPrzedmiotu.Size = new System.Drawing.Size(167, 20);
            this.t_edytujNazwaPrzedmiotu.TabIndex = 2;
            this.t_edytujNazwaPrzedmiotu.TextChanged += new System.EventHandler(this.t_edytujNazwaPrzedmiotu_TextChanged);
            // 
            // b_zapiszZmiany
            // 
            this.b_zapiszZmiany.Location = new System.Drawing.Point(118, 45);
            this.b_zapiszZmiany.Name = "b_zapiszZmiany";
            this.b_zapiszZmiany.Size = new System.Drawing.Size(58, 23);
            this.b_zapiszZmiany.TabIndex = 3;
            this.b_zapiszZmiany.Text = "Zapisz";
            this.b_zapiszZmiany.UseVisualStyleBackColor = true;
            this.b_zapiszZmiany.Click += new System.EventHandler(this.b_zapiszZmiany_Click);
            // 
            // b_dodajPrzedmiot
            // 
            this.b_dodajPrzedmiot.Location = new System.Drawing.Point(94, 45);
            this.b_dodajPrzedmiot.Name = "b_dodajPrzedmiot";
            this.b_dodajPrzedmiot.Size = new System.Drawing.Size(82, 23);
            this.b_dodajPrzedmiot.TabIndex = 2;
            this.b_dodajPrzedmiot.Text = "Dodaj";
            this.b_dodajPrzedmiot.UseVisualStyleBackColor = true;
            this.b_dodajPrzedmiot.Click += new System.EventHandler(this.b_dodajPrzedmiot_Click);
            // 
            // t_nazwaPrzedmiotu
            // 
            this.t_nazwaPrzedmiotu.Location = new System.Drawing.Point(9, 19);
            this.t_nazwaPrzedmiotu.Name = "t_nazwaPrzedmiotu";
            this.t_nazwaPrzedmiotu.Size = new System.Drawing.Size(167, 20);
            this.t_nazwaPrzedmiotu.TabIndex = 0;
            this.t_nazwaPrzedmiotu.TextChanged += new System.EventHandler(this.t_nazwaPrzedmiotu_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nazwa przedmiotu:";
            // 
            // fWidokPrzedmiotu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 229);
            this.Name = "fWidokPrzedmiotu";
            this.Text = "fWidokPrzedmiotu";
            this.Load += new System.EventHandler(this.fWidokPrzedmiotu_Load);
            this.tc_widok.ResumeLayout(false);
            this.tp_dodaj.ResumeLayout(false);
            this.tp_dodaj.PerformLayout();
            this.tp_edytuj.ResumeLayout(false);
            this.tp_edytuj.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox t_edytujNazwaPrzedmiotu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button b_zapiszZmiany;
        private System.Windows.Forms.Button b_dodajPrzedmiot;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox t_nazwaPrzedmiotu;
    }
}