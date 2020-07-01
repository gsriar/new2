using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionUtility.TransactionTool
{
    abstract class PersistedDataObject : IPersistDataObject
    {
        public PersistedDataObject(SQLContext context, DataObjectContext dataobjContext)
        {

        }
        public void CreatePersistTable()
        {
            throw new NotImplementedException();
        }

        public DataTable GetPersistData()
        {
            throw new NotImplementedException();
        }

        public void PersistData(DataTable inDataTable)
        {
            throw new NotImplementedException();
        }
    }
}
