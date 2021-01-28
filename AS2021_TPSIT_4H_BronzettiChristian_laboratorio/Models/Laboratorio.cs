using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace AS2021_TPSIT_4H_BronzettiChristian_laboratorio.Models
{
    class Laboratorio
    {
        List<Strumento> _strumenti = new List<Strumento>();
        public Laboratorio() { }
        public void AggiungiNuovoStrumento(string descrizione, double costo, int annoAcquisto, int garanzia)
            => _strumenti.Add(new Strumento(descrizione, costo, annoAcquisto, garanzia));

        public bool EliminaStrumento(int id)
        {
            //scorre la list e all'indice specificato cancella i dati
            foreach (Strumento s in _strumenti)
                if (s.Id == id)
                {
                    _strumenti.RemoveAt(id);
                    SalvaDati(); //salva dati
                    return true;
                }

            return false;
        }

        public Strumento RicercaPerId(int id)
        {
            //gira finchè non trova l'id uguale
            foreach (Strumento s in _strumenti)
                if (s.Id == id)
                    return s;

            //se non lo trova genera un msg 
            throw new Exception($"Il paziente {id} non è stato trovato");
        }

        public Strumento RicercaPerDescrizione(string descrizione)
        {
            descrizione = descrizione.ToUpper();
            //gira finchè non trova una descrizione uguale
            foreach (Strumento s in _strumenti)
                if (s.Descrizione.Equals(descrizione))
                    return s;

            //se non lo trova genera un msg 
            throw new Exception($"Il paziente con la descrizione richiesta ({descrizione}) non è stato trovato");
        }

        public double CalcolaValoreStrumentiPeriodo(int anno1, int anno2)
        {
            double totale = 0;

            if (anno2 > DateTime.Today.Year)
                anno2 = DateTime.Today.Year;

            //Deve cercare nella list ogni oggeto nel range indicato e poi sommare tutto
            foreach (Strumento s in _strumenti)
                if (s.AnnoAcquisizione.Year >= anno1 && s.AnnoAcquisizione.Year <= anno2)
                    totale += s.Costo;

            return totale;
        }

        public string TrovaStrumentiInGaranzia()
        {
            StringBuilder sb = new StringBuilder();

            //controllo se gli anni garanzia + quelli dell'acquisizioni sono minori o uguali all'anno corrente, 
            //se si aggiungo allo sb altrimenti no
            foreach (Strumento s in _strumenti)
                if ((s.AnnoAcquisizione.Year + s.AnniGaranzia) >= DateTime.Today.Year)
                    sb.Append(s.ToString());

            return sb.ToString();
        }

        //il file viene salvato nel bin
        public bool SalvaDati()
        {
            StringBuilder sb = new StringBuilder(); //uso uno stringbuilder in modo da costruirmi una stringq 
            sb.Append($"\nData di aggionamento: {DateTime.Now}\n");
            //aggiunge ogni stumento della list al file
            foreach (Strumento s in _strumenti)
                sb.Append(s.ToString());

            // prova ad aggingere la stringa creata dentro al file, altrimenti genera eccezione
            try
            {
                //scrive all'interno del file la stringa creata
                File.AppendAllText(@"ListaStrumenti.txt", sb.ToString());
                return true;
            }
            catch
            {
                throw new Exception("Si è verificato un errore nel salvataggio del file");
            }

        }

        public bool RipristinoDati()
        {
            //prova a scrivere dentro al file, altrimenti genera eccezione
            try
            {
                using (StreamWriter sw = new StreamWriter(@"ListaStrumenti.txt"))
                    sw.Write("");

                return true;
            }
            catch
            {

                throw new Exception("Si è verificato un errore nel ripristino del file");
            }
        }

    }
}