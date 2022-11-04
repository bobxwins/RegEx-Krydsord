using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CrozzWord_RegEx_Table
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        static string[] patternColumn = { @"(?<TM>\w*[^SPEAK]+\w*)","EP|IP|EF"};
        static string[] patternRow = { @"HE|LL|O+", "[PLEASE]+" };
        public  string[] FindHoriFirst()
        {
            List<String> listTemp = new List<string>();
            Regex regexSpeak = new Regex(patternColumn[0]);
            foreach (Match matchItem in regexSpeak.Matches(patternRow[0]))
            {
                listTemp.Add(matchItem.ToString());
            }
            string[] splitString = listTemp[listTemp.Count() - 1].Split('|');
            return splitString;
        }

        public void button1_Click(object sender, EventArgs e)
        {
            FindHoriSecond();
        }
        public  void FindHoriSecond()
        {
            tbHori[0] = textBox1;
            tbHori[1] = textBox2;
            Regex regexEPIF = new Regex("[EPIPEF]"); // EP|IP|EF  aflæses ikke korrekt 

            List<String> listTemp = new List<string>();
            string[] hello = FindHoriFirst();
            ; foreach (string s in hello)
            {
                foreach (Match matchItem in regexEPIF.Matches(s))
                {
                    listTemp.Add(hello[matchItem.Index - 1]);
                }
            }
           tbHori[0].Text = listTemp[0][0].ToString();
           tbHori[1].Text = listTemp[0][1].ToString();
            FindVertiFirst();
            FindVertiSecond();
        }
        public  string[] FindVertiFirst()
        {
           
            tbVerti[0] = textBox3;
            List<String> listTemp = new List<string>();
            List<String> listSolved = new List<string>();
            Regex regexSpeak = new Regex("[^SPEAK]");//patternColumn[0]);
            foreach (Match matchItem in regexSpeak.Matches(patternRow[1]))
            {
                listTemp.Add(matchItem.ToString());
            }
            foreach (string s in listTemp)
            {
                foreach (Match matchItem in regexSpeak.Matches(s))
                {
                    if (Regex.IsMatch(s, @"^[a-zA-Z]+$"))
                    {
                         
                        listSolved.Add(matchItem.ToString());
                    }
                }
            }
            tbVerti[0].Text = listSolved[0][0].ToString();
            Console.WriteLine(listSolved[0]);
            return listSolved.ToArray();
        }
        public void FindVertiSecond()
        {
            tbHori[1] = textBox2;
            tbVerti[1] = textBox4;
            Regex regexEPIF = new Regex("[EP|IP|EF]");
            string[] splitString = patternColumn[1].Split('|');
            List<String> listTempChars = new List<string>();
            List<String> listTempSplit = new List<string>();
            foreach (char c in patternRow[1])
            {
                foreach (Match matchItem in regexEPIF.Matches(c.ToString()))
                {
                    listTempChars.Add(matchItem.ToString());
                }
            }


            foreach (string s in splitString)
            {
                foreach (string list in listTempChars)
                { 
                    if (s[1].ToString() == list)
                    {    // Checker om det sidste bogstav fra regEX er det samme som et af bogstaverne "P E E"
                        tbVerti[1].Text = s[1].ToString();
                    }
                }

            }
            solve();
        }

        public void solve()
        {

           string solved = tbHori[0].Text + tbHori[1].Text + tbVerti[0].Text + tbVerti[1].Text;

            string[] patternRow = { "HE|LL|O+", "[PLEASE]+" };
            string[] patternColumn = {"[^SPEAK]+", "EP|IP|EF" };

           
                foreach (string row in patternRow)
                {

                    var matches = Regex.Match(solved, row, RegexOptions.IgnoreCase);
                    if (matches.Success)
                    {
                        Console.WriteLine("For Pattern " + row + " using the input " + solved + " the following character(s) where found:");
                    }
                    foreach (Match match in Regex.Matches(solved, row))

                    {
                        Console.WriteLine("'{0}',", match.Value.ToString(), match.Index);
                    }

                }
            foreach (string column in patternColumn)
            {

                var matches = Regex.Match(solved, column, RegexOptions.IgnoreCase);
                if (matches.Success)
                {
                    Console.WriteLine("For Pattern " + column + " using the input " + solved + " the following character(s) where found:");
                }
                foreach (Match match in Regex.Matches(solved, column))

                {
                    Console.WriteLine("'{0}',", match.Value.ToString(), match.Index);
                }

            }
        }
        }
        }
    
