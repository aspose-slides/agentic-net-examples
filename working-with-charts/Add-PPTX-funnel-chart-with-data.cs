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
            using (Presentation pres = new Presentation())
            {
                ISlide slide = pres.Slides[0];

                // Add a funnel chart without sample data
                IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Funnel, 50, 50, 500, 400, false);

                // Clear default series and categories
                chart.ChartData.Series.Clear();
                chart.ChartData.Categories.Clear();

                int defaultWorksheetIndex = 0;
                IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                // Add a series
                IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), Aspose.Slides.Charts.ChartType.Funnel);

                // Add categories
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Stage 1"));
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Stage 2"));
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Stage 3"));
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 4, 0, "Stage 4"));

                // Add data points for the funnel series
                series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 120));
                series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 80));
                series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 50));
                series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(defaultWorksheetIndex, 4, 1, 30));

                // Set chart title
                chart.HasTitle = true;
                chart.ChartTitle.AddTextFrameForOverriding("Funnel Chart Example");
                chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = Aspose.Slides.NullableBool.True;

                // Save the presentation
                pres.Save("FunnelChart_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}