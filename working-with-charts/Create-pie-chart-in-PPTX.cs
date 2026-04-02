using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace PieChartExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Access the first slide
                ISlide slide = presentation.Slides[0];

                // Add a pie chart
                IChart chart = slide.Shapes.AddChart(ChartType.Pie, 50f, 50f, 400f, 400f);

                // Set chart title
                chart.ChartTitle.AddTextFrameForOverriding("Sample Pie Chart");
                chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = Aspose.Slides.NullableBool.True;
                chart.ChartTitle.Height = 20f;
                chart.HasTitle = true;

                // Show values on the first series
                chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

                // Index for the chart data sheet
                int defaultWorksheetIndex = 0;

                // Get the chart data workbook
                IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                // Clear default series and categories
                chart.ChartData.Series.Clear();
                chart.ChartData.Categories.Clear();

                // Add categories
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category 1"));
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category 2"));
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Category 3"));

                // Add a new series
                IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);

                // Add data points for the pie series
                series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 30));
                series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 40));
                series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 30));

                // Enable varied colors for each slice
                series.ParentSeriesGroup.IsColorVaried = true;

                // Save the presentation
                presentation.Save("PieChartPresentation.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., unsupported format, file I/O errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}