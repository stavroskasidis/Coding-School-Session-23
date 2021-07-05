using System;

namespace MyClassLibrary
{
    public class VATCalculator
    {
        public decimal CalculateTotalValue(decimal netValue, decimal vatPercentage)
        {
            if (netValue <= 0) throw new ArgumentException("netValue cannot be below zero", nameof(netValue));
            if (vatPercentage < 0 || vatPercentage >= 1) throw new ArgumentException("vat percentage cannot be below zero and above 1", nameof(vatPercentage));

            return netValue * (1 + vatPercentage);
        }

        public decimal CalculateNetValue(decimal totalValue, decimal vatPercentage)
        {
            if (vatPercentage < 0 || vatPercentage >= 1) throw new ArgumentException("vat percentage cannot be below zero and above 1", nameof(vatPercentage));
            return totalValue / (1 + vatPercentage);
        }
    }
}
