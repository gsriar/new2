using System;

namespace TransactionUtility.TransactionTool
{
    public interface IWriter
    {
        void Dispose();
        void Write(string text);
    }
}