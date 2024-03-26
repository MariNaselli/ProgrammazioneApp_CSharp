using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole.Tests
{
    public class PrimitiveTypesSizeTests
    {
        [Fact] //atributo, es un test metod//  indica que el método es una prueba unitaria
        public void SizeOf_int_should_be_4()
        {
            //int intSize = sizeof(int); //me retorna el numero de byte del tipo que paso
            ushort intSize = sizeof(int);
            Assert.Equal(4, intSize); //Las afirmaciones son declaraciones que verifican que el resultado obtenido es el esperado. Assert.Equal(expected, actual)
        }

        [Fact]
        public void Size_short_should_be_2()
        {

            ushort size = sizeof(short);
            Assert.Equal(2, size);
        }

        [Fact]
        public void Size_bool_should_be_2()
        {

            ushort size = sizeof(bool);
            Assert.Equal(1, size);
        }

        [Fact]
        public void Size_double_should_be_2()
        {

            ushort size = sizeof(double);
            Assert.Equal(8, size);
        }

        [Fact]
        public void Sum_of_decimal_point_one_for_ten_times_should_be_one()
        {
            decimal sum = 0m;
            for (int i = 1; i <= 10; i++)
            {
                sum += 0.1m;
            }
            Assert.Equal(1, sum);
        }

        [Fact]
        public void Sum_of_zero_point_one_for_ten_times_should_be_one_precision()
        {
            double sum = 0d;
            for (int i = 1; i <= 10; i++)
            {
                sum += 0.1d;
            }
            Assert.Equal(1.0, sum, 5);
        }

        [Fact]
        public void String_are_immutable_obj()
        {
            string s = "Hello World";

            // Replace retorna una nueva cadena con los caracteres reemplazados
            string s2 = s.Replace('l', ' ');

            // La cadena original 's' no ha cambiado
            Assert.NotEqual("He  o Wor d", s);

            // La cadena original 's' sigue siendo "Hello World"
            Assert.Equal("Hello World", s);

            // La cadena modificada 's2' es "He  o Wor d"
            Assert.Equal("He  o Wor d", s2);

            // Trim() crea una nueva cadena en lugar de modificar la cadena original
            string s3 = "   hello   ";
            s3 = s3.Trim();


        }



    }
}
