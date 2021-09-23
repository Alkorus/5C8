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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Animation
{
    /// <summary>
    /// Logique d'interaction pour PromenadeCs.xaml
    /// </summary>
    public partial class PromenadeCs : Window
    {
        Storyboard[] scn_action = new Storyboard[4];

        public PromenadeCs()
        {
            InitializeComponent();
        }

        private void executeScenario(object sender, RoutedEventArgs e)
        {
            // Scénario 0: en bas
            DoubleAnimation deplaceBas = new DoubleAnimation();
            deplaceBas.From = 0;
            deplaceBas.To = 300;
            deplaceBas.Duration = TimeSpan.FromSeconds(2);

            scn_action[0] = new Storyboard();
            Storyboard.SetTarget(deplaceBas, btnImage);
            Storyboard.SetTargetProperty(deplaceBas, new PropertyPath("(Canvas.Top)"));
            scn_action[0].Children.Add(deplaceBas);

            // Scénario 1 : à droite
            DoubleAnimation deplaceDroite = new DoubleAnimation();
            deplaceDroite.From = 0;
            deplaceDroite.To = 600;
            deplaceDroite.Duration = TimeSpan.FromSeconds(2);

            scn_action[1] = new Storyboard();
            Storyboard.SetTarget(deplaceDroite, btnImage);
            Storyboard.SetTargetProperty(deplaceDroite, new PropertyPath("(Canvas.Left)"));
            scn_action[1].Children.Add(deplaceDroite);

            // Scénario 2 : en haut
            DoubleAnimation deplaceHaut = new DoubleAnimation();
            deplaceHaut.From = 300;
            deplaceHaut.To = 10;
            deplaceHaut.Duration = TimeSpan.FromSeconds(2);

            scn_action[2] = new Storyboard();
            Storyboard.SetTarget(deplaceHaut, btnImage);
            Storyboard.SetTargetProperty(deplaceHaut, new PropertyPath("(Canvas.Top)"));
            scn_action[2].Children.Add(deplaceHaut);

            // Scénario 3 : à gauche
            DoubleAnimation deplaceGauche = new DoubleAnimation();
            deplaceGauche.From = 600;
            deplaceGauche.To = 200;
            deplaceGauche.Duration = TimeSpan.FromSeconds(2);

            scn_action[3] = new Storyboard();
            Storyboard.SetTarget(deplaceGauche, btnImage);
            Storyboard.SetTargetProperty(deplaceGauche, new PropertyPath("(Canvas.Left)"));
            scn_action[3].Children.Add(deplaceGauche);

            scn_action[0].Completed += etapeZeroTerminated;
            scn_action[1].Completed += etapeUnTerminated;
            scn_action[2].Completed += etapeDeuxTerminated;
            scn_action[3].Completed += etapeTroisTerminated;

            scn_action[0].Begin();
        }

        private void etapeZeroTerminated(Object sender, EventArgs e)
        {
            scn_action[1].Begin();
        }

        private void etapeUnTerminated(Object sender, EventArgs e)
        {
            scn_action[2].Begin();
        }

        private void etapeDeuxTerminated(Object sender, EventArgs e)
        {
            scn_action[3].Begin();
        }
        private void etapeTroisTerminated(Object sender, EventArgs e)
        {
            MessageBox.Show("Scénario complété");
        }
    }
}
