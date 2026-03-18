using System;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartFormulaExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                var pres = new Aspose.Slides.Presentation();
                var slide = pres.Slides[0];
                var chart = slide.Shapes.AddChart(ChartType.Pie, 100, 100, 300, 400);
                var workbook = chart.ChartData.ChartDataWorkbook;
                workbook.GetCell(0, "B2", 2);
                workbook.GetCell(0, "B3", 3);
                var formulaCell = workbook.GetCell(0, "B4");
                formulaCell.Formula = "B2+B3";
                workbook.CalculateFormulas();
                pres.Save("ChartWithFormula.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}