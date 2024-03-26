using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCourseUtils
{
    public class StringUtils
    {
        public static string Reverse(string s)
        {
            string newString = "";
            for (int i = s.Length - 1; i >= 0; i--)
            {
                newString += s[i];
            }
            return newString;
        }

        public static bool IsPalindrome(string word)
        {
            bool isPalindrome = false;
            string reversedword = Reverse(word);
            if (word == reversedword)
            {
                isPalindrome = true;
            }
            return isPalindrome;
        }

        public static bool isPalindrome_2(string s)
        {
            for (int i = 0; i < s.Length/2; i++)
            {
                if (s[i] != s[s.Length -1 - i])
                {
                    return false;
                }
            }
            return true;
        }

        public static string ExtractVowels(string word)
        {
            StringBuilder vowels = new StringBuilder();

            // Convertimos la cadena a minúsculas para hacer la comparación más fácil
            word = word.ToLower();

            // Recorremos cada caracter de la cadena
            foreach (char character in word)
            {
                // Verificamos si el caracter es una vocal
                if (isVowel(character))
                {
                    vowels.Append(character);
                }
            }

            return vowels.ToString();
        }

        public static bool isVowel(char c)
        {
            // Definimos un arreglo de caracteres que representan las vocales
            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };

            // Verificamos si el carácter está contenido en el arreglo de vocales
            foreach (char vowel in vowels)
            {
                if (c == vowel)
                {
                    return true;
                }
            }
            return false;
        }

        public static string ExtractConsonants(string word)
        {
            StringBuilder consonants = new StringBuilder();

            // Convertimos la cadena a minúsculas para hacer la comparación más fácil
            word = word.ToLower();

            // Recorremos cada caracter de la cadena
            foreach (char c in word)
            {
                // Verificamos si el caracter no es una vocal
                if (!isVowel(c))
                {
                    consonants.Append(c);
                }
            }

            return consonants.ToString();
        }

        public static (string, string) ExtractVowelsAndConsonants(string word)
        {
            StringBuilder vowels = new StringBuilder();
            StringBuilder consonants = new StringBuilder();

            // Convertimos la cadena a minúsculas para hacer la comparación más fácil
            word = word.ToLower();

            // Recorremos cada caracter de la cadena
            foreach (char c in word)
            {
                // Verificamos si el caracter es una vocal
                if (isVowel(c))
                {
                    vowels.Append(c);
                }
                else // Si no es una vocal, es una consonante
                {
                    consonants.Append(c);
                }
            }

            return (vowels.ToString(), consonants.ToString());
        }

        //public static string Reverse(string s)
        //{
        //    string result = string.Empty;
        //    for (int i = s.Length - 1; i >= 0; --i)
        //    {
        //        result += s[i];
        //    }
        //    return result;
        //}

        //public static string Reverse2(string s)
        //{
        //    char[] chars = new char[s.Length];

        //    for (int i = 0; i < s.Length; i++)
        //    {
        //        chars[i] = s[s.Length - i - 1];
        //    }
        //    return new string(chars);
        //}

        //public static bool IsPalindrome1(string s) =>
        //    s == Reverse2(s);

        //public static bool IsPalindrome2(string s)
        //{   // len = 7
        //    //   0 1 2 3 4 5 6
        //    //   o t t e t t o

        //    // 0 1 2 3 
        //    // a b b a

        //    for (int i = 0; i < s.Length / 2; i++)
        //    {
        //        if (s[i] != s[s.Length - 1 - i])
        //        {
        //            return false;
        //        }
        //    }
        //    return true;
        //}


    }
}
