using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation())
            {
                Aspose.Slides.ISlide slide = pres.Slides[0];
                Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Pie, 50, 50, 400, 400);

                Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
                int defaultWorksheetIndex = 0;

                chart.ChartData.Series.Clear();
                chart.ChartData.Categories.Clear();

                var seriesNameCell = workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1");
                var series = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

                var cat1 = workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category 1");
                var cat2 = workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category 2");
                chart.ChartData.Categories.Add(cat1);
                chart.ChartData.Categories.Add(cat2);

                var valCell1 = workbook.GetCell(defaultWorksheetIndex, 1, 1, 2);
                var valCell2 = workbook.GetCell(defaultWorksheetIndex, 2, 1, 3);
                var formulaCell = workbook.GetCell(defaultWorksheetIndex, 3, 1);
                formulaCell.Formula = "B2+B3";

                series.DataPoints.AddDataPointForPieSeries(valCell1);
                series.DataPoints.AddDataPointForPieSeries(valCell2);
                series.DataPoints.AddDataPointForPieSeries(formulaCell);

                workbook.CalculateFormulas();

                pres.Save("ChartWithFormulas.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}