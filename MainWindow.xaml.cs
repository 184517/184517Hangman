/* Jordan Ross
 * April 23, 2019
 * Hangman Program
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

namespace _184517Hangman
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int lives = 5;
        string[] answer = new string[10];
        int counter = 0;
        Random random = new Random();
        string correctanswer;
        string recoveranswer;

        public MainWindow()
        {
            InitializeComponent();
            lblLivesLeft.Content = lives.ToString();
   
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            int randomnumber = random.Next(0, 10);

            counter = 0;
            txbCorrectLetters.Text = "";
            System.IO.StreamReader read = new System.IO.StreamReader("words.txt");
            while(!read.EndOfStream)
            {
                if (counter == randomnumber)
                {
                    answer[randomnumber] = read.ReadLine();
                    counter++;
                }
                else
                {
                    read.ReadLine();
                    counter++;
                }
                correctanswer = answer[randomnumber];
            }
            read.Close();
            for (int i = 0; i < correctanswer.Length; i++)
            {
                txbCorrectLetters.Text += "_ ";
            }
            lblLivesLeft.Content = 5;
            lblLettersGuessed.Content = " ";
        }

        private void btnGuess_Click(object sender, RoutedEventArgs e)
        {
            recoveranswer = txbCorrectLetters.Text;

            char singleletter = ' ';

            for(int i = 0; i < correctanswer.Length; i++)
            {
                singleletter = correctanswer[i];

                if (singleletter.ToString() == txtLetter.Text)
                {
                    recoveranswer = recoveranswer.Remove(i * 2, 1);
                    recoveranswer = recoveranswer.Insert(i * 2, singleletter.ToString());
                    txbCorrectLetters.Text = "";
                    txbCorrectLetters.Text += recoveranswer;
                } 
            }
            if (singleletter.ToString() != txtLetter.Text)
            {
                lives--;
                lblLivesLeft.Content = lives.ToString();
            }
            if ((string) lblLivesLeft.Content == "0")
            {
                txbCorrectLetters.Text = "You Lost :-(";
            }
            lblLettersGuessed.Content += txtLetter.Text;
                
        }
    }
    
}
