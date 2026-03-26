using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Paths for input and output files
        string presentationPath = "input.pptx";
        string outputPath = "output.pptx";

        // Verify that the input presentation exists
        if (!File.Exists(presentationPath))
        {
            Console.WriteLine("Presentation file not found: " + presentationPath);
            return;
        }

        // Load the presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(presentationPath);
        try
        {
            // Access the first shape on the first slide and cast it to a chart
            Aspose.Slides.IShape shape = pres.Slides[0].Shapes[0];
            Aspose.Slides.Charts.IChart chart = shape as Aspose.Slides.Charts.IChart;
            if (chart == null)
            {
                Console.WriteLine("No chart found on the first slide.");
                return;
            }

            // Retrieve the embedded workbook associated with the chart
            Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Example: list all worksheet names in the embedded workbook
            foreach (Aspose.Slides.Charts.IChartDataWorksheet worksheet in workbook.Worksheets)
            {
                Console.WriteLine("Worksheet: " + worksheet.Name);
            }

            // Perform any desired manipulation, e.g., recalculate formulas
            workbook.CalculateFormulas();

            // Save the modified presentation
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        finally
        {
            // Ensure resources are released
            pres.Dispose();
        }
    }
}