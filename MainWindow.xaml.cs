/*
 * Couper EbbsPicken
 * 6/18/2018
 * Does a problem
 */ 
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
using System.IO;

namespace culm_S1VoronoiVillages_CouperEbbsPicken
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // global variables
        StreamReader streamReader;
        int N;
        double[] villages;
        double tempDub;
        bool good;
        int counter;
        double minSize;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnRun_Click(object sender, RoutedEventArgs e)
        {
            // resetting variables
            minSize = 10000000000000000000;
            good = false;
            streamReader = new StreamReader("Input.txt");
            int.TryParse(streamReader.ReadLine(), out N);
            villages = new double[N];

            // creating array of village positions
            for (int i = 0; i < villages.Length; i++)
            {
                string temp = streamReader.ReadLine();
                //MessageBox.Show(temp);
                MessageBox.Show("Parse: " + double.TryParse(temp, out tempDub).ToString());
                villages[i] = tempDub;
            }

            // sorting the arary so it is lowest to highest
            while (good != true)
            {
                counter = 0;
                for (int i = 0; i < N - 1; i++)
                {
                    if (villages[i + 1] < villages[i])
                    {
                        tempDub = villages[i + 1];
                        villages[i + 1] = villages[i];
                        villages[i] = tempDub;
                        counter++;
                    }
                }

                if (counter == 0)
                {
                    good = true;
                }
            }

            // checking the neighbourhoods of villages
            for (int i = 1; i < N - 1; i++)
            {
                tempDub = ((villages[i] - villages[i - 1]) / 2) + ((villages[i + 1] - villages[i]) / 2);

                if (tempDub < minSize)
                {
                    minSize = tempDub;
                }

            }
            // finishing program and updating the output label
            lblOutput.Content = Math.Round(minSize, 2);
            streamReader.Close();

        }
    }
}
