namespace PrimeiraVogalPosConsoanteNaoRepetido
{
    interface IStream
    {
        char getNext();
        bool hasNext();
        char[] getInputCompleto();
    }
}
