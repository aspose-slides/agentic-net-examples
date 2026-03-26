using System;
using Aspose.Slides.Export;

namespace LineChartExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Output file path
            string outputPath = "LineChartPresentation.pptx";

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a line chart without sample data (initWithSample = false)
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.Line,
                50f, 50f, 600f, 400f, false);

            // Get the chart data workbook
            Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Clear default series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Add categories (X‑axis labels)
            chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Category 1"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Category 2"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Category 3"));

            // Add first series and its data points
            Aspose.Slides.Charts.IChartSeries series1 = chart.ChartData.Series.Add(
                workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);
            series1.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 1, 1, 10.0));
            series1.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 2, 1, 20.0));
            series1.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 3, 1, 30.0));

            // Add second series and its data points
            Aspose.Slides.Charts.IChartSeries series2 = chart.ChartData.Series.Add(
                workbook.GetCell(0, 0, 2, "Series 2"), chart.Type);
            series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 1, 2, 15.0));
            series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 2, 2, 25.0));
            series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 3, 2, 35.0));

            // Show values for the first series data labels
            series1.Labels.DefaultDataLabelFormat.ShowValue = true;

            // Save the presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}