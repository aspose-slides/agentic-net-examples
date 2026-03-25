using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Check command line arguments
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: program <input.pptx> <output.pptx>");
            return;
        }

        string inputPath = args[0];
        string outputPath = args[1];

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        try
        {
            // Load existing presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Access first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a line chart with sample data
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.Line, 50, 50, 450, 300);

            // Enable data table and set number format for precision
            chart.HasDataTable = true;
            chart.ChartData.Series[0].NumberFormatOfValues = "#,##0.00";

            // Compute actual layout values for accurate rendering
            chart.ValidateChartLayout();

            // Save the updated presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}