namespace AdoptApi.Utils;

public static class CpfCnpjUtils
{
    private static int GetSum(string acc, int[] multiplier, int size)
    {
        var sum = 0;

        for (var i = 0; i < size; i++)
            sum += int.Parse(acc[i].ToString()) * multiplier[i];
        return sum;
    }
    
    private static int GetQuotient(int sum)
    {
        var quotient = sum % 11;
        if (quotient < 2)
            quotient = 0;
        else
            quotient = 11 - quotient;
        return quotient;
    }

    public static bool IsCpf(string cpf)
    {
        var multiplier = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        var digitsMultiplier = new int[] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

        if (cpf.Length != 11)
            return false;
        
        var withoutDigits = cpf.Substring(0, 9);
        var sum = GetSum(withoutDigits, multiplier, 9);

        var quotient = GetQuotient(sum);

        var digits = quotient.ToString();
        var tempCpf = withoutDigits + digits;
        sum = GetSum(tempCpf, digitsMultiplier, 10);

        quotient = GetQuotient(sum);

        digits += quotient.ToString();

        return cpf.EndsWith(digits);
    }

    public static bool IsCnpj(string cnpj)
    {
        var multiplier = new int[] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        var digitsMultiplier = new int[] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

        if (cnpj.Length != 14)
            return false;

        var withoutDigits = cnpj.Substring(0, 12);
        var sum = GetSum(withoutDigits, multiplier, 12);

        var quotient = GetQuotient(sum);
        
        var digits = quotient.ToString();
        var tempCnpj = withoutDigits + digits;

        sum = GetSum(tempCnpj, digitsMultiplier, 13);
        quotient = GetQuotient(sum);

        digits += quotient.ToString();

        return cnpj.EndsWith(digits);
    }
}