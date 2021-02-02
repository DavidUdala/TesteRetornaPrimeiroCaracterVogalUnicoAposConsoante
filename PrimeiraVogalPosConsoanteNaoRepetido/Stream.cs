using System;

namespace PrimeiraVogalPosConsoanteNaoRepetido
{
    class Stream : IStream
    {
        //Texto digitado
        public char[] texto;
        //Tamanho do texto digitado
        public int tamanho;
        //Posição atual do texto digitado
        public int posAtual;

        //Construtor predefinindo as propriedades e regra para verificar se está vazio
        public Stream(string text)
        {
            if (text == null || text.Equals(""))
            {
                throw new Exception("Texto digitado não pode ser vazio");
            }
            this.texto = text.ToCharArray();
            this.tamanho = this.texto.Length;
            this.posAtual = 0;
        }

        public char getNext()
        {
            //retorna texto posição atual +1
            if (posAtual < tamanho)
                return texto[posAtual++];

            return texto[++posAtual];
        }

        public bool hasNext()
        {
            //retorna pos atual +1 enquanto for menor igual ao tamanho total 
            return posAtual + 1 <= tamanho;
        }

        public char[] getInputCompleto()
        {
            //retorna array char de todos caracteres digitados inicialmente
            return this.texto;
        }
    }
}
