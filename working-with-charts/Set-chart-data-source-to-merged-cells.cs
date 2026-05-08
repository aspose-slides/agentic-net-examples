using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define paths
        string dataDir = Directory.GetCurrentDirectory();
        string excelPath = Path.Combine(dataDir, "Data.xlsx");
        string outputPath = Path.Combine(dataDir, "ChartWithMergedCells.pptx");

        // Verify that the Excel source file exists
        if (!File.Exists(excelPath))
        {
            Console.WriteLine("Excel file not found: " + excelPath);
            return;
        }

        try
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Add a chart to the first slide
            Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn,
                50f,
                50f,
                600f,
                400f);

            // Set the external workbook as the data source
            ((Aspose.Slides.Charts.ChartData)chart.ChartData).SetExternalWorkbook(excelPath);

            // Define a range that includes merged cells (e.g., A1:C5)
            chart.ChartData.SetRange("Sheet1!$A$1:$C$5");

            // Optional: modify series appearance
            Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];
            series.ParentSeriesGroup.IsColorVaried = true;

            // Save the presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (ArgumentException ex)
        {
            // Handle unsupported format or invalid parameters
            Console.WriteLine("Argument error: " + ex.Message);
        }
        catch (InvalidOperationException ex)
        {
            // Handle operations that are not supported
            Console.WriteLine("Invalid operation: " + ex.Message);
        }
    }
}