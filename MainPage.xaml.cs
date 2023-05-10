using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Devices.Gpio;
using System.Net.NetworkInformation;
using Windows.UI.Xaml.Media.Imaging;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WinIOT_PIC32MX_RS232
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        //Variables
        double ExchangeRate;                         //Taux d'échange 
        double Result;                               //Résultat        
        BitmapImage bitmapImage = new BitmapImage(); //nouvelle image

        //Constructeur de l'image
        public MainPage()
        {
            this.InitializeComponent();

            //Selectionner par défaut le radio bouton "radioButtonCHF"
            radioButtonCHF.IsChecked = true;

            //Ecrire la valeur 0 par défaut dans le textbox
            textBoxInput.Text = "0";

            //Mettre par défaut l'image de la nati
            bitmapImage.UriSource = new Uri(image.BaseUri, "ms-appx:///Assets/CH.png"); //Assignation du fichier à l'image
            image.Source = bitmapImage;                                                 //Mettre à jour l'image
        }

        //radio bouton "radioButtonCH" selectionné
        private void radioButtonCHF_Checked(object sender, RoutedEventArgs e)
        {
            ExchangeRate = 1;                                                           //Taux d'échange à 1
            bitmapImage.UriSource = new Uri(image.BaseUri, "ms-appx:///Assets/CH.png"); //Assignation du fichier à l'image
            image.Source = bitmapImage;                                                 //Mettre à jour l'image
        }

        //radio bouton "radioButtonUSD" selectionné
        private void radioButtonUSD_Checked(object sender, RoutedEventArgs e)
        {
            ExchangeRate = 0.91;                                                        //Taux d'échange à 0.91
            bitmapImage.UriSource = new Uri(image.BaseUri, "ms-appx:///Assets/US.png"); //Assignation du fichier à l'image
            image.Source = bitmapImage;                                                 //Mettre à jour l'image
        }

        //radio bouton "radioButtonGBP" selectionné
        private void radioButtonGBP_Checked(object sender, RoutedEventArgs e)
        {
            ExchangeRate = 1.12;                                                        //Taux d'échange à 1.12
            bitmapImage.UriSource = new Uri(image.BaseUri, "ms-appx:///Assets/EN.png"); //Assignation du fichier à l'image
            image.Source = bitmapImage;                                                 //Mettre à jour l'image
        }

        //radio bouton "radioButtonJPY" selectionné
        private void radioButtonJPY_Checked(object sender, RoutedEventArgs e)
        {
            ExchangeRate = 0.0071;                                                      //Taux d'échange à 0.0071
            bitmapImage.UriSource = new Uri(image.BaseUri, "ms-appx:///Assets/JP.png"); //Assignation du fichier à l'image
            image.Source = bitmapImage;                                                 //Mettre à jour l'image
        }

        //Appui sur le bouton Convert 
        private void button_Convert_Click(object sender, RoutedEventArgs e)
        {
            double Amount = double.Parse(textBoxInput.Text);                            //Prends la valeur du Montant
            Result = ExchangeRate * Amount;                                             //Retourne le résultat avec le taux d'échange sélectionné
            textBoxOutput.Text = Result.ToString();                                     //Affiche le résultat dans "textBoxOutput"
        }
    }
}
