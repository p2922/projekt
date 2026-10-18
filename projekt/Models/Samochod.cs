
using System.ComponentModel;

namespace projekt.Models
{

    public class Samochod : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;


        private string _marka = "";
        private string _model = "";
        private int _rocznik;
        private int _przebieg;


        public string Marka
        {
            get { return _marka; }
            set { _marka = value; OnPropertyChanged("Marka"); }
        }

        public string Model
        {
            get { return _model; }
            set { _model = value; OnPropertyChanged("Model"); }
        }

        public int Rocznik
        {
            get { return _rocznik; }
            set { _rocznik = value; OnPropertyChanged("Rocznik"); }
        }

        public int Przebieg
        {
            get { return _przebieg; }
            set { _przebieg = value; OnPropertyChanged("Przebieg"); }
        }


        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public static string Validate(string marka, string model, string rocznik, string przebieg)
        {
            if (string.IsNullOrWhiteSpace(marka))
            {
                return "Podaj markę.";
            }

            if (string.IsNullOrWhiteSpace(model))
            {
                return "Podaj model.";
            }


            if (!int.TryParse(rocznik, out int rocznikValue) || rocznikValue < 1900 || rocznikValue > 2026)
            {
                return "Rocznik musi być liczbą od 1900 do 2026.";
            }

            if (!int.TryParse(przebieg, out int przebiegValue) || przebiegValue < 0)
            {
                return "Przebieg nie może być liczbą ujemną.";
            }

            return "";
        }
    }
}