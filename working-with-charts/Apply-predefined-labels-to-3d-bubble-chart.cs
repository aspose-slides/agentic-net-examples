using System;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a 3‑D bubble chart
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.Bubble, 50f, 50f, 600f, 400f);

            // Access the chart's workbook to add data
            Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Add a series
            Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(
                workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);

            // Add data points for the bubble series
            series.DataPoints.AddDataPointForBubbleSeries(
                workbook.GetCell(0, 1, 1, 1.0),
                workbook.GetCell(0, 1, 2, 2.0),
                workbook.GetCell(0, 1, 3, 3.0));

            series.DataPoints.AddDataPointForBubbleSeries(
                workbook.GetCell(0, 2, 1, 2.0),
                workbook.GetCell(0, 2, 2, 3.0),
                workbook.GetCell(0, 2, 3, 4.0));

            // Apply predefined data label format to all data points in the series
            series.Labels.DefaultDataLabelFormat.ShowBubbleSize = true;
            series.Labels.DefaultDataLabelFormat.ShowValue = true;

            // Ensure each bubble has a 3‑D effect
            foreach (Aspose.Slides.Charts.IChartDataPoint point in series.DataPoints)
            {
                point.IsBubble3D = true;
            }

            // Save the presentation
            string outputPath = "3DBubbleChart.pptx";
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (System.IO.FileNotFoundException ex)
        {
            // Handle missing file if any input files were used
            Console.WriteLine("File not found: " + ex.Message);
        }
        catch (Exception ex)
        {
            // Handle other exceptions (e.g., unsupported format)
            // Format not supported
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}