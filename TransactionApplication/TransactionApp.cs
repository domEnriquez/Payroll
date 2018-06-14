
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionApplication
{
    public abstract class TransactionApp
    {
        TransactionSource ts;


        public TransactionApp(TransactionSource ts)
        {
            this.ts = ts;
        }

        public void ExexcuteTransaction(string trName, Request r)
        {
            Transaction tr = ts.GetTransaction(trName, r);
            tr.Execute();
        }
    }
}
