using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace CrozzWord_RegEx_Table
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
         
        private void button1_Click(object sender, EventArgs e)
        {

            tbHori[0] = textBox1;
            tbHori[1] = textBox2;
            tbVerti[0] = textBox3;
            tbVerti[1] = textBox4;
            char[] hori = { 'H', 'E' };
            char[] verti = { 'L', 'P' };
            for (int i = 0; i < this.tbHori.Length; i++)
            {
                this.tbHori[i].Text = hori[i].ToString();
            }

            for (int i = 0; i < this.tbVerti.Length; i++)
            {
                this.tbVerti[i].Text = verti[i].ToString();
            }
            findMatch();
        }


        private void button2_Click_1(object sender, EventArgs e)
        {

            tbHori[0] = textBox1;
            tbHori[1] = textBox2;
            tbVerti[0] = textBox3;
            tbVerti[1] = textBox4;
            for (int i = 0; i < this.tbHori.Length; i++)
            {
                this.tbHori[i].Text = String.Empty;
            }

            for (int i = 0; i < this.tbVerti.Length; i++)
            {
                this.tbVerti[i].Text = String.Empty;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tbHori[0] = textBox1;
            tbHori[1] = textBox2;
            tbVerti[0] = textBox3;
            tbVerti[1] = textBox4;
            string[] patternColumn = { "[^SPEAK]+", "EP|IP|EF" };
            string[] patternRow = { "HE|LL|O+", "[PLEASE]+" };
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            for (int i = 0; i < this.tbHori.Length; i++)
            {
                foreach (string c in patternRow)
                {
                    //do something with letter
                    foreach (string s in patternColumn)
                    {

                        var matches = Regex.Match(c.ToString(), s, RegexOptions.IgnoreCase);
                        foreach (Match match in Regex.Matches(c.ToString(), s)

           )              this.tbHori[i].Text = match.Value;
                       // Console.WriteLine("'{0}',", match.Value, match.Index);
                    }

                  //  this.tbHori[i].Text = String.Empty;
                }



                for (int ii = 0; ii < this.tbVerti.Length; ii++)
                {
                 //   this.tbVerti[ii].Text = String.Empty;
                }
            }
        }
 

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }
    public static void solveCrossWord()
    {
        string[] patternColumn = { "[^SPEAK]+", "EP|IP|EF" };
        string[] patternRow = { "HE|LL|O+", "[PLEASE]+" };

        foreach (string column in patternColumn)
        {
            foreach (string row in patternRow)
            {
                var matches = Regex.Match(row, column, RegexOptions.IgnoreCase);

                if (matches.Success)
                {
                    Console.WriteLine("For Pattern " + column + " using the input " + row + " the following character(s) where found:");
                }

                foreach (Match match in Regex.Matches(row, column)

                    )

                    Console.WriteLine("'{0}',", match.Value, match.Index);
            }

        }
        static void solveCrossWord()
        {
            string[] patternColumn = { "[^SPEAK]+", "EP|IP|EF" };
            //   string[] patternRow = { "[^SPEAK]+", "EP|IP|EF" };
            string[] patternRow = { "HE|LL|O+", "[PLEASE]+" };
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            foreach (string s in patternColumn)
            {
                foreach (string row in patternRow)
                {
                    var regex = new Regex("ABCDEFGHIJKLMNOPRSTUVWXYZ");

                    

                    var matches = Regex.Match(row, s, RegexOptions.IgnoreCase);

                    var matchesletters = Regex.Match(matches.ToString(), alphabet, RegexOptions.IgnoreCase);
                    if (matches.Success)
                    {
                        Console.WriteLine("For Pattern " + s + " using the input " + row + " the following character(s) where found:");
                    }
                   // var isMatch = regex.IsMatch(matches);

                    foreach (Match match in Regex.Matches(row, s)

                        )
                        Console.WriteLine("'{0}',", match.Value, match.Index);

                }
            }
        }
    }
}
