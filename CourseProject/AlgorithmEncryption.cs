using System.Collections.Generic;
using System.Linq;

namespace CourseProject
{
    public class AlgorithmEncryption
    {
        static List<char> alphabetDown = new List<char> { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я' };
        static List<char> alphabetUp = new List<char> { 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И', 'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С', 'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ъ', 'Ы', 'Ь', 'Э', 'Ю', 'Я' };

        public static string Encrypt(string toEncrypt, string key, bool encrypt = true)
        {
            string result = string.Empty;

            var steps = GetSteps(key, toEncrypt.Length);
            var i = 0;

            foreach (var symbol in toEncrypt)
            {
                var step = steps[i];

                if (!encrypt)
                {
                    step = -step;
                }

                if (alphabetUp.Contains(symbol))
                {
                    int pozitionUp = alphabetUp.IndexOf(symbol) + step;

                    if (pozitionUp < 0)
                    {
                        pozitionUp %= 33;
                        pozitionUp += alphabetUp.Count;
                    }

                    if (pozitionUp >= 33)
                    {
                        pozitionUp %= 33;
                    }

                    result += alphabetUp.ElementAt(pozitionUp);
                    i++;
                }
                else if (alphabetDown.Contains(symbol))
                {
                    int pozitionDown = alphabetDown.IndexOf(symbol) + step;

                    if (pozitionDown < 0)
                    {
                        pozitionDown %= 33;
                        pozitionDown += alphabetDown.Count;
                    }

                    if (pozitionDown >= 33)
                    {
                        pozitionDown %= 33;
                    }

                    result += alphabetDown.ElementAt(pozitionDown);
                    i++;
                }
                else
                {
                    result += symbol;
                }
            }
            return result;
        }

        private static List<int> GetSteps(string key, int stringLength)
        {
            key = key.Replace(" ", "").ToLower();

            var stepsByKey = new List<int>();

            foreach (var symbol in key)
            {
                if (alphabetDown.Contains(symbol))
                {
                    stepsByKey.Add(alphabetDown.IndexOf(symbol));
                }
            }

            var steps = new List<int>();

            for (int i = 0; i < stringLength / stepsByKey.Count + 1; i++)
            {
                steps.AddRange(stepsByKey);
            }

            return steps.Take(stringLength).ToList();
        }
    }
}
