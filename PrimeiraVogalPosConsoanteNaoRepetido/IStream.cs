namespace PrimeiraVogalPosConsoanteNaoRepetido
{
    public interface IStream
    {
        char getNext();
        bool hasNext();
        char[] getInputCompleto();
    }
}
