namespace RestWithASPNETUdemy.IServices
{
    public interface IPersonSerevice
    {
        decimal ConvertToDecimal(string strNumber);

        double ConvertToDouble(string strNumber);

        bool IsNumeric(string strNumber);

        bool IsEqualZero(string strNumber);
    }
}
