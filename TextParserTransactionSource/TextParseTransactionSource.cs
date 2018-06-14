
using TransactionApplication;
using TF = TransactionFactory;

namespace TextParserTransactionSource
{
    public class TextParseTransactionSource : TransactionSource
    {
        private TF.TransactionFactory tf;


        public TextParseTransactionSource(TF.TransactionFactory tf)
        {
            this.tf = tf;
        }

        public Transaction GetTransaction(string trName, Request request)
        {
            if (trName == "addCommissionedEmployee")
            {
                return tf.MakeAddCommisionedEmployee(request);
            }
            else if (trName == "addHourlyEmployee")
            {
                return tf.MakeAddHourlyEmployee(request);
            } 
            else if (trName == "addSalariedEmployee")
            {
                return tf.MakeAddSalariedEmployee(request);
            }
            else if(trName == "deleteEmployee")
            {
                return tf.MakeDeleteEmployee(request);
            }
            else if(trName == "addTimeCard")
            {
                return tf.MakeAddTimeCard(request);
            }
            else if (trName == "addSalesReceipt")
            {
                return tf.MakeAddSalesReceipt(request);
            }
            else if (trName == "addServiceCharge")
            {
                return tf.MakeAddServiceCharge(request);
            }
            //else if (trName == "changeCommissioned")
            //{
            //    return tf.MakeChangeCommissioned(request);
            //}
            //else if (trName == "changeDirectMethod")
            //{
            //    return tf.MakeChangeDirectMethod(request);
            //}
            //else if (trName == "changeHoldMethod")
            //{
            //    return tf.MakeChangeHoldMethod(request);
            //}
            //else if (trName == "changeHourly")
            //{
            //    ChangeHourlyRequest r = request as ChangeHourlyRequest;
            //    return tf.MakeChangeHourly();
            //}
            else
                return null;

            //to be continued


        }
    }
}
