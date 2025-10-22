using System;
using System.Linq;
using System.Text.RegularExpressions;
using Patterns.Proxy.PaymentMethods;

namespace Patterns.Proxy.PaymentOperationProviders
{
    public class CardOperationValidator : IPaymentOperationValidator<Card>
    {
        private readonly Regex _numbersFilter = new Regex("[0-9]");
        public bool ValidatePayment(Card card)
        {
            if (!ValidateCardNumber(card.Number))
            {
                Console.Out.WriteLine("Validation Failed! Card with given number does not exist!");
                return false;
            }

            if (!ValidateExpirationDate(card.ExpirationDate))
            {
                Console.Out.WriteLine("Validation Failed! Card expired!");
                return false;
            }
            
            Console.Out.WriteLine("Validation Complete!");
            return true;
        }

        public bool ValidatePayment(PaymentMethod paymentMethod) => ValidatePayment((Card) paymentMethod);

        private bool ValidateCardNumber(string cardNumber)
        {
            string digitsString;
            if (TryFilterDigits(cardNumber, out digitsString))
            {
                return IsLuhnValid(digitsString);
            }

            return false;
        }

        private bool ValidateExpirationDate(string expirationDate)
        {
            string digitsString;
            if (TryFilterDigits(expirationDate, out digitsString))
            {
                return IsDateValid(digitsString);
            }

            return false;
        }

        private bool TryFilterDigits(string data, out string digitsString)
        {
            digitsString = String.Empty;
            if (string.IsNullOrEmpty(data)) return false;
            
            digitsString = string.Concat(_numbersFilter.Matches(data).Select(match => match.Value));
            Console.Out.WriteLine($"digitsString = {digitsString}");
            
            if (string.IsNullOrEmpty(digitsString)) return false;
            return true;
        }

        private bool IsLuhnValid(string number)
        {
            try
            {
                int sum = number.Reverse().Select((digitChar, index) =>
                {
                    int digit = int.Parse(digitChar.ToString());
                    if (index % 2 == 1)
                    {
                        digit *= 2;
                        if (digit > 9)
                        {
                            digit -= 9;
                        }
                    }

                    return digit;
                }).Sum();

                return sum % 10 == 0;
            }
            catch (Exception e)
            {
                if (e is FormatException || e is OverflowException)
                {
                    Console.Out.WriteLine("Validation Failed! Card number parse exception!" + e.Message);
                    return false;
                }

                throw;
            }
            
        }

        private bool IsDateValid(string digitsString)
        {
            if (digitsString.Length != 4) return false;
            
            DateTime currentDate = DateTime.Now;

            int month;
            int year;

            try
            {
                month = int.Parse(digitsString[0].ToString()) * 10 + int.Parse(digitsString[1].ToString());
                year = int.Parse(digitsString[2].ToString()) * 10 + int.Parse(digitsString[3].ToString());
            }
            catch (Exception e)
            {
                if (e is FormatException || e is OverflowException)
                {
                    Console.Out.WriteLine("Validation Failed! Expiration date parse exception!\n" + e.Message);
                    return false;
                }

                throw;
            }

            DateTime expirationDate;
            
            try
            {
                expirationDate = new DateTime(2000 + year, month, 1);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Out.WriteLine("Validation Failed! Wrong date format!\n" + e.Message);
                return false;
            }

            return currentDate.CompareTo(expirationDate) <= 0;
        }
    }
}