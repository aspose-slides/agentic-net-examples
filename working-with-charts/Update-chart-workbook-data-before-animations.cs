using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main(string[] args)
    {
        // Define data directory and output file path
        string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
        string outputPath = Path.Combine(dataDir, "UpdatedChart.pptx");

        // Ensure the data directory exists
        if (!Directory.Exists(dataDir))
        {
            Directory.CreateDirectory(dataDir);
        }

        // Create a new presentation
        using (Presentation pres = new Presentation())
        {
            // Get the first slide
            ISlide slide = pres.Slides[0];

            // Add a clustered column chart with sample data
            IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 600f, 400f, true);

            // Access the embedded workbook of the chart
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Worksheet index (default is 0)
            int defaultWorksheetIndex = 0;

            // Update category labels
            workbook.GetCell(defaultWorksheetIndex, "A2", "Category 1");
            workbook.GetCell(defaultWorksheetIndex, "A3", "Category 2");
            workbook.GetCell(defaultWorksheetIndex, "A4", "Category 3");

            // Update series names
            workbook.GetCell(defaultWorksheetIndex, "B1", "Series 1");
            workbook.GetCell(defaultWorksheetIndex, "C1", "Series 2");

            // Update series data values
            workbook.GetCell(defaultWorksheetIndex, "B2", 10);
            workbook.GetCell(defaultWorksheetIndex, "B3", 20);
            workbook.GetCell(defaultWorksheetIndex, "B4", 30);

            workbook.GetCell(defaultWorksheetIndex, "C2", 15);
            workbook.GetCell(defaultWorksheetIndex, "C3", 25);
            workbook.GetCell(defaultWorksheetIndex, "C4", 35);

            // Recalculate any formulas (if present)
            workbook.CalculateFormulas();

            // Save the presentation
            pres.Save(outputPath, SaveFormat.Pptx);
        }

        Console.WriteLine("Presentation saved to: " + outputPath);
    }
}