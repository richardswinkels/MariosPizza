using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;

namespace WpfMarioPizza
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Declareer variabelen
        double[] _prijzen = { 10.00, 8.00, 9.00, 10.50, 10.00, 11.00, 11.00, 10.50, 10.00, 12.00, 14.00, 8.00, 9.50, 12.50, 7.00, 11.00 };
        double _prijsGerecht;
        double _totaalbedrag;
        double _totaalOverzicht;
        string _formaat;
        int _aantal;


        public MainWindow()
        {
            InitializeComponent();
        }

        private void cmbGerecht_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Als Pizza's geselecteerd zijn
            if (cmbGerecht.SelectedIndex >= 0 && cmbGerecht.SelectedIndex <= 10)
            {
                //Maak textblock formaat en radiobuttons zichtbaar
                tbFormaat.Visibility = Visibility.Visible;
                spRadiobuttons.Visibility = Visibility.Visible;

                //Als Radiobutton 25cm is aangevinkt
                if (rbt25cm.IsChecked == true)
                {
                    //Ken de waarde "25cm" toe aan _formaat
                    _formaat = "25cm";
                    //Zet de prijs van het geselecteerde gerecht keer 0.7 (70%) in de variabele _prijsGerecht
                    _prijsGerecht = _prijzen[cmbGerecht.SelectedIndex] * 0.7;
                    //Laat de prijs zien in de textblock
                    tbPrijsGerecht.Text = "Prijs: € " + _prijsGerecht.ToString("0.00");
                }
                else if (rbt35cm.IsChecked == true)
                {
                    //Ken de waarde "35cm" toe aan formaat
                    _formaat = "35cm";
                    //Zet de prijs van het geselecteerde gerecht in de variabele _prijsGerecht
                    _prijsGerecht = _prijzen[cmbGerecht.SelectedIndex];
                    //Laat de prijs zien in de textblock
                    tbPrijsGerecht.Text = "Prijs: € " + _prijsGerecht.ToString("0.00");
                }
                else
                { 
                    //Maak _formaat leeg
                    _formaat = "";
                    //Maak waarde van _prijsGerecht 0
                    _prijsGerecht = 0;
                    //Laat de prijs zien in de textblock
                    tbPrijsGerecht.Text = "Prijs: € " + _prijsGerecht.ToString("0.00");
                }

            }
            //Anders als Pasta geselecteerd wordt
            else if (cmbGerecht.SelectedIndex >= 11 && cmbGerecht.SelectedIndex <= 16)
            {
                //Maak textblock formaat en radiobuttons onzichtbaar
                tbFormaat.Visibility = Visibility.Hidden;
                spRadiobuttons.Visibility = Visibility.Hidden;
                //Maak _formaat leeg
                _formaat = "";
                //Zet de prijs van het geselecteerde gerecht in de variabele _prijsGerecht
                _prijsGerecht = _prijzen[cmbGerecht.SelectedIndex];
                //Laat de prijs zien in de textblock
                tbPrijsGerecht.Text = "Prijs: € " + _prijsGerecht.ToString("0.00");
            }
        }

        private void rbt25cm_Click(object sender, RoutedEventArgs e)
        {
            //Ken de waarde "25cm" toe aan _formaat
            _formaat = "25cm";
            //Zet de prijs van het geselecteerde gerecht keer 0.7 (70%) in de variabele _prijsGerecht
            _prijsGerecht = _prijzen[cmbGerecht.SelectedIndex] * 0.7;
            //Laat de prijs zien in de textblock
            tbPrijsGerecht.Text = "Prijs: € " + _prijsGerecht.ToString("0.00");
        }

        private void rbt35cm_Click(object sender, RoutedEventArgs e)
        {
            //Ken de waarde "35cm" toe aan formaat
            _formaat = "35cm";
            //Zet de prijs van het geselecteerde gerecht in de variabele _prijsGerecht
            _prijsGerecht = _prijzen[cmbGerecht.SelectedIndex];
            //Laat de prijs zien in de textblock
            tbPrijsGerecht.Text = "Prijs: € " + _prijsGerecht.ToString("0.00");
        }

        private void txbAantal_TextChanged(object sender, TextChangedEventArgs e)
        {
                //Foutafhandeling
                try
                {
                    //Zet string uit textbox om in Int en zet het in variabele _aantal
                    _aantal = int.Parse(txbAantal.Text);
                    //Doe het aantal keer de prijs van het gerecht
                    _totaalbedrag = _aantal * _prijsGerecht;
                    //Maak de tekstkleur zwart
                    tbTotaalbedrag.Foreground = Brushes.Black;
                    //Laat prijs zien in de textblock
                    tbTotaalbedrag.Text = "€ " + _totaalbedrag.ToString("0.00");
                }
                catch (Exception Fout)
                {
                    //Maak de tekstkleur rood
                    tbTotaalbedrag.Foreground = Brushes.Red;
                    //Laat fout zien in de textblock
                    tbTotaalbedrag.Text = "*** Fout ***";
                }
        }

        private void btToevoegen_Click(object sender, RoutedEventArgs e)
        {
            //Als geen gerecht is geselecteerd
            if (cmbGerecht.SelectedIndex == -1)
            {
                //Laat melding zien
                MessageBox.Show("U heeft geen geldige menukeuze gemaakt.", "Melding", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            //Als de eerste 11 items (Pizza's) uit de ComboBox geselecteerd worden en er is geen formaat geselecteerd
            if (cmbGerecht.SelectedIndex >= 0 && cmbGerecht.SelectedIndex <= 10 && _formaat == "")
            {
                //Laat melding zien
                MessageBox.Show("U heeft geen formaat gekozen.", "Melding", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            //Als aantal kleiner of gelijk aan 0 is, de TextBox leeg is of een fout geeft
            if (_aantal <= 0 || txbAantal.Text == "" || tbTotaalbedrag.Text == "*** Fout ***")
            {
                //Laat melding zien
                MessageBox.Show("U heeft geen geldig aantal ingevuld.", "Melding", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            //Als er een erecht geselecteerd is en formaat niet nul is
            else if ( 
                     (cmbGerecht.SelectedIndex >= 0 && cmbGerecht.SelectedIndex <= 10 && _formaat != "" && _aantal > 0 && txbAantal.Text != "" && tbTotaalbedrag.Text != "*** Fout ***") ||
                     (cmbGerecht.SelectedIndex >= 11 && cmbGerecht.SelectedIndex <= 16 && txbAantal.Text != "" && tbTotaalbedrag.Text != "*** Fout ***") 
                     )
            {
                //Declareer variabele gerecht
                string gerecht;
                //Haal geselecteerde waarde op uit de combobox
                ComboBoxItem cbiGerecht = cmbGerecht.SelectedItem as ComboBoxItem;
                gerecht = cbiGerecht.Content.ToString();

                //Als _formaat niet leeg is
                if (!string.IsNullOrEmpty(_formaat))
                {
                    //Voeg pizza toe aan listbox
                    lbOverzicht.Items.Add(gerecht + " - " + "€" + _totaalbedrag.ToString("0.00") + " - " + _formaat + " - " + _aantal + "x");
                }
                else
                {   //Voeg pasta toe aan listbox
                    lbOverzicht.Items.Add(gerecht + " - " + "€" + _totaalbedrag.ToString("0.00") + " - " + _aantal + "x");
                }

                //Verhoog totaalOverzicht met totaalbedrag
                _totaalOverzicht += _totaalbedrag;
                //Laat totaalprijs zien in textblock
                tbTotaal.Text = "Totaal: € " + _totaalOverzicht.ToString("0.00");
            }
        }

        private void tbPrijsGerecht_LayoutUpdated(object sender, EventArgs e)
        {
            //Als textbox niet leeg is
            if (!string.IsNullOrEmpty(txbAantal.Text))
            {
                //Foutafhandeling
                try
                {
                    //Zet string uit textbox om in Int en zet het in variabele _aantal
                    _aantal = int.Parse(txbAantal.Text);
                    //Doe het aantal keer de prijs van het gerecht
                    _totaalbedrag = _aantal * _prijsGerecht;
                    //Maak de tekstkleur zwart
                    tbTotaalbedrag.Foreground = Brushes.Black;
                    //Laat prijs zien in de textblock
                    tbTotaalbedrag.Text = "€ " + _totaalbedrag.ToString("0.00");
                }
                catch (Exception Fout)
                {
                    //Maak de tekstkleur rood
                    tbTotaalbedrag.Foreground = Brushes.Red;
                    //Laat fout zien in de textblock
                    tbTotaalbedrag.Text = "*** Fout ***";
                }
            }
        }

        private void lbOverzicht_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //Als geselecteerd item niet leeg is
            if (lbOverzicht.SelectedItem != null)
            {
                //Laat melding zien en zet het resultaat in een variabele
                MessageBoxResult verwijderitem = MessageBox.Show("Weet u zeker dat u het geselecteerde item van uw bestellijst wilt verwijderen?", "Melding", MessageBoxButton.YesNo, MessageBoxImage.Question);
                //Als waarde van verwijderitem messageboxresult.yes is
                if (verwijderitem == MessageBoxResult.Yes) {
                    //Haal waarde op van het geselecteerde item
                    string item = lbOverzicht.SelectedItem.ToString();
                    //Haal het bedrag op uit het item
                    string bedrag = item.Split('€', '-')[2];

                    //Zet string bedrag om in een double en tel het van de _totaalOverzicht af
                    _totaalOverzicht -= double.Parse(bedrag);

                    //Laat totaalprijs zien in textblock
                    tbTotaal.Text = "Totaal: € " + _totaalOverzicht.ToString("0.00");
                    //Vewijder geselecteerde item uit de listbox
                    lbOverzicht.Items.RemoveAt(lbOverzicht.SelectedIndex);
                }
            }
        }

        private void BtnBetalen_Click(object sender, RoutedEventArgs e)
        {
            //Als textbox naam leeg is
            if (string.IsNullOrEmpty(txbNaam.Text))
            {
                //Laat melding zien
                MessageBox.Show("U heeft geen naam ingevuld. Een naam moet uit een voornaam, spatie en achternaam bestaan en alleen letters bevatten.", "Melding", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            //Als naam niet voldoet aan de eisen
            else if (!Regex.IsMatch(txbNaam.Text, "[A-Za-z]+\\s{1}[A-Za-z]+"))
            {
                //Laat melding zien
                MessageBox.Show(txbNaam.Text + " is geen geldige invoer voor naam. Een naam moet uit een voornaam, spatie en achternaam bestaan en alleen letters bevatten.", "Melding", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            //Als textbox adres leeg is
            if (string.IsNullOrEmpty(txbAdres.Text))
            {
                //Laat melding zien
                MessageBox.Show("U heeft geen adres ingevuld. Een adres moet een straatnaam, spatie en huisnummer bevatten.", "Melding", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            //Als adres niet voldoet aan de eisen
            else if (!Regex.IsMatch(txbAdres.Text, "[A-Za-z]+\\s{1}[0-9]{2}"))
            {
                //Laat melding zien
                MessageBox.Show(txbAdres.Text + " is geen geldige invoer voor adres. Een adres moet een straatnaam, spatie en huisnummer bevatten.", "Melding", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            //Als textbox postcode leeg is
            if (string.IsNullOrEmpty(txbPostcode.Text))
            {
                //Laat melding zien
                MessageBox.Show("U heeft geen postcode ingevuld. Een postcode moet uit 4 cijfers, 1 spatie en 2 letters bestaan, en mag niet met 0 beginnen.", "Melding", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            //Als textbox postcode niet voldoet aan eisen
            else if (!Regex.IsMatch(txbPostcode.Text, "[1-9]{1}[0-9]{3}\\s{1}[A-Z]+"))
            {
                //Laat melding zien
                MessageBox.Show(txbPostcode.Text + " is geen geldige invoer voor postcode. Uw postcode moet uit 4 cijfers, 1 spatie en 2 hoofdletters bestaan, en mag niet met 0 beginnen.", "Melding", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            //Als textbox plaats leeg is
            if (string.IsNullOrEmpty(txbPlaats.Text))
            {
                //Laat melding zien
                MessageBox.Show("U heeft geen plaatsnaam ingevuld. Een plaatsnaam mag alleen letters bevatten.", "Melding", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            //Als plaats niet voldoet aan eisen 
            else if (!Regex.IsMatch(txbPlaats.Text, "[A-Za-z]+"))
            {
                //Laat melding zien
                MessageBox.Show(txbPlaats.Text + " is geen geldige invoer voor plaats. Een plaatsnaam mag alleen letters bevatten.", "Melding", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            //Als er geen items zijn toegevoegd aan de listbox
            if (lbOverzicht.Items.Count == 0)
            {
                //Laat melding zien
                MessageBox.Show("U heeft geen gerechten aan het overzicht toegevoegd. Voeg gerechten toe aan het overzicht toe om te kunnen betalen.", "Melding", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            //Als lbItems niet gelijk is aan nul
            else if (lbOverzicht.Items.Count != 0)
                //Als alle klantgegevens correct zijn ingevuld
                if (        
                         !string.IsNullOrEmpty(txbNaam.Text) &&
                         !string.IsNullOrEmpty(txbAdres.Text) &&
                         !string.IsNullOrEmpty(txbPostcode.Text) &&
                         !string.IsNullOrEmpty(txbPlaats.Text) &&
                         Regex.IsMatch(txbNaam.Text, "[A-Za-z]+\\s{1}[A-Za-z]+") &&
                         Regex.IsMatch(txbAdres.Text, "[A-Za-z]+\\s*[0-9]{2}") &&
                         Regex.IsMatch(txbPostcode.Text, "[1-9}{1}[0-9]{3}\\s{1}[A-Z]+") &&
                         Regex.IsMatch(txbPlaats.Text, "[A-Za-z]+")
                    )
                {
                    //Laat melding zien
                    MessageBox.Show("Bedankt voor uw bestelling!\nHet totaalbedrag is \u20AC " + _totaalOverzicht.ToString("0.00") + ".", "Melding", MessageBoxButton.OK, MessageBoxImage.Information);

                    //Reset de invoervelden
                    txbNaam.Text = "";
                    txbAdres.Text = "";
                    txbPostcode.Text = "";
                    txbPlaats.Text = "";
                    cmbGerecht.SelectedIndex = -1;
                    tbFormaat.Visibility = Visibility.Hidden;
                    spRadiobuttons.Visibility = Visibility.Hidden;
                    rbt25cm.IsChecked = false;
                    rbt25cm.IsChecked = false;
                    txbAantal.Text = "";

                    //Reset de variabelen
                    _prijsGerecht = 0;
                    _totaalbedrag = 0;
                    _totaalOverzicht = 0;
                    _formaat = "";
                    _aantal = 0;

                    //Reset de textboxen en listbox
                    tbPrijsGerecht.Text = "Prijs: € " + _prijsGerecht.ToString("0.00");
                    tbTotaalbedrag.Foreground = Brushes.Black;
                    tbTotaalbedrag.Text = "€ " + _totaalbedrag.ToString("0.00");
                    tbTotaal.Text = "Totaal: € " + _totaalOverzicht.ToString("0.00");
                    lbOverzicht.Items.Clear();
                }
            }
    }
    }

 
   

       


