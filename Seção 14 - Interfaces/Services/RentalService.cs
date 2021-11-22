using System;
using Seção_14___Interfaces.Entites;

namespace Seção_14___Interfaces.Services
{
    class RentalService
    {
        public double PricePorHour { get; private set; }
        public double PricePorDay { get; private set; }

        private ITaxService _taxService;

        public RentalService(double pricePorHour, double pricePorDay, ITaxService taxService)
        {
            PricePorHour = pricePorHour;
            PricePorDay = pricePorDay;
            _taxService = taxService;
        }

        public void ProcessInVoice(CarRental carRental)
        {
            TimeSpan duration = carRental.Finish.Subtract(carRental.Start);

            double basicPayment = 0.0;
            if (duration.TotalHours <= 12.0)
            {
                basicPayment = PricePorHour * Math.Ceiling(duration.TotalHours);
            }
            else
            {
                basicPayment = PricePorDay * Math.Ceiling(duration.TotalDays);
            }

            double tax = _taxService.Tax(basicPayment);
            carRental.Invoice = new InVoice(basicPayment, tax);
        }
    }
}
