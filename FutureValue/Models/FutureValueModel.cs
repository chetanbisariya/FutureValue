
using System.ComponentModel.DataAnnotations;
using System;

namespace FutureValue.Models
{
    public class FutureValueModel
    {
        [EmailAddress(ErrorMessage = "Please enter your Email Address ")]
        public string Email { get; set; }

        [Phone(ErrorMessage = "Please enter your Phone Number ")]
        public int Phone { get; set; }

        [MaxLength(20, ErrorMessage = "Please enter your Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a Periodic Monthly Investment (Pmt)")]
        [Range(1, 500, ErrorMessage =
               "Monthly investment amount must be between 1 and 500.")]
        public decimal? PeriodicPayment { get; set; }

        [Required(ErrorMessage = "Please enter a yearly interest rate.")]
        [Range(0.1, 10.0, ErrorMessage =
               "Yearly interest rate must be between 0.1 and 10.0.")]
        public decimal? DiscountRate { get; set; }

        [Required(ErrorMessage = "Please enter a number of years.")]
        [Range(1, 50, ErrorMessage =
               "Number of years must be between 1 and 50.")]
        public int? NumberOfPeriods { get; set; }

        public decimal? CalculateFutureValue()
        {
            decimal? FutureValue;
            decimal? FinalRate = 1 + DiscountRate;
            decimal? TothePower = (decimal)Math.Pow((double)FinalRate, (double)NumberOfPeriods);

            {

                FutureValue = (PeriodicPayment * (TothePower - 1)) / DiscountRate;
            }
            return FutureValue;
        }
    }
}