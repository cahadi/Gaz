using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Spreadsheet;
using Gaz.Domain.Entities;

namespace Gaz.Domain.Repositories.EntityFramework.SendMessage.Headers
{
    public class QuarterHeaderTable
	{
		public static void CreateHeader(WorkbookPart workbookPart, StringValue id,
			User user, List<User> users)
		{

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

			#region Списки

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


				if (int.TryParse(id, out int idValue12) && idValue12 == 13)
				{
					Cell cellE5 = new Cell();
					cellE5.CellReference = $"E{i}";
					cellE5.DataType = CellValues.SharedString;
					cellE5.CellValue = new CellValue($"=(ЕСЛИ(Январь!E{i}=5;1;0)+ЕСЛИ(Январь!E{i}=10;2;0)+ЕСЛИ(Январь!E{i}=15;3;0)+ЕСЛИ(Январь!E{i}=20;4;0))+(ЕСЛИ(Февраль!E{i}=5;1;0)+ЕСЛИ(Февраль!E{i}=10;2;0)+ЕСЛИ(Февраль!E{i}=15;3;0)+ЕСЛИ(Февраль!E{i}=20;4;0))+(ЕСЛИ(Март!E{i}=5;1;0)+ЕСЛИ(Март!E{i}=10;2;0)+ЕСЛИ(Март!E{i}=15;3;0)+ЕСЛИ(Март!E{i}=20;4;0))");
					row5.Append(cellE5);


					Cell cellF5 = new Cell();
					cellF5.CellReference = $"F{i}";
					cellF5.DataType = CellValues.String;
					cellF5.CellValue = new CellValue($"=(ЕСЛИ(Январь!F{i}=5;0,5;0)+ЕСЛИ(Январь!F{i}=10;1;0)+ЕСЛИ(Январь!F{i}=20;2;0))+(ЕСЛИ(Февраль!F{i}=5;0,5;0)+ЕСЛИ(Февраль!F{i}=10;1;0)+ЕСЛИ(Февраль!F{i}=20;2;0))+(ЕСЛИ(Март!F{i}=5;0,5;0)+ЕСЛИ(Март!F{i}=10;1;0)+ЕСЛИ(Март!F{i}=20;2;0))");
					row5.Append(cellF5);

					Cell cellG5 = new Cell();
					cellG5.CellReference = $"G{i}";
					cellG5.DataType = CellValues.String;
					cellG5.CellValue = new CellValue($"=ЕСЛИ(Январь!G{i}=\"Да\";1;0)+ЕСЛИ(Февраль!G{i}=\"Да\";1;0)+ЕСЛИ(Март!G{i}=\"Да\";1;0)");
					row5.Append(cellG5);

					Cell cellI5 = new Cell();
					cellI5.CellReference = $"I{i}";
					cellI5.DataType = CellValues.String;
					cellI5.CellValue = new CellValue($"=ЕСЛИ(Январь!I{i}=\"Да\";1;0)+ЕСЛИ(Февраль!I{i}=\"Да\";1;0)+ЕСЛИ(Март!I{i}=\"Да\";1;0)");
					row5.Append(cellI5);

					Cell cellJ5 = new Cell();
					cellJ5.CellReference = $"J{i}";
					cellJ5.DataType = CellValues.String;
					cellJ5.CellValue = new CellValue($"=ЕСЛИ(Январь!J{i}=\"Да\";1;0)+ЕСЛИ(Февраль!J{i}=\"Да\";1;0)+ЕСЛИ(Март!J{i}=\"Да\";1;0)");
					row5.Append(cellJ5);

					Cell cellK5 = new Cell();
					cellK5.CellReference = $"K{i}";
					cellK5.DataType = CellValues.String;
					cellK5.CellValue = new CellValue($"=ЕСЛИ(Январь!K{i}=\"Да\";1;0)+ЕСЛИ(Февраль!K{i}=\"Да\";1;0)+ЕСЛИ(Март!K{i}=\"Да\";1;0)");
					row5.Append(cellK5);

					Cell cellL5 = new Cell();
					cellL5.CellReference = $"L{i}";
					cellL5.DataType = CellValues.String;
					cellL5.CellValue = new CellValue($"=ЕСЛИ(Январь!L{i}=\"Да\";1;0)+ЕСЛИ(Февраль!L{i}=\"Да\";1;0)+ЕСЛИ(Март!L{i}=\"Да\";1;0)");
					row5.Append(cellL5);

					Cell cellM5 = new Cell();
					cellM5.CellReference = $"M{i}";
					cellM5.DataType = CellValues.String;
					cellM5.CellValue = new CellValue($"=ЕСЛИ(СОВПАД(Январь!M{i};\"да\");0,5;0)+ЕСЛИ(СОВПАД(Январь!M{i};\"Да\");1;0)+ЕСЛИ(СОВПАД(Февраль!M{i};\"да\");0,5;0)+ЕСЛИ(СОВПАД(Февраль!M{i};\"Да\");1;0)+ЕСЛИ(СОВПАД(Март!M{i};\"да\");0,5;0)+ЕСЛИ(СОВПАД(Март!M{i};\"Да\");1;0)");
					row5.Append(cellM5);

					Cell cellN5 = new Cell();
					cellN5.CellReference = $"N{i}";
					cellN5.DataType = CellValues.String;
					cellN5.CellValue = new CellValue($"=ЕСЛИ(СОВПАД(Январь!N{i};\"да\");0,5;0)+ЕСЛИ(СОВПАД(Январь!N{i};\"Да\");1;0)+ЕСЛИ(СОВПАД(Февраль!N{i};\"да\");0,5;0)+ЕСЛИ(СОВПАД(Февраль!N{i};\"Да\");1;0)+ЕСЛИ(СОВПАД(Март!N{i};\"да\");0,5;0)+ЕСЛИ(СОВПАД(Март!N{i};\"Да\");1;0)");
					row5.Append(cellN5);

					Cell cellO5 = new Cell();
					cellO5.CellReference = $"O{i}";
					cellO5.DataType = CellValues.String;
					cellO5.CellValue = new CellValue($"=ЕСЛИ(СОВПАД(Январь!O{i};\"да\");0,5;0)+ЕСЛИ(СОВПАД(Январь!O{i};\"Да\");1;0)+ЕСЛИ(СОВПАД(Февраль!O{i};\"да\");0,5;0)+ЕСЛИ(СОВПАД(Февраль!O{i};\"Да\");1;0)+ЕСЛИ(СОВПАД(Март!O{i};\"да\");0,5;0)+ЕСЛИ(СОВПАД(Март!O{i};\"Да\");1;0)");
					row5.Append(cellO5);

					Cell cellQ5 = new Cell();
					cellQ5.CellReference = $"Q{i}";
					cellQ5.DataType = CellValues.String;
					cellQ5.CellValue = new CellValue($"=Март!Q{i}");
					row5.Append(cellQ5);
				}
				else if (int.TryParse(id, out int idValue13) && idValue13 == 14)
				{
					Cell cellE5 = new Cell();
					cellE5.CellReference = $"E{i}";
					cellE5.DataType = CellValues.String;
					cellE5.CellValue = new CellValue($"=(ЕСЛИ(Апрель!E{i}=5;1;0)+ЕСЛИ(Апрель!E{i}=10;2;0)+ЕСЛИ(Апрель!E{i}=15;3;0)+ЕСЛИ(Апрель!E{i}=4;2;0))+(ЕСЛИ(Май!E{i}=5;1;0)+ЕСЛИ(Май!E{i}=10;2;0)+ЕСЛИ(Май!E{i}=15;3;0)+ЕСЛИ(Май!E{i}=20;4;0))+(ЕСЛИ(Июнь!E{i}=5;1;0)+ЕСЛИ(Июнь!E{i}=10;2;0)+ЕСЛИ(Июнь!E{i}=15;3;0)+ЕСЛИ(Июнь!E{i}=20;4;0))");
					row5.Append(cellE5);


					Cell cellF5 = new Cell();
					cellF5.CellReference = $"F{i}";
					cellF5.DataType = CellValues.String;
					cellF5.CellValue = new CellValue($"=(ЕСЛИ(Апрель!F{i}=5;0,5;0)+ЕСЛИ(Апрель!F{i}=10;1;0)+ЕСЛИ(Апрель!F{i}=20;2;0))+(ЕСЛИ(Май!F{i}=5;0,5;0)+ЕСЛИ(Май!F{i}=10;1;0)+ЕСЛИ(Май!F{i}=20;2;0))+(ЕСЛИ(Июнь!F{i}=5;0,5;0)+ЕСЛИ(Июнь!F{i}=10;1;0)+ЕСЛИ(Июнь!F{i}=20;2;0))");
					row5.Append(cellF5);

					Cell cellG5 = new Cell();
					cellG5.CellReference = $"G{i}";
					cellG5.DataType = CellValues.String;
					cellG5.CellValue = new CellValue($"=ЕСЛИ(Апрель!G{i}=\"Да\";1;0)+ЕСЛИ(Май!G{i}=\"Да\";1;0)+ЕСЛИ(Июнь!G{i}=\"Да\";1;0)");
					row5.Append(cellG5);

					Cell cellI5 = new Cell();
					cellI5.CellReference = $"I{i}";
					cellI5.DataType = CellValues.String;
					cellI5.CellValue = new CellValue($"=ЕСЛИ(Апрель!I{i}=\"Да\";1;0)+ЕСЛИ(Май!I{i}=\"Да\";1;0)+ЕСЛИ(Июнь!I{i}=\"Да\";1;0)");
					row5.Append(cellI5);

					Cell cellJ5 = new Cell();
					cellJ5.CellReference = $"J{i}";
					cellJ5.DataType = CellValues.String;
					cellJ5.CellValue = new CellValue($"=ЕСЛИ(Апрель!J{i}=\"Да\";1;0)+ЕСЛИ(Май!J{i}=\"Да\";1;0)+ЕСЛИ(Июнь!J{i}=\"Да\";1;0)");
					row5.Append(cellJ5);

					Cell cellK5 = new Cell();
					cellK5.CellReference = $"K{i}";
					cellK5.DataType = CellValues.String;
					cellK5.CellValue = new CellValue($"=ЕСЛИ(Апрель!K{i}=\"Да\";1;0)+ЕСЛИ(Май!K{i}=\"Да\";1;0)+ЕСЛИ(Июнь!K{i}=\"Да\";1;0)");
					row5.Append(cellK5);

					Cell cellL5 = new Cell();
					cellL5.CellReference = $"L{i}";
					cellL5.DataType = CellValues.String;
					cellL5.CellValue = new CellValue($"=ЕСЛИ(Апрель!L{i}=\"Да\";1;0)+ЕСЛИ(Май!L{i}=\"Да\";1;0)+ЕСЛИ(Июнь!L{i}=\"Да\";1;0)");
					row5.Append(cellL5);

					Cell cellM5 = new Cell();
					cellM5.CellReference = $"M{i}";
					cellM5.DataType = CellValues.String;
					cellM5.CellValue = new CellValue($"=ЕСЛИ(СОВПАД(Апрель!M{i};\"да\");0,5;0)+ЕСЛИ(СОВПАД(Апрель!M{i};\"Да\");1;0)+ЕСЛИ(СОВПАД(Май!M{i};\"да\");0,5;0)+ЕСЛИ(СОВПАД(Май!M{i};\"Да\");1;0)+ЕСЛИ(СОВПАД(Июнь!M{i};\"да\");0,5;0)+ЕСЛИ(СОВПАД(Июнь!M{i};\"Да\");1;0)");
					row5.Append(cellM5);

					Cell cellN5 = new Cell();
					cellN5.CellReference = $"N{i}";
					cellN5.DataType = CellValues.String;
					cellN5.CellValue = new CellValue($"=ЕСЛИ(СОВПАД(Апрель!N{i};\"да\");0,5;0)+ЕСЛИ(СОВПАД(Апрель!N{i};\"Да\");1;0)+ЕСЛИ(СОВПАД(Май!N{i};\"да\");0,5;0)+ЕСЛИ(СОВПАД(Май!N{i};\"Да\");1;0)+ЕСЛИ(СОВПАД(Июнь!N{i};\"да\");0,5;0)+ЕСЛИ(СОВПАД(Июнь!N{i};\"Да\");1;0)");
					row5.Append(cellN5);

					Cell cellO5 = new Cell();
					cellO5.CellReference = $"O{i}";
					cellO5.DataType = CellValues.String;
					cellO5.CellValue = new CellValue($"=ЕСЛИ(СОВПАД(Апрель!O{i};\"да\");0,5;0)+ЕСЛИ(СОВПАД(Апрель!O{i};\"Да\");1;0)+ЕСЛИ(СОВПАД(Май!O{i};\"да\");0,5;0)+ЕСЛИ(СОВПАД(Май!O{i};\"Да\");1;0)+ЕСЛИ(СОВПАД(Июнь!O{i};\"да\");0,5;0)+ЕСЛИ(СОВПАД(Июнь!O{i};\"Да\");1;0)");
					row5.Append(cellO5);

					Cell cellQ5 = new Cell();
					cellQ5.CellReference = $"Q{i}";
					cellQ5.DataType = CellValues.String;
					cellQ5.CellValue = new CellValue($"=Июнь!Q{i}");
					row5.Append(cellQ5);
				}
				else if (int.TryParse(id, out int idValue14) && idValue14 == 15)
				{
					Cell cellE5 = new Cell();
					cellE5.CellReference = $"E{i}";
					cellE5.DataType = CellValues.String;
					cellE5.CellValue = new CellValue($"=(ЕСЛИ(Июль!E{i}=5;1;0)+ЕСЛИ(Июль!E{i}=10;2;0)+ЕСЛИ(Июль!E{i}=15;3;0)+ЕСЛИ(Июль!E{i}=20;4;0))+(ЕСЛИ(Август!E{i}=5;1;0)+ЕСЛИ(Август!E{i}=10;2;0)+ЕСЛИ(Август!E{i}=15;3;0)+ЕСЛИ(Август!E{i}=20;4;0))+(ЕСЛИ(Сентябрь!E{i}=5;1;0)+ЕСЛИ(Сентябрь!E{i}=10;2;0)+ЕСЛИ(Сентябрь!E{i}=15;3;0)+ЕСЛИ(Сентябрь!E{i}=20;4;0))");
					row5.Append(cellE5);


					Cell cellF5 = new Cell();
					cellF5.CellReference = $"F{i}";
					cellF5.DataType = CellValues.String;
					cellF5.CellValue = new CellValue($"=(ЕСЛИ(Июль!F{i}=5;0,5;0)+ЕСЛИ(Июль!F{i}=10;1;0)+ЕСЛИ(Июль!F{i}=20;2;0))+(ЕСЛИ(Август!F{i}=5;0,5;0)+ЕСЛИ(Август!F{i}=10;1;0)+ЕСЛИ(Август!F{i}=20;2;0))+(ЕСЛИ(Сентябрь!F{i}=5;0,5;0)+ЕСЛИ(Сентябрь!F{i}=10;1;0)+ЕСЛИ(Сентябрь!F{i}=20;2;0))");
					row5.Append(cellF5);

					Cell cellG5 = new Cell();
					cellG5.CellReference = $"G{i}";
					cellG5.DataType = CellValues.String;
					cellG5.CellValue = new CellValue($"=ЕСЛИ(Июль!G{i}=\"Да\";1;0)+ЕСЛИ(Август!G{i}=\"Да\";1;0)+ЕСЛИ(Сентябрь!G{i}=\"Да\";1;0)");
					row5.Append(cellG5);

					Cell cellI5 = new Cell();
					cellI5.CellReference = $"I{i}";
					cellI5.DataType = CellValues.String;
					cellI5.CellValue = new CellValue($"=ЕСЛИ(Июль!I{i}=\"Да\";1;0)+ЕСЛИ(Август!I{i}=\"Да\";1;0)+ЕСЛИ(Сентябрь!I{i}=\"Да\";1;0)");
					row5.Append(cellI5);

					Cell cellJ5 = new Cell();
					cellJ5.CellReference = $"J{i}";
					cellJ5.DataType = CellValues.String;
					cellJ5.CellValue = new CellValue($"=ЕСЛИ(Июль!J{i}=\"Да\";1;0)+ЕСЛИ(Август!J{i}=\"Да\";1;0)+ЕСЛИ(Сентябрь!J{i}=\"Да\";1;0)");
					row5.Append(cellJ5);

					Cell cellK5 = new Cell();
					cellK5.CellReference = $"K{i}";
					cellK5.DataType = CellValues.String;
					cellK5.CellValue = new CellValue($"=ЕСЛИ(Июль!K{i}=\"Да\";1;0)+ЕСЛИ(Август!K{i}=\"Да\";1;0)+ЕСЛИ(Сентябрь!K{i}=\"Да\";1;0)");
					row5.Append(cellK5);

					Cell cellL5 = new Cell();
					cellL5.CellReference = $"L{i}";
					cellL5.DataType = CellValues.String;
					cellL5.CellValue = new CellValue($"=ЕСЛИ(Июль!L{i}=\"Да\";1;0)+ЕСЛИ(Август!L{i}=\"Да\";1;0)+ЕСЛИ(Сентябрь!L{i}=\"Да\";1;0)");
					row5.Append(cellL5);

					Cell cellM5 = new Cell();
					cellM5.CellReference = $"M{i}";
					cellM5.DataType = CellValues.String;
					cellM5.CellValue = new CellValue($"=ЕСЛИ(СОВПАД(Июль!M{i};\"да\");0,5;0)+ЕСЛИ(СОВПАД(Июль!M{i};\"Да\");1;0)+ЕСЛИ(СОВПАД(Август!M{i};\"да\");0,5;0)+ЕСЛИ(СОВПАД(Август!M{i};\"Да\");1;0)+ЕСЛИ(СОВПАД(Сентябрь!M{i};\"да\");0,5;0)+ЕСЛИ(СОВПАД(Сентябрь!M{i};\"Да\");1;0)");
					row5.Append(cellM5);

					Cell cellN5 = new Cell();
					cellN5.CellReference = $"N{i}";
					cellN5.DataType = CellValues.String;
					cellN5.CellValue = new CellValue($"=ЕСЛИ(СОВПАД(Июль!N{i};\"да\");0,5;0)+ЕСЛИ(СОВПАД(Июль!N{i};\"Да\");1;0)+ЕСЛИ(СОВПАД(Август!N{i};\"да\");0,5;0)+ЕСЛИ(СОВПАД(Август!N{i};\"Да\");1;0)+ЕСЛИ(СОВПАД(Сентябрь!N{i};\"да\");0,5;0)+ЕСЛИ(СОВПАД(Сентябрь!N{i};\"Да\");1;0)");
					row5.Append(cellN5);

					Cell cellO5 = new Cell();
					cellO5.CellReference = $"O{i}";
					cellO5.DataType = CellValues.String;
					cellO5.CellValue = new CellValue($"=ЕСЛИ(СОВПАД(Июль!O{i};\"да\");0,5;0)+ЕСЛИ(СОВПАД(Июль!O{i};\"Да\");1;0)+ЕСЛИ(СОВПАД(Август!O{i};\"да\");0,5;0)+ЕСЛИ(СОВПАД(Август!O{i};\"Да\");1;0)+ЕСЛИ(СОВПАД(Сентябрь!O{i};\"да\");0,5;0)+ЕСЛИ(СОВПАД(Сентябрь!O{i};\"Да\");1;0)");
					row5.Append(cellO5);

					Cell cellQ5 = new Cell();
					cellQ5.CellReference = $"Q{i}";
					cellQ5.DataType = CellValues.String;
					cellQ5.CellValue = new CellValue($"=Сентябрь!Q{i}");
					row5.Append(cellQ5);
				}
				else if (int.TryParse(id, out int idValue15) && idValue15 == 16)
				{
					Cell cellE5 = new Cell();
					cellE5.CellReference = $"E{i}";
					cellE5.DataType = CellValues.String;
					cellE5.CellValue = new CellValue($"=(ЕСЛИ(Октябрь!E{i}=5;1;0)+ЕСЛИ(Октябрь!E{i}=10;2;0)+ЕСЛИ(Октябрь!E{i}=15;3;0)+ЕСЛИ(Октябрь!E{i}=20;4;0))+(ЕСЛИ(Ноябрь!E{i}=5;1;0)+ЕСЛИ(Ноябрь!E{i}=10;2;0)+ЕСЛИ(Ноябрь!E{i}=15;3;0)+ЕСЛИ(Ноябрь!E{i}=20;4;0))+(ЕСЛИ(Декабрь!E{i}=5;1;0)+ЕСЛИ(Декабрь!E{i}=10;2;0)+ЕСЛИ(Декабрь!E{i}=15;3;0)+ЕСЛИ(Декабрь!E{i}=20;4;0))");
					row5.Append(cellE5);


					Cell cellF5 = new Cell();
					cellF5.CellReference = $"F{i}";
					cellF5.DataType = CellValues.String;
					cellF5.CellValue = new CellValue($"=(ЕСЛИ(Октябрь!F{i}=5;0,5;0)+ЕСЛИ(Октябрь!F{i}=10;1;0)+ЕСЛИ(Октябрь!F{i}=20;2;0))+(ЕСЛИ(Ноябрь!F{i}=5;0,5;0)+ЕСЛИ(Ноябрь!F{i}=10;1;0)+ЕСЛИ(Ноябрь!F{i}=20;2;0))+(ЕСЛИ(Декабрь!F{i}=5;0,5;0)+ЕСЛИ(Декабрь!F{i}=10;1;0)+ЕСЛИ(Декабрь!F{i}=20;2;0))");
					row5.Append(cellF5);

					Cell cellG5 = new Cell();
					cellG5.CellReference = $"G{i}";
					cellG5.DataType = CellValues.String;
					cellG5.CellValue = new CellValue($"=ЕСЛИ(Октябрь!G{i}=\"Да\";1;0)+ЕСЛИ(Ноябрь!G{i}=\"Да\";1;0)+ЕСЛИ(Декабрь!G{i}=\"Да\";1;0)");
					row5.Append(cellG5);

					Cell cellI5 = new Cell();
					cellI5.CellReference = $"I{i}";
					cellI5.DataType = CellValues.String;
					cellI5.CellValue = new CellValue($"=ЕСЛИ(Октябрь!I{i}=\"Да\";1;0)+ЕСЛИ(Ноябрь!I{i}=\"Да\";1;0)+ЕСЛИ(Декабрь!I{i}=\"Да\";1;0)");
					row5.Append(cellI5);

					Cell cellJ5 = new Cell();
					cellJ5.CellReference = $"J{i}";
					cellJ5.DataType = CellValues.String;
					cellJ5.CellValue = new CellValue($"=ЕСЛИ(Октябрь!J{i}=\"Да\";1;0)+ЕСЛИ(Ноябрь!J{i}=\"Да\";1;0)+ЕСЛИ(Декабрь!J{i}=\"Да\";1;0)");
					row5.Append(cellJ5);

					Cell cellK5 = new Cell();
					cellK5.CellReference = $"K{i}";
					cellK5.DataType = CellValues.String;
					cellK5.CellValue = new CellValue($"=ЕСЛИ(Октябрь!K{i}=\"Да\";1;0)+ЕСЛИ(Ноябрь!K{i}=\"Да\";1;0)+ЕСЛИ(Декабрь!K{i}=\"Да\";1;0)");
					row5.Append(cellK5);

					Cell cellL5 = new Cell();
					cellL5.CellReference = $"L{i}";
					cellL5.DataType = CellValues.String;
					cellL5.CellValue = new CellValue($"=ЕСЛИ(Октябрь!L{i}=\"Да\";1;0)+ЕСЛИ(Ноябрь!L{i}=\"Да\";1;0)+ЕСЛИ(Декабрь!L{i}=\"Да\";1;0)");
					row5.Append(cellL5);

					Cell cellM5 = new Cell();
					cellM5.CellReference = $"M{i}";
					cellM5.DataType = CellValues.String;
					cellM5.CellValue = new CellValue($"=ЕСЛИ(СОВПАД(Октябрь!M{i};\"да\");0,5;0)+ЕСЛИ(СОВПАД(Октябрь!M{i};\"Да\");1;0)+ЕСЛИ(СОВПАД(Ноябрь!M{i};\"да\");0,5;0)+ЕСЛИ(СОВПАД(Ноябрь!M{i};\"Да\");1;0)+ЕСЛИ(СОВПАД(Декабрь!M{i};\"да\");0,5;0)+ЕСЛИ(СОВПАД(Декабрь!M{i};\"Да\");1;0)");
					row5.Append(cellM5);

					Cell cellN5 = new Cell();
					cellN5.CellReference = $"N{i}";
					cellN5.DataType = CellValues.String;
					cellN5.CellValue = new CellValue($"=ЕСЛИ(СОВПАД(Октябрь!N{i};\"да\");0,5;0)+ЕСЛИ(СОВПАД(Октябрь!N{i};\"Да\");1;0)+ЕСЛИ(СОВПАД(Ноябрь!N{i};\"да\");0,5;0)+ЕСЛИ(СОВПАД(Ноябрь!N{i};\"Да\");1;0)+ЕСЛИ(СОВПАД(Декабрь!N{i};\"да\");0,5;0)+ЕСЛИ(СОВПАД(Декабрь!N{i};\"Да\");1;0)");
					row5.Append(cellN5);

					Cell cellO5 = new Cell();
					cellO5.CellReference = $"O{i}";
					cellO5.DataType = CellValues.String;
					cellO5.CellValue = new CellValue($"=ЕСЛИ(СОВПАД(Октябрь!O{i};\"да\");0,5;0)+ЕСЛИ(СОВПАД(Октябрь!O{i};\"Да\");1;0)+ЕСЛИ(СОВПАД(Ноябрь!O{i};\"да\");0,5;0)+ЕСЛИ(СОВПАД(Ноябрь!O{i};\"Да\");1;0)+ЕСЛИ(СОВПАД(Декабрь!O{i};\"да\");0,5;0)+ЕСЛИ(СОВПАД(Декабрь!O{i};\"Да\");1;0)");
					row5.Append(cellO5);

					Cell cellQ5 = new Cell();
					cellQ5.CellReference = $"Q{i}";
					cellQ5.DataType = CellValues.String;
					cellQ5.CellValue = new CellValue($"=Декабрь!Q{i}");
					row5.Append(cellQ5);
				}
				else if (int.TryParse(id, out int idValue16) && idValue16 == 17)
				{
					Cell cellE5 = new Cell();
					cellE5.CellReference = $"E{i}";
					cellE5.DataType = CellValues.String;
					cellE5.CellValue = new CellValue($"='1 квартал'!E{i}+'2 квартал'!E{i}+'3 квартал'!E{i}+'4 квартал'!E{i}");
					row5.Append(cellE5);


					Cell cellF5 = new Cell();
					cellF5.CellReference = $"F{i}";
					cellF5.DataType = CellValues.String;
					cellF5.CellValue = new CellValue($"='1 квартал'!F{i}+'2 квартал'!F{i}+'3 квартал'!F{i}+'4 квартал'!F{i}");
					row5.Append(cellF5);

					Cell cellG5 = new Cell();
					cellG5.CellReference = $"G{i}";
					cellG5.DataType = CellValues.String;
					cellG5.CellValue = new CellValue($"='1 квартал'!G{i}+'2 квартал'!G{i}+'3 квартал'!G{i}+'4 квартал'!G{i}");
					row5.Append(cellG5);

					Cell cellI5 = new Cell();
					cellI5.CellReference = $"I{i}";
					cellI5.DataType = CellValues.String;
					cellI5.CellValue = new CellValue($"='1 квартал'!I{i}+'2 квартал'!I{i}+'3 квартал'!I{i}+'4 квартал'!I{i}");
					row5.Append(cellI5);

					Cell cellJ5 = new Cell();
					cellJ5.CellReference = $"J{i}";
					cellJ5.DataType = CellValues.String;
					cellJ5.CellValue = new CellValue($"='1 квартал'!J{i}+'2 квартал'!J{i}+'3 квартал'!J{i}+'4 квартал'!J{i}");
					row5.Append(cellJ5);

					Cell cellK5 = new Cell();
					cellK5.CellReference = $"K{i}";
					cellK5.DataType = CellValues.String;
					cellK5.CellValue = new CellValue($"='1 квартал'!K{i}+'2 квартал'!K{i}+'3 квартал'!K{i}+'4 квартал'!K{i}");
					row5.Append(cellK5);

					Cell cellL5 = new Cell();
					cellL5.CellReference = $"L{i}";
					cellL5.DataType = CellValues.String;
					cellL5.CellValue = new CellValue($"='1 квартал'!L{i}+'2 квартал'!L{i}+'3 квартал'!L{i}+'4 квартал'!L{i}");
					row5.Append(cellL5);

					Cell cellM5 = new Cell();
					cellM5.CellReference = $"M{i}";
					cellM5.DataType = CellValues.String;
					cellM5.CellValue = new CellValue($"='1 квартал'!M{i}+'2 квартал'!M{i}+'3 квартал'!M{i}+'4 квартал'!M{i}");
					row5.Append(cellM5);

					Cell cellN5 = new Cell();
					cellN5.CellReference = $"N{i}";
					cellN5.DataType = CellValues.String;
					cellN5.CellValue = new CellValue($"='1 квартал'!N{i}+'2 квартал'!N{i}+'3 квартал'!N{i}+'4 квартал'!N{i}");
					row5.Append(cellN5);

					Cell cellO5 = new Cell();
					cellO5.CellReference = $"O{i}";
					cellO5.DataType = CellValues.String;
					cellO5.CellValue = new CellValue($"='1 квартал'!O{i}+'2 квартал'!O{i}+'3 квартал'!O{i}+'4 квартал'!O{i}");
					row5.Append(cellO5);

					Cell cellQ5 = new Cell();
					cellQ5.CellReference = $"Q{i}";
					cellQ5.DataType = CellValues.String;
					cellQ5.CellValue = new CellValue($"='4 квартал'!Q{i}");
					row5.Append(cellQ5);
				}


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


				if (int.TryParse(id, out int idValue12) && idValue12 == 13)
				{
					Cell cellE5 = new Cell();
					cellE5.CellReference = $"E{i}";
					cellE5.DataType = CellValues.String;
					cellE5.CellValue = new CellValue($"=(ЕСЛИ(Январь!E{i}=5;1;0)+ЕСЛИ(Январь!E{i}=10;2;0)+ЕСЛИ(Январь!E{i}=15;3;0)+ЕСЛИ(Январь!E{i}=20;4;0))+(ЕСЛИ(Февраль!E{i}=5;1;0)+ЕСЛИ(Февраль!E{i}=10;2;0)+ЕСЛИ(Февраль!E{i}=15;3;0)+ЕСЛИ(Февраль!E{i}=20;4;0))+(ЕСЛИ(Март!E{i}=5;1;0)+ЕСЛИ(Март!E{i}=10;2;0)+ЕСЛИ(Март!E{i}=15;3;0)+ЕСЛИ(Март!E{i}=20;4;0))");
					dataRow.Append(cellE5);


					Cell cellF5 = new Cell();
					cellF5.CellReference = $"F{i}";
					cellF5.DataType = CellValues.String;
					cellF5.CellValue = new CellValue($"=(ЕСЛИ(Январь!F{i}=5;0,5;0)+ЕСЛИ(Январь!F{i}=10;1;0)+ЕСЛИ(Январь!F{i}=20;2;0))+(ЕСЛИ(Февраль!F{i}=5;0,5;0)+ЕСЛИ(Февраль!F{i}=10;1;0)+ЕСЛИ(Февраль!F{i}=20;2;0))+(ЕСЛИ(Март!F{i}=5;0,5;0)+ЕСЛИ(Март!F{i}=10;1;0)+ЕСЛИ(Март!F{i}=20;2;0))");
					dataRow.Append(cellF5);

					Cell cellG5 = new Cell();
					cellG5.CellReference = $"G{i}";
					cellG5.DataType = CellValues.String;
					cellG5.CellValue = new CellValue($"=ЕСЛИ(Январь!G{i}=\"Да\";1;0)+ЕСЛИ(Февраль!G{i}=\"Да\";1;0)+ЕСЛИ(Март!G{i}=\"Да\";1;0)");
					dataRow.Append(cellG5);

					Cell cellI5 = new Cell();
					cellI5.CellReference = $"I{i}";
					cellI5.DataType = CellValues.String;
					cellI5.CellValue = new CellValue($"=ЕСЛИ(Январь!I{i}=\"Да\";1;0)+ЕСЛИ(Февраль!I{i}=\"Да\";1;0)+ЕСЛИ(Март!I{i}=\"Да\";1;0)");
					dataRow.Append(cellI5);

					Cell cellJ5 = new Cell();
					cellJ5.CellReference = $"J{i}";
					cellJ5.DataType = CellValues.String;
					cellJ5.CellValue = new CellValue($"=ЕСЛИ(Январь!J{i}=\"Да\";1;0)+ЕСЛИ(Февраль!J{i}=\"Да\";1;0)+ЕСЛИ(Март!J{i}=\"Да\";1;0)");
					dataRow.Append(cellJ5);

					Cell cellK5 = new Cell();
					cellK5.CellReference = $"K{i}";
					cellK5.DataType = CellValues.String;
					cellK5.CellValue = new CellValue($"=ЕСЛИ(Январь!K{i}=\"Да\";1;0)+ЕСЛИ(Февраль!K{i}=\"Да\";1;0)+ЕСЛИ(Март!K{i}=\"Да\";1;0)");
					dataRow.Append(cellK5);

					Cell cellL5 = new Cell();
					cellL5.CellReference = $"L{i}";
					cellL5.DataType = CellValues.String;
					cellL5.CellValue = new CellValue($"=ЕСЛИ(Январь!L{i}=\"Да\";1;0)+ЕСЛИ(Февраль!L{i}=\"Да\";1;0)+ЕСЛИ(Март!L{i}=\"Да\";1;0)");
					dataRow.Append(cellL5);

					Cell cellM5 = new Cell();
					cellM5.CellReference = $"M{i}";
					cellM5.DataType = CellValues.String;
					cellM5.CellValue = new CellValue($"=ЕСЛИ(СОВПАД(Январь!M{i};\"да\");0,5;0)+ЕСЛИ(СОВПАД(Январь!M{i};\"Да\");1;0)+ЕСЛИ(СОВПАД(Февраль!M{i};\"да\");0,5;0)+ЕСЛИ(СОВПАД(Февраль!M{i};\"Да\");1;0)+ЕСЛИ(СОВПАД(Март!M{i};\"да\");0,5;0)+ЕСЛИ(СОВПАД(Март!M{i};\"Да\");1;0)");
					dataRow.Append(cellM5);

					Cell cellN5 = new Cell();
					cellN5.CellReference = $"N{i}";
					cellN5.DataType = CellValues.String;
					cellN5.CellValue = new CellValue($"=ЕСЛИ(СОВПАД(Январь!N{i};\"да\");0,5;0)+ЕСЛИ(СОВПАД(Январь!N{i};\"Да\");1;0)+ЕСЛИ(СОВПАД(Февраль!N{i};\"да\");0,5;0)+ЕСЛИ(СОВПАД(Февраль!N{i};\"Да\");1;0)+ЕСЛИ(СОВПАД(Март!N{i};\"да\");0,5;0)+ЕСЛИ(СОВПАД(Март!N{i};\"Да\");1;0)");
					dataRow.Append(cellN5);

					Cell cellO5 = new Cell();
					cellO5.CellReference = $"O{i}";
					cellO5.DataType = CellValues.String;
					cellO5.CellValue = new CellValue($"=ЕСЛИ(СОВПАД(Январь!O{i};\"да\");0,5;0)+ЕСЛИ(СОВПАД(Январь!O{i};\"Да\");1;0)+ЕСЛИ(СОВПАД(Февраль!O{i};\"да\");0,5;0)+ЕСЛИ(СОВПАД(Февраль!O{i};\"Да\");1;0)+ЕСЛИ(СОВПАД(Март!O{i};\"да\");0,5;0)+ЕСЛИ(СОВПАД(Март!O{i};\"Да\");1;0)");
					dataRow.Append(cellO5);

					Cell cellQ5 = new Cell();
					cellQ5.CellReference = $"Q{i}";
					cellQ5.DataType = CellValues.String;
					cellQ5.CellValue = new CellValue($"=Март!Q{i}");
					dataRow.Append(cellQ5);
				}
				else if (int.TryParse(id, out int idValue13) && idValue13 == 14)
				{
					Cell cellE5 = new Cell();
					cellE5.CellReference = $"E{i}";
					cellE5.DataType = CellValues.String;
					cellE5.CellValue = new CellValue($"=(ЕСЛИ(Апрель!E{i}=5;1;0)+ЕСЛИ(Апрель!E{i}=10;2;0)+ЕСЛИ(Апрель!E{i}=15;3;0)+ЕСЛИ(Апрель!E{i}=4;2;0))+(ЕСЛИ(Май!E{i}=5;1;0)+ЕСЛИ(Май!E{i}=10;2;0)+ЕСЛИ(Май!E{i}=15;3;0)+ЕСЛИ(Май!E{i}=20;4;0))+(ЕСЛИ(Июнь!E{i}=5;1;0)+ЕСЛИ(Июнь!E{i}=10;2;0)+ЕСЛИ(Июнь!E{i}=15;3;0)+ЕСЛИ(Июнь!E{i}=20;4;0))");
					dataRow.Append(cellE5);


					Cell cellF5 = new Cell();
					cellF5.CellReference = $"F{i}";
					cellF5.DataType = CellValues.String;
					cellF5.CellValue = new CellValue($"=(ЕСЛИ(Апрель!F{i}=5;0,5;0)+ЕСЛИ(Апрель!F{i}=10;1;0)+ЕСЛИ(Апрель!F{i}=20;2;0))+(ЕСЛИ(Май!F{i}=5;0,5;0)+ЕСЛИ(Май!F{i}=10;1;0)+ЕСЛИ(Май!F{i}=20;2;0))+(ЕСЛИ(Июнь!F{i}=5;0,5;0)+ЕСЛИ(Июнь!F{i}=10;1;0)+ЕСЛИ(Июнь!F{i}=20;2;0))");
					dataRow.Append(cellF5);

					Cell cellG5 = new Cell();
					cellG5.CellReference = $"G{i}";
					cellG5.DataType = CellValues.String;
					cellG5.CellValue = new CellValue($"=ЕСЛИ(Апрель!G{i}=\"Да\";1;0)+ЕСЛИ(Май!G{i}=\"Да\";1;0)+ЕСЛИ(Июнь!G{i}=\"Да\";1;0)");
					dataRow.Append(cellG5);

					Cell cellI5 = new Cell();
					cellI5.CellReference = $"I{i}";
					cellI5.DataType = CellValues.String;
					cellI5.CellValue = new CellValue($"=ЕСЛИ(Апрель!I{i}=\"Да\";1;0)+ЕСЛИ(Май!I{i}=\"Да\";1;0)+ЕСЛИ(Июнь!I{i}=\"Да\";1;0)");
					dataRow.Append(cellI5);

					Cell cellJ5 = new Cell();
					cellJ5.CellReference = $"J{i}";
					cellJ5.DataType = CellValues.String;
					cellJ5.CellValue = new CellValue($"=ЕСЛИ(Апрель!J{i}=\"Да\";1;0)+ЕСЛИ(Май!J{i}=\"Да\";1;0)+ЕСЛИ(Июнь!J{i}=\"Да\";1;0)");
					dataRow.Append(cellJ5);

					Cell cellK5 = new Cell();
					cellK5.CellReference = $"K{i}";
					cellK5.DataType = CellValues.String;
					cellK5.CellValue = new CellValue($"=ЕСЛИ(Апрель!K{i}=\"Да\";1;0)+ЕСЛИ(Май!K{i}=\"Да\";1;0)+ЕСЛИ(Июнь!K{i}=\"Да\";1;0)");
					dataRow.Append(cellK5);

					Cell cellL5 = new Cell();
					cellL5.CellReference = $"L{i}";
					cellL5.DataType = CellValues.String;
					cellL5.CellValue = new CellValue($"=ЕСЛИ(Апрель!L{i}=\"Да\";1;0)+ЕСЛИ(Май!L{i}=\"Да\";1;0)+ЕСЛИ(Июнь!L{i}=\"Да\";1;0)");
					dataRow.Append(cellL5);

					Cell cellM5 = new Cell();
					cellM5.CellReference = $"M{i}";
					cellM5.DataType = CellValues.String;
					cellM5.CellValue = new CellValue($"=ЕСЛИ(СОВПАД(Апрель!M{i};\"да\");0,5;0)+ЕСЛИ(СОВПАД(Апрель!M{i};\"Да\");1;0)+ЕСЛИ(СОВПАД(Май!M{i};\"да\");0,5;0)+ЕСЛИ(СОВПАД(Май!M{i};\"Да\");1;0)+ЕСЛИ(СОВПАД(Июнь!M{i};\"да\");0,5;0)+ЕСЛИ(СОВПАД(Июнь!M{i};\"Да\");1;0)");
					dataRow.Append(cellM5);

					Cell cellN5 = new Cell();
					cellN5.CellReference = $"N{i}";
					cellN5.DataType = CellValues.String;
					cellN5.CellValue = new CellValue($"=ЕСЛИ(СОВПАД(Апрель!N{i};\"да\");0,5;0)+ЕСЛИ(СОВПАД(Апрель!N{i};\"Да\");1;0)+ЕСЛИ(СОВПАД(Май!N{i};\"да\");0,5;0)+ЕСЛИ(СОВПАД(Май!N{i};\"Да\");1;0)+ЕСЛИ(СОВПАД(Июнь!N{i};\"да\");0,5;0)+ЕСЛИ(СОВПАД(Июнь!N{i};\"Да\");1;0)");
					dataRow.Append(cellN5);

					Cell cellO5 = new Cell();
					cellO5.CellReference = $"O{i}";
					cellO5.DataType = CellValues.String;
					cellO5.CellValue = new CellValue($"=ЕСЛИ(СОВПАД(Апрель!O{i};\"да\");0,5;0)+ЕСЛИ(СОВПАД(Апрель!O{i};\"Да\");1;0)+ЕСЛИ(СОВПАД(Май!O{i};\"да\");0,5;0)+ЕСЛИ(СОВПАД(Май!O{i};\"Да\");1;0)+ЕСЛИ(СОВПАД(Июнь!O{i};\"да\");0,5;0)+ЕСЛИ(СОВПАД(Июнь!O{i};\"Да\");1;0)");
					dataRow.Append(cellO5);

					Cell cellQ5 = new Cell();
					cellQ5.CellReference = $"Q{i}";
					cellQ5.DataType = CellValues.String;
					cellQ5.CellValue = new CellValue($"=Июнь!Q{i}");
					dataRow.Append(cellQ5);
				}
				else if (int.TryParse(id, out int idValue14) && idValue14 == 15)
				{
					Cell cellE5 = new Cell();
					cellE5.CellReference = $"E{i}";
					cellE5.DataType = CellValues.String;
					cellE5.CellValue = new CellValue($"=(ЕСЛИ(Июль!E{i}=5;1;0)+ЕСЛИ(Июль!E{i}=10;2;0)+ЕСЛИ(Июль!E{i}=15;3;0)+ЕСЛИ(Июль!E{i}=20;4;0))+(ЕСЛИ(Август!E{i}=5;1;0)+ЕСЛИ(Август!E{i}=10;2;0)+ЕСЛИ(Август!E{i}=15;3;0)+ЕСЛИ(Август!E{i}=20;4;0))+(ЕСЛИ(Сентябрь!E{i}=5;1;0)+ЕСЛИ(Сентябрь!E{i}=10;2;0)+ЕСЛИ(Сентябрь!E{i}=15;3;0)+ЕСЛИ(Сентябрь!E{i}=20;4;0))");
					dataRow.Append(cellE5);


					Cell cellF5 = new Cell();
					cellF5.CellReference = $"F{i}";
					cellF5.DataType = CellValues.String;
					cellF5.CellValue = new CellValue($"=(ЕСЛИ(Июль!F{i}=5;0,5;0)+ЕСЛИ(Июль!F{i}=10;1;0)+ЕСЛИ(Июль!F{i}=20;2;0))+(ЕСЛИ(Август!F{i}=5;0,5;0)+ЕСЛИ(Август!F{i}=10;1;0)+ЕСЛИ(Август!F{i}=20;2;0))+(ЕСЛИ(Сентябрь!F{i}=5;0,5;0)+ЕСЛИ(Сентябрь!F{i}=10;1;0)+ЕСЛИ(Сентябрь!F{i}=20;2;0))");
					dataRow.Append(cellF5);

					Cell cellG5 = new Cell();
					cellG5.CellReference = $"G{i}";
					cellG5.DataType = CellValues.String;
					cellG5.CellValue = new CellValue($"=ЕСЛИ(Июль!G{i}=\"Да\";1;0)+ЕСЛИ(Август!G{i}=\"Да\";1;0)+ЕСЛИ(Сентябрь!G{i}=\"Да\";1;0)");
					dataRow.Append(cellG5);

					Cell cellI5 = new Cell();
					cellI5.CellReference = $"I{i}";
					cellI5.DataType = CellValues.String;
					cellI5.CellValue = new CellValue($"=ЕСЛИ(Июль!I{i}=\"Да\";1;0)+ЕСЛИ(Август!I{i}=\"Да\";1;0)+ЕСЛИ(Сентябрь!I{i}=\"Да\";1;0)");
					dataRow.Append(cellI5);

					Cell cellJ5 = new Cell();
					cellJ5.CellReference = $"J{i}";
					cellJ5.DataType = CellValues.String;
					cellJ5.CellValue = new CellValue($"=ЕСЛИ(Июль!J{i}=\"Да\";1;0)+ЕСЛИ(Август!J{i}=\"Да\";1;0)+ЕСЛИ(Сентябрь!J{i}=\"Да\";1;0)");
					dataRow.Append(cellJ5);

					Cell cellK5 = new Cell();
					cellK5.CellReference = $"K{i}";
					cellK5.DataType = CellValues.String;
					cellK5.CellValue = new CellValue($"=ЕСЛИ(Июль!K{i}=\"Да\";1;0)+ЕСЛИ(Август!K{i}=\"Да\";1;0)+ЕСЛИ(Сентябрь!K{i}=\"Да\";1;0)");
					dataRow.Append(cellK5);

					Cell cellL5 = new Cell();
					cellL5.CellReference = $"L{i}";
					cellL5.DataType = CellValues.String;
					cellL5.CellValue = new CellValue($"=ЕСЛИ(Июль!L{i}=\"Да\";1;0)+ЕСЛИ(Август!L{i}=\"Да\";1;0)+ЕСЛИ(Сентябрь!L{i}=\"Да\";1;0)");
					dataRow.Append(cellL5);

					Cell cellM5 = new Cell();
					cellM5.CellReference = $"M{i}";
					cellM5.DataType = CellValues.String;
					cellM5.CellValue = new CellValue($"=ЕСЛИ(СОВПАД(Июль!M{i};\"да\");0,5;0)+ЕСЛИ(СОВПАД(Июль!M{i};\"Да\");1;0)+ЕСЛИ(СОВПАД(Август!M{i};\"да\");0,5;0)+ЕСЛИ(СОВПАД(Август!M{i};\"Да\");1;0)+ЕСЛИ(СОВПАД(Сентябрь!M{i};\"да\");0,5;0)+ЕСЛИ(СОВПАД(Сентябрь!M{i};\"Да\");1;0)");
					dataRow.Append(cellM5);

					Cell cellN5 = new Cell();
					cellN5.CellReference = $"N{i}";
					cellN5.DataType = CellValues.String;
					cellN5.CellValue = new CellValue($"=ЕСЛИ(СОВПАД(Июль!N{i};\"да\");0,5;0)+ЕСЛИ(СОВПАД(Июль!N{i};\"Да\");1;0)+ЕСЛИ(СОВПАД(Август!N{i};\"да\");0,5;0)+ЕСЛИ(СОВПАД(Август!N{i};\"Да\");1;0)+ЕСЛИ(СОВПАД(Сентябрь!N{i};\"да\");0,5;0)+ЕСЛИ(СОВПАД(Сентябрь!N{i};\"Да\");1;0)");
					dataRow.Append(cellN5);

					Cell cellO5 = new Cell();
					cellO5.CellReference = $"O{i}";
					cellO5.DataType = CellValues.String;
					cellO5.CellValue = new CellValue($"=ЕСЛИ(СОВПАД(Июль!O{i};\"да\");0,5;0)+ЕСЛИ(СОВПАД(Июль!O{i};\"Да\");1;0)+ЕСЛИ(СОВПАД(Август!O{i};\"да\");0,5;0)+ЕСЛИ(СОВПАД(Август!O{i};\"Да\");1;0)+ЕСЛИ(СОВПАД(Сентябрь!O{i};\"да\");0,5;0)+ЕСЛИ(СОВПАД(Сентябрь!O{i};\"Да\");1;0)");
					dataRow.Append(cellO5);

					Cell cellQ5 = new Cell();
					cellQ5.CellReference = $"Q{i}";
					cellQ5.DataType = CellValues.String;
					cellQ5.CellValue = new CellValue($"=Сентябрь!Q{i}");
					dataRow.Append(cellQ5);
				}
				else if (int.TryParse(id, out int idValue15) && idValue15 == 16)
				{
					Cell cellE5 = new Cell();
					cellE5.CellReference = $"E{i}";
					cellE5.DataType = CellValues.String;
					cellE5.CellValue = new CellValue($"=(ЕСЛИ(Октябрь!E{i}=5;1;0)+ЕСЛИ(Октябрь!E{i}=10;2;0)+ЕСЛИ(Октябрь!E{i}=15;3;0)+ЕСЛИ(Октябрь!E{i}=20;4;0))+(ЕСЛИ(Ноябрь!E{i}=5;1;0)+ЕСЛИ(Ноябрь!E{i}=10;2;0)+ЕСЛИ(Ноябрь!E{i}=15;3;0)+ЕСЛИ(Ноябрь!E{i}=20;4;0))+(ЕСЛИ(Декабрь!E{i}=5;1;0)+ЕСЛИ(Декабрь!E{i}=10;2;0)+ЕСЛИ(Декабрь!E{i}=15;3;0)+ЕСЛИ(Декабрь!E{i}=20;4;0))");
					dataRow.Append(cellE5);


					Cell cellF5 = new Cell();
					cellF5.CellReference = $"F{i}";
					cellF5.DataType = CellValues.String;
					cellF5.CellValue = new CellValue($"=(ЕСЛИ(Октябрь!F{i}=5;0,5;0)+ЕСЛИ(Октябрь!F{i}=10;1;0)+ЕСЛИ(Октябрь!F{i}=20;2;0))+(ЕСЛИ(Ноябрь!F{i}=5;0,5;0)+ЕСЛИ(Ноябрь!F{i}=10;1;0)+ЕСЛИ(Ноябрь!F{i}=20;2;0))+(ЕСЛИ(Декабрь!F{i}=5;0,5;0)+ЕСЛИ(Декабрь!F{i}=10;1;0)+ЕСЛИ(Декабрь!F{i}=20;2;0))");
					dataRow.Append(cellF5);

					Cell cellG5 = new Cell();
					cellG5.CellReference = $"G{i}";
					cellG5.DataType = CellValues.String;
					cellG5.CellValue = new CellValue($"=ЕСЛИ(Октябрь!G{i}=\"Да\";1;0)+ЕСЛИ(Ноябрь!G{i}=\"Да\";1;0)+ЕСЛИ(Декабрь!G{i}=\"Да\";1;0)");
					dataRow.Append(cellG5);

					Cell cellI5 = new Cell();
					cellI5.CellReference = $"I{i}";
					cellI5.DataType = CellValues.String;
					cellI5.CellValue = new CellValue($"=ЕСЛИ(Октябрь!I{i}=\"Да\";1;0)+ЕСЛИ(Ноябрь!I{i}=\"Да\";1;0)+ЕСЛИ(Декабрь!I{i}=\"Да\";1;0)");
					dataRow.Append(cellI5);

					Cell cellJ5 = new Cell();
					cellJ5.CellReference = $"J{i}";
					cellJ5.DataType = CellValues.String;
					cellJ5.CellValue = new CellValue($"=ЕСЛИ(Октябрь!J{i}=\"Да\";1;0)+ЕСЛИ(Ноябрь!J{i}=\"Да\";1;0)+ЕСЛИ(Декабрь!J{i}=\"Да\";1;0)");
					dataRow.Append(cellJ5);

					Cell cellK5 = new Cell();
					cellK5.CellReference = $"K{i}";
					cellK5.DataType = CellValues.String;
					cellK5.CellValue = new CellValue($"=ЕСЛИ(Октябрь!K{i}=\"Да\";1;0)+ЕСЛИ(Ноябрь!K{i}=\"Да\";1;0)+ЕСЛИ(Декабрь!K{i}=\"Да\";1;0)");
					dataRow.Append(cellK5);

					Cell cellL5 = new Cell();
					cellL5.CellReference = $"L{i}";
					cellL5.DataType = CellValues.String;
					cellL5.CellValue = new CellValue($"=ЕСЛИ(Октябрь!L{i}=\"Да\";1;0)+ЕСЛИ(Ноябрь!L{i}=\"Да\";1;0)+ЕСЛИ(Декабрь!L{i}=\"Да\";1;0)");
					dataRow.Append(cellL5);

					Cell cellM5 = new Cell();
					cellM5.CellReference = $"M{i}";
					cellM5.DataType = CellValues.String;
					cellM5.CellValue = new CellValue($"=ЕСЛИ(СОВПАД(Октябрь!M{i};\"да\");0,5;0)+ЕСЛИ(СОВПАД(Октябрь!M{i};\"Да\");1;0)+ЕСЛИ(СОВПАД(Ноябрь!M{i};\"да\");0,5;0)+ЕСЛИ(СОВПАД(Ноябрь!M{i};\"Да\");1;0)+ЕСЛИ(СОВПАД(Декабрь!M{i};\"да\");0,5;0)+ЕСЛИ(СОВПАД(Декабрь!M{i};\"Да\");1;0)");
					dataRow.Append(cellM5);

					Cell cellN5 = new Cell();
					cellN5.CellReference = $"N{i}";
					cellN5.DataType = CellValues.String;
					cellN5.CellValue = new CellValue($"=ЕСЛИ(СОВПАД(Октябрь!N{i};\"да\");0,5;0)+ЕСЛИ(СОВПАД(Октябрь!N{i};\"Да\");1;0)+ЕСЛИ(СОВПАД(Ноябрь!N{i};\"да\");0,5;0)+ЕСЛИ(СОВПАД(Ноябрь!N{i};\"Да\");1;0)+ЕСЛИ(СОВПАД(Декабрь!N{i};\"да\");0,5;0)+ЕСЛИ(СОВПАД(Декабрь!N{i};\"Да\");1;0)");
					dataRow.Append(cellN5);

					Cell cellO5 = new Cell();
					cellO5.CellReference = $"O{i}";
					cellO5.DataType = CellValues.String;
					cellO5.CellValue = new CellValue($"=ЕСЛИ(СОВПАД(Октябрь!O{i};\"да\");0,5;0)+ЕСЛИ(СОВПАД(Октябрь!O{i};\"Да\");1;0)+ЕСЛИ(СОВПАД(Ноябрь!O{i};\"да\");0,5;0)+ЕСЛИ(СОВПАД(Ноябрь!O{i};\"Да\");1;0)+ЕСЛИ(СОВПАД(Декабрь!O{i};\"да\");0,5;0)+ЕСЛИ(СОВПАД(Декабрь!O{i};\"Да\");1;0)");
					dataRow.Append(cellO5);

					Cell cellQ5 = new Cell();
					cellQ5.CellReference = $"Q{i}";
					cellQ5.DataType = CellValues.String;
					cellQ5.CellValue = new CellValue($"=Декабрь!Q{i}");
					dataRow.Append(cellQ5);
				}
				else if (int.TryParse(id, out int idValue16) && idValue16 == 17)
				{
					Cell cellE5 = new Cell();
					cellE5.CellReference = $"E{i}";
					cellE5.DataType = CellValues.String;
					cellE5.CellValue = new CellValue($"='1 квартал'!E{i}+'2 квартал'!E{i}+'3 квартал'!E{i}+'4 квартал'!E{i}");
					dataRow.Append(cellE5);


					Cell cellF5 = new Cell();
					cellF5.CellReference = $"F{i}";
					cellF5.DataType = CellValues.String;
					cellF5.CellValue = new CellValue($"='1 квартал'!F{i}+'2 квартал'!F{i}+'3 квартал'!F{i}+'4 квартал'!F{i}");
					dataRow.Append(cellF5);

					Cell cellG5 = new Cell();
					cellG5.CellReference = $"G{i}";
					cellG5.DataType = CellValues.String;
					cellG5.CellValue = new CellValue($"='1 квартал'!G{i}+'2 квартал'!G{i}+'3 квартал'!G{i}+'4 квартал'!G{i}");
					dataRow.Append(cellG5);

					Cell cellI5 = new Cell();
					cellI5.CellReference = $"I{i}";
					cellI5.DataType = CellValues.String;
					cellI5.CellValue = new CellValue($"='1 квартал'!I{i}+'2 квартал'!I{i}+'3 квартал'!I{i}+'4 квартал'!I{i}");
					dataRow.Append(cellI5);

					Cell cellJ5 = new Cell();
					cellJ5.CellReference = $"J{i}";
					cellJ5.DataType = CellValues.String;
					cellJ5.CellValue = new CellValue($"='1 квартал'!J{i}+'2 квартал'!J{i}+'3 квартал'!J{i}+'4 квартал'!J{i}");
					dataRow.Append(cellJ5);

					Cell cellK5 = new Cell();
					cellK5.CellReference = $"K{i}";
					cellK5.DataType = CellValues.String;
					cellK5.CellValue = new CellValue($"='1 квартал'!K{i}+'2 квартал'!K{i}+'3 квартал'!K{i}+'4 квартал'!K{i}");
					dataRow.Append(cellK5);

					Cell cellL5 = new Cell();
					cellL5.CellReference = $"L{i}";
					cellL5.DataType = CellValues.String;
					cellL5.CellValue = new CellValue($"='1 квартал'!L{i}+'2 квартал'!L{i}+'3 квартал'!L{i}+'4 квартал'!L{i}");
					dataRow.Append(cellL5);

					Cell cellM5 = new Cell();
					cellM5.CellReference = $"M{i}";
					cellM5.DataType = CellValues.String;
					cellM5.CellValue = new CellValue($"='1 квартал'!M{i}+'2 квартал'!M{i}+'3 квартал'!M{i}+'4 квартал'!M{i}");
					dataRow.Append(cellM5);

					Cell cellN5 = new Cell();
					cellN5.CellReference = $"N{i}";
					cellN5.DataType = CellValues.String;
					cellN5.CellValue = new CellValue($"='1 квартал'!N{i}+'2 квартал'!N{i}+'3 квартал'!N{i}+'4 квартал'!N{i}");
					dataRow.Append(cellN5);

					Cell cellO5 = new Cell();
					cellO5.CellReference = $"O{i}";
					cellO5.DataType = CellValues.String;
					cellO5.CellValue = new CellValue($"='1 квартал'!O{i}+'2 квартал'!O{i}+'3 квартал'!O{i}+'4 квартал'!O{i}");
					dataRow.Append(cellO5);

					Cell cellQ5 = new Cell();
					cellQ5.CellReference = $"Q{i}";
					cellQ5.DataType = CellValues.String;
					cellQ5.CellValue = new CellValue($"='4 квартал'!Q{i}");
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
