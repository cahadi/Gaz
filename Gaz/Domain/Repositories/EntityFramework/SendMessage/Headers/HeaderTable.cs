using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml;
using Gaz.Domain.Entities;
using Gaz.Data;

namespace Gaz.Domain.Repositories.EntityFramework.SendMessage.Headers
{
    public class HeaderTable
	{
		private readonly freedb_testdbgazContext _context;
		public HeaderTable(freedb_testdbgazContext context)
		{
			_context = context;
		}

		public static void CreateHeader(WorkbookPart workbookPart, StringValue id,
			User user, List<User> users,
			Explanation ex, List<Explanation> explanations,
			List<Poll> polls)
		{
			List<Poll> polls1 = polls.Where(p => p.Month == int.Parse(id)).ToList();
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
				Width = 20,
				CustomWidth = true
			};
			columns.Append(columnC);

			Column columnD = new Column()
			{
				Min = 4,
				Max = 4,
				Width = 25,
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
				Width = 30,
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
				Width = 20,
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

			Cell cell2 = new Cell();
			cell2.CellReference = "C2";
			cell2.DataType = CellValues.String;
			cell2.CellValue = new CellValue("ПОЯСНЕНИЯ");
			row2.Append(cell2);
			MergeCells mergeCells2 = new MergeCells();
			MergeCell mergeCell2 = new MergeCell()
			{
				Reference = new StringValue("C2:C4")
			};
			mergeCells2.Append(mergeCell2);
			worksheet.Append(mergeCells2);

			Cell cell3 = new Cell();
			cell3.CellReference = "D2";
			cell3.DataType = CellValues.String;
			cell3.CellValue = new CellValue("НАПРАВЛЕНИЕ ДЕЯТЕЛЬНОСТИ");
			row2.Append(cell3);
			MergeCells mergeCells3 = new MergeCells();
			MergeCell mergeCell3 = new MergeCell()
			{
				Reference = new StringValue("D2:O2")
			};
			mergeCells3.Append(mergeCell3);
			worksheet.Append(mergeCells3);

			Cell cell1 = new Cell();
			cell1.CellReference = "P2";
			cell1.DataType = CellValues.String;
			cell1.CellValue = new CellValue("БАЛЛЫ");
			row2.Append(cell1);
			MergeCells mergeCells1 = new MergeCells();
			MergeCell mergeCell1 = new MergeCell()
			{
				Reference = new StringValue("P2:Q3")
			};
			mergeCells1.Append(mergeCell1);
			worksheet.Append(mergeCells1);

			Cell cell4 = new Cell();
			cell4.CellReference = "D3";
			cell4.DataType = CellValues.String;
			cell4.CellValue = new CellValue("Производственное");
			row3.Append(cell4);
			MergeCells mergeCells4 = new MergeCells();
			MergeCell mergeCell4 = new MergeCell()
			{
				Reference = new StringValue("D3:I3")
			};
			mergeCells4.Append(mergeCell4);
			worksheet.Append(mergeCells4);

			Cell cell5 = new Cell();
			cell5.CellReference = "J3";
			cell5.DataType = CellValues.String;
			cell5.CellValue = new CellValue("Дополнительное\n производственное");
			row3.Append(cell5);
			MergeCells mergeCells5 = new MergeCells();
			MergeCell mergeCell5 = new MergeCell()
			{
				Reference = new StringValue("J3:K3")
			};
			mergeCells5.Append(mergeCell5);
			worksheet.Append(mergeCells5);

			Cell cell6 = new Cell();
			cell6.CellReference = "L3";
			cell6.DataType = CellValues.String;
			cell6.CellValue = new CellValue("Социально-культурное");
			row3.Append(cell6);
			MergeCells mergeCells6 = new MergeCells();
			MergeCell mergeCell6 = new MergeCell()
			{
				Reference = new StringValue("L3:N3")
			};
			mergeCells6.Append(mergeCell6);
			worksheet.Append(mergeCells6);

			Cell cell7 = new Cell();
			cell7.CellReference = "O3";
			cell7.DataType = CellValues.String;
			cell7.CellValue = new CellValue("Доп.\n социокульт.");
			row3.Append(cell7);

			Cell cell8 = new Cell();
			cell8.CellReference = "D4";
			cell8.DataType = CellValues.String;
			cell8.CellValue = new CellValue("Дисциплина организации\n труда и качество\n выполнения работ");
			row4.Append(cell8);

			Cell cell9 = new Cell();
			cell9.CellReference = "E4";
			cell9.DataType = CellValues.String;
			cell9.CellValue = new CellValue("Заполнение формы\n идентификации опасности\n в системе \"СТОП-РИСК\"");
			row4.Append(cell9);

			Cell cell10 = new Cell();
			cell10.CellReference = "F4";
			cell10.DataType = CellValues.String;
			cell10.CellValue = new CellValue("Рационализаторская\n деятельность");
			row4.Append(cell10);

			Cell cell11 = new Cell();
			cell11.CellReference = "G4";
			cell11.DataType = CellValues.String;
			cell11.CellValue = new CellValue("Внедрение предложений\n по системе\n \"Бережливое производство\"");
			row4.Append(cell11);

			Cell cell12 = new Cell();
			cell12.CellReference = "H4";
			cell12.DataType = CellValues.String;
			cell12.CellValue = new CellValue("Оценка руководителя\n (корректирующий коэффициент)");
			row4.Append(cell12);

			Cell cell13 = new Cell();
			cell13.CellReference = "I4";
			cell13.DataType = CellValues.String;
			cell13.CellValue = new CellValue("Положительный опыт,\n Оценка филиала");
			row4.Append(cell13);

			Cell cell14 = new Cell();
			cell14.CellReference = "J4";
			cell14.DataType = CellValues.String;
			cell14.CellValue = new CellValue("Наставничество");
			row4.Append(cell14);

			Cell cell15 = new Cell();
			cell15.CellReference = "K4";
			cell15.DataType = CellValues.String;
			cell15.CellValue = new CellValue("Участие в конкурсе\n профмастерства,\n Семинарах в\n качестве докладчика");
			row4.Append(cell15);

			Cell cell16 = new Cell();
			cell16.CellReference = "L4";
			cell16.DataType = CellValues.String;
			cell16.CellValue = new CellValue("Экология (участие в\n экологических акциях)");
			row4.Append(cell16);

			Cell cell17 = new Cell();
			cell17.CellReference = "M4";
			cell17.DataType = CellValues.String;
			cell17.CellValue = new CellValue("Спорт (участие в\n спортивных мероприятиях)");
			row4.Append(cell17);

			Cell cell18 = new Cell();
			cell18.CellReference = "N4";
			cell18.DataType = CellValues.String;
			cell18.CellValue = new CellValue("Культурно-массовые\n мероприятия");
			row4.Append(cell18);

			Cell cell19 = new Cell();
			cell19.CellReference = "O4";
			cell19.DataType = CellValues.String;
			cell19.CellValue = new CellValue("Благотворительные\n акции");
			row4.Append(cell19);

			Cell cell20 = new Cell();
			cell20.CellReference = "P4";
			cell20.DataType = CellValues.String;
			cell20.CellValue = new CellValue("За текущий месяц");
			row4.Append(cell20);

			Cell cell21 = new Cell();
			cell21.CellReference = "Q4";
			cell21.DataType = CellValues.String;
			cell21.CellValue = new CellValue("Суммарный годовой\n (январь - декабрь)");
			row4.Append(cell21);

			#endregion

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

				if (ex != null)
				{
					Cell cellC5 = new Cell();
					cellC5.CellReference = $"C{i}";
					cellC5.DataType = CellValues.String;
					cellC5.CellValue = new CellValue($"{ex.Explanation1}");
					row5.Append(cellC5);
				}

				List<Poll> polls2 = polls.Where(p => p.UserId == user.Id).ToList();

				Poll poll = polls2.FirstOrDefault(p => p.EstimationsMarks.EstimationId == 1);
				Cell cellD5 = new Cell();
				cellD5.CellReference = $"D{i}";
				cellD5.DataType = CellValues.String;
				cellD5.CellValue = new CellValue($"{poll.EstimationsMarks.Mark.YesNo}");
				row5.Append(cellD5);

				Poll poll1 = polls2.FirstOrDefault(p => p.EstimationsMarks.EstimationId == 2);
				Cell cellE5 = new Cell();
				cellE5.CellReference = $"E{i}";
				cellE5.DataType = CellValues.String;
				if (poll1.EstimationsMarks.Mark.YesNo != null)
					cellE5.CellValue = new CellValue($"{poll1.EstimationsMarks.Mark.YesNo}");
				else
					cellE5.CellValue = new CellValue($"{poll1.EstimationsMarks.Mark.BigMark}");
				row5.Append(cellE5);

				Poll poll2 = polls2.FirstOrDefault(p => p.EstimationsMarks.EstimationId == 3);
				Cell cellF5 = new Cell();
				cellF5.CellReference = $"F{i}";
				cellF5.DataType = CellValues.String;
				if (poll2.EstimationsMarks.Mark.YesNo != null)
					cellF5.CellValue = new CellValue($"{poll2.EstimationsMarks.Mark.YesNo}");
				else
					cellE5.CellValue = new CellValue($"{poll1.EstimationsMarks.Mark.BigMark}");
				row5.Append(cellF5);

				Poll poll3 = polls2.FirstOrDefault(p => p.EstimationsMarks.EstimationId == 4);
				Cell cellG5 = new Cell();
				cellG5.CellReference = $"G{i}";
				cellG5.DataType = CellValues.String;
				cellG5.CellValue = new CellValue($"{poll3.EstimationsMarks.Mark.YesNo}");
				row5.Append(cellG5);

				Poll poll4 = polls2.FirstOrDefault(p => p.EstimationsMarks.EstimationId == 5);
				Cell cellH5 = new Cell();
				cellH5.CellReference = $"H{i}";
				cellH5.DataType = CellValues.String;
				cellH5.CellValue = new CellValue($"{poll4.EstimationsMarks.Mark.LowMark}");
				row5.Append(cellH5);

				Poll poll5 = polls2.FirstOrDefault(p => p.EstimationsMarks.EstimationId == 6);
				Cell cellI5 = new Cell();
				cellI5.CellReference = $"I{i}";
				cellI5.DataType = CellValues.String;
				cellI5.CellValue = new CellValue($"{poll5.EstimationsMarks.Mark.YesNo}");
				row5.Append(cellI5);

				Poll poll6 = polls2.FirstOrDefault(p => p.EstimationsMarks.EstimationId == 12);
				Cell cellJ5 = new Cell();
				cellJ5.CellReference = $"J{i}";
				cellJ5.DataType = CellValues.String;
				cellJ5.CellValue = new CellValue($"{poll6.EstimationsMarks.Mark.YesNo}");
				row5.Append(cellJ5);

				Poll poll7 = polls2.FirstOrDefault(p => p.EstimationsMarks.EstimationId == 7);
				Cell cellK5 = new Cell();
				cellK5.CellReference = $"K{i}";
				cellK5.DataType = CellValues.String;
				cellK5.CellValue = new CellValue($"{poll7.EstimationsMarks.Mark.YesNo}");
				row5.Append(cellK5);

				Poll poll8 = polls2.FirstOrDefault(p => p.EstimationsMarks.EstimationId == 8);
				Cell cellL5 = new Cell();
				cellL5.CellReference = $"L{i}";
				cellL5.DataType = CellValues.String;
				cellL5.CellValue = new CellValue($"{poll8.EstimationsMarks.Mark.YesNo}");
				row5.Append(cellL5);

				Poll poll9 = polls2.FirstOrDefault(p => p.EstimationsMarks.EstimationId == 9);
				Cell cellM5 = new Cell();
				cellM5.CellReference = $"M{i}";
				cellM5.DataType = CellValues.String;
				cellM5.CellValue = new CellValue($"{poll9.EstimationsMarks.Mark.YesNo}");
				row5.Append(cellM5);

				Poll poll10 = polls2.FirstOrDefault(p => p.EstimationsMarks.EstimationId == 10);
				Cell cellN5 = new Cell();
				cellN5.CellReference = $"N{i}";
				cellN5.DataType = CellValues.String;
				cellN5.CellValue = new CellValue($"{poll10.EstimationsMarks.Mark.YesNo}");
				row5.Append(cellN5);

				Poll poll11 = polls2.FirstOrDefault(p => p.EstimationsMarks.EstimationId == 11);
				Cell cellO5 = new Cell();
				cellO5.CellReference = $"O{i}";
				cellO5.DataType = CellValues.String;
				cellO5.CellValue = new CellValue($"{poll11.EstimationsMarks.Mark.YesNo}");
				row5.Append(cellO5);


				Cell cellP5 = new Cell();
				cellP5.CellReference = $"P{i}";
				cellP5.DataType = CellValues.SharedString;
				cellP5.CellValue = new CellValue($"=((ЕСЛИ(И(D{i}=\"Да\";H{i}=1);15;0))+(ЕСЛИ(И(D{i}=\"Да\";НЕ(H{i}=1));H{i}*30;0))+ЕСЛИ(E{i}=\"Нет\";0;E{i}))+(ЕСЛИ(F{i}=\"Нет\";0;F5))+(ЕСЛИ(I{i}=\"Да\";10;0))+(ЕСЛИ(I{i}=\"Нет\";0))+(ЕСЛИ(G{i}=\"Да\";10;0))+(ЕСЛИ(J{i}=\"Да\";10;0))+(ЕСЛИ(K{i}=\"Да\";10;0))+(ЕСЛИ(L{i}=\"Да\";10;0))+(ЕСЛИ(СОВПАД(\"Да\";M{i});10;0))+(ЕСЛИ(СОВПАД(\"да\";M{i});5;0))+(ЕСЛИ(СОВПАД(\"Да\";N{i});10;0))+(ЕСЛИ(СОВПАД(\"да\";N{i});5;0))+(ЕСЛИ(СОВПАД(\"Да\";O{i});10;0))+(ЕСЛИ(СОВПАД(\"да\";O{i});5;0))");
				row5.Append(cellP5);


				Cell cellQ5 = new Cell();
				cellQ5.CellReference = $"Q{i}";
				cellQ5.DataType = CellValues.SharedString;
				if (int.TryParse(id, out int idValue) && idValue == 1)
				{
					cellQ5.CellValue = new CellValue($"=P{i}");
				}
				else if (int.TryParse(id, out int idValue2) && idValue2 == 2)
				{
					cellQ5.CellValue = new CellValue($"=P{i}+Январь!Q{i}");
				}
				else if (int.TryParse(id, out int idValue3) && idValue3 == 3)
				{
					cellQ5.CellValue = new CellValue($"=P{i}+Февраль!Q{i}");
				}
				else if (int.TryParse(id, out int idValue4) && idValue4 == 4)
				{
					cellQ5.CellValue = new CellValue($"=P{i}+Март!Q{i}");
				}
				else if (int.TryParse(id, out int idValue5) && idValue5 == 5)
				{
					cellQ5.CellValue = new CellValue($"=P{i}+Апрель!Q{i}");
				}
				else if (int.TryParse(id, out int idValue6) && idValue6 == 6)
				{
					cellQ5.CellValue = new CellValue($"=P{i}+Май!Q{i}");
				}
				else if (int.TryParse(id, out int idValue7) && idValue7 == 7)
				{
					cellQ5.CellValue = new CellValue($"=P{i}+Июнь!Q{i}");
				}
				else if (int.TryParse(id, out int idValue8) && idValue8 == 8)
				{
					cellQ5.CellValue = new CellValue($"=P{i}+Июль!Q{i}");
				}
				else if (int.TryParse(id, out int idValue9) && idValue9 == 9)
				{
					cellQ5.CellValue = new CellValue($"=P{i}+Август!Q{i}");
				}
				else if (int.TryParse(id, out int idValue10) && idValue10 == 10)
				{
					cellQ5.CellValue = new CellValue($"=P{i}+Сентябрь!Q{i}");
				}
				else if (int.TryParse(id, out int idValue11) && idValue11 == 11)
				{
					cellQ5.CellValue = new CellValue($"=P{i}+Октябрь!Q{i}");
				}
				else if (int.TryParse(id, out int idValue12) && idValue12 == 12)
				{
					cellQ5.CellValue = new CellValue($"=P{i}+Ноябрь!Q{i}");
				}
				row5.Append(cellQ5);


				sheetData.Append(row5);
				i++;
			}

			sheetData.Append(row);
			sheetData.Append(row2);
			sheetData.Append(row3);
			sheetData.Append(row4);

			foreach (User us in users)
			{
				Row dataRow = new Row();
				dataRow.Height = 25;

				Cell dataCell2 = new Cell();
				dataCell2.DataType = CellValues.String;
				dataCell2.CellValue = new CellValue(us.Fio);
				dataCell2.CellReference = $"B{i}";
				dataRow.Append(dataCell2);

				var exp = explanations.FirstOrDefault(e => e.UserId == us.Id);
				if (exp != null)
				{
					Cell cellC5 = new Cell();
					cellC5.CellReference = $"C{i}";
					cellC5.DataType = CellValues.String;
					cellC5.CellValue = new CellValue($"{ex.Explanation1}");
					dataRow.Append(cellC5);
				}
				else
				{
					Cell cellC5 = new Cell();
					cellC5.CellReference = $"C{i}";
					cellC5.DataType = CellValues.String;
					cellC5.CellValue = new CellValue("Нет пояснений");
					dataRow.Append(cellC5);
				}

				List<Poll> polls2 = polls.Where(p => p.UserId == us.Id).ToList();


				Poll poll = polls2.FirstOrDefault(p => p.EstimationsMarks.EstimationId == 1);

				Cell cellD5 = new Cell();
				cellD5.CellReference = $"D{i}";
				cellD5.DataType = CellValues.String;
				if (poll == null)
					cellD5.CellValue = new CellValue($"Нет");
				else
					cellD5.CellValue = new CellValue($"{poll.EstimationsMarks.Mark.YesNo}");
				dataRow.Append(cellD5);


				Poll poll1 = polls2.FirstOrDefault(p => p.EstimationsMarks.EstimationId == 2);

				Cell cellE5 = new Cell();
				cellE5.CellReference = $"E{i}";
				cellE5.DataType = CellValues.String;
				if (poll1 == null)
					cellE5.CellValue = new CellValue($"Нет");
				else if (poll1.EstimationsMarks.Mark.YesNo != null)
					cellE5.CellValue = new CellValue($"{poll1.EstimationsMarks.Mark.YesNo}");
				else
					cellE5.CellValue = new CellValue($"{poll1.EstimationsMarks.Mark.BigMark}");
				dataRow.Append(cellE5);


				Poll poll2 = polls2.FirstOrDefault(p => p.EstimationsMarks.EstimationId == 3);

				Cell cellF5 = new Cell();
				cellF5.CellReference = $"F{i}";
				cellF5.DataType = CellValues.String;

				if (poll2 == null)
					cellF5.CellValue = new CellValue($"Нет");
				else if (poll2.EstimationsMarks.Mark.YesNo != null)
					cellF5.CellValue = new CellValue($"{poll2.EstimationsMarks.Mark.YesNo}");
				else
					cellE5.CellValue = new CellValue($"{poll1.EstimationsMarks.Mark.BigMark}");
				dataRow.Append(cellF5);


				Poll poll3 = polls2.FirstOrDefault(p => p.EstimationsMarks.EstimationId == 4);

				Cell cellG5 = new Cell();
				cellG5.CellReference = $"G{i}";
				cellG5.DataType = CellValues.String;
				if (poll3 == null)
					cellG5.CellValue = new CellValue($"Нет");
				else
					cellG5.CellValue = new CellValue($"{poll3.EstimationsMarks.Mark.YesNo}");
				dataRow.Append(cellG5);


				Poll poll4 = polls2.FirstOrDefault(p => p.EstimationsMarks.EstimationId == 5);

				Cell cellH5 = new Cell();
				cellH5.CellReference = $"H{i}";
				cellH5.DataType = CellValues.Number;
				if (poll4 == null)
					cellH5.CellValue = new CellValue(1);
				else
					cellH5.CellValue = new CellValue($"{poll4.EstimationsMarks.Mark.LowMark}");
				dataRow.Append(cellH5);


				Poll poll5 = polls2.FirstOrDefault(p => p.EstimationsMarks.EstimationId == 6);

				Cell cellI5 = new Cell();
				cellI5.CellReference = $"I{i}";
				cellI5.DataType = CellValues.String;
				if (poll5 == null)
					cellI5.CellValue = new CellValue($"Нет");
				else
					cellI5.CellValue = new CellValue($"{poll5.EstimationsMarks.Mark.YesNo}");
				dataRow.Append(cellI5);

				Poll poll6 = polls2.FirstOrDefault(p => p.EstimationsMarks.EstimationId == 12);

				Cell cellJ5 = new Cell();
				cellJ5.CellReference = $"J{i}";
				cellJ5.DataType = CellValues.String;
				if (poll6 == null)
					cellJ5.CellValue = new CellValue($"Нет");
				else
					cellJ5.CellValue = new CellValue($"{poll6.EstimationsMarks.Mark.YesNo}");
				dataRow.Append(cellJ5);


				Poll poll7 = polls2.FirstOrDefault(p => p.EstimationsMarks.EstimationId == 7);

				Cell cellK5 = new Cell();
				cellK5.CellReference = $"K{i}";
				cellK5.DataType = CellValues.String;
				if (poll7 == null)
					cellK5.CellValue = new CellValue($"Нет");
				else
					cellK5.CellValue = new CellValue($"{poll7.EstimationsMarks.Mark.YesNo}");
				dataRow.Append(cellK5);


				Poll poll8 = polls2.FirstOrDefault(p => p.EstimationsMarks.EstimationId == 8);

				Cell cellL5 = new Cell();
				cellL5.CellReference = $"L{i}";
				cellL5.DataType = CellValues.String;
				if (poll8 == null)
					cellL5.CellValue = new CellValue($"Нет");
				else
					cellL5.CellValue = new CellValue($"{poll8.EstimationsMarks.Mark.YesNo}");
				dataRow.Append(cellL5);


				Poll poll9 = polls2.FirstOrDefault(p => p.EstimationsMarks.EstimationId == 9);

				Cell cellM5 = new Cell();
				cellM5.CellReference = $"M{i}";
				cellM5.DataType = CellValues.String;
				if (poll9 == null)
					cellM5.CellValue = new CellValue($"Нет");
				else
					cellM5.CellValue = new CellValue($"{poll9.EstimationsMarks.Mark.YesNo}");
				dataRow.Append(cellM5);


				Poll poll10 = polls2.FirstOrDefault(p => p.EstimationsMarks.EstimationId == 10);

				Cell cellN5 = new Cell();
				cellN5.CellReference = $"N{i}";
				cellN5.DataType = CellValues.String;
				if (poll10 == null)
					cellN5.CellValue = new CellValue($"Нет");
				else
					cellN5.CellValue = new CellValue($"{poll10.EstimationsMarks.Mark.YesNo}");
				dataRow.Append(cellN5);


				Poll poll11 = polls2.FirstOrDefault(p => p.EstimationsMarks.EstimationId == 11);

				Cell cellO5 = new Cell();
				cellO5.CellReference = $"O{i}";
				cellO5.DataType = CellValues.String;
				if (poll11 == null)
					cellO5.CellValue = new CellValue($"Нет");
				else
					cellO5.CellValue = new CellValue($"{poll11.EstimationsMarks.Mark.YesNo}");
				dataRow.Append(cellO5);


				Cell cellP5 = new Cell();
				cellP5.CellReference = $"P{i}";
				cellP5.DataType = CellValues.String;
				cellP5.CellValue = new CellValue($"=(ЕСЛИ((D{i}=\"Да\");H{i}*30;0)+ЕСЛИ(E{i}=\"Нет\";0;E{i}))+(ЕСЛИ(F{i}=\"Нет\";0;F{i}))+(ЕСЛИ(I{i}=\"Да\";10;0))+(ЕСЛИ(I{i}=\"Нет\";0))+(ЕСЛИ(G{i}=\"Да\";10;0))+(ЕСЛИ(J{i}=\"Да\";10;0))+(ЕСЛИ(K{i}=\"Да\";10;0))+(ЕСЛИ(L{i}=\"Да\";10;0))+(ЕСЛИ(СОВПАД(\"Да\";M{i});10;0))+(ЕСЛИ(СОВПАД(\"да\";M{i});5;0))+(ЕСЛИ(N{i}=\"Да\";10;0))+(ЕСЛИ(СОВПАД(\"Да\";O{i});10;0))+(ЕСЛИ(СОВПАД(\"да\";O{i});5;0))");
				dataRow.Append(cellP5);


				Cell cellQ5 = new Cell();
				cellQ5.CellReference = $"Q{i}";
				cellQ5.DataType = CellValues.String;
				if (int.TryParse(id, out int idValue) && idValue == 1)
				{
					cellQ5.CellValue = new CellValue($"=P{i}");
				}
				else if (int.TryParse(id, out int idValue1) && idValue1 == 2)
				{
					cellQ5.CellValue = new CellValue($"=P{i}+Январь!Q{i}");
				}
				else if (int.TryParse(id, out int idValue2) && idValue2 == 3)
				{
					cellQ5.CellValue = new CellValue($"=P{i}+Февраль!Q{i}");
				}
				else if (int.TryParse(id, out int idValue3) && idValue3 == 4)
				{
					cellQ5.CellValue = new CellValue($"=P{i}+Март!Q{i}");
				}
				else if (int.TryParse(id, out int idValue4) && idValue4 == 5)
				{
					cellQ5.CellValue = new CellValue($"=P{i}+Апрель!Q{i}");
				}
				else if (int.TryParse(id, out int idValue5) && idValue5 == 6)
				{
					cellQ5.CellValue = new CellValue($"=P{i}+Май!Q{i}");
				}
				else if (int.TryParse(id, out int idValue6) && idValue6 == 7)
				{
					cellQ5.CellValue = new CellValue($"=P{i}+Июнь!Q{i}");
				}
				else if (int.TryParse(id, out int idValue7) && idValue7 == 8)
				{
					cellQ5.CellValue = new CellValue($"=P{i}+Июль!Q{i}");
				}
				else if (int.TryParse(id, out int idValue8) && idValue8 == 9)
				{
					cellQ5.CellValue = new CellValue($"=P{i}+Август!Q{i}");
				}
				else if (int.TryParse(id, out int idValue9) && idValue9 == 10)
				{
					cellQ5.CellValue = new CellValue($"=P{i}+Сентябрь!Q{i}");
				}
				else if (int.TryParse(id, out int idValue10) && idValue10 == 11)
				{
					cellQ5.CellValue = new CellValue($"=P{i}+Октябрь!Q{i}");
				}
				else if (int.TryParse(id, out int idValue11) && idValue11 == 12)
				{
					cellQ5.CellValue = new CellValue($"=P{i}+Ноябрь!Q{i}");
				}
				dataRow.Append(cellQ5);


				sheetData.Append(dataRow);
				i++;
			}

			worksheetPart.Worksheet = worksheet;
			workbookPart.Workbook.Save();
		}
	}
}
