﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dziennik_nauczyciela
{
    public class BAZADANYCH
    {
        
        public class nauczyciel
        {
            public int nauczycielID {get; set; }
            public string login { get; set; }
            public string haslo { get; set; }
            public string imie { get; set; }
            public string nazwisko { get; set; }
            public string email { get; set; }
            public string email_haslo { get; set; }
            public int zalogowany_mail { get; set; }
        }

        public class przedmiot
        {
            public int przedmiotID { get; set; }
            public int klasaNR { get; set; }
            public string nazwa { get; set; }
        }
        
        public class klasa
        {
            public int klasaID { get; set; }
            public string nazwa { get; set; }
            public string rocznik { get; set; }
            public int nauczycielNR { get; set; }
            public int gospodarzNR { get; set; }
        }

        public class uczen
        {
            public int uczenID { get; set; }
            public int klasaNR { get; set; }
            public string imie { get; set; }
            public string nazwisko { get; set; }
            public string pesel { get; set; }
            public string email { get; set; }
            public string telefon_ucznia { get; set; }
            public string telefon_rodzica { get; set; }
        }
        public class lekcja
        {
            public int lekcjaID { get; set; }
            public int klasaNR { get; set; }
            public int przedmiotNR { get; set; }
            public int dataID { get; set; }
        }
        public class uczen_na_lekcji
        {
            public int uczen_na_lekcjiID { get; set; }
            public int uczenNR { get; set; }
            public int lekcjaNR { get; set; }
            public int obecnosc { get; set; }
            public int ocena { get; set; }
        }
        public class data
        {
            public int dataID { get; set; }
            public DateTime dzien { get; set; }
            public int klasaNR { get; set; }
        }
    }
}