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
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
            {
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a line chart without sample data
                Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.Line, 50f, 50f, 500f, 400f);

                // Set chart title
                chart.HasTitle = true;
                chart.ChartTitle.AddTextFrameForOverriding("Sample Line Chart");
                chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = Aspose.Slides.NullableBool.True;

                // Clear default series and categories
                chart.ChartData.Series.Clear();
                chart.ChartData.Categories.Clear();

                int defaultWorksheetIndex = 0;
                Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                // Add series
                Aspose.Slides.Charts.IChartSeries series1 = chart.ChartData.Series.Add(
                    workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"),
                    Aspose.Slides.Charts.ChartType.Line);
                Aspose.Slides.Charts.IChartSeries series2 = chart.ChartData.Series.Add(
                    workbook.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"),
                    Aspose.Slides.Charts.ChartType.Line);

                // Add categories
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category 1"));
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category 2"));
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Category 3"));

                // Populate data points for series 1
                series1.DataPoints.AddDataPointForLineSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 10));
                series1.DataPoints.AddDataPointForLineSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 20));
                series1.DataPoints.AddDataPointForLineSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 30));

                // Populate data points for series 2
                series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(defaultWorksheetIndex, 1, 2, 15));
                series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(defaultWorksheetIndex, 2, 2, 25));
                series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(defaultWorksheetIndex, 3, 2, 35));

                // Save the presentation
                presentation.Save("LineChartPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}