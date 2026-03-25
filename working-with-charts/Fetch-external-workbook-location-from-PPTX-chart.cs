using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Define paths
        string dataDir = "Data";
        string inputFile = Path.Combine(dataDir, "input.pptx");
        string outputFile = Path.Combine(dataDir, "output.pptx");

        // Check if input file exists
        if (!File.Exists(inputFile))
        {
            Console.WriteLine("Input file not found: " + inputFile);
            return;
        }

        // Load presentation
        using (Presentation pres = new Presentation(inputFile))
        {
            // Get the first chart on the first slide
            Aspose.Slides.Charts.IChart chart = pres.Slides[0].Shapes[0] as Aspose.Slides.Charts.IChart;
            if (chart != null)
            {
                // Retrieve external workbook path
                string workbookPath = chart.ChartData.ExternalWorkbookPath;
                Console.WriteLine("External workbook path: " + (workbookPath ?? "None"));
            }
            else
            {
                Console.WriteLine("No chart found on the first slide.");
            }

            // Save presentation before exit
            pres.Save(outputFile, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}