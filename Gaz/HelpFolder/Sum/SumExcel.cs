using Gaz.Data;
using SerGaz.Controllers;

namespace Gaz.HelpFolder.Sum
{
    public class SumExcel
    {
            DateTime now = DateTime.Now;
        private readonly freedb_testdbgazContext _context;
        private readonly PollsController pollsController;
        private readonly GetSum getSum;

        public SumExcel(freedb_testdbgazContext context)
        {
            _context = context;
            pollsController = new PollsController(_context);
            getSum = new GetSum(_context);
        }
        public void GetListsForSumExcel()
        {
            int year = now.Year;
            pollsController.GetPolls();
            pollsController.GetPollsForExcel1(year);
            pollsController.GetPollsForExcel2(year);
            pollsController.GetPollsForExcel3(year);
            pollsController.GetPollsForExcel4(year);
        }

        public async Task<int> GetSumE(int userId, int quarter)
        {
            int score = await getSum.GetSumBigMark(userId, quarter, 2);
            return score;
        }


        public int GetSumF(int userId, int quarter)
        {
            int score = getSum.GetSumBigMark(userId, quarter, 3).Result;
            return score;
        }
        public int GetSumG(int userId, int quarter)
        {
            int score = getSum.GetSumYesNo(userId, quarter, 4).Result;
            return score;
        }
        public int GetSumI(int userId, int quarter)
        {
            int score = getSum.GetSumYesNo(userId, quarter, 6).Result;
            return score;
        }
        public int GetSumJ(int userId, int quarter)
        {
            int score = getSum.GetSumYesNo(userId, quarter, 12).Result;
            return score;
        }
        public int GetSumK(int userId, int quarter)
        {
            int score = getSum.GetSumYesNo(userId, quarter, 7).Result;
            return score;
        }
        public int GetSumL(int userId, int quarter)
        {
            int score = getSum.GetSumYesNo(userId, quarter, 8).Result;
            return score;
        }
        public int GetSumM(int userId, int quarter)
        {
            int score = getSum.GetSumYesNo(userId, quarter, 9).Result;
            return score;
        }
        public int GetSumN(int userId, int quarter)
        {
            int score = getSum.GetSumYesNo(userId, quarter, 10).Result;
            return score;
        }
        public int GetSumO(int userId, int quarter)
        {
            int score = getSum.GetSumYesNo(userId, quarter, 11).Result;
            return score;
        }
    }
}
