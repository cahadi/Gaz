using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Spreadsheet;
using Gaz.Domain.Entities;
using System.Data;

namespace Gaz.ApiControllers.SendTable.CreateQuarter
{
    public class CreateAll
    {
        public static void CreateSheet(WorkbookPart workbookPart, StringValue id,
            List<User> users)
        {
            WorksheetPart worksheetPart = workbookPart.GetPartById(id) as WorksheetPart;

            Worksheet worksheet = new Worksheet();
            SheetData sheetData = worksheet.AppendChild(new SheetData());

            #region Строки
            Row row = new Row();
            #endregion
            #region Колонки			
            Columns columns = worksheet.GetFirstChild<Columns>();

            Column columnA = new Column()
            {
                Min = 1,
                Max = 1,
                Width = 50,
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
                Width = 20,
                CustomWidth = true
            };
            columns.Append(columnC);

            Column columnD = new Column()
            {
                Min = 4,
                Max = 4,
                Width = 20,
                CustomWidth = true
            };
            columns.Append(columnD);

            Column columnE = new Column()
            {
                Min = 5,
                Max = 5,
                Width = 20,
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
                Width = 30,
                CustomWidth = true
            };
            columns.Append(columnG);

            Column columnH = new Column()
            {
                Min = 8,
                Max = 8,
                Width = 20,
                CustomWidth = true
            };
            columns.Append(columnH);

            Column columnI = new Column()
            {
                Min = 9,
                Max = 9,
                Width = 20,
                CustomWidth = true
            };
            columns.Append(columnI);

            Column columnJ = new Column()
            {
                Min = 10,
                Max = 10,
                Width = 20,
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
                Width = 30,
                CustomWidth = true
            };
            columns.Append(columnL);

            Column columnM = new Column()
            {
                Min = 13,
                Max = 13,
                Width = 20,
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
                Width = 30,
                CustomWidth = true
            };
            columns.Append(columnQ);

            Column columnR = new Column()
            {
                Min = 18,
                Max = 18,
                Width = 20,
                CustomWidth = true
            };
            columns.Append(columnR);

            Column columnS = new Column()
            {
                Min = 19,
                Max = 19,
                Width = 20,
                CustomWidth = true
            };
            columns.Append(columnS);

            Column columnT = new Column()
            {
                Min = 20,
                Max = 20,
                Width = 20,
                CustomWidth = true
            };
            columns.Append(columnT);

            Column columnU = new Column()
            {
                Min = 21,
                Max = 21,
                Width = 20,
                CustomWidth = true
            };
            columns.Append(columnU);

            Column columnV = new Column()
            {
                Min = 22,
                Max = 22,
                Width = 30,
                CustomWidth = true
            };
            columns.Append(columnV);

            Column columnW = new Column()
            {
                Min = 23,
                Max = 23
            };
            columns.Append(columnW);

            Column columnX = new Column()
            {
                Min = 24,
                Max = 24
            };
            columns.Append(columnX);

            Column columnY = new Column()
            {
                Min = 25,
                Max = 25
            };
            columns.Append(columnY);
            #endregion
            #region Ячейкм
            Cell cellA1 = new Cell();
            cellA1.CellReference = "A1";
            cellA1.DataType = CellValues.String;
            cellA1.CellValue = new CellValue("ФИО");
            row.Append(cellA1);

            Cell cellB1 = new Cell();
            cellA1.CellReference = "B1";
            cellA1.DataType = CellValues.String;
            cellA1.CellValue = new CellValue("Подразделение");
            row.Append(cellB1);

            Cell cellC1 = new Cell();
            cellA1.CellReference = "C1";
            cellA1.DataType = CellValues.String;
            cellA1.CellValue = new CellValue("1кв СР");
            row.Append(cellC1);

            Cell cellD1 = new Cell();
            cellA1.CellReference = "D1";
            cellA1.DataType = CellValues.String;
            cellA1.CellValue = new CellValue("1кв РД");
            row.Append(cellD1);

            Cell cellE1 = new Cell();
            cellA1.CellReference = "E1";
            cellA1.DataType = CellValues.String;
            cellA1.CellValue = new CellValue("1кв БП");
            row.Append(cellE1);

            Cell cellF1 = new Cell();
            cellA1.CellReference = "F1";
            cellA1.DataType = CellValues.String;
            cellA1.CellValue = new CellValue("1кв ПО");
            row.Append(cellF1);

            Cell cellG1 = new Cell();
            cellA1.CellReference = "G1";
            cellA1.DataType = CellValues.String;
            cellA1.CellValue = new CellValue("баллы за 1кв ");
            row.Append(cellG1);

            Cell cellH1 = new Cell();
            cellA1.CellReference = "H1";
            cellA1.DataType = CellValues.String;
            cellA1.CellValue = new CellValue("2кв СР");
            row.Append(cellH1);

            Cell cellI1 = new Cell();
            cellA1.CellReference = "I1";
            cellA1.DataType = CellValues.String;
            cellA1.CellValue = new CellValue("2кв РД");
            row.Append(cellI1);

            Cell cellJ1 = new Cell();
            cellA1.CellReference = "J1";
            cellA1.DataType = CellValues.String;
            cellA1.CellValue = new CellValue("2кв БП");
            row.Append(cellJ1);

            Cell cellK1 = new Cell();
            cellA1.CellReference = "K1";
            cellA1.DataType = CellValues.String;
            cellA1.CellValue = new CellValue("2кв ПО");
            row.Append(cellK1);

            Cell cellL1 = new Cell();
            cellA1.CellReference = "L1";
            cellA1.DataType = CellValues.String;
            cellA1.CellValue = new CellValue("баллы за 2кв ");
            row.Append(cellL1);

            Cell cellM1 = new Cell();
            cellA1.CellReference = "M1";
            cellA1.DataType = CellValues.String;
            cellA1.CellValue = new CellValue("3кв СР");
            row.Append(cellM1);

            Cell cellN1 = new Cell();
            cellA1.CellReference = "N1";
            cellA1.DataType = CellValues.String;
            cellA1.CellValue = new CellValue("3кв РД");
            row.Append(cellN1);

            Cell cellO1 = new Cell();
            cellA1.CellReference = "O1";
            cellA1.DataType = CellValues.String;
            cellA1.CellValue = new CellValue("3кв БП");
            row.Append(cellO1);

            Cell cellP1 = new Cell();
            cellA1.CellReference = "P1";
            cellA1.DataType = CellValues.String;
            cellA1.CellValue = new CellValue("3кв ПО");
            row.Append(cellP1);

            Cell cellQ1 = new Cell();
            cellA1.CellReference = "B1";
            cellA1.DataType = CellValues.String;
            cellA1.CellValue = new CellValue("баллы за 3кв ");
            row.Append(cellB1);
                        
            Cell cellR1 = new Cell();
            cellA1.CellReference = "R1";
            cellA1.DataType = CellValues.String;
            cellA1.CellValue = new CellValue("4кв СР");
            row.Append(cellR1);

            Cell cellS1 = new Cell();
            cellA1.CellReference = "S1";
            cellA1.DataType = CellValues.String;
            cellA1.CellValue = new CellValue("4кв РД");
            row.Append(cellS1);

            Cell cellT1 = new Cell();
            cellA1.CellReference = "T1";
            cellA1.DataType = CellValues.String;
            cellA1.CellValue = new CellValue("4кв БП");
            row.Append(cellT1);

            Cell cellU1 = new Cell();
            cellA1.CellReference = "U1";
            cellA1.DataType = CellValues.String;
            cellA1.CellValue = new CellValue("4кв ПО");
            row.Append(cellU1);

            Cell cellV1 = new Cell();
            cellA1.CellReference = "V1";
            cellA1.DataType = CellValues.String;
            cellA1.CellValue = new CellValue("баллы за 4кв ");
            row.Append(cellV1);

            Cell cellW1 = new Cell();
            cellA1.CellReference = "W1";
            cellA1.DataType = CellValues.String;
            cellA1.CellValue = new CellValue("");
            row.Append(cellW1);

            Cell cellX1 = new Cell();
            cellA1.CellReference = "X1";
            cellA1.DataType = CellValues.String;
            cellA1.CellValue = new CellValue("");
            row.Append(cellX1);

            Cell cellY1 = new Cell();
            cellA1.CellReference = "Y1";
            cellA1.DataType = CellValues.String;
            cellA1.CellValue = new CellValue("");
            row.Append(cellY1);
            #endregion

            sheetData.Append(row);
            int i = 2;
            foreach(User us in users)
            {
                Row row1 = new Row();
                row1.Height = 25;

                Cell cellA = new Cell();
                cellA.DataType = CellValues.String;
                cellA.CellValue = new CellValue(us.Fio);
                cellA.CellReference = $"A{i}";
                row1.Append(cellA);

                Cell cellB = new Cell();
                cellA.DataType = CellValues.String;
                cellA.CellValue = new CellValue(us.Division);
                cellA.CellReference = $"B{i}";
                row1.Append(cellB);
            }

            sheetData.Append(row);
            worksheetPart.Worksheet = worksheet;
            workbookPart.Workbook.Save();
        }
    }
}
