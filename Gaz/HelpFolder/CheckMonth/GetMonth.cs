namespace Gaz.HelpFolder.CheckMonth
{
    public class GetMonth
    {
        public string GetMonths(int month)
        {
            string monthName = new DateTime(2023, month, 1).ToString("MMMM");
            monthName = char.ToUpper(monthName[0]) + monthName.Substring(1);
            return monthName;
        }
    }
}
