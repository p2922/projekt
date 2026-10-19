using System.Windows;
using projekt.Models;

namespace projekt.Views
{
    
    public partial class SamochodEditWindow : Window
    {
        
        private readonly Samochod _samochod;

        
        public SamochodEditWindow(Samochod samochod)
        {
            InitializeComponent();
            _samochod = samochod;

            
            if (samochod.Marka != "")
            {
                MarkaTextBox.Text = samochod.Marka;
                ModelTextBox.Text = samochod.Model;
                RocznikTextBox.Text = samochod.Rocznik.ToString();
                PrzebiegTextBox.Text = samochod.Przebieg.ToString();
            }
        }

        
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            
            string error = Samochod.Validate(MarkaTextBox.Text, ModelTextBox.Text,
                RocznikTextBox.Text, PrzebiegTextBox.Text);

            
            if (error != "")
            {
                ErrorTextBlock.Text = error;
                return;
            }

            
            _samochod.Marka = MarkaTextBox.Text.Trim();
            _samochod.Model = ModelTextBox.Text.Trim();
            _samochod.Rocznik = int.Parse(RocznikTextBox.Text);
            _samochod.Przebieg = int.Parse(PrzebiegTextBox.Text);

            
            DialogResult = true;
        }

        
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            
            DialogResult = false;
        }
    }
}