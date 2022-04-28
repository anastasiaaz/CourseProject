using CourseProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseProjectTest
{
    [TestClass]
    public class AlgorithmEncryptionTests
    {
        static List<char> allSymbols = new List<char>
        {
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
            'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И', 'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С', 'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ъ', 'Ы', 'Ь', 'Э', 'Ю', 'Я',
            'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я',
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '.', ',', '!', '?', '#', '$', '%', '^', '&', '*', '(', ')', '_', '+', '-', '=', '{', '}', '[', ']', '`', '"',
        };

        static List<char> allRusLetters = new List<char> { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я' };

        static Random random = new Random();

        [TestMethod]
        public void Test()
        {
            string key = GetRandomString(allRusLetters, 10);
            string expected = GetRandomString(allSymbols, 1000);

            string encrypted = AlgorithmEncryption.Encrypt(expected, key, true);
            string actual = AlgorithmEncryption.Encrypt(encrypted, key, false);

            Assert.AreEqual(expected, actual);
        }

        private static string GetRandomString(List<char> chars, int length)
        {
            StringBuilder stringBuilder = new StringBuilder(length - 1);
            for (int i = 0; i < length; i++)
            {
                var position = random.Next(0, chars.Count);
                stringBuilder.Append(chars[position]);
            }

            return stringBuilder.ToString();
        }
    }
}
