namespace Practice;

public class Bill
{
    public static int GetRatesPerKwh(int group)
    {
        int rates;
        switch (group)
        {
            case 1:
                rates = 1350;
                break;
            case 2:
                rates = 1450;
                break;
            case 3:
                rates = 1500;
                break;
            default:
                rates = 0;
                break;
        }
        return rates;
    }


    public static float TotalBill(int bill)
    {
        const float percentTax = 1.03f;
        const int adminFee = 2500;

        float totalBill = (bill * percentTax) + adminFee;
        return totalBill;
    }

    public static string UsageCategory(int kwh)
    {
        switch (kwh)
        {
            case < 100:
                return "Hemat";
            case < 300:
                return "Normal";
            default:
                return "Boros";
        }
    }
}
