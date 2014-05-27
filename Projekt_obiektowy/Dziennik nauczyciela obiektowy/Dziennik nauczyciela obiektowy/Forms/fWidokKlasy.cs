﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Dziennik_nauczyciela_obiektowy.Forms
{
    public partial class fWidokKlasy : Form
    {
        enum ladowanie
        {
            dziennik,
            wykresy,
            indywidualne,
            powiadomienia,
            wiadomosci
        }
        private bool[] ladowaneTabele = new bool[Convert.ToInt32(ladowanie.wiadomosci) + 1];
        klasa zalogowanaKlasa = null;
        ListaDat listaDat = null;
        ListaPrzedmiotow listaPrzedmiotow = null;
        ListaUczniow listaUczniow_indywidualne = null;
        DuzaLista dl_indywidualne_obecnosci = null;
        DuzaLista dl_indywidualne_oceny = null;
        //ListaUczniow listaUczniow_
        public fWidokKlasy(klasa zalogowanaKlasa)
        {
            this.zalogowanaKlasa = zalogowanaKlasa;
            InitializeComponent();
            tworzPasekInformacji();
            b_pokazDaneDziennik.Enabled = ((cb_typ.ValueMember.Length != 0) && (cb_przedmiotDziennik.ValueMember.Length != 0));

            cb_typ.SelectedIndexChanged += new EventHandler(obslugaPokazDaneDziennik);
            cb_przedmiotDziennik.SelectedIndexChanged += new EventHandler(obslugaPokazDaneDziennik);
            //MessageBox.Show(cb_typ.ValueMember);
        }

        private void fWidokKlasy_Load(object sender, EventArgs e)
        {
           listaDat = new ListaDat(mc_kalendarz, zalogowanaKlasa.KlasaID);
           Dictionary<string,ComboBox> zbiorListWyboru = new Dictionary<string,ComboBox>();
           zbiorListWyboru.Add("cb_przedmiotDziennik", cb_przedmiotDziennik);
           zbiorListWyboru.Add("cb_przedmiotWykresy", cb_przedmiotWykresy);
           listaPrzedmiotow = new ListaPrzedmiotow(this,null,zalogowanaKlasa.KlasaID,zbiorListWyboru);
           tworzDGVDziennik();
        }
        private void tworzDGVDziennik()
        {
            for (int i = 0; i < listaDat.zbior.Count; i++)
            {
                DataGridViewColumn newCol = new DataGridViewColumn();
                DataGridViewCell cell = new DataGridViewTextBoxCell();
                newCol.CellTemplate = cell;

                newCol.HeaderText = listaDat.zbior[i].Dzien.ToShortDateString();
                newCol.Name = listaDat.zbior[i].Dzien.ToShortDateString();
                newCol.Visible = true;
                dgv_dziennik.Columns.Add(newCol);
            }
        }

        private void obslugaPokazDaneDziennik(object sender, EventArgs e)
        {
            b_pokazDaneDziennik.Enabled = ((cb_typ.SelectedIndex >= 0) && (cb_typ.SelectedIndex >= 0));
            /*
            if (b_pokazDaneDziennik.Enabled == true)
            {
             //pobranie tych wartosci z zaznaczonego elementu
                MessageBox.Show(cb_przedmiotDziennik.Text + " " + cb_przedmiotDziennik.SelectedValue);
            }
             */
        }

        private void tworzPasekInformacji()
        {
            nauczyciel n = new nauczyciel(zalogowanaKlasa.NauczycielNR);
            if (zalogowanaKlasa.GospodarzNR > 0)
            {
                uczen u = new uczen(zalogowanaKlasa.GospodarzNR);
                l_gospodarz.Text = u.Imie + " " + u.Nazwisko;
            }
            else
            {
                l_gospodarz.Text = "nie wybrany";
            }
            l_nazwaKlasy.Text = zalogowanaKlasa.Nazwa;
            l_prowadzacy.Text = n.Imie + " " + n.Nazwisko;
        }

       


        private void klasaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fEdycjaKlasy edycjaKlas = new fEdycjaKlasy(this.zalogowanaKlasa);
            edycjaKlas.ShowDialog();
            edycjaKlas.Hide();
            edycjaKlas.Close();
        }

        private void uczeńToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fWidokUcznia widokUcznia = new fWidokUcznia(zalogowanaKlasa.KlasaID);
            widokUcznia.ShowDialog();
            //listaUczniow_indywidualne.odswiezDGV();
        }

        private void przedmiotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fWidokPrzedmiotu widokPrzedmiotu = new fWidokPrzedmiotu(zalogowanaKlasa,listaPrzedmiotow);
            widokPrzedmiotu.ShowDialog();
        }

        private void b_dodajDzien_Click(object sender, EventArgs e)
        {
            data d = new data
            {
                KlasaNR = this.zalogowanaKlasa.KlasaID,
                Dzien = listaDat.ZaznaczonyElement
            };
            try
            {
                //TODO 1 dodac event na odswiezenie duzej listy
                d.dodajDoBazy();
                listaDat.aktualizujPogrubione();
            }
            catch
            {
                MessageBox.Show("już istnieje taka data w tej klasie");
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabelaGlowna.SelectedTab == Indywidualne && (ladowaneTabele[(int)ladowanie.indywidualne] == false))
            {
                listaUczniow_indywidualne = new ListaUczniow(this, dgv_listaUczniow_indywidualne, zalogowanaKlasa.KlasaID);
                ladowaneTabele[(int)ladowanie.indywidualne] = true;
                dl_indywidualne_obecnosci = new DuzaLista(this, listaUczniow_indywidualne, listaPrzedmiotow, listaDat, dgv_listaObecnosci_indywidualne,EtypDanych.obecnosc);
                dl_indywidualne_oceny     = new DuzaLista(this, listaUczniow_indywidualne, listaPrzedmiotow, listaDat, dgv_listaOcen_indywidualne, EtypDanych.ocena);
            }
        }

        private void b_pokazDaneDziennik_Click(object sender, EventArgs e)
        {
            
        }
    }
}
