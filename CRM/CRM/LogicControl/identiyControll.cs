namespace CRM.LogicControl
{
    public class identiyControll
    {
        public static bool IsValidIdentity(string IdNo)
        {
            if (!string.IsNullOrEmpty(IdNo))
            {
                string idStr = IdNo.ToString();
                if (idStr.Length != 11 || idStr[0] == '0')
                    return false;

                int sumOdd = 0, sumEven = 0;
                for (int i = 0; i < 9; i++)
                {
                    int digit = idStr[i] - '0';
                    if (i % 2 == 0)
                        sumOdd += digit;
                    else
                        sumEven += digit;
                }

                int tenthDigit = ((sumOdd * 7) - sumEven) % 10;
                int eleventhDigit = (sumOdd + sumEven + tenthDigit) % 10;

                return tenthDigit == (idStr[9] - '0') && eleventhDigit == (idStr[10] - '0');
            }
            else
            {
                return false;
            }

        }
    }
}
