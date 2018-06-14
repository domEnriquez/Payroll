

namespace TransactionApplication
{
    public interface TransactionSource
    {
        Transaction GetTransaction(string trName, Request r);
    }
}
