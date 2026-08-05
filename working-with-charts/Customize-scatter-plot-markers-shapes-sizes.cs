// -----------------------------------------------------------------------------
// Example: Customize scatter plot marker shapes and sizes using C#
//
// Description:
// Demonstrates how to create a scatter chart, add data points with literal X/Y
// values, and customize individual marker shapes and sizes as well as the
// default series marker using Aspose.Slides for .NET. The presentation is saved
// as a PPTX file in a console application, illustrating typical steps for
// PowerPoint chart manipulation.
//
// Keywords:
// C#, Aspose.Slides for .NET, PowerPoint, PPTX, Scatter Chart, Marker Shape,
// Marker Size, Chart Customization, Presentation Automation, Office Automation
//
// Use Cases:
// - Generate scatter charts with custom marker appearances in PPTX files.
// - Build .NET utilities that programmatically style chart data points.
// - Automate creation of presentation assets with specific visual requirements.
// - Validate and test chart rendering logic in PowerPoint automation workflows.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        string outputPath = "ScatterChartMarkers.pptx";

        // Ensure the output directory exists
        try
        {
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!String.IsNullOrEmpty(outputDir) && !Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to prepare output directory: " + ex.Message);
            return;
        }

        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a scatter chart
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ScatterWithSmoothLines,
                0, 0, 400, 400);

            // Clear any default series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
            int defaultWorksheetIndex = 0;

            // Add a series
            chart.ChartData.Series.Add(
                workbook.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"),
                chart.Type);
            Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];

            // Configure the series to use literal double values for X and Y
            series.DataPoints.DataSourceTypeForXValues = Aspose.Slides.Charts.DataSourceType.DoubleLiterals;
            series.DataPoints.DataSourceTypeForYValues = Aspose.Slides.Charts.DataSourceType.DoubleLiterals;

            // Add data points with custom markers
            Aspose.Slides.Charts.IChartDataPoint point1 = series.DataPoints.AddDataPointForScatterSeries(1.0, 2.0);
            point1.Marker.Size = 12;
            point1.Marker.Symbol = Aspose.Slides.Charts.MarkerStyleType.Circle;

            Aspose.Slides.Charts.IChartDataPoint point2 = series.DataPoints.AddDataPointForScatterSeries(2.5, 3.5);
            point2.Marker.Size = 16;
            point2.Marker.Symbol = Aspose.Slides.Charts.MarkerStyleType.Star;

            Aspose.Slides.Charts.IChartDataPoint point3 = series.DataPoints.AddDataPointForScatterSeries(4.0, 1.5);
            point3.Marker.Size = 10;
            point3.Marker.Symbol = Aspose.Slides.Charts.MarkerStyleType.Square;

            // Set default marker for any points without custom settings
            series.Marker.Size = 8;
            series.Marker.Symbol = Aspose.Slides.Charts.MarkerStyleType.Diamond;

            // Save the presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (NotSupportedException ex)
        {
            // Format not supported
            Console.WriteLine("The requested file format is not supported: " + ex.Message);
        }
        catch (Exception ex)
        {
            // General error handling
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
