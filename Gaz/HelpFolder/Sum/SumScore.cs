using Gaz.Data;
using Gaz.Domain.Entities;
using SerGaz.Controllers;

namespace Gaz.HelpFolder.Sum
{
    public class SumScore
    {
        private readonly freedb_testdbgazContext _context;
        private readonly ScoresController scoresController;
        private readonly PollsController pollsController;
        public SumScore(freedb_testdbgazContext context)
        {
            _context = context;
            scoresController = new ScoresController(_context);
            pollsController = new PollsController(_context);
        }
        // переделать подсчёт
        // для Аппарата отделные формулы
        // параметр coeff только для Аппарата
        // через параметр name опряделяется способ подсчёта

        // не забудь поднять Аппарат вверх списка
        public async Task<Score> Score(int userId, int month, int year, string name, int coeff)
        {
            Score score = null;
            score = scoresController.GetScoreByDetail(userId, month, year);
            if (score != null)
            {
                Score sc = null;
                int mo = month == 1 ? 12 : month - 1;
                if (mo != 0) sc = scoresController.GetScoreByDetail(userId, mo, year);
                if (month == 1) score.FinalScore = score.MonthScore;
                else
                {
                    if (sc == null) sc = new Score { MonthScore = 0 };
                    score.FinalScore = score.MonthScore + sc.MonthScore;
                }
                await scoresController.PutScore(score.Id, score);
            }
            else
            {
                int monthScore = 0;
                List<Poll> polls = await pollsController.GetPollsByDetail(userId, month, year);
                if (polls.Count() != 0)
                {
                    var poll1 = await pollsController.GetPollByMoreDetail(1);
                    var poll2 = await pollsController.GetPollByMoreDetail(2);
                    var poll3 = await pollsController.GetPollByMoreDetail(3);
                    var poll4 = await pollsController.GetPollByMoreDetail(4);
                    var poll5 = await pollsController.GetPollByMoreDetail(5);
                    var poll6 = await pollsController.GetPollByMoreDetail(6);
                    var poll7 = await pollsController.GetPollByMoreDetail(7);
                    var poll8 = await pollsController.GetPollByMoreDetail(8);
                    var poll9 = await pollsController.GetPollByMoreDetail(9);
                    var poll10 = await pollsController.GetPollByMoreDetail(10);
                    var poll11 = await pollsController.GetPollByMoreDetail(11);
                    var poll12 = await pollsController.GetPollByMoreDetail(12);

                    if (poll1 != null && poll5 != null && poll1.EstimationsMarks.Mark.YesNo == "Да" && poll5.EstimationsMarks.Mark.LowMark == 1)
                    {
                        monthScore = monthScore + 15;
                    }
                    else if(poll1 != null && poll5 != null && poll1.EstimationsMarks.Mark.YesNo == "Да" && poll5.EstimationsMarks.Mark.LowMark == 1.1)
                    {
                        monthScore = monthScore + 21;
                    }
                    else if (poll1 != null && poll5 != null && poll1.EstimationsMarks.Mark.YesNo == "Да" && poll5.EstimationsMarks.Mark.LowMark == 1.2)
                    {
                        monthScore = monthScore + 27;
                    }
                    else if (poll1 != null && poll5 != null && poll1.EstimationsMarks.Mark.YesNo == "Да" && poll5.EstimationsMarks.Mark.LowMark == 1.3)
                    {
                        monthScore = monthScore + 33;
                    }
                    else if (poll1 != null && poll5 != null && poll1.EstimationsMarks.Mark.YesNo == "Да" && poll5.EstimationsMarks.Mark.LowMark == 1.4)
                    {
                        monthScore = monthScore + 39;
                    }
                    else if (poll1 != null && poll5 != null && poll1.EstimationsMarks.Mark.YesNo == "Да" && poll5.EstimationsMarks.Mark.LowMark == 1.5)
                    {
                        monthScore = monthScore + 45;
                    }
                    else
                    {
                        monthScore = monthScore + 0;
                    }

                    if (poll2 != null && poll2.EstimationsMarks.Mark.YesNo == "Нет")
                    {
                        monthScore = monthScore + 0;
                    }
                    else
                    {
                        monthScore = monthScore + poll2.EstimationsMarks.Mark.BigMark.Value;
                    }
                    if (poll3 != null && poll3.EstimationsMarks.Mark.YesNo == "Нет")
                    {
                        monthScore = monthScore + 0;
                    }
                    else
                    {
                        monthScore = monthScore + poll3.EstimationsMarks.Mark.BigMark.Value;
                    }
                    if (poll4 != null && poll4.EstimationsMarks.Mark.YesNo == "Да")
                    {
                        monthScore = monthScore + 10;
                    }
                    else
                    {
                        monthScore = monthScore + 0;
                    }
                    if (poll6 != null && poll6.EstimationsMarks.Mark.YesNo == "Да")
                    {
                        monthScore = monthScore + 10;
                    }
                    else
                    {
                        monthScore = monthScore + 0;
                    }
                    if (poll7 != null && poll7.EstimationsMarks.Mark.YesNo == "Да")
                    {
                        monthScore = monthScore + 10;
                    }
                    else
                    {
                        monthScore = monthScore + 0;
                    }
                    if (poll8 != null && poll8.EstimationsMarks.Mark.YesNo == "Да")
                    {
                        monthScore = monthScore + 10;
                    }
                    else
                    {
                        monthScore = monthScore + 0;
                    }
                    if (poll9 != null && poll9.EstimationsMarks.Mark.YesNo == "Да")
                    {
                        monthScore = monthScore + 10;
                    }
                    else
                    {
                        monthScore = monthScore + 0;
                    }
                    if (poll10 != null && poll10.EstimationsMarks.Mark.YesNo == "Да")
                    {
                        monthScore = monthScore + 10;
                    }
                    else if (poll10 != null && poll10.EstimationsMarks.Mark.YesNo == "да")
                    {
                        monthScore = monthScore + 5;
                    }
                    else
                    {
                        monthScore = monthScore + 0;
                    }
                    if (poll11 != null && poll11.EstimationsMarks.Mark.YesNo == "Да")
                    {
                        monthScore = monthScore + 10;
                    }
                    else if (poll11 != null && poll11.EstimationsMarks.Mark.YesNo == "да")
                    {
                        monthScore = monthScore + 5;
                    }
                    else
                    {
                        monthScore = monthScore + 0;
                    }
                    if (poll12 != null && poll12.EstimationsMarks.Mark.YesNo == "Да")
                    {
                        monthScore = monthScore + 10;
                    }
                    else if (poll12 != null && poll12.EstimationsMarks.Mark.YesNo == "да")
                    {
                        monthScore = monthScore + 5;
                    }
                    else
                    {
                        monthScore = monthScore + 0;
                    }
                    score = new Score { MonthScore = monthScore };

                    Score sc = null;
                    int mo = month == 1 ? 12 : month - 1;
                    if (mo != 0) sc = scoresController.GetScoreByDetail(userId, mo, year);
                    if (month == 1) score.FinalScore = score.MonthScore;
                    else
                    {
                        if (sc == null) sc = new Score { MonthScore = 0 };
                        score.FinalScore = score.MonthScore + sc.MonthScore;
                    }
                    score.UserId = userId;
                    score.Month = month;
                    score.Year = year;
                    await scoresController.PostScore(score);
                }
            }
            return score;
        }
    }
}
