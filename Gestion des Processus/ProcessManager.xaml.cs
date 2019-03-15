using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace Gestion_des_Processus
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //Déclaration d'un thread pour la gestion d'évènement de fermeture d'un processus en cours
        private Thread thread;

        //Liste de tous les ID des processus Ballons en cours
        public ObservableCollection<int> listeBallons = new ObservableCollection<int>();

        //Liste de tous les ID des processus en cours
        public ObservableCollection<int> liste = new ObservableCollection<int>();

        //Liste de tous les ID des processus Premiers en cours
        public ObservableCollection<int> listePremiers = new ObservableCollection<int>();

        public MainWindow()
        {
            InitializeComponent();
        }

        //Rafraîchissement des nombres totaux des processus en cours
        public void refresh()
        {
            nbreBallons.Content = listeBallons.Count; //Nombre total de processus Ballons en cours
            nbrePremiers.Content = listePremiers.Count; //Nombre total de processus Premiers en cours
        }

        #region Fermeture d'un processus à partir de l'évènement effectué sur la fermeture du processus en cours
        private void ballon_Exited(object sender, EventArgs e)
        {

            Process ballon = (Process)sender;

            thread = new Thread(
                new ThreadStart(
                    () => fermeture(listeBallons, ballon.Id)
                )
            );

            thread.Start();

        }

        private void premier_Exited(object sender, EventArgs e)
        {

            Process premier = (Process)sender;

            thread = new Thread(
                new ThreadStart(
                    () => fermeture(listePremiers, premier.Id)
                )
            );

            thread.Start();

        }

        private void fermeture(ObservableCollection<int> listeProcessus, int processus)
        {
            this.Dispatcher.BeginInvoke(
                DispatcherPriority.Normal,
                (ThreadStart)delegate()
                {

                    if (liste.Contains(processus))
                    {
                        liste.Remove(processus);
                    }

                    if (listeProcessus.Contains(processus))
                    {
                        listeProcessus.Remove(processus);
                        refresh();
                    }

                }
            );
        }
        #endregion

        #region Fermeture des derniers processus en cours
        public void dernier(ObservableCollection<int> listeBallons, ObservableCollection<int> listePremiers, ObservableCollection<int> liste, ObservableCollection<int> listeProcessus, String processus)
        {

            if (processus == null)
            {

                if (liste.Count == 0)
                {
                    MessageBoxResult result = MessageBox.Show("Aucun processus en cours.", "Aucun", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK);
                }

                else
                {

                    Process proc = Process.GetProcessById(liste[liste.Count - 1]);
                    proc.Kill(); //Tuer un processus

                    if (liste.Contains(proc.Id))
                    {
                        liste.Remove(proc.Id);
                    }

                    if (listeBallons.Contains(proc.Id))
                    {
                        listeBallons.Remove(proc.Id);
                        refresh();
                    }

                    if (listePremiers.Contains(proc.Id))
                    {
                        listePremiers.Remove(proc.Id);
                        refresh();
                    }

                }

            }

            else
            {

                if (listeProcessus.Count == 0)
                {
                    MessageBoxResult result = MessageBox.Show("Aucun processus " + processus + " en cours.", "Aucun " + processus, MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK);
                }

                else
                {

                    Process proc = Process.GetProcessById(listeProcessus[listeProcessus.Count - 1]);
                    proc.Kill();

                    if (liste.Contains(proc.Id))
                    {
                        liste.Remove(proc.Id);
                    }

                    if (listeProcessus.Contains(proc.Id))
                    {
                        listeProcessus.Remove(proc.Id);
                        refresh();
                    }

                }

            }

        }
        #endregion

        #region Fermeture de l'ensemble des processus en cours
        public void tous(ObservableCollection<int> listeBallons, ObservableCollection<int> listePremiers, ObservableCollection<int> liste, ObservableCollection<int> listeProcessus, String processus)
        {

            if (processus == null)
            {

                if (liste.Count == 0)
                {
                    MessageBoxResult result = MessageBox.Show("Aucun processus en cours.", "Aucun", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK);
                }

                else
                {

                    for (int i = 0; i < liste.Count; i++)
                    {
                        Process.GetProcessById(liste[i]).Kill();
                    }

                    liste.Clear();
                    listeBallons.Clear();
                    listePremiers.Clear();
                    refresh();

                }

            }

            else
            {

                if (listeProcessus.Count == 0)
                {
                    MessageBoxResult result = MessageBox.Show("Aucun processus " + processus + " en cours.", "Aucun " + processus, MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK);
                }

                else
                {

                    for (int i = 0; i < listeProcessus.Count; i++)
                    {

                        Process.GetProcessById(listeProcessus[i]).Kill();

                        if (liste.Contains(listeProcessus[i]))
                        {
                            liste.Remove(listeProcessus[i]);
                        }

                    }

                    listeProcessus.Clear();
                    refresh();

                }

            }

        }
        #endregion

        #region Création d'un nouveau processus Ballon
        private void Ballon_Click(object sender, RoutedEventArgs e)
        {

            //Limite de création d'un processus
            if ( listeBallons.Count > 7 )
            {
                MessageBoxResult result = MessageBox.Show("Vous avez atteint la limite de processus Ballon à créer.", "Limite atteinte", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK);
            }

            else
            {

                Process ballon = Process.Start("Ballon.exe"); //Execution d'un processus

                listeBallons.Add(ballon.Id); //Ajouter un nouveau processus crée dans une liste de processus
                liste.Add(ballon.Id);

                processusBallons.ItemsSource = listeBallons; //Binding permettant de lier une ListView à une liste de processus
                refresh();


                ballon.EnableRaisingEvents = true; //Déclencher l'évènement Exited d'nu processus en cours
                ballon.Exited += new EventHandler(ballon_Exited); //Exécuter la terminaison d'un processus en cours
            
            }

            
        }
        #endregion

        #region Création d'un nouveau processus Premier
        private void Premiers_Click(object sender, RoutedEventArgs e)
        {

            if ( listePremiers.Count > 7 )
            {
                MessageBoxResult result = MessageBox.Show("Vous avez atteint la limite de processus Premiers à créer.", "Limite atteinte", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK);
            }

            else
            {

                Process premier = Process.Start("Premiers.exe");
                
                listePremiers.Add(premier.Id);
                liste.Add(premier.Id);
                
                processusPremiers.ItemsSource = listePremiers;
                refresh();

                premier.EnableRaisingEvents = true;
                premier.Exited += new EventHandler(premier_Exited);
            
            }
            
        }
        #endregion

        #region Fermeture un procesus Ballon sélectionné
        private void ballon_Click(object sender, RoutedEventArgs e)
        {

            int select = processusBallons.SelectedIndex;

            if (select == -1)
            {
                MessageBoxResult result = MessageBox.Show("Aucun processus sélectionné.", "Aucune selection", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK);
            }

            else
            {

                Process ballon = Process.GetProcessById(listeBallons[select]);
                ballon.Kill();

                if (liste.Contains(ballon.Id))
                {
                    liste.Remove(ballon.Id);
                }

                if (listeBallons.Contains(ballon.Id))
                {
                    listeBallons.Remove(ballon.Id);
                    refresh();
                }

            }

        }
        #endregion

        #region Fermeture un procesus Premier sélectionné
        private void premier_Click(object sender, RoutedEventArgs e)
        {

            int select = processusPremiers.SelectedIndex;

            if (select == -1)
            {
                MessageBoxResult result = MessageBox.Show("Aucun processus sélectionné.", "Aucune selection", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK);
            }

            else
            {

                Process premier = Process.GetProcessById(listePremiers[select]);
                premier.Kill();

                if (liste.Contains(premier.Id))
                {
                    liste.Remove(premier.Id);
                }

                if (listePremiers.Contains(premier.Id))
                {
                    listePremiers.Remove(premier.Id);
                    refresh();
                }

            }

        }
        #endregion

        //Fermeture du dernier processus en cours
        private void dernierProcessus_Click(object sender, RoutedEventArgs e)
        {
            dernier(listeBallons, listePremiers, liste, null, null);
        }

        //Fermeture du dernier processus Ballon en cours
        private void dernierBallon_Click(object sender, RoutedEventArgs e)
        {
            dernier(null, null, liste, listeBallons, "Ballon");
        }

        //Fermeture du dernier processus Premier en cours
        private void dernierPremier_Click(object sender, RoutedEventArgs e)
        {
            dernier(null, null, liste, listePremiers, "Premier");
        }

        //Fermeture de tous les processus Ballons en cours
        private void tousBallons_Click(object sender, RoutedEventArgs e)
        {
            tous(null, null, liste, listeBallons, "Ballon");
        }

        //Fermeture de tous les processus Premiers en cours
        private void tousPremiers_Click(object sender, RoutedEventArgs e)
        {
            tous(null, null, liste, listePremiers, "Premier");
        }

        //Fermeture de tous les processus en cours
        private void tousProcessus_Click(object sender, RoutedEventArgs e)
        {
            tous(listeBallons, listePremiers, liste, null, null);

        }

        #region Masquer et rendre visible l'interface de gestion des processus
        private void masquerVisible_Click(object sender, RoutedEventArgs e)
        {

            if (visibilite.Header.Equals("Masquer"))
            {
                contenu.Visibility = Visibility.Hidden;
                visibilite.Header = "Visible";
            }

            else
            {
                contenu.Visibility = Visibility.Visible;
                visibilite.Header = "Masquer";
            }
            
        }
        #endregion

        //Ouverture de la fenêtre d'aide
        private void aide_Click(object sender, RoutedEventArgs e)
        {
            Aide aide = new Aide();
            aide.Show();
        }

        #region Fermeture de tous les processus en cours et fermeture de l'application
        private void quitter_Click(object sender, RoutedEventArgs e)
        {

            if (liste.Count > 0)
            {
                tous(listeBallons, listePremiers, liste, null, null);
            }

            Close(); //Fermeture de l'application

        }

        private void Manager_Closed(object sender, EventArgs e)
        {

            if (liste.Count > 0)
            {
                tous(listeBallons, listePremiers, liste, null, null);
            }

            Close();

        }
        #endregion

    }

}
