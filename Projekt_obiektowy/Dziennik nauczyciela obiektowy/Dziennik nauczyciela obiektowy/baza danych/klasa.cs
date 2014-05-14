﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Dziennik_nauczyciela_obiektowy
{
    public class klasa : bazadanych
    {
        private string haslo        = string.Empty;
        private string nazwa        = string.Empty;
        private string rocznik      = string.Empty;
        private int klasaID         = -1;
        private int nauczycielNR    = -1;
        private int gospodarzNR     = -1;

        /// <summary>
        /// tworzy obiekt klasa po ID
        /// </summary>
        public klasa(int klasaID)
        {
            this.klasaID = klasaID;
            SQLite = new cSQLite();
            SQLite.Zapytanie = "SELECT * FROM klasa WHERE klasaID = " + klasaID + ";";
            wykonajZapytanie(rodzajZapytania.pobierz);
            wylaczEdycje = false;
        }

        /// <summary>
        /// tworzy obiekt klasa
        /// </summary>
        public klasa()
        {
            SQLite = new cSQLite();
            //wylaczEdycje = false;
        }
        public int KlasaID
        {
            get
            {
                return klasaID;
            }
        }
        public string Haslo
        {
            get
            {
                return haslo;
            }
            set
            {
                haslo = value;
                if (!wylaczEdycje) aktualizuj("haslo");
            }
        }
        public string Nazwa
        {
            get
            {
                return nazwa;
            }
            set
            {
                nazwa = value;
                if (!wylaczEdycje) aktualizuj("nazwa");
            }
        }
        public int NauczycielNR
        {
            get
            {
                return nauczycielNR;   
            }
            set
            {
                nauczycielNR = value;
            }
        }
        public string Rocznik
        {
            get
            {
                return rocznik;
            }
            set
            {
                rocznik = value;
                if (!wylaczEdycje) aktualizuj("rocznik");
            }
        }
        public int GospodarzNR
        {
            get
            {
                return gospodarzNR;
            }
            set
            {
                gospodarzNR = value;
            }
        }

        /// <summary>
        /// aktualizuje dane w bazie danych
        /// </summary>
        public override void aktualizuj(params string[] elementy)
        {
            if (wylaczEdycje == true) throw new Exception("wlacz pierw edycje!");
            if ((elementy.Length == 1) && (elementy[0] == "*"))
            {
                SQLite.Zapytanie = "UPDATE klasa SET haslo = '" + haslo + "' WHERE klasaID = " + klasaID + ";"; SQLite.wykonajZapytanie(rodzajZapytania.wyslij);
                SQLite.Zapytanie = "UPDATE klasa SET nazwa = '" + nazwa + "' WHERE klasaID= " + klasaID + ";"; SQLite.wykonajZapytanie(rodzajZapytania.wyslij);
                SQLite.Zapytanie = "UPDATE klasa SET gospodarzNR = '" + gospodarzNR + "' WHERE klasaID= " + klasaID + ";"; SQLite.wykonajZapytanie(rodzajZapytania.wyslij);
                SQLite.Zapytanie = "UPDATE klasa SET rocznik = '" + rocznik + "' WHERE klasaID= " + klasaID + ";"; SQLite.wykonajZapytanie(rodzajZapytania.wyslij);
                return;
            }
            foreach (string element in elementy)
            {
                switch (element)
                {
                    case "haslo": SQLite.Zapytanie = "UPDATE klasa SET haslo = '" + haslo + "' WHERE klasaID = " + klasaID + ";"; SQLite.wykonajZapytanie(rodzajZapytania.wyslij); break;
                    case "nazwa": SQLite.Zapytanie = "UPDATE klasa SET nazwa = '" + nazwa + "' WHERE klasaID= " + klasaID + ";"; SQLite.wykonajZapytanie(rodzajZapytania.wyslij); break;
                    case "gospodarzNR": SQLite.Zapytanie = "UPDATE klasa SET gospodarzNR = '" + gospodarzNR + "' WHERE klasaID= " + klasaID + ";"; SQLite.wykonajZapytanie(rodzajZapytania.wyslij); break;
                    case "rocznik": SQLite.Zapytanie = "UPDATE klasa SET rocznik = '" + rocznik + "' WHERE klasaID= " + klasaID + ";"; SQLite.wykonajZapytanie(rodzajZapytania.wyslij); break;
                    default: throw new Exception("niepoprawny parametr do aktualizacji danych");
                }
            }
            
        }

        /// <summary>
        /// dodaje obiekt do bazy
        /// </summary>
        public override void dodajDoBazy()
        {
            SQLite.Zapytanie= "INSERT INTO klasa (nazwa, nauczycielNR, rocznik, gospodarzNR) VALUES (@nazwa, @nauczycielNR, @rocznik,@gospodarzNR);";

            SQLite.dodajParametr("nazwa", nazwa);
            SQLite.dodajParametr("nauczycielNR", nauczycielNR);
            SQLite.dodajParametr("rocznik", rocznik);
            SQLite.dodajParametr("gospodarzNR", gospodarzNR);
            wykonajZapytanie(rodzajZapytania.wyslij);
            wylaczEdycje = false;
            nauczyciel n = new nauczyciel();
        }

        /// <summary>
        /// pobiera wszystkie klasy z bazy po ID nauczyciela
        /// </summary>
        /// <param name="dgv">ID nauczyciela aktualnie zalogowanego</param>
        public static List<klasa> pobierzWszystkich(int nauczycielID)
        {
            List<klasa> listaKlas = new List<klasa>();
            cSQLite SQLite = new cSQLite();
            SQLite.Zapytanie = "SELECT * FROM klasa WHERE nauczycielNR = " + nauczycielID + ";";
            SQLite.DataReader = SQLite.command.ExecuteReader();
            while (SQLite.DataReader.Read())
            {
                int klasaID = Convert.ToInt32(SQLite.DataReader["klasaID"].ToString());
                klasa k = new klasa(klasaID);
                listaKlas.Add(k);
            }
            return listaKlas;
        }

        /// <summary>
        /// wymusza haslo do logowania
        /// </summary>
        public bool podajHaslo()
        {
            fWalidacjaHasla walidacjaHasla = new fWalidacjaHasla(haslo);
            walidacjaHasla.ShowDialog();
            if (walidacjaHasla.czyPoprawne == false)
            {
                MessageBox.Show("zle haslo!");
            }
            return walidacjaHasla.czyPoprawne;
        }

        /// <summary>
        /// usuwa obiekt z bazy danych
        /// </summary>
        public override bool usun()
        {
            SQLite.Zapytanie = "DELETE FROM klasa WHERE klasaID =" + klasaID + ";";
            SQLite.wykonajZapytanie(rodzajZapytania.wyslij);
            return true;
        }

        /// <summary>
        /// wykonuje zapytanie na obiekcie
        /// </summary>
        protected override void wykonajZapytanie(rodzajZapytania rodzaj)
        {
            if (rodzaj == rodzajZapytania.wyslij)
            {
                SQLite.wykonajZapytanie(rodzaj);
            }
            else
            {
                SQLite.otworzPolaczenie();
                SQLite.DataReader = SQLite.command.ExecuteReader();
                while (SQLite.DataReader.Read())
                {
                    klasaID = Convert.ToInt32(SQLite.DataReader["klasaID"].ToString());
                    NauczycielNR = Convert.ToInt32(SQLite.DataReader["nauczycielNR"].ToString());
                    gospodarzNR = Convert.ToInt32(SQLite.DataReader["gospodarzNR"].ToString());
                    nazwa = SQLite.DataReader["nazwa"].ToString();
                    rocznik = SQLite.DataReader["rocznik"].ToString();
                }
                SQLite.zamknijPolaczenie();
            }
        }

        /// <summary>
        /// po kliknieciu
        /// </summary>
        public void zaloguj(Form f)
        {
            if (podajHaslo() == true)
            {
                
            }
        }
    }
}
