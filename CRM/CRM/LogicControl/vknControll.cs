using System;

namespace CRM.LogicControl
{
    public class vknControll
    {
        public static bool IsVKNV(string vkn)
        {
            if (!string.IsNullOrEmpty(vkn) && vkn.Length == 10 && IsInt(vkn))
            {
                int sum = 0;
                int lastDigit = int.Parse(vkn[9].ToString());

                for (int i = 0; i < 9; i++)
                {
                    int digit = int.Parse(vkn[i].ToString());
                    int tmp = (digit + 10 - (i + 1)) % 10;

                    sum += tmp == 9 ? tmp : (int)((tmp * (Math.Pow(2, 10 - (i + 1)))) % 9);
                }

                return lastDigit == (10 - (sum % 10)) % 10;
            }
            return false;
        }

        private static bool IsInt(string s)
        {
            if (string.IsNullOrEmpty(s))
                return false;

            for (int i = 0; i < s.Length; i++)
            {
                if (i == 0 && s[i] == '-') continue; // Negatif kontrolü (gerekliyse)
                if (!char.IsDigit(s[i])) return false;
            }

            return true;
        }

    }
}
