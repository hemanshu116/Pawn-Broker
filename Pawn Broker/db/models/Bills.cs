using System;
using System.Data.SQLite;
using Pawn_Broker.constants;

namespace Pawn_Broker.db.models
{
    public class Bills : AbstractDataModel
    {
        private string Address;
        private string BillNo;
        private DateTime Date;
        private int FinalAmount;
        private int GrossGm;
        private int GrossMg;
        private string MobileNumber;
        private string NameOfPawner;
        private int PresentValue;
        private long principle;

        public override void SetFields(SQLiteDataReader reader)
        {
            Address = reader[Global.ADDRESS] as string;
            BillNo = reader[Global.BILLNO] as string;
            Date = (DateTime) reader[Global.DATE];
            FinalAmount = (int) reader[Global.FINALAMOUNT];
            GrossGm = (int) reader[Global.GROSSGM];
            GrossMg = (int) reader[Global.GROSSMG];
            MobileNumber = reader[Global.MOBILENUMBER] as string;
            NameOfPawner = reader[Global.NAMEOFPAWNER] as string;
            PresentValue = (int) reader[Global.PRESENTVALUE];
            principle = (long) reader[Global.PRINCIPLE];
        }
        public override string ToString()
        {
            return
                $"BillNo: {BillNo}, Date: {Date}, NameOfPawner: {NameOfPawner}, Address: {Address}, MobileNumber: {MobileNumber}, Principle: {principle}, GrossGm: {GrossGm}, GrossMg: {GrossMg}, PresentValue: {PresentValue}, FinalAmount: {FinalAmount}";
        }
    }
}