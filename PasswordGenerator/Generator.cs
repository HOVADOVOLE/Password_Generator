using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PasswordGenerator
{
    internal class Generator
    {
        private readonly Random rnd = new Random();
        private readonly char[] letters = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
        private readonly char[] specialSymbols = "!@#$%^&*()_+{}[]".ToCharArray();
        private readonly List<char> passwordChars = new List<char>();

        public Generator(bool upper, bool number, bool symbol, bool save, int passLength, Label label)
        {
            passwordChars.Clear();
            List<char> decisionChars = Filter(upper, number, symbol);

            for (int i = 0; i < passLength; i++)
            {
                char randomChar = decisionChars[rnd.Next(0, decisionChars.Count)];
                passwordChars.Add(randomChar);
            }

            string password = new string(passwordChars.ToArray());

            if (save)
            {
                string destPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "passwords.txt");
                using (FileStream fs = new FileStream(destPath, FileMode.Append, FileAccess.Write))
                using (StreamWriter writer = new StreamWriter(fs))
                {
                    writer.WriteLine(password);
                }
            }

            label.Text = $"Your password is: {password}";
        }

        private List<char> Filter(bool upper, bool number, bool symbol)
        {
            List<char> decisionChars = new List<char>();
            if (upper)
            {
                decisionChars.AddRange(letters.Where(c => char.IsUpper(c)));
            }
            if (number)
            {
                decisionChars.AddRange(Enumerable.Range('0', 10).Select(c => (char)c));
            }
            if (symbol)
            {
                decisionChars.AddRange(specialSymbols);
            }
            decisionChars.AddRange(letters);
            return decisionChars;
        }
    }
}