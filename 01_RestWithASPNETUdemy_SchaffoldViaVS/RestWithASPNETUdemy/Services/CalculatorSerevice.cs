using RestWithASPNETUdemy.IServices;

namespace RestWithASPNETUdemy.Services
{
    public class CalculatorSerevice : IPersonSerevice
    {
        public decimal ConvertToDecimal(string strNumber)
        {
            decimal decimalValue;
            if (decimal.TryParse(
                strNumber, 
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo, 
                out decimalValue))
            {
                return decimalValue;
            }
            return 0;
        }

        public double ConvertToDouble(string strNumber)
        {
            double doubleValue;
            if (double.TryParse(
                strNumber,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out doubleValue))
            {
                return doubleValue;
            }
            return 0;
        }

        public bool IsEqualZero(string strNumber)
        {
            bool isZero = false;
            decimal decimalValue;
            decimal.TryParse(
                strNumber,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out decimalValue);

            isZero = decimalValue == 0;

            return isZero;
        }

        public bool IsNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(
                strNumber,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out number);
            return isNumber;
        }
    }
}
