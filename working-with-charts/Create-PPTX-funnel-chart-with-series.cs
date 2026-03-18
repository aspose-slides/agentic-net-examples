using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            using (var pres = new Presentation())
            {
                var slide = pres.Slides[0];
                var chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Funnel, 50, 50, 500, 400);
                chart.HasTitle = true;
                chart.ChartTitle.AddTextFrameForOverriding("Funnel Chart");
                chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;

                // Clear default data
                chart.ChartData.Series.Clear();
                chart.ChartData.Categories.Clear();

                var defaultWorksheetIndex = 0;
                var workbook = chart.ChartData.ChartDataWorkbook;

                // Add a series
                var series = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), Aspose.Slides.Charts.ChartType.Funnel);

                // Add categories
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Stage 1"));
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Stage 2"));
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Stage 3"));

                // Add data points for the funnel series
                series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 30));
                series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 20));
                series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 10));

                // Set series fill color
                series.Format.Fill.FillType = FillType.Solid;
                series.Format.Fill.SolidFillColor.Color = Color.Blue;

                // Save the presentation
                pres.Save("FunnelChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}