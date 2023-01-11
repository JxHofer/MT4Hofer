using Microsoft.EntityFrameworkCore;
using MT4Hofer.models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MT4Hofer
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Theoriefrage: Ein Array nimmt nur einen Datentyp an - es kann zb ein Array für ints sein, dann
             nimmt es keine Strings. Ein Tupel kann Strings und ints und alle Datentypen mischen. Außerdem nimmt
            ein Tupel maximal 7 items. Bei einem Array kann ich einfach bestimmen wie groß es sein soll. */

            string path = @"D:\VisualStudio2017\Meins\MT4Hofer\4a.txt";

            List<Schueler> alteListe =Import(path);
            using (MeinContext context = new MeinContext())
            {
                RemoveAllKlassenbucheintraegeOlderThan(2);
                int klassenid = GetSchulklasse("4a").Id;
                GetSchulklasse("1a");


                AddToDatabase(alteListe, klassenid);

                int aktasId = context.Schueler.FirstOrDefault(x => x.Nachname == "Aktas" && x.Vorname == "Franz").Id;
                AddKlassenbucheintrag("hallo", aktasId);
                AddKlassenbucheintrag("noch ein Eintrag", aktasId);
                AddKlassenbucheintrag("so brav", aktasId);
                AddKlassenbucheintrag("also echt", aktasId);


                //Leider geht bei mir Franz Aktas in die Klasse 1, nicht 4a, deshalb hab ich es doppelt:
                //einmal mit 4a und einmal mit Klasse 1 - mit Klasse 1 wird er gefunden und ausgegeben.

                //List<Schueler> gefaehrdeteSchueler = GetGefaerdeteSchueler("4a");

                //foreach (var item in gefaehrdeteSchueler)
                //{
                //    Console.WriteLine("Vorname: " + item.Vorname + "Nachname" + item.Nachname);
                //}

                List<Schueler> gefaehrdeteSchueler = GetGefaerdeteSchueler("Klasse 1");

                foreach (var item in gefaehrdeteSchueler)
                {
                    Console.WriteLine("Vorname: " + item.Vorname + " Nachname " + item.Nachname);
                }


            }







        }
        
        public static List<Schueler> Import(string path)
        {
            string[] zeilen = File.ReadAllLines(path);
            List<Schueler> meineSchuelerListe = new List<Schueler>();

                foreach (var item in zeilen)
                {
                    Schueler meinSchueler = new Schueler();
                    string[] Namen = item.Split(" ");
                    meinSchueler.Vorname = Namen[0];
                    meinSchueler.Nachname = Namen[1];
                   
                  
                    meineSchuelerListe.Add(meinSchueler);
                

                }
                return meineSchuelerListe;
            }
           
        

        public static void RemoveAllKlassenbucheintraegeOlderThan(int days)
        {
            using (MeinContext context = new MeinContext())
            {
                var AlteZeilen = context.Klassenbucheintraege
                    .Where(x => x.Datum < DateTime.Now.AddDays(-days))
                    .ToList();



                foreach (var zeile in AlteZeilen)
                {
                    context.Klassenbucheintraege.Remove(zeile);
                }

                
                    context.SaveChanges();
                
            }
        }

        public static Schulklasse GetSchulklasse(string classname)
        {
            using (MeinContext context = new MeinContext())
            {
                
               
                Schulklasse Schulklassenauswahl = context.Schulklassen.FirstOrDefault(x => x.Namen == classname);
                if (Schulklassenauswahl == null)
                {
                    Schulklasse neueSchulklasse = new Schulklasse { Namen = classname };
                    context.Schulklassen.Add(neueSchulklasse);
                    context.SaveChanges();
                    return neueSchulklasse;

                }
                else
                {
                    return Schulklassenauswahl;
                }

            }
        }
        public static List<Schueler> AddToDatabase(List<Schueler> schuelers, int classId)
        {
            using (MeinContext context = new MeinContext())
            {
               
                foreach (var item in schuelers)
                {
                    item.SchulklasseId = classId;
                   
                    context.Schueler.Add(item);
                    
                    context.SaveChanges();

                }

                List<Schueler> meineneueSchuelerListe = new List<Schueler>();
                meineneueSchuelerListe = context.Schueler.ToList();
                return meineneueSchuelerListe;
            }
        }

        public static void AddKlassenbucheintrag(string text, int schuelerId)
        {
            using (MeinContext context = new MeinContext())
            {
                Schueler meinSchueler = context.Schueler.FirstOrDefault(x => x.Id == schuelerId);
                Klassenbucheintrag meinEintrag = new Klassenbucheintrag();
                meinEintrag.Schueler = meinSchueler;
                meinEintrag.SchuelerId = schuelerId;
                meinEintrag.Text = text;
                context.Klassenbucheintraege.Add(meinEintrag);
                context.SaveChanges();

            }
            
        }

        public static List<Schueler> GetGefaerdeteSchueler(string classname)
        {
            using (MeinContext context = new MeinContext())
            {
                List<Schueler> gefaehrdeteSchueler = new List<Schueler>();

                gefaehrdeteSchueler = context.Schueler.Include(x=>x.Schulklasse)
                    .Where(x=>x.Schulklasse.Namen==classname&& x.KlassenbucheintragListe.Count >= 3)
                   .ToList();
                    


                return gefaehrdeteSchueler;
            }
           
        }
    }
}
