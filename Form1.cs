using System.Text.RegularExpressions;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
// CODE MADED BY FRANCISZEK CHMIELEWSKI
namespace Logicer_Interpreter
{
    public partial class Form1 : Form
    {
        private bool consoleOpen = true;
        private bool hide_messages = false;
        private bool programPaused = false;
        private string mergedText = ""; // Zmienna pomocnicza do przechowywania wyniku merge_text

        public Form1()
        {
            InitializeComponent();
            codeBox.KeyPress += new KeyPressEventHandler(CodeBox_KeyPress);
        }
        private void deugujToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunButton_Click();
        }
        // CODE MADED BY FRANCISZEK CHMIELEWSKI

        // Funkcja wywo³ywana przy ka¿dym naciœniêciu klawisza w codeBox
        private void CodeBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatCode();

        }
        private int i;
        private async void RunButton_Click()
        {
            string[] lines = codeBox.Lines;

            // Regex dla ró¿nych poleceñ
            string newWordsPattern = @"mouth\.new_words\s*=\s*(?:mouth\.merge_text\((.*?)\)|""(.*?)"")\s*;";
            Regex newWordsRegex = new Regex(newWordsPattern);

            string statusOpenedPattern = @"mouth\.status\s*\+=\s*status\.opened_level\((close|open)\)\s*;";
            Regex statusRegex = new Regex(statusOpenedPattern);

            string hiddenMessagesPattern = @"mouth\.status\s*\+=\s*status\.hidden_words\((hide|show)\)\s*;";
            Regex hiddenMessagesRegex = new Regex(hiddenMessagesPattern);

            string sleepPattern = @"mind\.sleep\((\d+)\)\s*;";
            Regex sleepRegex = new Regex(sleepPattern);
            // CODE MADED BY FRANCISZEK CHMIELEWSKI
            string sitPattern = @"mind\.sit\(\)\s*;";
            Regex sitRegex = new Regex(sitPattern);

            string mergeTextPattern = @"mouth\.merge_text\((.*?)\)\s*;";
            Regex mergeTextRegex = new Regex(mergeTextPattern);

            string commentPattern = @"~~(.*?)";
            Regex commentRegex = new Regex(commentPattern);

            bool sitFound = false; // Flaga, by sprawdziæ czy `mind.sit();` jest ostatni

            foreach (string line in lines)
            {
                // CODE MADED BY FRANCISZEK CHMIELEWSKI

                i++;
                if (!lines.Contains("mind.sit();"))
                {
                    AppendColoredText("Error: mind.sit(); must be the last command.\n", Color.Red);
                    break;
                }
                if (line == "") { continue; }   

                while (programPaused)
                {
                    await Task.Delay(100);
                }

                Match commentMatch = commentRegex.Match(line);
                if (commentMatch.Success) { continue; }

                Match statusMatch = statusRegex.Match(line);
                if (statusMatch.Success)
                {
                    string level = statusMatch.Groups[1].Value;
                    // CODE MADED BY FRANCISZEK CHMIELEWSKI
                    if (level == "close")
                    {
                        consoleOpen = false;
                        if (!hide_messages)
                        {
                            console.AppendText("Console is now closed.\n");
                        }
                    }
                    else if (level == "open")
                    {
                        consoleOpen = true;
                        if (!hide_messages)
                        {
                            console.AppendText("Console is now open.\n");
                        }
                    }
                    continue;
                }

                Match hiddenMessagesMatch = hiddenMessagesRegex.Match(line);
                if (hiddenMessagesMatch.Success)
                {
                    // CODE MADED BY FRANCISZEK CHMIELEWSKI
                    string level = hiddenMessagesMatch.Groups[1].Value;

                    if (level == "hide")
                    {
                        hide_messages = true;
                    }
                    else if (level == "show")
                    {
                        hide_messages = false;
                    }
                    continue;
                }

                // Przypisanie wartoœci mouth.new_words = mouth.merge_text(...) lub mouth.new_words = "tekst"
                Match newWordsMatch = newWordsRegex.Match(line);
                if (newWordsMatch.Success)
                {
                    // CODE MADED BY FRANCISZEK CHMIELEWSKI
                    // Pobieramy wartoœæ z matcha
                    string mergedTextValue = newWordsMatch.Groups[1].Success ? newWordsMatch.Groups[1].Value : newWordsMatch.Groups[2].Value;
                    mergedTextValue = mergedTextValue.Replace("\" + \"", ""); // Usuwamy znaki ³¹czenia tekstów
                    mergedTextValue = mergedTextValue.Replace("\"+\"", ""); // Usuwamy znaki ³¹czenia tekstów
                    mergedTextValue = mergedTextValue.Replace("\"", ""); // Usuwamy znaki ³¹czenia tekstów

                    if (consoleOpen)
                    {
                        console.AppendText(mergedTextValue + Environment.NewLine);
                    }
                    else
                    {
                        if (!hide_messages)
                        {
                            console.AppendText("Error: Console is closed. Cannot print the merged text.\n");
                        }
                    }
                    continue;
                }
                Match mergeTextMatch = mergeTextRegex.Match(line);
                if (mergeTextMatch.Success)
                {
                    // £¹czenie tekstów, ale nie wypisujemy od razu
                    mergedText = mergeTextMatch.Groups[1].Value.Replace("\" + \"", ""); // Usuwamy znaki ³¹czenia tekstów
                    continue;
                }
                // CODE MADED BY FRANCISZEK CHMIELEWSKI

                Match sleepMatch = sleepRegex.Match(line);
                if (sleepMatch.Success)
                {
                    int seconds = int.Parse(sleepMatch.Groups[1].Value);
                    int milliseconds = seconds * 1000;
                    await Task.Delay(milliseconds);
                    continue;
                }
                // CODE MADED BY FRANCISZEK CHMIELEWSKI
                Match sitMatch = sitRegex.Match(line);
                if (sitMatch.Success)
                {
                    sitFound = true; // Mark as found to block further execution
                    console.AppendText("Program is now paused. Code execution stopped.\n");
                    break; // Koñczymy wykonywanie kodu
                }

                AppendColoredText("No valid command found on line " + i + ": " + line + Environment.NewLine, Color.Red);
            }
        }

        private void FormatCode()
        {
            // CODE MADED BY FRANCISZEK CHMIELEWSKI
            string[] lines = codeBox.Lines;

            int originalSelectionStart = codeBox.SelectionStart;
            int originalSelectionLength = codeBox.SelectionLength;

            codeBox.SuspendLayout();
            codeBox.SelectAll();
            codeBox.SelectionColor = Color.Black;

            Regex stringRegex = new Regex("\"(.*?)\"");
            Regex numberRegex = new Regex(@"\b\d+\b");
            Regex operatorRegex = new Regex(@"(\+=|=)");
            Regex afterDotRegex = new Regex(@"\.(\w+)");
            Regex semicolonRegex = new Regex(";");
            Regex commentColorRegex = new Regex(@"~~(.*?)");

            int lineStart = 0;

            foreach (string line in lines)
            {
                // CODE MADED BY FRANCISZEK CHMIELEWSKI
                foreach (Match match in stringRegex.Matches(line))
                {
                    codeBox.Select(lineStart + match.Index, match.Length);
                    codeBox.SelectionColor = Color.Orange;
                }

                foreach (Match match in numberRegex.Matches(line))
                {
                    if (!stringRegex.IsMatch(line)) // Nie koloruj cyfr, jeœli s¹ w cudzys³owie
                    {
                        codeBox.Select(lineStart + match.Index, match.Length);
                        codeBox.SelectionColor = Color.Green;
                    }
                }
                // CODE MADED BY FRANCISZEK CHMIELEWSKI
                foreach (Match match in operatorRegex.Matches(line))
                {
                    if (!stringRegex.IsMatch(line)) // Nie koloruj, jeœli operator jest w cudzys³owie
                    {
                        codeBox.Select(lineStart + match.Index, match.Length);
                        codeBox.SelectionColor = Color.DarkBlue;
                    }
                }

                foreach (Match match in afterDotRegex.Matches(line))
                {
                    codeBox.Select(lineStart + match.Index + 1, match.Length - 1);
                    codeBox.SelectionColor = Color.DarkRed;
                }

                foreach (Match match in semicolonRegex.Matches(line))
                {
                    // CODE MADED BY FRANCISZEK CHMIELEWSKI
                    codeBox.Select(lineStart + match.Index, match.Length);
                    codeBox.SelectionColor = Color.Gray;
                }

                foreach (Match match in commentColorRegex.Matches(line))
                {
                    // Zaznacz ca³y tekst komentarza w tym spacje
                    codeBox.Select(lineStart + match.Index, line.Length - match.Index); // Zaznacz od `~~` do koñca linii
                    codeBox.SelectionColor = Color.DarkGreen;
                }

                lineStart += line.Length + 1;
            }

            codeBox.Select(originalSelectionStart, originalSelectionLength);
            codeBox.ResumeLayout();
        }
        // Metoda do kolorowego dodawania tekstu do konsoli
        private void AppendColoredText(string text, Color color)
        {
            // CODE MADED BY FRANCISZEK CHMIELEWSKI
            console.SelectionStart = console.TextLength;
            console.SelectionLength = 0;
            console.SelectionColor = color;
            console.AppendText(text);
            console.SelectionColor = console.ForeColor; // Przywróæ domyœlny kolor
        }

    }
    // nic tu nie dawaj!!!
    // CODE MADED BY FRANCISZEK CHMIELEWSKI
}







// CODE MADED BY FRANCISZEK CHMIELEWSKI
