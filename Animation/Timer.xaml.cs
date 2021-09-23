using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Animation
{
    /// <summary>
    /// Logique d'interaction pour Timer.xaml
    /// </summary>
    public partial class Timer : Window
    {
        DispatcherTimer gereAgrandit = new DispatcherTimer();
        DispatcherTimer gereRetrecit = new DispatcherTimer();

        DispatcherTimer gereMoveRight = new DispatcherTimer();
        DispatcherTimer gereMoveLeft = new DispatcherTimer();
        DispatcherTimer gereMoveTop = new DispatcherTimer();
        DispatcherTimer gereMoveBottom = new DispatcherTimer();

        int iDeplacementHorizon = 0;
        int iDeplacementVertical = 0;
        int largeur = 40;

        public Timer()
        {
            InitializeComponent();
            gereAgrandit.Tick += agrandir;
            gereAgrandit.Interval = TimeSpan.FromMilliseconds(50);

            gereRetrecit.Tick += retrecir;
            gereRetrecit.Interval = TimeSpan.FromMilliseconds(50);

            gereMoveRight.Tick += moveRight;
            gereMoveRight.Interval = TimeSpan.FromMilliseconds(50);
            gereMoveLeft.Tick += moveLeft;
            gereMoveLeft.Interval = TimeSpan.FromMilliseconds(50);
            gereMoveTop.Tick += moveUp;
            gereMoveTop.Interval = TimeSpan.FromMilliseconds(50);
            gereMoveBottom.Tick += moveDown;
            gereMoveBottom.Interval = TimeSpan.FromMilliseconds(50);
        }

        private void btnAgrandir(object sender, RoutedEventArgs e)
        {
            gereRetrecit.Stop();
            gereAgrandit.Start();
        }

        private void agrandir(object sender, EventArgs e)
        { 
            if(largeur <= 700)
                largeur += 10;
            imgDrapeau.Width = largeur;
        }

        private void btnRetrecir(object sender, RoutedEventArgs e)
        {
            gereAgrandit.Stop();
            gereRetrecit.Start();
        }

        private void retrecir(object sender, EventArgs e)
        {
            if (largeur >= 40)
                largeur -= 10;
            imgDrapeau.Width = largeur;
        }

        private void btnMoveRight(object sender, RoutedEventArgs e)
        {
            gereMoveLeft.Stop();
            gereMoveRight.Start();
        }

        private void moveRight(object sender, EventArgs e)
        {
            if (iDeplacementHorizon <= 700)
                iDeplacementHorizon += 10;
            Canvas.SetLeft(imgDrapeau, iDeplacementHorizon);
        }

        private void btnMoveLeft(object sender, RoutedEventArgs e)
        {
            gereMoveRight.Stop();
            gereMoveLeft.Start();
        }

        private void moveLeft(object sender, EventArgs e)
        {
            if (iDeplacementHorizon >= 0)
                iDeplacementHorizon -= 10;
            Canvas.SetLeft(imgDrapeau, iDeplacementHorizon);
        }

        private void btnMoveUp(object sender, RoutedEventArgs e)
        {
            gereMoveBottom.Stop();
            gereMoveTop.Start();
        }

        private void moveUp(object sender, EventArgs e)
        {
            if (iDeplacementVertical >= 0)
                iDeplacementVertical -= 10;
            Canvas.SetTop(imgDrapeau, iDeplacementVertical);
        }

        private void btnMoveDown(object sender, RoutedEventArgs e)
        {
            gereMoveTop.Stop();
            gereMoveBottom.Start();
        }

        private void moveDown(object sender, EventArgs e)
        {
            if (iDeplacementVertical <= 500)
                iDeplacementVertical += 10;
            Canvas.SetTop(imgDrapeau, iDeplacementVertical);
        }

        private void btnArret(object sender, RoutedEventArgs e)
        {
            gereRetrecit.Stop();
            gereAgrandit.Stop();
            gereMoveRight.Stop();
            gereMoveLeft.Stop();
            gereMoveTop.Stop();
            gereMoveBottom.Stop();
        }
    }
}
