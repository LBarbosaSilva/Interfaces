using System.Globalization;

namespace Seção_14___Interfaces.Entites
{
    class InVoice
    {
        public double basicPayment { get; set; }
        public double Tax { get; set; }

        public InVoice(double basicPaymento, double tax)
        {
            this.basicPayment = basicPaymento;
            Tax = tax;
        }

        public double TotalPayment
        {
            get { return basicPayment + Tax; }
        }


        public override string ToString()
        {
            return "Basic Payment: " + basicPayment.ToString("F2", CultureInfo.InvariantCulture)
                + "\nTax: " + Tax.ToString("F2", CultureInfo.InvariantCulture)
                +"\nTotal Payment: " + TotalPayment.ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}
