using System;
using System.Collections.Generic;
using System.Text;

namespace AS2021_TPSIT_4H_BronzettiChristian_laboratorio.Models
{
    class Strumento
    {
        int _id; //id privata per ogni oggetto creato da main
        public int Id { get => _id; } //proprieta readonly per id
        static int _contaStrumenti; //campo statico per aggiornare l'id
        
        string _descrizione; //descrzione breve dello strumento
        public string Descrizione { get => _descrizione; } //proiprietà per usare la desc

        double _costo;
        public double Costo { get => _costo; } //proprietà per il costo

        int _anniGaranzia;
        public int AnniGaranzia { get => (_anniGaranzia); }

        int _annoAcquisizione;
        public DateTime AnnoAcquisizione { get => new DateTime(_annoAcquisizione, 1, 1); }
        
        public Strumento(string descrizione, double costo, int annoAcquisto, int garanzia)
        {
            _id = ContaStrumenti();
            _descrizione = descrizione.ToUpper();
            _costo = costo;
            _annoAcquisizione = annoAcquisto;
            _anniGaranzia = garanzia;
        }

        private static int ContaStrumenti() => _contaStrumenti++;

        public override string ToString()
        {
            return $"\nId strumento: {_id}\n" + $"Descrizione: {_descrizione}\n" +
                   $"Costo: {_costo}€\n" + $"Anno acquisto: {_annoAcquisizione}\n" +
                   $"Anni garanzia: {_anniGaranzia}\n";
        }
    }
}
