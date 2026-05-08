using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        // Define input and output paths
        string dataDir = "Data";
        string inputPath = Path.Combine(dataDir, "input.pptx");
        string outputPath = Path.Combine(dataDir, "output.pptx");

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        // Load the presentation with error handling for unsupported formats
        Presentation presentation = null;
        try
        {
            presentation = new Presentation(inputPath);
        }
        catch (PptxEditException)
        {
            // format not supported
            Console.WriteLine("The file format is not supported.");
            return;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error loading presentation: " + ex.Message);
            return;
        }

        // Ensure there is at least one slide
        if (presentation.Slides.Count == 0)
        {
            presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
        }

        // Add a bubble chart with sample data
        IChart chart = presentation.Slides[0].Shapes.AddChart(
            ChartType.Bubble, 50f, 50f, 600f, 400f, true);

        // Access the first series of the chart
        IChartSeries series = chart.ChartData.Series[0];

        // Update the chart's data table (example modifications)
        IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
        workbook.GetCell(0, "A1", "Series 1");
        workbook.GetCell(0, "B1", "Category 1");
        workbook.GetCell(0, "C1", 10.0);
        workbook.GetCell(0, "A2", "Series 2");
        workbook.GetCell(0, "B2", "Category 2");
        workbook.GetCell(0, "C2", 20.0);

        // Configure X-direction error bars
        IErrorBarsFormat errorBarsX = series.ErrorBarsXFormat;
        if (errorBarsX != null)
        {
            errorBarsX.IsVisible = true;
            errorBarsX.ValueType = ErrorBarValueType.Fixed;
            errorBarsX.Value = 5f;
            errorBarsX.Type = ErrorBarType.Plus;
            errorBarsX.HasEndCap = true;
        }

        // Configure Y-direction error bars
        IErrorBarsFormat errorBarsY = series.ErrorBarsYFormat;
        if (errorBarsY != null)
        {
            errorBarsY.IsVisible = true;
            errorBarsY.ValueType = ErrorBarValueType.Percentage;
            errorBarsY.Value = 10f;
            // Set line width for Y error bars
            errorBarsY.Format.Line.Width = 2;
        }

        // Save the modified presentation as PPTX
        try
        {
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error saving presentation: " + ex.Message);
        }
        finally
        {
            presentation.Dispose();
        }
    }
}