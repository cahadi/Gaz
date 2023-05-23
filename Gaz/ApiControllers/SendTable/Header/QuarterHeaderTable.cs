using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Spreadsheet;
using Gaz.Domain.Entities;
using Gaz.Data;
using SerGaz.Controllers;
using Gaz.HelpFolder.Sum;

namespace SerGaz.SendTable.Header
{
	//Поменять формулы
    public class QuarterHeaderTable
    {
		private readonly freedb_testdbgazContext _context;
		private readonly PollsController pollsController;
		private readonly ScoresController scoresController;
		private readonly SumExcel sumExcel;

        public QuarterHeaderTable(freedb_testdbgazContext context)
        {
			_context = context;
			pollsController = new PollsController(_context);
			scoresController = new ScoresController(_context);
            sumExcel = new SumExcel(_context);
        }

        public async Task CreateHeader(WorkbookPart workbookPart, StringValue id, 
            User user, List<User> users, int sheetId)
        {
			DateTime now = DateTime.Now;
			int year = now.Year;
			//sumExcel.GetListsForSumExcel();

            WorksheetPart worksheetPart = workbookPart.GetPartById(id) as WorksheetPart;

            Worksheet worksheet = new Worksheet();
            SheetData sheetData = worksheet.AppendChild(new SheetData());
            #region Строки
            Row row = new Row();
            row.Height = 1;
            Row row2 = new Row();
            row2.Height = 25;
            Row row3 = new Row();
            row3.Height = 25;
            Row row4 = new Row();
            row4.Height = 50;
			#endregion

			#region Колонки
			Columns columns = worksheet.GetFirstChild<Columns>();
            if (columns == null)
            {
                columns = new Columns();
                worksheet.InsertAt(columns, 0);
            }

            Column columnA = new Column()
            {
                Min = 1,
                Max = 1,
                Width = 1,
                CustomWidth = true
            };
            columns.Append(columnA);

            Column columnB = new Column()
            {
                Min = 2,
                Max = 2,
                Width = 25,
                CustomWidth = true
            };
            columns.Append(columnB);

            Column columnC = new Column()
            {
                Min = 3,
                Max = 3,
                Width = 1,
                CustomWidth = true
            };
            columns.Append(columnC);

            Column columnD = new Column()
            {
                Min = 4,
                Max = 4,
                Width = 1,
                CustomWidth = true
            };
            columns.Append(columnD);

            Column columnE = new Column()
            {
                Min = 5,
                Max = 5,
                Width = 25,
                CustomWidth = true
            };
            columns.Append(columnE);

            Column columnF = new Column()
            {
                Min = 6,
                Max = 6,
                Width = 20,
                CustomWidth = true
            };
            columns.Append(columnF);

            Column columnG = new Column()
            {
                Min = 7,
                Max = 7,
                Width = 27,
                CustomWidth = true
            };
            columns.Append(columnG);

            Column columnH = new Column()
            {
                Min = 8,
                Max = 8,
                Width = 1,
                CustomWidth = true
            };
            columns.Append(columnH);

            Column columnI = new Column()
            {
                Min = 9,
                Max = 9,
                Width = 15,
                CustomWidth = true
            };
            columns.Append(columnI);

            Column columnJ = new Column()
            {
                Min = 10,
                Max = 10,
                Width = 15,
                CustomWidth = true
            };
            columns.Append(columnJ);

            Column columnK = new Column()
            {
                Min = 11,
                Max = 11,
                Width = 20,
                CustomWidth = true
            };
            columns.Append(columnK);

            Column columnL = new Column()
            {
                Min = 12,
                Max = 12,
                Width = 20,
                CustomWidth = true
            };
            columns.Append(columnL);

            Column columnM = new Column()
            {
                Min = 13,
                Max = 13,
                Width = 25,
                CustomWidth = true
            };
            columns.Append(columnM);

            Column columnN = new Column()
            {
                Min = 14,
                Max = 14,
                Width = 20,
                CustomWidth = true
            };
            columns.Append(columnN);

            Column columnO = new Column()
            {
                Min = 15,
                Max = 15,
                Width = 20,
                CustomWidth = true
            };
            columns.Append(columnO);

            Column columnP = new Column()
            {
                Min = 16,
                Max = 16,
                Width = 1,
                CustomWidth = true
            };
            columns.Append(columnP);

            Column columnQ = new Column()
            {
                Min = 17,
                Max = 17,
                Width = 20,
                CustomWidth = true
            };
            columns.Append(columnQ);
            #endregion

            #region Ячейки
            Cell cell = new Cell();
            cell.CellReference = "B2";
            cell.DataType = CellValues.String;
            cell.CellValue = new CellValue("ОЦЕНИВАЕМЫЕ");
            row2.Append(cell);
            MergeCells mergeCells = new MergeCells();
            MergeCell mergeCell = new MergeCell()
            {
                Reference = new StringValue("B2:B4")
            };
            mergeCells.Append(mergeCell);
            worksheet.Append(mergeCells);

            Cell cell1 = new Cell();
            cell1.CellReference = "D2";
            cell1.DataType = CellValues.String;
            cell1.CellValue = new CellValue("Количество участий");
            row2.Append(cell1);
            MergeCells mergeCells1 = new MergeCells();
            MergeCell mergeCell1 = new MergeCell()
            {
                Reference = new StringValue("D2:O2")
            };
            mergeCells1.Append(mergeCell1);
            worksheet.Append(mergeCells1);

            Cell cell2 = new Cell();
            cell2.CellReference = "P2";
            cell2.DataType = CellValues.String;
            cell2.CellValue = new CellValue("БАЛЛЫ");
            row2.Append(cell2);
            MergeCells mergeCells2 = new MergeCells();
            MergeCell mergeCell2 = new MergeCell()
            {
                Reference = new StringValue("P2:Q3")
            };
            mergeCells2.Append(mergeCell2);
            worksheet.Append(mergeCells2);

            Cell cell3 = new Cell();
            cell3.CellReference = "D3";
            cell3.DataType = CellValues.String;
            cell3.CellValue = new CellValue("Производственное");
            row3.Append(cell3);
            MergeCells mergeCells3 = new MergeCells();
            MergeCell mergeCell3 = new MergeCell()
            {
                Reference = new StringValue("D3:I3")
            };
            mergeCells3.Append(mergeCell3);
            worksheet.Append(mergeCells3);

            Cell cell4 = new Cell();
            cell4.CellReference = "J3";
            cell4.DataType = CellValues.String;
            cell4.CellValue = new CellValue("Дополнительное\n производственное");
            row3.Append(cell4);
            MergeCells mergeCells4 = new MergeCells();
            MergeCell mergeCell4 = new MergeCell()
            {
                Reference = new StringValue("J3:K3")
            };
            mergeCells4.Append(mergeCell4);
            worksheet.Append(mergeCells4);

            Cell cell5 = new Cell();
            cell5.CellReference = "L3";
            cell5.DataType = CellValues.String;
            cell5.CellValue = new CellValue("Социально-культурное");
            row3.Append(cell5);
            MergeCells mergeCells5 = new MergeCells();
            MergeCell mergeCell5 = new MergeCell()
            {
                Reference = new StringValue("L3:N3")
            };
            mergeCells5.Append(mergeCell5);
            worksheet.Append(mergeCells5);

            Cell cell6 = new Cell();
            cell6.CellReference = "O3";
            cell6.DataType = CellValues.String;
            cell6.CellValue = new CellValue("Доп.\n социокульт.");
            row3.Append(cell6);

            Cell cell7 = new Cell();
            cell7.CellReference = "E4";
            cell7.DataType = CellValues.String;
            cell7.CellValue = new CellValue("Заполнение формы\n идентификации опасности\n в системе \"СТОП-РИСК\"");
            row4.Append(cell7);


            Cell cell8 = new Cell();
            cell8.CellReference = "F4";
            cell8.DataType = CellValues.String;
            cell8.CellValue = new CellValue("Рационализаторская\n деятельность");
            row4.Append(cell8);

            Cell cell9 = new Cell();
            cell9.CellReference = "G4";
            cell9.DataType = CellValues.String;
            cell9.CellValue = new CellValue("Внедрение предложений\n по системе\n \"Бережливое производство\"");
            row4.Append(cell9);

            Cell cell10 = new Cell();
            cell10.CellReference = "I4";
            cell10.DataType = CellValues.String;
            cell10.CellValue = new CellValue("Положительный\n опыт");
            row4.Append(cell10);

            Cell cell11 = new Cell();
            cell11.CellReference = "J4";
            cell11.DataType = CellValues.String;
            cell11.CellValue = new CellValue("Наставничество");
            row4.Append(cell11);

            Cell cell12 = new Cell();
            cell12.CellReference = "K4";
            cell12.DataType = CellValues.String;
            cell12.CellValue = new CellValue("Участие в конкурсе\n профмастерства");
            row4.Append(cell12);

            Cell cell13 = new Cell();
            cell13.CellReference = "L4";
            cell13.DataType = CellValues.String;
            cell13.CellValue = new CellValue("Экология (участие в\n экологических акциях)");
            row4.Append(cell13);

            Cell cell14 = new Cell();
            cell14.CellReference = "M4";
            cell14.DataType = CellValues.String;
            cell14.CellValue = new CellValue("Спорт (участие в\n спортивных мероприятиях)");
            row4.Append(cell14);

            Cell cell15 = new Cell();
            cell15.CellReference = "N4";
            cell15.DataType = CellValues.String;
            cell15.CellValue = new CellValue("Культурно-массовые\n мероприятия");
            row4.Append(cell15);

            Cell cell16 = new Cell();
            cell16.CellReference = "O4";
            cell16.DataType = CellValues.String;
            cell16.CellValue = new CellValue("Благоворительные\n акции");
            row4.Append(cell16);

            Cell cell17 = new Cell();
            cell17.CellReference = "Q4";
            cell17.DataType = CellValues.String;
            cell17.CellValue = new CellValue("Суммарный годовой\n (январь - декабрь)");
            row4.Append(cell17);

            #endregion

            #region Переменные для ячеек
            int score1 = 0;
            int score2 = 0;
            int score3 = 0;
            int score4 = 0;
            int score5 = 0;
            int score6 = 0;
            int score7 = 0;
            int score8 = 0;
            int score9 = 0;
            int score10 = 0;
            int score11 = 0;
            int score12 = 0;
            int score13 = 0;
            int score14 = 0;
            int score15 = 0;
            int score16 = 0;
            int score17 = 0;
            int score18 = 0;
            int score19 = 0;
            int score20 = 0;
            int score21 = 0;
            int score22 = 0;
            int score23 = 0;
            int score24 = 0;
            int score25 = 0;
            int score26 = 0;
            int score27 = 0;
            int score28 = 0;
            int score29 = 0;
            int score30 = 0;
            int score31 = 0;
            int score32 = 0;
            int score33 = 0;
            int score34 = 0;
            int score35 = 0;
            int score36 = 0;
            int score37 = 0;
            int score38 = 0;
            int score39 = 0;
            int score40 = 0;
            #endregion

            #region Списки

			sheetData.Append(row);
            sheetData.Append(row2);
            sheetData.Append(row3);
            sheetData.Append(row4);

            //await scoresController.GetScores();

            int i = 5;
			if (user != null)
			{
                Row row5 = new Row();
                row5.Height = 25;

				Cell cellB5 = new Cell();
				cellB5.CellReference = $"B{i}";
				cellB5.DataType = CellValues.String;
				cellB5.CellValue = new CellValue($"{user.Fio}");
				row5.Append(cellB5);


				if (sheetId == 13)
                {
					score1 = await sumExcel.GetSumE(user.Id, 1);
                    Cell cellE5 = new Cell();
					cellE5.CellReference = $"E{i}";
					cellE5.DataType = CellValues.String;
					cellE5.CellValue = new CellValue($"{score1}");
					row5.Append(cellE5);

					score2 = sumExcel.GetSumF(user.Id, 1);
                    Cell cellF5 = new Cell();
					cellF5.CellReference = $"F{i}";
					cellF5.DataType = CellValues.String;
					cellF5.CellValue = new CellValue($"{score2}");
					row5.Append(cellF5);

					score3 = sumExcel.GetSumG(user.Id, 1);
					Cell cellG5 = new Cell();
					cellG5.CellReference = $"G{i}";
					cellG5.DataType = CellValues.String;
					cellG5.CellValue = new CellValue($"{score3}");
					row5.Append(cellG5);

                    score4 = sumExcel.GetSumI(user.Id, 1);
                    Cell cellI5 = new Cell();
					cellI5.CellReference = $"I{i}";
					cellI5.DataType = CellValues.String;
					cellI5.CellValue = new CellValue($"{score4}");
					row5.Append(cellI5);

                    score5 = sumExcel.GetSumJ(user.Id, 1);
                    Cell cellJ5 = new Cell();
					cellJ5.CellReference = $"J{i}";
					cellJ5.DataType = CellValues.String;
					cellJ5.CellValue = new CellValue($"{score5}");
					row5.Append(cellJ5);

                    score6 = sumExcel.GetSumK(user.Id, 1);
                    Cell cellK5 = new Cell();
					cellK5.CellReference = $"K{i}";
					cellK5.DataType = CellValues.String;
					cellK5.CellValue = new CellValue($"{score6}");
					row5.Append(cellK5);

                    score7 = sumExcel.GetSumL(user.Id, 1);
                    Cell cellL5 = new Cell();
					cellL5.CellReference = $"L{i}";
					cellL5.DataType = CellValues.String;
					cellL5.CellValue = new CellValue($"{score7}");
					row5.Append(cellL5);

                    score8 = sumExcel.GetSumM(user.Id, 1);
                    Cell cellM5 = new Cell();
					cellM5.CellReference = $"M{i}";
					cellM5.DataType = CellValues.String;
					cellM5.CellValue = new CellValue($"{score8}");
					row5.Append(cellM5);

                    score9 = sumExcel.GetSumN(user.Id, 1);
                    Cell cellN5 = new Cell();
					cellN5.CellReference = $"N{i}";
					cellN5.DataType = CellValues.String;
					cellN5.CellValue = new CellValue($"{score9}");
					row5.Append(cellN5);

                    score10 = sumExcel.GetSumO(user.Id, 1);
                    Cell cellO5 = new Cell();
					cellO5.CellReference = $"O{i}";
					cellO5.DataType = CellValues.String;
					cellO5.CellValue = new CellValue($"{score10}");
					row5.Append(cellO5);

                    var score = scoresController.GetScoreByDetail(user.Id, 3, year);
                    if (score == null)
                    {
                        score = scoresController.GetScoreByDetail(user.Id, 2, year);
                        if (score == null)
                            score = scoresController.GetScoreByDetail(user.Id, 1, year);
                    }
                    
                    Cell cellQ5 = new Cell();
                    cellQ5.CellReference = $"Q{i}";
                    cellQ5.DataType = CellValues.String;
                    if (score == null)
                    {
                        cellQ5.CellValue = new CellValue($"{0}");
                    }
                    else
                    {
                        cellQ5.CellValue = new CellValue($"{score.FinalScore}");
                    }
                    row5.Append(cellQ5);
				}
				else if (sheetId == 14)
                {
                    score11 = await sumExcel.GetSumE(user.Id, 2);
                    Cell cellE5 = new Cell();
                    cellE5.CellReference = $"E{i}";
                    cellE5.DataType = CellValues.String;
                    cellE5.CellValue = new CellValue($"{score11}");
                    row5.Append(cellE5);

                    score12 = sumExcel.GetSumF(user.Id, 2);
                    Cell cellF5 = new Cell();
                    cellF5.CellReference = $"F{i}";
                    cellF5.DataType = CellValues.String;
                    cellF5.CellValue = new CellValue($"{score12}");
                    row5.Append(cellF5);

                    score13 = sumExcel.GetSumG(user.Id, 2);
                    Cell cellG5 = new Cell();
                    cellG5.CellReference = $"G{i}";
                    cellG5.DataType = CellValues.String;
                    cellG5.CellValue = new CellValue($"{score13}");
                    row5.Append(cellG5);

                    score14 = sumExcel.GetSumI(user.Id, 2);
                    Cell cellI5 = new Cell();
                    cellI5.CellReference = $"I{i}";
                    cellI5.DataType = CellValues.String;
                    cellI5.CellValue = new CellValue($"{score14}");
                    row5.Append(cellI5);

                    score15 = sumExcel.GetSumJ(user.Id, 2);
                    Cell cellJ5 = new Cell();
                    cellJ5.CellReference = $"J{i}";
                    cellJ5.DataType = CellValues.String;
                    cellJ5.CellValue = new CellValue($"{score15}");
                    row5.Append(cellJ5);

                    score16 = sumExcel.GetSumK(user.Id, 2);
                    Cell cellK5 = new Cell();
                    cellK5.CellReference = $"K{i}";
                    cellK5.DataType = CellValues.String;
                    cellK5.CellValue = new CellValue($"{score16}");
                    row5.Append(cellK5);

                    score17 = sumExcel.GetSumL(user.Id, 2);
                    Cell cellL5 = new Cell();
                    cellL5.CellReference = $"L{i}";
                    cellL5.DataType = CellValues.String;
                    cellL5.CellValue = new CellValue($"{score17}");
                    row5.Append(cellL5);

                    score18 = sumExcel.GetSumM(user.Id, 2);
                    Cell cellM5 = new Cell();
                    cellM5.CellReference = $"M{i}";
                    cellM5.DataType = CellValues.String;
                    cellM5.CellValue = new CellValue($"{score18}");
                    row5.Append(cellM5);

                    score19 = sumExcel.GetSumN(user.Id, 2);
                    Cell cellN5 = new Cell();
                    cellN5.CellReference = $"N{i}";
                    cellN5.DataType = CellValues.String;
                    cellN5.CellValue = new CellValue($"{score19}");
                    row5.Append(cellN5);

                    score20 = sumExcel.GetSumO(user.Id, 2);
                    Cell cellO5 = new Cell();
                    cellO5.CellReference = $"O{i}";
                    cellO5.DataType = CellValues.String;
                    cellO5.CellValue = new CellValue($"{score20}");
                    row5.Append(cellO5);

                    var score = scoresController.GetScoreByDetail(user.Id, 6, year);
                    if (score == null)
                    {
                        score = scoresController.GetScoreByDetail(user.Id, 5, year);
                        if (score == null)
                        {
                            score = scoresController.GetScoreByDetail(user.Id, 4, year);
                            if(score == null)
                            {
                                score = scoresController.GetScoreByDetail(user.Id, 3, year);
                                if (score == null)
                                {
                                    score = scoresController.GetScoreByDetail(user.Id, 2, year);
                                    if (score == null)
                                        score = scoresController.GetScoreByDetail(user.Id, 1, year);
                                }
                            }
                             
                        }
                    }

                    Cell cellQ5 = new Cell();
                    cellQ5.CellReference = $"Q{i}";
                    cellQ5.DataType = CellValues.String;
                    if (score == null)
                    {
                        cellQ5.CellValue = new CellValue($"{0}");
                    }
                    else
                    {
                        cellQ5.CellValue = new CellValue($"{score.FinalScore}");
                    }
                    row5.Append(cellQ5);
                }
				else if (sheetId == 15)
                {
                    score21 =  await sumExcel.GetSumE(user.Id, 3);
                    Cell cellE5 = new Cell();
                    cellE5.CellReference = $"E{i}";
                    cellE5.DataType = CellValues.String;
                    cellE5.CellValue = new CellValue($"{score21}");
                    row5.Append(cellE5);

                    score22 = sumExcel.GetSumF(user.Id, 3);
                    Cell cellF5 = new Cell();
                    cellF5.CellReference = $"F{i}";
                    cellF5.DataType = CellValues.String;
                    cellF5.CellValue = new CellValue($"{score22}");
                    row5.Append(cellF5);

                    score23 = sumExcel.GetSumG(user.Id, 3);
                    Cell cellG5 = new Cell();
                    cellG5.CellReference = $"G{i}";
                    cellG5.DataType = CellValues.String;
                    cellG5.CellValue = new CellValue($"{score23}");
                    row5.Append(cellG5);

                    score24 = sumExcel.GetSumI(user.Id, 3);
                    Cell cellI5 = new Cell();
                    cellI5.CellReference = $"I{i}";
                    cellI5.DataType = CellValues.String;
                    cellI5.CellValue = new CellValue($"{score24}");
                    row5.Append(cellI5);

                    score25 = sumExcel.GetSumJ(user.Id, 3);
                    Cell cellJ5 = new Cell();
                    cellJ5.CellReference = $"J{i}";
                    cellJ5.DataType = CellValues.String;
                    cellJ5.CellValue = new CellValue($"{score25}");
                    row5.Append(cellJ5);

                    score26 = sumExcel.GetSumK(user.Id, 3);
                    Cell cellK5 = new Cell();
                    cellK5.CellReference = $"K{i}";
                    cellK5.DataType = CellValues.String;
                    cellK5.CellValue = new CellValue($"{score26}");
                    row5.Append(cellK5);

                    score27 = sumExcel.GetSumL(user.Id, 3);
                    Cell cellL5 = new Cell();
                    cellL5.CellReference = $"L{i}";
                    cellL5.DataType = CellValues.String;
                    cellL5.CellValue = new CellValue($"{score27}");
                    row5.Append(cellL5);

                    score28 = sumExcel.GetSumM(user.Id, 3);
                    Cell cellM5 = new Cell();
                    cellM5.CellReference = $"M{i}";
                    cellM5.DataType = CellValues.String;
                    cellM5.CellValue = new CellValue($"{score28}");
                    row5.Append(cellM5);

                    score29 = sumExcel.GetSumN(user.Id, 3);
                    Cell cellN5 = new Cell();
                    cellN5.CellReference = $"N{i}";
                    cellN5.DataType = CellValues.String;
                    cellN5.CellValue = new CellValue($"{score29}");
                    row5.Append(cellN5);

                    score30 = sumExcel.GetSumO(user.Id, 3);
                    Cell cellO5 = new Cell();
                    cellO5.CellReference = $"O{i}";
                    cellO5.DataType = CellValues.String;
                    cellO5.CellValue = new CellValue($"{score30}");
                    row5.Append(cellO5);

                    var score = scoresController.GetScoreByDetail(user.Id, 9, year);
                    if (score == null)
                    {
                        score = scoresController.GetScoreByDetail(user.Id, 8, year);
                        if (score == null)
                        {
                            score = scoresController.GetScoreByDetail(user.Id, 7, year);
                            if(score == null) {
                                score = scoresController.GetScoreByDetail(user.Id, 6, year);
                                if (score == null)
                                {
                                    score = scoresController.GetScoreByDetail(user.Id, 5, year);
                                    if (score == null)
                                    {
                                        score = scoresController.GetScoreByDetail(user.Id, 4, year);
                                        if (score == null)
                                        {
                                            score = scoresController.GetScoreByDetail(user.Id, 3, year);
                                            if (score == null)
                                            {
                                                score = scoresController.GetScoreByDetail(user.Id, 2, year);
                                                if (score == null)
                                                    score = scoresController.GetScoreByDetail(user.Id, 1, year);
                                            }
                                        }

                                    }
                                }
                            }
                        }
                    }

                    Cell cellQ5 = new Cell();
                    cellQ5.CellReference = $"Q{i}";
                    cellQ5.DataType = CellValues.String;
                    if (score == null)
                    {
                        cellQ5.CellValue = new CellValue($"{0}");
                    }
                    else
                    {
                        cellQ5.CellValue = new CellValue($"{score.FinalScore}");
                    }
                    row5.Append(cellQ5);
                }
				else if (sheetId == 16)
                {
                    score31 = await sumExcel.GetSumE(user.Id, 4);
                    Cell cellE5 = new Cell();
                    cellE5.CellReference = $"E{i}";
                    cellE5.DataType = CellValues.String;
                    cellE5.CellValue = new CellValue($"{score31}");
                    row5.Append(cellE5);

                    score32 = sumExcel.GetSumF(user.Id, 4);
                    Cell cellF5 = new Cell();
                    cellF5.CellReference = $"F{i}";
                    cellF5.DataType = CellValues.String;
                    cellF5.CellValue = new CellValue($"{score32}");
                    row5.Append(cellF5);

                    score33 = sumExcel.GetSumG(user.Id, 4);
                    Cell cellG5 = new Cell();
                    cellG5.CellReference = $"G{i}";
                    cellG5.DataType = CellValues.String;
                    cellG5.CellValue = new CellValue($"{score33}");
                    row5.Append(cellG5);

                    score34 = sumExcel.GetSumI(user.Id, 4);
                    Cell cellI5 = new Cell();
                    cellI5.CellReference = $"I{i}";
                    cellI5.DataType = CellValues.String;
                    cellI5.CellValue = new CellValue($"{score34}");
                    row5.Append(cellI5);

                    score35 = sumExcel.GetSumJ(user.Id, 4);
                    Cell cellJ5 = new Cell();
                    cellJ5.CellReference = $"J{i}";
                    cellJ5.DataType = CellValues.String;
                    cellJ5.CellValue = new CellValue($"{score35}");
                    row5.Append(cellJ5);

                    score36 = sumExcel.GetSumK(user.Id, 4);
                    Cell cellK5 = new Cell();
                    cellK5.CellReference = $"K{i}";
                    cellK5.DataType = CellValues.String;
                    cellK5.CellValue = new CellValue($"{score36}");
                    row5.Append(cellK5);

                    score37 = sumExcel.GetSumL(user.Id, 4);
                    Cell cellL5 = new Cell();
                    cellL5.CellReference = $"L{i}";
                    cellL5.DataType = CellValues.String;
                    cellL5.CellValue = new CellValue($"{score37}");
                    row5.Append(cellL5);

                    score38 = sumExcel.GetSumM(user.Id, 4);
                    Cell cellM5 = new Cell();
                    cellM5.CellReference = $"M{i}";
                    cellM5.DataType = CellValues.String;
                    cellM5.CellValue = new CellValue($"{score38}");
                    row5.Append(cellM5);

                    score39 = sumExcel.GetSumN(user.Id, 4);
                    Cell cellN5 = new Cell();
                    cellN5.CellReference = $"N{i}";
                    cellN5.DataType = CellValues.String;
                    cellN5.CellValue = new CellValue($"{score39}");
                    row5.Append(cellN5);

                    score40 = sumExcel.GetSumO(user.Id, 4);
                    Cell cellO5 = new Cell();
                    cellO5.CellReference = $"O{i}";
                    cellO5.DataType = CellValues.String;
                    cellO5.CellValue = new CellValue($"{score40}");
                    row5.Append(cellO5);

                    var score = scoresController.GetScoreByDetail(user.Id, 12, year);
                    if (score == null)
                    {
                        score = scoresController.GetScoreByDetail(user.Id, 11, year);
                        if (score == null)
                        {
                            score = scoresController.GetScoreByDetail(user.Id, 10, year);
                            if(score == null)
                            {
                                score = scoresController.GetScoreByDetail(user.Id, 9, year);
                                if (score == null)
                                {
                                    score = scoresController.GetScoreByDetail(user.Id, 8, year);
                                    if (score == null)
                                    {
                                        score = scoresController.GetScoreByDetail(user.Id, 7, year);
                                        if (score == null)
                                        {
                                            score = scoresController.GetScoreByDetail(user.Id, 6, year);
                                            if (score == null)
                                            {
                                                score = scoresController.GetScoreByDetail(user.Id, 5, year);
                                                if (score == null)
                                                {
                                                    score = scoresController.GetScoreByDetail(user.Id, 4, year);
                                                    if (score == null)
                                                    {
                                                        score = scoresController.GetScoreByDetail(user.Id, 3, year);
                                                        if (score == null)
                                                        {
                                                            score = scoresController.GetScoreByDetail(user.Id, 2, year);
                                                            if (score == null)
                                                                score = scoresController.GetScoreByDetail(user.Id, 1, year);
                                                        }
                                                    }

                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    Cell cellQ5 = new Cell();
                    cellQ5.CellReference = $"Q{i}";
                    cellQ5.DataType = CellValues.String;
                    if (score == null)
                    {
                        cellQ5.CellValue = new CellValue($"{0}");
                    }
                    else
                    {
                        cellQ5.CellValue = new CellValue($"{score.FinalScore}");
                    }
                    row5.Append(cellQ5);
                }
				else if (sheetId == 17)
				{
                    int sc = score1 + score11 + score21 + score31;
					Cell cellE5 = new Cell();
					cellE5.CellReference = $"E{i}";
					cellE5.DataType = CellValues.String;
					cellE5.CellValue = new CellValue($"{sc}");
					row5.Append(cellE5);


                    int sc1 = score2 + score12 + score22 + score32;
                    Cell cellF5 = new Cell();
					cellF5.CellReference = $"F{i}";
					cellF5.DataType = CellValues.String;
					cellF5.CellValue = new CellValue($"{sc1}");
					row5.Append(cellF5);


                    int sc2 = score3 + score13 + score23 + score33;
                    Cell cellG5 = new Cell();
					cellG5.CellReference = $"G{i}";
					cellG5.DataType = CellValues.String;
					cellG5.CellValue = new CellValue($"{sc2}");
					row5.Append(cellG5);


                    int sc3 = score4 + score14 + score24 + score34;
                    Cell cellI5 = new Cell();
					cellI5.CellReference = $"I{i}";
					cellI5.DataType = CellValues.String;
					cellI5.CellValue = new CellValue($"{sc3}");
					row5.Append(cellI5);


                    int sc4 = score5 + score15 + score25 + score35;
                    Cell cellJ5 = new Cell();
					cellJ5.CellReference = $"J{i}";
					cellJ5.DataType = CellValues.String;
					cellJ5.CellValue = new CellValue($"{sc4}");
					row5.Append(cellJ5);


                    int sc5 = score6 + score16 + score26 + score36;
                    Cell cellK5 = new Cell();
					cellK5.CellReference = $"K{i}";
					cellK5.DataType = CellValues.String;
					cellK5.CellValue = new CellValue($"{sc5}");
					row5.Append(cellK5);


                    int sc6 = score7 + score17 + score27 + score37;
                    Cell cellL5 = new Cell();
					cellL5.CellReference = $"L{i}";
					cellL5.DataType = CellValues.String;
					cellL5.CellValue = new CellValue($"{sc6}");
					row5.Append(cellL5);


                    int sc7 = score8 + score18 + score28 + score38;
                    Cell cellM5 = new Cell();
					cellM5.CellReference = $"M{i}";
					cellM5.DataType = CellValues.String;
					cellM5.CellValue = new CellValue($"{sc7}");
					row5.Append(cellM5);


                    int sc8 = score9 + score19 + score29 + score39;
                    Cell cellN5 = new Cell();
					cellN5.CellReference = $"N{i}";
					cellN5.DataType = CellValues.String;
					cellN5.CellValue = new CellValue($"{sc8}");
					row5.Append(cellN5);


                    int sc9 = score10 + score20 + score30 + score40;
                    Cell cellO5 = new Cell();
					cellO5.CellReference = $"O{i}";
					cellO5.DataType = CellValues.String;
					cellO5.CellValue = new CellValue($"{sc9}");
					row5.Append(cellO5);

                    var score = scoresController.GetScoreByDetail(user.Id, 12, year);
                    if (score == null)
                    {
                        score = scoresController.GetScoreByDetail(user.Id, 11, year);
                        if (score == null)
                        {
                            score = scoresController.GetScoreByDetail(user.Id, 10, year);
                            if (score == null)
                            {
                                score = scoresController.GetScoreByDetail(user.Id, 9, year);
                                if (score == null)
                                {
                                    score = scoresController.GetScoreByDetail(user.Id, 8, year);
                                    if (score == null)
                                    {
                                        score = scoresController.GetScoreByDetail(user.Id, 7, year);
                                        if (score == null)
                                        {
                                            score = scoresController.GetScoreByDetail(user.Id, 6, year);
                                            if (score == null)
                                            {
                                                score = scoresController.GetScoreByDetail(user.Id, 5, year);
                                                if (score == null)
                                                {
                                                    score = scoresController.GetScoreByDetail(user.Id, 4, year);
                                                    if (score == null)
                                                    {
                                                        score = scoresController.GetScoreByDetail(user.Id, 3, year);
                                                        if (score == null)
                                                        {
                                                            score = scoresController.GetScoreByDetail(user.Id, 2, year);
                                                            if (score == null)
                                                                score = scoresController.GetScoreByDetail(user.Id, 1, year);
                                                        }
                                                    }

                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }


                    Cell cellQ5 = new Cell();
                    cellQ5.CellReference = $"Q{i}";
                    cellQ5.DataType = CellValues.String;
                    if (score == null)
                    {
                        cellQ5.CellValue = new CellValue($"{0}");
                    }
                    else
                    {
                        cellQ5.CellValue = new CellValue($"{score.FinalScore}");
                    }
                    row5.Append(cellQ5);
                }


				sheetData.Append(row5);
				i ++;
			}


			foreach (User us in users)
			{
				Row dataRow = new Row();
				dataRow.Height = 25;
				Cell dataCell2 = new Cell();
				dataCell2.DataType = CellValues.String;
				dataCell2.CellValue = new CellValue(us.Fio);
				dataCell2.CellReference = $"B{i}";
				dataRow.Append(dataCell2);


                if (sheetId == 13)
                {
                    score1 = await sumExcel.GetSumE(us.Id, 1);
                    Cell cellE5 = new Cell();
                    cellE5.CellReference = $"E{i}";
                    cellE5.DataType = CellValues.String;
                    cellE5.CellValue = new CellValue($"{score1}");
                    dataRow.Append(cellE5);

                    score2 = sumExcel.GetSumF(us.Id, 1);
                    Cell cellF5 = new Cell();
                    cellF5.CellReference = $"F{i}";
                    cellF5.DataType = CellValues.String;
                    cellF5.CellValue = new CellValue($"{score2}");
                    dataRow.Append(cellF5);

                    score3 = sumExcel.GetSumG(us.Id, 1);
                    Cell cellG5 = new Cell();
                    cellG5.CellReference = $"G{i}";
                    cellG5.DataType = CellValues.String;
                    cellG5.CellValue = new CellValue($"{score3}");
                    dataRow.Append(cellG5);

                    score4 = sumExcel.GetSumI(us.Id, 1);
                    Cell cellI5 = new Cell();
                    cellI5.CellReference = $"I{i}";
                    cellI5.DataType = CellValues.String;
                    cellI5.CellValue = new CellValue($"{score4}");
                    dataRow.Append(cellI5);

                    score5 = sumExcel.GetSumJ(us.Id, 1);
                    Cell cellJ5 = new Cell();
                    cellJ5.CellReference = $"J{i}";
                    cellJ5.DataType = CellValues.String;
                    cellJ5.CellValue = new CellValue($"{score5}");
                    dataRow.Append(cellJ5);

                    score6 = sumExcel.GetSumK(us.Id, 1);
                    Cell cellK5 = new Cell();
                    cellK5.CellReference = $"K{i}";
                    cellK5.DataType = CellValues.String;
                    cellK5.CellValue = new CellValue($"{score6}");
                    dataRow.Append(cellK5);

                    score7 = sumExcel.GetSumL(us.Id, 1);
                    Cell cellL5 = new Cell();
                    cellL5.CellReference = $"L{i}";
                    cellL5.DataType = CellValues.String;
                    cellL5.CellValue = new CellValue($"{score7}");
                    dataRow.Append(cellL5);

                    score8 = sumExcel.GetSumM(us.Id, 1);
                    Cell cellM5 = new Cell();
                    cellM5.CellReference = $"M{i}";
                    cellM5.DataType = CellValues.String;
                    cellM5.CellValue = new CellValue($"{score8}");
                    dataRow.Append(cellM5);

                    score9 = sumExcel.GetSumN(us.Id, 1);
                    Cell cellN5 = new Cell();
                    cellN5.CellReference = $"N{i}";
                    cellN5.DataType = CellValues.String;
                    cellN5.CellValue = new CellValue($"{score9}");
                    dataRow.Append(cellN5);

                    score10 = sumExcel.GetSumO(us.Id, 1);
                    Cell cellO5 = new Cell();
                    cellO5.CellReference = $"O{i}";
                    cellO5.DataType = CellValues.String;
                    cellO5.CellValue = new CellValue($"{score10}");
                    dataRow.Append(cellO5);

                    var score = scoresController.GetScoreByDetail(user.Id, 3, year);
                    if (score == null)
                    {
                        score = scoresController.GetScoreByDetail(user.Id, 2, year);
                        if (score == null)
                            score = scoresController.GetScoreByDetail(user.Id, 1, year);
                    }

                    Cell cellQ5 = new Cell();
                    cellQ5.CellReference = $"Q{i}";
                    cellQ5.DataType = CellValues.String;
                    if (score == null)
                    {
                        cellQ5.CellValue = new CellValue($"{0}");
                    }
                    else
                    {
                        cellQ5.CellValue = new CellValue($"{score.FinalScore}");
                    }
                    dataRow.Append(cellQ5);
                }
				else if (sheetId == 14)
                {
                    score11 = await sumExcel.GetSumE(us.Id, 2);
                    Cell cellE5 = new Cell();
                    cellE5.CellReference = $"E{i}";
                    cellE5.DataType = CellValues.String;
                    cellE5.CellValue = new CellValue($"{score11}");
                    dataRow.Append(cellE5);

                    score12 = sumExcel.GetSumF(us.Id, 2);
                    Cell cellF5 = new Cell();
                    cellF5.CellReference = $"F{i}";
                    cellF5.DataType = CellValues.String;
                    cellF5.CellValue = new CellValue($"{score12}");
                    dataRow.Append(cellF5);

                    score13 = sumExcel.GetSumG(us.Id, 2);
                    Cell cellG5 = new Cell();
                    cellG5.CellReference = $"G{i}";
                    cellG5.DataType = CellValues.String;
                    cellG5.CellValue = new CellValue($"{score13}");
                    dataRow.Append(cellG5);

                    score14 = sumExcel.GetSumI(us.Id, 2);
                    Cell cellI5 = new Cell();
                    cellI5.CellReference = $"I{i}";
                    cellI5.DataType = CellValues.String;
                    cellI5.CellValue = new CellValue($"{score14}");
                    dataRow.Append(cellI5);

                    score15 = sumExcel.GetSumJ(us.Id, 2);
                    Cell cellJ5 = new Cell();
                    cellJ5.CellReference = $"J{i}";
                    cellJ5.DataType = CellValues.String;
                    cellJ5.CellValue = new CellValue($"{score15}");
                    dataRow.Append(cellJ5);

                    score16 = sumExcel.GetSumK(us.Id, 2);
                    Cell cellK5 = new Cell();
                    cellK5.CellReference = $"K{i}";
                    cellK5.DataType = CellValues.String;
                    cellK5.CellValue = new CellValue($"{score16}");
                    dataRow.Append(cellK5);

                    score17 = sumExcel.GetSumL(us.Id, 2);
                    Cell cellL5 = new Cell();
                    cellL5.CellReference = $"L{i}";
                    cellL5.DataType = CellValues.Number;
                    cellL5.CellValue = new CellValue($"{score17}");
                    dataRow.Append(cellL5);

                    score18 = sumExcel.GetSumM(us.Id, 2);
                    Cell cellM5 = new Cell();
                    cellM5.CellReference = $"M{i}";
                    cellM5.DataType = CellValues.String;
                    cellM5.CellValue = new CellValue($"{score18}");
                    dataRow.Append(cellM5);

                    score19 = sumExcel.GetSumN(us.Id, 2);
                    Cell cellN5 = new Cell();
                    cellN5.CellReference = $"N{i}";
                    cellN5.DataType = CellValues.String;
                    cellN5.CellValue = new CellValue($"{score19}");
                    dataRow.Append(cellN5);

                    score20 = sumExcel.GetSumO(us.Id, 2);
                    Cell cellO5 = new Cell();
                    cellO5.CellReference = $"O{i}";
                    cellO5.DataType = CellValues.String;
                    cellO5.CellValue = new CellValue($"{score20}");
                    dataRow.Append(cellO5);

                    var score = scoresController.GetScoreByDetail(us.Id, 6, year);
                    if(score == null)
                    {
                        score = scoresController.GetScoreByDetail(us.Id, 5, year);
                        if(score == null)
                        {
                            score = scoresController.GetScoreByDetail(us.Id, 4, year);
                            if(score == null)
                            {
                                score = scoresController.GetScoreByDetail(user.Id, 3, year);
                                if (score == null)
                                {
                                    score = scoresController.GetScoreByDetail(user.Id, 2, year);
                                    if (score == null)
                                        score = scoresController.GetScoreByDetail(user.Id, 1, year);
                                }
                            }
                        }
                    }

                    Cell cellQ5 = new Cell();
                    cellQ5.CellReference = $"Q{i}";
                    cellQ5.DataType = CellValues.String;
                    if (score == null)
                    {
                        cellQ5.CellValue = new CellValue($"{0}");
                    }
                    else
                    {
                        cellQ5.CellValue = new CellValue($"{score.FinalScore}");
                    }
                    dataRow.Append(cellQ5);
                }
				else if (sheetId == 15)
                {
                    score21 = await sumExcel.GetSumE(us.Id, 3);
                    Cell cellE5 = new Cell();
                    cellE5.CellReference = $"E{i}";
                    cellE5.DataType = CellValues.String;
                    cellE5.CellValue = new CellValue($"{score21}");
                    dataRow.Append(cellE5);

                    score22 = sumExcel.GetSumF(us.Id, 3);
                    Cell cellF5 = new Cell();
                    cellF5.CellReference = $"F{i}";
                    cellF5.DataType = CellValues.String;
                    cellF5.CellValue = new CellValue($"{score22}");
                    dataRow.Append(cellF5);

                    score23 = sumExcel.GetSumG(us.Id, 3);
                    Cell cellG5 = new Cell();
                    cellG5.CellReference = $"G{i}";
                    cellG5.DataType = CellValues.String;
                    cellG5.CellValue = new CellValue($"{score23}");
                    dataRow.Append(cellG5);

                    score24 = sumExcel.GetSumI(us.Id, 3);
                    Cell cellI5 = new Cell();
                    cellI5.CellReference = $"I{i}";
                    cellI5.DataType = CellValues.String;
                    cellI5.CellValue = new CellValue($"{score24}");
                    dataRow.Append(cellI5);

                    score25 = sumExcel.GetSumJ(us.Id, 3);
                    Cell cellJ5 = new Cell();
                    cellJ5.CellReference = $"J{i}";
                    cellJ5.DataType = CellValues.String;
                    cellJ5.CellValue = new CellValue($"{score25}");
                    dataRow.Append(cellJ5);

                    score26 = sumExcel.GetSumK(us.Id, 3);
                    Cell cellK5 = new Cell();
                    cellK5.CellReference = $"K{i}";
                    cellK5.DataType = CellValues.String;
                    cellK5.CellValue = new CellValue($"{score26}");
                    dataRow.Append(cellK5);

                    score27 = sumExcel.GetSumL(us.Id, 3);
                    Cell cellL5 = new Cell();
                    cellL5.CellReference = $"L{i}";
                    cellL5.DataType = CellValues.String;
                    cellL5.CellValue = new CellValue($"{score27}");
                    dataRow.Append(cellL5);

                    score28 = sumExcel.GetSumM(us.Id, 3);
                    Cell cellM5 = new Cell();
                    cellM5.CellReference = $"M{i}";
                    cellM5.DataType = CellValues.String;
                    cellM5.CellValue = new CellValue($"{score28}");
                    dataRow.Append(cellM5);

                    score29 = sumExcel.GetSumN(us.Id, 3);
                    Cell cellN5 = new Cell();
                    cellN5.CellReference = $"N{i}";
                    cellN5.DataType = CellValues.String;
                    cellN5.CellValue = new CellValue($"{score29}");
                    dataRow.Append(cellN5);

                    score30 = sumExcel.GetSumO(us.Id, 3);
                    Cell cellO5 = new Cell();
                    cellO5.CellReference = $"O{i}";
                    cellO5.DataType = CellValues.String;
                    cellO5.CellValue = new CellValue($"{score30}");
                    dataRow.Append(cellO5);


                    var score = scoresController.GetScoreByDetail(user.Id, 9, year);
                    if (score == null)
                    {
                        score = scoresController.GetScoreByDetail(user.Id, 8, year);
                        if (score == null)
                        {
                            score = scoresController.GetScoreByDetail(user.Id, 7, year);
                            if(score == null)
                            {
                                score = scoresController.GetScoreByDetail(us.Id, 6, year);
                                if (score == null)
                                {
                                    score = scoresController.GetScoreByDetail(us.Id, 5, year);
                                    if (score == null)
                                    {
                                        score = scoresController.GetScoreByDetail(us.Id, 4, year);
                                        if (score == null)
                                        {
                                            score = scoresController.GetScoreByDetail(user.Id, 3, year);
                                            if (score == null)
                                            {
                                                score = scoresController.GetScoreByDetail(user.Id, 2, year);
                                                if (score == null)
                                                    score = scoresController.GetScoreByDetail(user.Id, 1, year);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    Cell cellQ5 = new Cell();
                    cellQ5.CellReference = $"Q{i}";
                    cellQ5.DataType = CellValues.String;
                    if (score == null)
                    {
                        cellQ5.CellValue = new CellValue($"{0}");
                    }
                    else
                    {
                        cellQ5.CellValue = new CellValue($"{score.FinalScore}");
                    }
                    dataRow.Append(cellQ5);
                }
				else if (sheetId == 16)
                {
                    score31 = await sumExcel.GetSumE(us.Id, 4);
                    Cell cellE5 = new Cell();
                    cellE5.CellReference = $"E{i}";
                    cellE5.DataType = CellValues.String ;
                    cellE5.CellValue = new CellValue($"{score31}");
                    dataRow.Append(cellE5);

                    score32 = sumExcel.GetSumF(us.Id, 4);
                    Cell cellF5 = new Cell();
                    cellF5.CellReference = $"F{i}";
                    cellF5.DataType = CellValues.String;
                    cellF5.CellValue = new CellValue($"{score32}");
                    dataRow.Append(cellF5);

                    score33 = sumExcel.GetSumG(us.Id, 4);
                    Cell cellG5 = new Cell();
                    cellG5.CellReference = $"G{i}";
                    cellG5.DataType = CellValues.String;
                    cellG5.CellValue = new CellValue($"{score33}");
                    dataRow.Append(cellG5);

                    score34 = sumExcel.GetSumI(us.Id, 4);
                    Cell cellI5 = new Cell();
                    cellI5.CellReference = $"I{i}";
                    cellI5.DataType = CellValues.String;
                    cellI5.CellValue = new CellValue($"{score34}");
                    dataRow.Append(cellI5);

                    score35 = sumExcel.GetSumJ(us.Id, 4);
                    Cell cellJ5 = new Cell();
                    cellJ5.CellReference = $"J{i}";
                    cellJ5.DataType = CellValues.String;
                    cellJ5.CellValue = new CellValue($"{score35}");
                    dataRow.Append(cellJ5);

                    score36 = sumExcel.GetSumK(us.Id, 4);
                    Cell cellK5 = new Cell();
                    cellK5.CellReference = $"K{i}";
                    cellK5.DataType = CellValues.String;
                    cellK5.CellValue = new CellValue($"{score36}");
                    dataRow.Append(cellK5);

                    score37 = sumExcel.GetSumL(us.Id, 4);
                    Cell cellL5 = new Cell();
                    cellL5.CellReference = $"L{i}";
                    cellL5.DataType = CellValues.String;
                    cellL5.CellValue = new CellValue($"{score37}");
                    dataRow.Append(cellL5);

                    score38 = sumExcel.GetSumM(us.Id, 4);
                    Cell cellM5 = new Cell();
                    cellM5.CellReference = $"M{i}";
                    cellM5.DataType = CellValues.String;
                    cellM5.CellValue = new CellValue($"{score38}");
                    dataRow.Append(cellM5);

                    score39 = sumExcel.GetSumN(us.Id, 4);
                    Cell cellN5 = new Cell();
                    cellN5.CellReference = $"N{i}";
                    cellN5.DataType = CellValues.String;
                    cellN5.CellValue = new CellValue($"{score39}");
                    dataRow.Append(cellN5);

                    score40 = sumExcel.GetSumO(us.Id, 4);
                    Cell cellO5 = new Cell();
                    cellO5.CellReference = $"O{i}";
                    cellO5.DataType = CellValues.String;
                    cellO5.CellValue = new CellValue($"{score40}");
                    dataRow.Append(cellO5);


                    var score = scoresController.GetScoreByDetail(user.Id, 12, year);
                    if (score == null)
                    {
                        score = scoresController.GetScoreByDetail(user.Id, 11, year);
                        if (score == null)
                        {
                            score = scoresController.GetScoreByDetail(user.Id, 10, year);
                            if(score == null)
                            {
                                score = scoresController.GetScoreByDetail(user.Id, 9, year);
                                if (score == null)
                                {
                                    score = scoresController.GetScoreByDetail(user.Id, 8, year);
                                    if (score == null)
                                    {
                                        score = scoresController.GetScoreByDetail(user.Id, 7, year);
                                        if (score == null)
                                        {
                                            score = scoresController.GetScoreByDetail(us.Id, 6, year);
                                            if (score == null)
                                            {
                                                score = scoresController.GetScoreByDetail(us.Id, 5, year);
                                                if (score == null)
                                                {
                                                    score = scoresController.GetScoreByDetail(us.Id, 4, year);
                                                    if (score == null)
                                                    {
                                                        score = scoresController.GetScoreByDetail(user.Id, 3, year);
                                                        if (score == null)
                                                        {
                                                            score = scoresController.GetScoreByDetail(user.Id, 2, year);
                                                            if (score == null)
                                                                score = scoresController.GetScoreByDetail(user.Id, 1, year);
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    Cell cellQ5 = new Cell();
                    cellQ5.CellReference = $"Q{i}";
                    cellQ5.DataType = CellValues.String;
                    if (score == null)
                    {
                        cellQ5.CellValue = new CellValue($"{0}");
                    }
                    else
                    {
                        cellQ5.CellValue = new CellValue($"{score.FinalScore}");
                    }
                    dataRow.Append(cellQ5);
                }
				else if (sheetId == 17)
                {
                    int sc = score1 + score11 + score21 + score31;
                    Cell cellE5 = new Cell();
                    cellE5.CellReference = $"E{i}";
                    cellE5.DataType = CellValues.String;
                    cellE5.CellValue = new CellValue($"{sc}");
                    dataRow.Append(cellE5);


                    int sc1 = score2 + score12 + score22 + score32;
                    Cell cellF5 = new Cell();
                    cellF5.CellReference = $"F{i}";
                    cellF5.DataType = CellValues.String;
                    cellF5.CellValue = new CellValue($"{sc1}");
                    dataRow.Append(cellF5);


                    int sc2 = score3 + score13 + score23 + score33;
                    Cell cellG5 = new Cell();
                    cellG5.CellReference = $"G{i}";
                    cellG5.DataType = CellValues.String;
                    cellG5.CellValue = new CellValue($"{sc2}");
                    dataRow.Append(cellG5);


                    int sc3 = score4 + score14 + score24 + score34;
                    Cell cellI5 = new Cell();
                    cellI5.CellReference = $"I{i}";
                    cellI5.DataType = CellValues.String;
                    cellI5.CellValue = new CellValue($"{sc3}");
                    dataRow.Append(cellI5);


                    int sc4 = score5 + score15 + score25 + score35;
                    Cell cellJ5 = new Cell();
                    cellJ5.CellReference = $"J{i}";
                    cellJ5.DataType = CellValues.String;
                    cellJ5.CellValue = new CellValue($"{sc4}");
                    dataRow.Append(cellJ5);


                    int sc5 = score6 + score16 + score26 + score36;
                    Cell cellK5 = new Cell();
                    cellK5.CellReference = $"K{i}";
                    cellK5.DataType = CellValues.String;
                    cellK5.CellValue = new CellValue($"{sc5}");
                    dataRow.Append(cellK5);


                    int sc6 = score7 + score17 + score27 + score37;
                    Cell cellL5 = new Cell();
                    cellL5.CellReference = $"L{i}";
                    cellL5.DataType = CellValues.String;
                    cellL5.CellValue = new CellValue($"{sc6}");
                    dataRow.Append(cellL5);


                    int sc7 = score8 + score18 + score28 + score38;
                    Cell cellM5 = new Cell();
                    cellM5.CellReference = $"M{i}";
                    cellM5.DataType = CellValues.String;
                    cellM5.CellValue = new CellValue($"{sc7}");
                    dataRow.Append(cellM5);


                    int sc8 = score9 + score19 + score29 + score39;
                    Cell cellN5 = new Cell();
                    cellN5.CellReference = $"N{i}";
                    cellN5.DataType = CellValues.String;
                    cellN5.CellValue = new CellValue($"{sc8}");
                    dataRow.Append(cellN5);


                    int sc9 = score10 + score20 + score30 + score40;
                    Cell cellO5 = new Cell();
                    cellO5.CellReference = $"O{i}";
                    cellO5.DataType = CellValues.String;
                    cellO5.CellValue = new CellValue($"{sc9}");
                    dataRow.Append(cellO5);


                    var score = scoresController.GetScoreByDetail(user.Id, 12, year);
                    if (score == null)
                    {
                        score = scoresController.GetScoreByDetail(user.Id, 11, year);
                        if (score == null)
                        {
                            score = scoresController.GetScoreByDetail(user.Id, 10, year);
                            if (score == null)
                            {
                                score = scoresController.GetScoreByDetail(user.Id, 9, year);
                                if (score == null)
                                {
                                    score = scoresController.GetScoreByDetail(user.Id, 8, year);
                                    if (score == null)
                                    {
                                        score = scoresController.GetScoreByDetail(user.Id, 7, year);
                                        if (score == null)
                                        {
                                            score = scoresController.GetScoreByDetail(us.Id, 6, year);
                                            if (score == null)
                                            {
                                                score = scoresController.GetScoreByDetail(us.Id, 5, year);
                                                if (score == null)
                                                {
                                                    score = scoresController.GetScoreByDetail(us.Id, 4, year);
                                                    if (score == null)
                                                    {
                                                        score = scoresController.GetScoreByDetail(user.Id, 3, year);
                                                        if (score == null)
                                                        {
                                                            score = scoresController.GetScoreByDetail(user.Id, 2, year);
                                                            if (score == null)
                                                                score = scoresController.GetScoreByDetail(user.Id, 1, year);
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    Cell cellQ5 = new Cell();
                    cellQ5.CellReference = $"Q{i}";
                    cellQ5.DataType = CellValues.String;
                    if (score == null)
                    {
                        cellQ5.CellValue = new CellValue($"{0}");
                    }
                    else
                    {
                        cellQ5.CellValue = new CellValue($"{score.FinalScore}");
                    }
                    dataRow.Append(cellQ5);
                }


				sheetData.Append(dataRow);
				i++;
			}

			#endregion

			worksheetPart.Worksheet = worksheet;
            workbookPart.Workbook.Save();
        }
    }
}
