using System;
using AS2021_TPSIT_4H_BronzettiChristian_laboratorio.Models;

namespace AS2021_TPSIT_4H_BronzettiChristian_laboratorio
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Programma che gestisce gli strumenti di un laboratorio, scritto da Bronzetti Christian, 4 H");

            Laboratorio lab = new Laboratorio();

            lab.AggiungiNuovoStrumento("Penna", 1.02, 2017, 0);
            lab.AggiungiNuovoStrumento("Matita", 0.60, 2019, 0);
            lab.AggiungiNuovoStrumento("Sedia", 13, 2014, 3);
            lab.AggiungiNuovoStrumento("LIM", 250.99, 2020, 3);

            try
            {
                if (lab.SalvaDati()) 
                {
                    Console.WriteLine("Dati salvati, controllare il file txt");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Ricerco per descrizione");
            try
            {
                Console.WriteLine(lab.RicercaPerDescrizione("Penna"));
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
           
            

            Console.WriteLine("Ricerco per id");
            try
            {
                Console.WriteLine(lab.RicercaPerId(2));
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            

            double valorePeriodo = lab.CalcolaValoreStrumentiPeriodo(2014, 2017);
            Console.WriteLine($"Calcolo il prezzo tra i 2 anni richiesti...\nIl valore è {valorePeriodo}");

            Console.WriteLine($"Gli strumenti in garanzia sono: {lab.TrovaStrumentiInGaranzia()}");

            try
            {
                if (lab.EliminaStrumento(1))
                    Console.WriteLine("Lo strumento con l'id richiesto è stato eliminato... Verrà aggiornato il file");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            //try
            //{
            //    if (lab.RipristinoDati())
            //        Console.WriteLine("dati ripristinati");

            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}
        }
    }
}
