using System;
using System.Drawing;
using System.IO;
using Xceed.Document.NET;
using Xceed.Words.NET;
using PayMaster.SQL;
using System.Collections.Generic;

namespace PayMaster.Tools
{
    class WordDocTools
    {
        TimeCalculations tc = new TimeCalculations();
        private readonly string docPath = Environment.CurrentDirectory + "\\RAPORTS";
        private readonly string today = new TimeCalculations().GetToday();
        private bool amountFontBold = false;
        
        public void CreateDocDir()
        {
           
            if (!string.IsNullOrEmpty(docPath) && !Directory.Exists(docPath))
            {
                Directory.CreateDirectory(docPath);
            }

        }

        private string PageChecksumGenerate()
        {
            string todayText = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");
            todayText = todayText.Replace(".", "");
            todayText = todayText.Replace(" ", "");
            todayText = todayText.Replace(":", "");

            return todayText;
        }

        public void GenerateRaport(List<TransactionModel> transactionModel)
        {
            string controlSum = PageChecksumGenerate();
            int countList = transactionModel.Count;
            DocX document = DocX.Create(docPath + "\\Raport_" + tc.ReformatDateDMY(today) + "_" + controlSum + ".docx");
            //DocX document = DocX.Create(docPath + "\\Raport_" + tc.ReformatDateDMY(today) + ".docx");
            document.MarginLeft = 30f;
            document.MarginRight = 30f;
            document.MarginTop = 30f;
            document.MarginBottom = 30f;
            document.Sections[0].PageLayout.Orientation = Orientation.Landscape;
            document.AddFooters();

            
            Paragraph title = document.InsertParagraph();
            title.Append("ZESTAWIENIE TRANSAKCJI")
                .FontSize(14d)
                .Bold(true)
                .Alignment = Alignment.center;


            Paragraph dateOfCreate = document.InsertParagraph();
            dateOfCreate.Append("data raportu: ")
                .FontSize(11d)
                .Bold(false)
                .Append(tc.ReformatDateDMY(today))
                .Bold(true)
                .Alignment = Alignment.right;
            

            Paragraph checksumText = document.InsertParagraph();
            checksumText.Append("suma kontrolna: ")
                .FontSize(11d)
                .Bold(false)
                .Append(controlSum)
                .Bold(true)
                .Alignment = Alignment.right;

            Paragraph raportPeriod = document.InsertParagraph();
            raportPeriod.Append("raport za okres: ")
                .FontSize(11d)
                .Bold(false)
                .Append(tc.ReformatDateDMY(transactionModel[countList - 1].TransactionDate) + " - "
                + tc.ReformatDateDMY(transactionModel[0].TransactionDate))
                .Bold(true)
                .Alignment = Alignment.left;

            Paragraph payInText = document.InsertParagraph();
            payInText.Append("suma wpłat: ")
                .FontSize(11d)
                .Bold(false)
                .Append(new FinancialOps().GetPayIn(transactionModel).ToString("C2"))
                .Bold(true)
                .Append(" --> liczba wpłat: ")
                .Bold(false)
                .Append(new FinancialOps().GetPayInCount(transactionModel).ToString())
                .Bold(true)
                .Alignment = Alignment.left;

            Paragraph payOutText = document.InsertParagraph();
            payOutText.Append("suma wypłat: ")
                .FontSize(11d)
                .Bold(false)
                .Append(new FinancialOps().GetPayOut(transactionModel).ToString("C2"))
                .Bold(true)
                .Append(" --> liczba wypłat: ")
                .Bold(false)
                .Append(new FinancialOps().GetPayOutCount(transactionModel).ToString())
                .Bold(true)
                .Alignment = Alignment.left;

            Paragraph raportBalance = document.InsertParagraph();
            raportBalance.Append("saldo raportu: ")
                .FontSize(11d)
                .Bold(false)
                .Append(new FinancialOps()
                .GetFilteredBalance(new FinancialOps()
                .GetPayIn(transactionModel), new FinancialOps()
                .GetPayOut(transactionModel)).ToString("C2"))
                .Bold(true)
                .Append(" --> liczba wszystkich transakcji: ")
                .Bold(false)
                .Append(new FinancialOps().GetFilteredBalanceCount(transactionModel).ToString())
                .Bold(true)
                .Alignment = Alignment.left;

            Paragraph mainBalance = document.InsertParagraph();
            mainBalance.Append("saldo konta: ")
                .FontSize(11d)
                .Bold(false)
                .Append(new SQLTransaction().GetAccountBalance().ToString("C2"))
                .Bold(true)
                .SpacingAfter(20d)
                .Alignment = Alignment.right;

            var mainTable = document.AddTable(countList, 5);
            var columnsWidth = new float[] { 70f, 240f, 80f, 240f, 240f };
            mainTable.SetWidths(columnsWidth);
            mainTable.Alignment = Alignment.center;

            var firstRow = mainTable.InsertRow(0);

            firstRow.Height = 16;
            Color firstRowFillColor = Color.DimGray;
            Color firstRowFontColor = Color.White;

            firstRow.Cells[0].VerticalAlignment = VerticalAlignment.Center;
            firstRow.Cells[0].FillColor = firstRowFillColor;
            firstRow.Cells[0].Paragraphs[0].Append("DATA").Bold(true).Color(firstRowFontColor).Alignment=Alignment.center;

            firstRow.Cells[1].VerticalAlignment = VerticalAlignment.Center;
            firstRow.Cells[1].FillColor = firstRowFillColor;
            firstRow.Cells[1].Paragraphs[0].Append("PŁATNIK").Bold(true).Color(firstRowFontColor).Alignment = Alignment.center;

            firstRow.Cells[2].VerticalAlignment = VerticalAlignment.Center;
            firstRow.Cells[2].FillColor = firstRowFillColor;
            firstRow.Cells[2].Paragraphs[0].Append("KWOTA").Bold(true).Color(firstRowFontColor).Alignment = Alignment.center;

            firstRow.Cells[3].VerticalAlignment = VerticalAlignment.Center;
            firstRow.Cells[3].FillColor = firstRowFillColor;
            firstRow.Cells[3].Paragraphs[0].Append("CEL OPERACJI").Bold(true).Color(firstRowFontColor).Alignment = Alignment.center;

            firstRow.Cells[4].VerticalAlignment = VerticalAlignment.Center;
            firstRow.Cells[4].FillColor = firstRowFillColor;
            firstRow.Cells[4].Paragraphs[0].Append("OPIS").Bold(true).Color(firstRowFontColor).Alignment = Alignment.center;

            for (int i = 0; i < countList ; i++)
            {
                mainTable.Rows[i + 1].MinHeight = 16;
                
                mainTable.Rows[i + 1].Cells[0].VerticalAlignment = VerticalAlignment.Center;
                
                mainTable.Rows[i + 1].Cells[0].Paragraphs[0].Append(transactionModel[i].TransactionDate).Alignment = Alignment.center;

                mainTable.Rows[i + 1].Cells[1].VerticalAlignment = VerticalAlignment.Center;
                mainTable.Rows[i + 1].Cells[1].Paragraphs[0].Append(transactionModel[i].TransactionPersonName + " " 
                    + transactionModel[i].TransactionPersonSurname + " " + transactionModel[i].TransactionPersonNick).Alignment = Alignment.left;


                
                if(transactionModel[i].TransactionAmount < 0)
                {
                    amountFontBold = true;
                }
                else
                {
                    amountFontBold = false;
                }
                mainTable.Rows[i + 1].Cells[2].VerticalAlignment = VerticalAlignment.Center;
                mainTable.Rows[i + 1].Cells[2].Paragraphs[0]
                    .Append(transactionModel[i].TransactionAmount.ToString("C2"))
                    .Bold(amountFontBold)
                    .KeepWithNextParagraph(true)
                    .Alignment = Alignment.right;

                mainTable.Rows[i + 1].Cells[3].VerticalAlignment = VerticalAlignment.Center;
                mainTable.Rows[i + 1].Cells[3].Paragraphs[0].Append(transactionModel[i].TransactionTargetText).Alignment = Alignment.left;

                mainTable.Rows[i + 1].Cells[4].VerticalAlignment = VerticalAlignment.Center;
                mainTable.Rows[i + 1].Cells[4].Paragraphs[0].
                    Append(transactionModel[i].TransactionDescription)
                    .KeepLinesTogether(true)
                    .Alignment = Alignment.left;

            }

            
            document.InsertTable(mainTable);

            // Add the page number in the first Footer.
            document.Footers.First.InsertParagraph("Strona ").AppendPageNumber(PageNumberFormat.normal)
                .Append(" z ").AppendPageCount(PageNumberFormat.normal)
                .Append("        suma kontrolna: " + controlSum);


            // Add the page number in the even Footers.
            document.Footers.Even.InsertParagraph("Strona ").AppendPageNumber(PageNumberFormat.normal)
                .Append(" z ").AppendPageCount(PageNumberFormat.normal)
                .Append("        suma kontrolna: " + controlSum);


            // Add the page number in the odd Footers.
            document.Footers.Odd.InsertParagraph("Strona ").AppendPageNumber(PageNumberFormat.normal)
                .Append(" z ").AppendPageCount(PageNumberFormat.normal)
                .Append("        suma kontrolna: " + controlSum);
            

            document.Save();
        }

        public void GenerateDocOld()
        {
            DocX document = DocX.Create("test.docx");
            Paragraph p = document.InsertParagraph();
            p.Append("bla bla bla");
            document.InsertParagraph("to kolejna linijka");
            var t = document.AddTable(5, 2);
            var c = new float[] { 100f, 300f };
            t.SetWidths(c);
            int columnsLen = c.Length;
            //t.Design = TableDesign.Custom;

            t.Alignment = Alignment.center;
            t.Rows[0].Cells[0].FillColor = Color.Red;
            t.Rows[0].Cells[1].FillColor = Color.Red;
            t.Rows[0].Height = 80;
            t.Rows[0].Cells[0].Paragraphs[0].Append("Mike").Color(Color.White);
            t.Rows[0].Cells[1].Paragraphs[0].Append("65").Color(Color.White);
            t.Rows[1].Cells[0].Paragraphs[0].Append("Kevin");
            t.Rows[1].Cells[1].Paragraphs[0].Append("62");
            t.Rows[2].Cells[0].Paragraphs[0].Append("Carl");
            t.Rows[2].Cells[1].Paragraphs[0].Append("60");
            t.Rows[3].Cells[0].Paragraphs[0].Append("Michael");
            t.Rows[3].Cells[1].Paragraphs[0].Append("59");
            t.Rows[4].Cells[0].Paragraphs[0].Append("Shawn");
            t.Rows[4].Cells[1].Paragraphs[0].Append("57");
            document.InsertTable(t);
            document.Save();
        }


    }
}
