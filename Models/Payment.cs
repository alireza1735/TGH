using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Models
{
    public class Payment
    {
        public int PaymentID { get; set; }
        public string UserName { get; set; }
        public Decimal TotalPrice { get; set; }
        public DateTime PaymentCreted { get; set; }
        public DateTime? PaymentPaid { get; set; }
        public DateTime? PaymentConfirmed { get; set; }
        public string TrackingCode { get; set; }

        [ScaffoldColumn(false)]
        public int PaymentTypeID { get; set; }

        [DisplayName("نوع پرداخت")]
        public PaymentType PaymentType
        {
            get { return (PaymentType)PaymentTypeID; }
            set { PaymentTypeID = (int)value; }
        }

        [DisplayName("وضعیت پرداخت")]
        [ScaffoldColumn(false)]
        public int StatusID { get; set; }
        public PaymentStatus PaymentStatus
        {
            get { return (PaymentStatus)StatusID; }
            set { StatusID = (int)value; }
        }

        [DisplayName("بانک")]
        [ScaffoldColumn(false)]
        public int BankID { get; set; }
        public Bank Bank
        {
            get { return (Bank)BankID; }
            set { BankID = (int)value; }
        }
    }

    public enum Bank
    {
        Melli,
        Passargard
    }

    public enum PaymentStatus
    {
        Pending, //Payment is created
        Done, //Money is paid
        Confirm //Admin Confirmed
    }

    public enum PaymentType
    {
        Cash,
        Credit,
        InternetBank
    }
}
