namespace SeriesA;


// Condiiton, evaluasi boolean berdasarkan syarat/kondisi
// if 
// switch
internal class ECondition
{
    public static void ifCondition()
    {
        bool isActive = true;
        float gpa = 3.7f;
        float studyPeriod = 5;

        // if (kondisi
        // {
        //      statement
        // }
        if (isActive)
        {
            Console.WriteLine("Aktif");
        }
        else
        {
            Console.WriteLine("Tidak Aktif");
        }

        if (gpa > 3.9f & studyPeriod < 4)
        {
            Console.WriteLine("Summa Cumlaude");
        }
        else if (gpa < 3.5f & studyPeriod < 4)
        {
            Console.WriteLine("Cummlaude");
        }
        else
        {
            Console.WriteLine("Lulus");
        }

        if (studyPeriod < 4)
        {
            if (gpa < 3.9f)
            {
                Console.WriteLine("Summa Cumlaude");
            }
            else if (gpa < 3.5f)
            {
                Console.WriteLine("Cummlaude");
            }

        }
        else if (studyPeriod == 4)
        {
            Console.WriteLine("lulus");
        }
        else
        {
            Console.WriteLine("Sedikit Terlambat");
        }
    }


    public static void SwitchCondition()
    {
        int month = 5;
        string monthName;

        switch (month) // CONDITION harus kondisi yang pasti, berbeda dengan IF
        {
            case 1:
                monthName = "January";
                break;
            case 2:
                monthName = "February";
                break;
            case 3:
                monthName = "March";
                break;
            case 4:
                monthName = "April";
                break;
            case 5:
                monthName = "May";
                break;
            case 6:
                monthName = "June";
                break;
            case 7:
                monthName = "July";
                break;
            case 8:
                monthName = "August";
                break;
            case 9:
                monthName = "September";
                break;
            case 10:
                monthName = "October";
                break;
            case 11:
                monthName = "November";
                break;
            case 12:
                monthName = "December";
                break;
            default:
                monthName = "N/A";
                break;
        }

        Console.WriteLine(monthName);
    }

}

