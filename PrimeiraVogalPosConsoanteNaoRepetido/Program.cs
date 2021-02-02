using System;
using System.Collections.Generic;

namespace PrimeiraVogalPosConsoanteNaoRepetido
{
    class Program
    {

        static void Main(string[] args)
        {
            string continuar = "s";
            while (continuar == "S" || continuar == "s")
            {
                Console.WriteLine("\r\nDigite um texto:");
                string input = Console.ReadLine();
                string output = "";
                try
                {
                    Stream stream = new Stream(input);
                    Console.WriteLine("\r\nInput: {0}", input);

                    output = firstChar(stream).ToString();
                    if (!string.IsNullOrWhiteSpace(output))
                        Console.WriteLine("\r\nCaractere encontrado!\r\nResultado: {0}", output);
                    else
                        Console.WriteLine("\r\nCaractere não encontrado!");

                    Console.WriteLine("\r\nDeseja continuar procurando?(S/N)");
                    continuar = Console.ReadLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static char firstChar(IStream input)
        {
            Dictionary<char, int> dicioContadorChar = new Dictionary<char, int>();
            char primeiraVogalQueNaoRepetePosConsoante = ' ';
            char caracterAnteriorAVogalUnica = ' ';

            //Cria um dicionario com as vogais onde a key é o caractere e value é a quantidade de vezes que ela aparece
            while (input.hasNext())
            {
                char caractere = input.getNext();

                if (dicioContadorChar.TryGetValue(caractere, out int count))
                {
                    dicioContadorChar.Remove(caractere);
                    dicioContadorChar.Add(caractere, ++count);
                }
                else
                    dicioContadorChar.Add(caractere, 1);
            }

            //Verifica quais caracteres vogais do dicionarios estão com value 1 que é a quantidade de vezes que ele aparece no caso unico
            foreach (char caracter in dicioContadorChar.Keys)
            {
                int i = 0;
                dicioContadorChar.TryGetValue(caracter, out int value);
                if (value == 1 && isVogal(caracter))
                {
                    //Busca a posição inicial dentro da string desse caractere vogal unico
                    foreach (char vowalUnique in input.getInputCompleto())
                    {
                        if (vowalUnique == caracter)
                        {
                            //Recebe caracter anterior a posição inicial do caracter vogal unico
                            caracterAnteriorAVogalUnica = (Char)input.getInputCompleto().GetValue(i - 1);
                            break;
                        }
                        ++i;
                    }

                    //Verifica se é uma consoante
                    if (isConsoant(caracterAnteriorAVogalUnica))
                    {
                        //Se for consoante retorna o valor da primeira vogal que não se repete em que o anterior é uma consoante
                        primeiraVogalQueNaoRepetePosConsoante = caracter;
                        break;
                    }
                }
            }

            return primeiraVogalQueNaoRepetePosConsoante;
        }

        //Verifica se é vogal
        public static bool isVogal(char caractere)
        {
            string vogais = "aeiouAEIOU";

            if (vogais.IndexOf(caractere) > -1)
            {
                return true;
            }

            return false;
        }
        //Verifica se é consoante
        public static bool isConsoant(char caractere)
        {                                  //Verifica se é letra do alfabeto usando tabela ASCII
            return !isVogal(caractere) && (caractere >= 'A' && caractere <= 'Z' || caractere >= 'a' && caractere <= 'z');
        }

    }
}
