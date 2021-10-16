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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace HokejIspitJun
{
    /// <summary>
    /// Interaction logic for IgrajHokej.xaml
    /// </summary>
    public partial class IgrajHokej : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        public string ImePrvogI { get; set; }
        public string ImeDrugogI { get; set; }
        public int score1 { get; set; } = 0;
        public int score2 { get; set; } = 0;
        int brzina = 1;
        int brzinapaka = 0;
        public int pakleft = 100;
        public int pakright = 170;
        public int igrac1down = 1;
        public int igrac1top = 1;
        public int igrac2down = 1;
        public int igrac2top = 1;
        Random rnd = new Random();


        public IgrajHokej(string ime1, string ime2)
        {
            ImePrvogI =ime1;
            ImeDrugogI = ime2;
            InitializeComponent();
            txtime1.Content = $"{ime1}         {score1}";
            txtime2.Content =$":   {score2}        { ime2}";
            MyCanvas.Focus();
        }

        private void GameEngine(object sender, EventArgs e)
        {
         
            if(pakright>igrac2top && pakright<igrac2top && pakright<=670)
            {
                brzina += 1;
                brzinapaka -= brzina;
            }
            if (pakleft > igrac1top && pakleft < igrac1top && pakright <= 70)
            {
                brzina -= 1;
                brzinapaka +=brzina;
            }
            Canvas.SetLeft(pak, pakleft);
            Canvas.SetRight(pak, pakright);
            StvaranjeLopte();
           foreach(var x in MyCanvas.Children.OfType<Ellipse>())
            {
                if ((string)x.Tag == "pak")
                {
                    if (Canvas.GetLeft(x) + 70 < 200)
                        score1++;
                    txtime1.Content = $"{ImePrvogI}      {score1}";

                    if (Canvas.GetRight(x)< 690)
                        score2++;
                    txtime2.Content = $"{ImeDrugogI}     {score2}";
                }
            }
        }

        public void StvaranjeLopte()
        {
            brzina = brzinapaka;
            pakleft = rnd.Next(70, 750);
            Canvas.SetLeft(pak, pakleft);
            Canvas.SetTop(pak, pakright);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Down)
            {
                if(igrac1down>0 && igrac1down<240)
                {
                    igrac1down += 5;
                }
                Canvas.SetTop(igrac1, igrac1down);
            }
            if (e.Key==Key.Up)
            {
                if (igrac1top>0)
                {
                    igrac1top -= 1;
                }
                Canvas.SetTop(igrac1, igrac1top);

            }
            if (e.Key == Key.Left)
            {
                if (igrac2top > 0 && igrac2top<240)
                {
                    igrac2top += 5;
                }
                Canvas.SetTop(igrac2, igrac2top);
            }
            if (e.Key == Key.Right)
            {
                if (igrac2down > 0)
                {
                    igrac2down -= 5;
                }
                Canvas.SetTop(igrac2, igrac2down);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StvaranjeLopte();
            timer.Tick += GameEngine;
            timer.Interval = TimeSpan.FromMilliseconds(20);
            timer.Start();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            timer.Stop();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            
            score1 = 0;
            score2 = 0;
            //timer.Stop();
        }
    }
}
