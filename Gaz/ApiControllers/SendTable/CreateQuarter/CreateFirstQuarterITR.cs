using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Gaz.Domain.Entities;

namespace Gaz.ApiControllers.SendTable.CreateQuarter
{
    public class CreateFirstQuarterITR
    {
        public static void CreateSheet(WorkbookPart workbookPart, StringValue id,
            List<User> users)
        {
            WorksheetPart worksheetPart = workbookPart.GetPartById(id) as WorksheetPart;

            Worksheet worksheet = new Worksheet();
            SheetData sheetData = worksheet.AppendChild(new SheetData());

            #region Строки
            Row row = new Row();
            row.Height = 25;
            Row row2 = new Row();
            row2.Height = 1;
            Row row3 = new Row();
            row3.Height = 60;
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
                Width = 50,
                CustomWidth = true
            };
            columns.Append(columnB);
            Column columnC = new Column()
            {
                Min = 3,
                Max = 3,
                Width = 25,
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
                Width = 25,
                CustomWidth = true
            };
            columns.Append(columnF);
            Column columnG = new Column()
            {
                Min = 7,
                Max = 7,
                Width = 25,
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
                Width = 1,
                CustomWidth = true
            };
            columns.Append(columnI);
            Column columnJ = new Column()
            {
                Min = 10,
                Max = 10
            };
            columns.Append(columnJ);
            Column columnK = new Column()
            {
                Min = 11,
                Max = 11,
                Width = 50,
                CustomWidth = true
            };
            columns.Append(columnK);
            Column columnL = new Column()
            {
                Min = 12,
                Max = 12,
                Width = 25,
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
                Width = 25,
                CustomWidth = true
            };
            columns.Append(columnN);
            Column columnO = new Column()
            {
                Min = 15,
                Max = 15,
                Width = 25,
                CustomWidth = true
            };
            columns.Append(columnO);
            Column columnP = new Column()
            {
                Min = 16,
                Max = 16,
                Width = 25,
                CustomWidth = true
            };
            columns.Append(columnP);
            Column columnQ = new Column()
            {
                Min = 17,
                Max = 17,
                Width = 1,
                CustomWidth = true
            };
            columns.Append(columnQ);
            Column columnR = new Column()
            {
                Min = 18,
                Max = 18
            };
            columns.Append(columnR);
            Column columnS = new Column()
            {
                Min = 19,
                Max = 19,
                Width = 1,
                CustomWidth = true
            };
            columns.Append(columnS);
            Column columnT = new Column()
            {
                Min = 20,
                Max = 20,
                Width = 50,
                CustomWidth = true
            };
            columns.Append(columnT);
            Column columnU = new Column()
            {
                Min = 21,
                Max = 21,
                Width = 25,
                CustomWidth = true
            };
            columns.Append(columnU);
            Column columnV = new Column()
            {
                Min = 22,
                Max = 22,
                Width = 25,
                CustomWidth = true
            };
            columns.Append(columnV);
            Column columnW = new Column()
            {
                Min = 23,
                Max = 23,
                Width = 25,
                CustomWidth = true
            };
            columns.Append(columnW);
            Column columnX = new Column()
            {
                Min = 24,
                Max = 24,
                Width = 25,
                CustomWidth = true
            };
            columns.Append(columnX);
            Column columnY = new Column()
            {
                Min = 25,
                Max = 25,
                Width = 25,
                CustomWidth = true
            };
            columns.Append(columnY);
            Column columnZ = new Column()
            {
                Min = 26,
                Max = 26,
                Width = 1,
                CustomWidth = true
            };
            columns.Append(columnZ);


            Column columnAA = new Column()
            {
                Min = 27,
                Max = 27
            };
            columns.Append(columnAA);
            Column columnAB = new Column()
            {
                Min = 28,
                Max = 28,
                Width = 1,
                CustomWidth = true
            };
            columns.Append(columnAB);
            Column columnAC = new Column()
            {
                Min = 29,
                Max = 29,
                Width = 50,
                CustomWidth = true
            };
            columns.Append(columnAC);
            Column columnAD = new Column()
            {
                Min = 30,
                Max = 30,
                Width = 25,
                CustomWidth = true
            };
            columns.Append(columnAD);
            Column columnAE = new Column()
            {
                Min = 31,
                Max = 31,
                Width = 25,
                CustomWidth = true
            };
            columns.Append(columnAE);
            Column columnAF = new Column()
            {
                Min = 32,
                Max = 32,
                Width = 25,
                CustomWidth = true
            };
            columns.Append(columnAF);
            Column columnAG = new Column()
            {
                Min = 33,
                Max = 33,
                Width = 25,
                CustomWidth = true
            };
            columns.Append(columnAG);
            Column columnAH = new Column()
            {
                Min = 34,
                Max = 34,
                Width = 25,
                CustomWidth = true
            };
            columns.Append(columnAH);
            Column columnAI = new Column()
            {
                Min = 35,
                Max = 35,
                Width = 1,
                CustomWidth = true
            };
            columns.Append(columnAI);
            Column columnAJ = new Column()
            {
                Min = 36,
                Max = 36
            };
            columns.Append(columnAJ);
            Column columnAK = new Column()
            {
                Min = 37,
                Max = 37,
                Width = 1,
                CustomWidth = true
            };
            columns.Append(columnAK);
            Column columnAL = new Column()
            {
                Min = 38,
                Max = 38,
                Width = 50,
                CustomWidth = true
            };
            columns.Append(columnAL);
            Column columnAM = new Column()
            {
                Min = 39,
                Max = 39,
                Width = 25,
                CustomWidth = true
            };
            columns.Append(columnAM);
            Column columnAN = new Column()
            {
                Min = 40,
                Max = 40,
                Width = 25,
                CustomWidth = true
            };
            columns.Append(columnAN);
            Column columnAO = new Column()
            {
                Min = 41,
                Max = 41,
                Width = 25,
                CustomWidth = true
            };
            columns.Append(columnAO);
            Column columnAP = new Column()
            {
                Min = 42,
                Max = 42,
                Width = 25,
                CustomWidth = true
            };
            columns.Append(columnAP);
            Column columnAQ = new Column()
            {
                Min = 43,
                Max = 43,
                Width = 25,
                CustomWidth = true
            };
            columns.Append(columnAQ);
            Column columnAR = new Column()
            {
                Min = 44,
                Max = 44,
                Width = 1,
                CustomWidth = true
            };
            columns.Append(columnAR);
            Column columnAS = new Column()
            {
                Min = 45,
                Max = 45
            };
            columns.Append(columnAS);
            Column columnAT = new Column()
            {
                Min = 46,
                Max = 46,
                Width = 1,
                CustomWidth = true
            };
            columns.Append(columnAT);
            Column columnAU = new Column()
            {
                Min = 47,
                Max = 47,
                Width = 50,
                CustomWidth = true
            };
            columns.Append(columnAU);
            Column columnAV = new Column()
            {
                Min = 48,
                Max = 48,
                Width = 25,
                CustomWidth = true
            };
            columns.Append(columnAV);
            Column columnAW = new Column()
            {
                Min = 49,
                Max = 49,
                Width = 25,
                CustomWidth = true
            };
            columns.Append(columnAW);
            Column columnAX = new Column()
            {
                Min = 50,
                Max = 50,
                Width = 25,
                CustomWidth = true
            };
            columns.Append(columnAX);
            Column columnAY = new Column()
            {
                Min = 51,
                Max = 51,
                Width = 25,
                CustomWidth = true
            };
            columns.Append(columnAY);
            Column columnAZ = new Column()
            {
                Min = 52,
                Max = 52,
                Width = 25,
                CustomWidth = true
            };
            columns.Append(columnAZ);

            Column columnBA = new Column()
            {
                Min = 53,
                Max = 53,
                Width = 1,
                CustomWidth = true
            };
            columns.Append(columnBA);
            #endregion
            #region Ячейки
            Cell cell = new Cell();
            cell.CellReference = "B1";
            cell.DataType = CellValues.String;
            cell.CellValue = new CellValue("Участок ЭВС, участок ЭХЗ, участок КИПиА");
            row.Append(cell);
            MergeCells mergeCells = new MergeCells();
            MergeCell mergeCell = new MergeCell()
            {
                Reference = new StringValue("B1:H1")
            };
            mergeCells.Append(mergeCell);
            worksheet.Append(mergeCells);


            Cell cell1 = new Cell();
            cell.CellReference = "K1";
            cell.DataType = CellValues.String;
            cell.CellValue = new CellValue("Транспортный цех, РСГ и участок МТС");
            row.Append(cell1);
            MergeCells mergeCells1 = new MergeCells();
            MergeCell mergeCell1 = new MergeCell()
            {
                Reference = new StringValue("K1:O1")
            };
            mergeCells1.Append(mergeCell1);
            worksheet.Append(mergeCells1);


            Cell cell2 = new Cell();
            cell.CellReference = "T1";
            cell.DataType = CellValues.String;
            cell.CellValue = new CellValue("Служба ЛЭС и участок ГРС");
            row.Append(cell2);
            MergeCells mergeCells2 = new MergeCells();
            MergeCell mergeCell2 = new MergeCell()
            {
                Reference = new StringValue("T1:Z1")
            };
            mergeCells2.Append(mergeCell2);
            worksheet.Append(mergeCells2);


            Cell cell3 = new Cell();
            cell.CellReference = "AC1";
            cell.DataType = CellValues.String;
            cell.CellValue = new CellValue("Служба ТС");
            row.Append(cell3);
            MergeCells mergeCells3 = new MergeCells();
            MergeCell mergeCell3 = new MergeCell()
            {
                Reference = new StringValue("AC1:AI1")
            };
            mergeCells3.Append(mergeCell3);
            worksheet.Append(mergeCells3);


            Cell cell4 = new Cell();
            cell.CellReference = "AL1";
            cell.DataType = CellValues.String;
            cell.CellValue = new CellValue("Диспетчерская служба и группа ИТ");
            row.Append(cell4);
            MergeCells mergeCells4 = new MergeCells();
            MergeCell mergeCell4 = new MergeCell()
            {
                Reference = new StringValue("AL1:AR1")
            };
            mergeCells4.Append(mergeCell4);
            worksheet.Append(mergeCells4);


            Cell cell5 = new Cell();
            cell.CellReference = "AU1";
            cell.DataType = CellValues.String;
            cell.CellValue = new CellValue("Аппарат при руководстве");
            row.Append(cell5);
            MergeCells mergeCells5 = new MergeCells();
            MergeCell mergeCell5 = new MergeCell()
            {
                Reference = new StringValue("AU1:BA1")
            };
            mergeCells5.Append(mergeCell5);
            worksheet.Append(mergeCells5);

            #region Повторения

            #region Повтор 1
            Cell cell6 = new Cell();
            cell6.CellReference = "C3";
            cell6.DataType = CellValues.String;
            cell6.CellValue = new CellValue("Заполнение формы индентификации\r\n опасности в системе \"СТОП-РИСК\"");
            row3.Append(cell6);

            Cell cell7 = new Cell();
            cell7.CellReference = "D3";
            cell7.DataType = CellValues.String;
            cell7.CellValue = new CellValue("Рационализаторская деятельность");
            row3.Append(cell7);

            Cell cell8 = new Cell();
            cell8.CellReference = "E3";
            cell8.DataType = CellValues.String;
            cell8.CellValue = new CellValue("Внедрение предложений по системе \"Бережливое производство\"");
            row3.Append(cell8);

            Cell cell9 = new Cell();
            cell9.CellReference = "F3";
            cell9.DataType = CellValues.String;
            cell9.CellValue = new CellValue("Положительный опыт");
            row3.Append(cell9);

            Cell cell10 = new Cell();
            cell10.CellReference = "G3";
            cell10.DataType = CellValues.String;
            cell10.CellValue = new CellValue("Сумма баллов за квартал");
            row3.Append(cell10);
            #endregion

            #region Повтор 2
            Cell cell11 = new Cell();
            cell11.CellReference = "L3";
            cell11.DataType = CellValues.String;
            cell11.CellValue = new CellValue("Заполнение формы индентификации\r\n опасности в системе \"СТОП-РИСК\"");
            row3.Append(cell11);

            Cell cell12 = new Cell();
            cell12.CellReference = "M3";
            cell12.DataType = CellValues.String;
            cell12.CellValue = new CellValue("Рационализаторская деятельность");
            row3.Append(cell12);

            Cell cell13 = new Cell();
            cell13.CellReference = "N3";
            cell13.DataType = CellValues.String;
            cell13.CellValue = new CellValue("Внедрение предложений по системе \"Бережливое производство\"");
            row3.Append(cell13);

            Cell cell14 = new Cell();
            cell14.CellReference = "O3";
            cell14.DataType = CellValues.String;
            cell14.CellValue = new CellValue("Положительный опыт");
            row3.Append(cell14);

            Cell cell15 = new Cell();
            cell15.CellReference = "P3";
            cell15.DataType = CellValues.String;
            cell15.CellValue = new CellValue("Сумма баллов за квартал");
            row3.Append(cell15);
            #endregion

            #region Повтор 3
            Cell cell16 = new Cell();
            cell16.CellReference = "U3";
            cell16.DataType = CellValues.String;
            cell16.CellValue = new CellValue("Заполнение формы индентификации\r\n опасности в системе \"СТОП-РИСК\"");
            row3.Append(cell16);

            Cell cell17 = new Cell();
            cell17.CellReference = "V3";
            cell17.DataType = CellValues.String;
            cell17.CellValue = new CellValue("Рационализаторская деятельность");
            row3.Append(cell17);

            Cell cell18 = new Cell();
            cell18.CellReference = "W3";
            cell18.DataType = CellValues.String;
            cell18.CellValue = new CellValue("Внедрение предложений по системе \"Бережливое производство\"");
            row3.Append(cell18);

            Cell cell19 = new Cell();
            cell19.CellReference = "X3";
            cell19.DataType = CellValues.String;
            cell19.CellValue = new CellValue("Положительный опыт");
            row3.Append(cell19);

            Cell cell20 = new Cell();
            cell20.CellReference = "Y3";
            cell20.DataType = CellValues.String;
            cell20.CellValue = new CellValue("Сумма баллов за квартал");
            row3.Append(cell20);
            #endregion

            #region Повтор 4
            Cell cell21 = new Cell();
            cell21.CellReference = "AD3";
            cell21.DataType = CellValues.String;
            cell21.CellValue = new CellValue("Заполнение формы индентификации\r\n опасности в системе \"СТОП-РИСК\"");
            row3.Append(cell21);

            Cell cell22 = new Cell();
            cell22.CellReference = "AE3";
            cell22.DataType = CellValues.String;
            cell22.CellValue = new CellValue("Рационализаторская деятельность");
            row3.Append(cell22);

            Cell cell23 = new Cell();
            cell23.CellReference = "AF3";
            cell23.DataType = CellValues.String;
            cell23.CellValue = new CellValue("Внедрение предложений по системе \"Бережливое производство\"");
            row3.Append(cell23);

            Cell cell24 = new Cell();
            cell24.CellReference = "AG3";
            cell24.DataType = CellValues.String;
            cell24.CellValue = new CellValue("Положительный опыт");
            row3.Append(cell24);

            Cell cell25 = new Cell();
            cell25.CellReference = "AH3";
            cell25.DataType = CellValues.String;
            cell25.CellValue = new CellValue("Сумма баллов за квартал");
            row3.Append(cell25);
            #endregion

            #region Повтор 5
            Cell cell26 = new Cell();
            cell26.CellReference = "AM3";
            cell26.DataType = CellValues.String;
            cell26.CellValue = new CellValue("Заполнение формы индентификации\r\n опасности в системе \"СТОП-РИСК\"");
            row3.Append(cell26);

            Cell cell27 = new Cell();
            cell27.CellReference = "AN3";
            cell27.DataType = CellValues.String;
            cell27.CellValue = new CellValue("Рационализаторская деятельность");
            row3.Append(cell27);

            Cell cell28 = new Cell();
            cell28.CellReference = "AO3";
            cell28.DataType = CellValues.String;
            cell28.CellValue = new CellValue("Внедрение предложений по системе \"Бережливое производство\"");
            row3.Append(cell28);

            Cell cell29 = new Cell();
            cell29.CellReference = "AP3";
            cell29.DataType = CellValues.String;
            cell29.CellValue = new CellValue("Положительный опыт");
            row3.Append(cell29);

            Cell cell30 = new Cell();
            cell30.CellReference = "AQ3";
            cell30.DataType = CellValues.String;
            cell30.CellValue = new CellValue("Сумма баллов за квартал");
            row3.Append(cell30);
            #endregion

            #region Повтор 6
            Cell cell31 = new Cell();
            cell31.CellReference = "AV3";
            cell31.DataType = CellValues.String;
            cell31.CellValue = new CellValue("Заполнение формы индентификации\r\n опасности в системе \"СТОП-РИСК\"");
            row3.Append(cell31);

            Cell cell32 = new Cell();
            cell32.CellReference = "AW3";
            cell32.DataType = CellValues.String;
            cell32.CellValue = new CellValue("Рационализаторская деятельность");
            row3.Append(cell32);

            Cell cell33 = new Cell();
            cell33.CellReference = "AX3";
            cell33.DataType = CellValues.String;
            cell33.CellValue = new CellValue("Внедрение предложений по системе \"Бережливое производство\"");
            row3.Append(cell33);

            Cell cell34 = new Cell();
            cell34.CellReference = "AY3";
            cell34.DataType = CellValues.String;
            cell34.CellValue = new CellValue("Положительный опыт");
            row3.Append(cell34);

            Cell cell35 = new Cell();
            cell35.CellReference = "AZ3";
            cell35.DataType = CellValues.String;
            cell35.CellValue = new CellValue("Сумма баллов за квартал");
            row3.Append(cell35);
            #endregion
            #endregion

            int i = 4;

            List<User> users1 = users.Where(u => u.Division == "ЭВС" || u.Division == "ЭХЗ" || u.Division == "КИПиА").ToList();
            List<User> users2 = users.Where(u => u.Division == "ТЦ" || u.Division == "РСГ" || u.Division == "МТС").ToList();
            List<User> users3 = users.Where(u => u.Division == "ЛЭС" || u.Division == "ГРС").ToList();
            List<User> users4 = users.Where(u => u.Division == "ТС").ToList();
            List<User> users5 = users.Where(u => u.Division == "ДС" || u.Division == "ГИТ").ToList();
            List<User> users6 = users.Where(u => u.Division == "Аппарат").ToList();

            foreach (User user in users)
            {
                Row dataRow = new Row();
                dataRow.Height = 25;

                Cell dataCell2 = new Cell();
                dataCell2.DataType = CellValues.String;
                dataCell2.CellValue = new CellValue(user.Fio);
                dataCell2.CellReference = $"B{i}";
                dataRow.Append(dataCell2);



                sheetData.Append(dataRow);
                i++;
            }
            
            
            
            #endregion
            worksheetPart.Worksheet = worksheet;
            workbookPart.Workbook.Save();
        }
    }
}
