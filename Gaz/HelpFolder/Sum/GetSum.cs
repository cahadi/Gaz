using Gaz.Data;
using SerGaz.Controllers;
using System.Drawing;

namespace Gaz.HelpFolder.Sum
{
    public class GetSum
    {
        private readonly freedb_testdbgazContext _context;
        private readonly PollsController pollsController;
        public GetSum(freedb_testdbgazContext context)
        {
            _context = context;
            pollsController = new PollsController(_context);
        }

        public async Task<int> GetSumBigMark(int userId, int quarter, int estiMarkId)
        {
            int? poll = 0;
            int score = 0;

            await pollsController.GetPollForExcel(quarter, userId, estiMarkId);
            var pollFirstM = await pollsController.GetPollForExcelFirst(quarter);
            var pollSecondM = await pollsController.GetPollForExcelSecond(quarter);
            var pollThirdM = await pollsController.GetPollForExcelThird(quarter);
            
            for (int i = 0; i < 3; i++)
            {
                if (i == 0)
                    poll = pollFirstM.EstimationsMarks.Mark.BigMark;
                else if (i == 1)
                    poll = pollSecondM.EstimationsMarks.Mark.BigMark;
                else if (i == 2)
                    poll = pollThirdM.EstimationsMarks.Mark.BigMark;

                if(estiMarkId == 2)
                {
                    switch (poll)
                    {
                        case 5:
                            score += 1;
                            break;
                        case 10:
                            score += 2;
                            break;
                        case 15:
                            score += 3;
                            break;
                        case 20:
                            score += 4;
                            break;
                    }
                }

                else if(estiMarkId == 3)
                {
                    var p = 1 / 2;
                    switch (poll)
                    {
                        case 5:
                            score += p;
                            break;
                        case 10:
                            score += 1;
                            break;
                        case 20:
                            score += 2;
                            break;
                    }
                }
            }
            return score;
        }

        public async Task<int> GetSumYesNo(int userId, int quarter, int estiMarkId)
        {
            string poll = "";
            int score = 0;

            await pollsController.GetPollForExcel(quarter, userId, estiMarkId);
            var pollFirstM = await pollsController.GetPollForExcelFirst(quarter);
            var pollSecondM = await pollsController.GetPollForExcelSecond(quarter);
            var pollThirdM = await pollsController.GetPollForExcelThird(quarter);

            int p = 1 / 2;
            for(int i = 0; i < 3; i++)
            {
                if (i == 0)
                    poll = pollFirstM.EstimationsMarks.Mark.YesNo;
                else if (i == 1)
                    poll = pollSecondM.EstimationsMarks.Mark.YesNo;
                else if (i == 2)
                    poll = pollThirdM.EstimationsMarks.Mark.YesNo;

                if(estiMarkId == 4 || 
                    estiMarkId == 6 ||
                    estiMarkId == 12 ||
                    estiMarkId == 7 ||
                    estiMarkId == 8)
                {
                    switch (poll)
                    {
                        case "Да":
                            score += 1;
                            break;
                        case "Нет":
                            score += 0;
                            break;
                    }
                }
                else if(estiMarkId == 9 ||
                    estiMarkId == 10 ||
                    estiMarkId == 11)
                {
                    
                    switch (poll)
                    {
                        case "да":
                            score += p;
                            break;
                        case "Да":
                            score += 1;
                            break;
                        case "Нет":
                            score += 0;
                            break;
                    }
                }
            }
            return score;
        }
    }
}
