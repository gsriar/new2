using System.Data;

namespace TransactionUtility.TransactionTool
{
    public interface IPersistDataObject
    {
        void CreatePersistTable();

        void PersistData(DataTable inDataTable);

        DataTable GetPersistData();
    }
}