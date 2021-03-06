﻿using System;
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

namespace MorseCode
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Dictionary<char, string> DutchToMorse = new Dictionary<char, string>();

        Dictionary<string, string> MorseToDutch = new Dictionary<string, string>();

        public MainWindow()
        {
            InitializeComponent();

            DutchToMorse.Add('a',".-");
            DutchToMorse.Add('b',"-...");
            DutchToMorse.Add('c',"-.-.");
            DutchToMorse.Add('d',"-..");
            DutchToMorse.Add('e',".");
            DutchToMorse.Add('f',"..-.");
            DutchToMorse.Add('g',"--.");
            DutchToMorse.Add('h',"....");
            DutchToMorse.Add('i',"..");
            DutchToMorse.Add('j',".---");
            DutchToMorse.Add('k',"-.-");
            DutchToMorse.Add('l',".-..");
            DutchToMorse.Add('m',"--");
            DutchToMorse.Add('n',"-.");
            DutchToMorse.Add('o',"---");
            DutchToMorse.Add('p',".--.");
            DutchToMorse.Add('q',"--.-");
            DutchToMorse.Add('r',".-.");
            DutchToMorse.Add('s',"...");
            DutchToMorse.Add('t',"-");
            DutchToMorse.Add('u',"..--");
            DutchToMorse.Add('v',"...-");
            DutchToMorse.Add('w',".--");
            DutchToMorse.Add('x',"-..-");
            DutchToMorse.Add('y',"-.--");
            DutchToMorse.Add('z',"--..");
            

            MorseToDutch.Add(".-","a");
            MorseToDutch.Add("-...","b");
            MorseToDutch.Add("-.-.","c");
            MorseToDutch.Add("-..","d");
            MorseToDutch.Add(".","e");
            MorseToDutch.Add("..-.","f");
            MorseToDutch.Add("--.","g");
            MorseToDutch.Add("....","h");
            MorseToDutch.Add("..","i");
            MorseToDutch.Add(".---","j");
            MorseToDutch.Add("-.-","k");
            MorseToDutch.Add(".-..","l");
            MorseToDutch.Add("--","m");
            MorseToDutch.Add("-.","n");
            MorseToDutch.Add("---","o");
            MorseToDutch.Add(".--.","p");
            MorseToDutch.Add("--.-","q");
            MorseToDutch.Add(".-.","r");
            MorseToDutch.Add("...","s");
            MorseToDutch.Add("-","t");
            MorseToDutch.Add("..--","u");
            MorseToDutch.Add("...-","v");
            MorseToDutch.Add(".--","w");
            MorseToDutch.Add("-..-","x");
            MorseToDutch.Add("-.--","y");
            MorseToDutch.Add("--..", "z");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string dutch = DutchBox.Text.ToLower();

            char[] dutchArray = dutch.ToCharArray();

            string morse = "";

            char check = ' ';

            foreach (char ch in dutchArray)
            {
                if (ch == ' ')
                {
                    morse += "/";                    
                }
                else if (check == '/')
                {
                    morse += DutchToMorse[ch];                   
                }
                else
                {
                    morse += DutchToMorse[ch] + " ";
                }
            }
            
            MorseBox.Text = morse;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            List<string> list = new List<string>();

            string morse = "";
            char[] mArray = MorseBox.Text.ToArray();

            string text = "";

            DutchBox.Text = "";

            for(int i = 0; i < MorseBox.Text.Length;i++)
            {
                if (MorseBox.Text[i] != ' ' && MorseBox.Text[i] != '/')
                {
                    morse += MorseBox.Text[i];
                }
                else if(MorseBox.Text[i] == ' ')
                {
                    list.Add(morse);
                    morse = "";
                }
                else
                {
                    list.Add(morse);
                    list.Add(" ");
                    morse = "";
                }

                if (i == MorseBox.Text.Length - 1)
                {
                    list.Add(morse);
                }
            }
            list.RemoveAll(item => item == "");

            foreach (string s in list)
            {
                if(s != " ")
                {
                    text += MorseToDutch[s];
                }
                else
                {
                    text += " ";
                }
            }

            DutchBox.Text = text;
            #region          
            //for (int i = 0;i < MorseBox.Text.Length;i++)
            //{
            //    string box = ""  + MorseBox.Text[i];

            //    if (box == " ")
            //    {
            //        list.Add(morse);
            //        morse = "";
            //    }

            //    morse += box;

            //    if (Convert.ToChar(box) == '\\' )
            //    {
            //        list.Add(" ");
            //    }               
            //}

            //foreach(string s in list)
            //{
            //    if (s != " ")
            //    {
            //        DutchBox.Text += MorseToDutch["."];
            //    }
            //    else
            //    {
            //        DutchBox.Text += " ";
            //    }
            //}

            #endregion
        }
    }
}
