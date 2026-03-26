using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace RetrieveExternalWorkbookPath
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string dataDir = Directory.GetCurrentDirectory();
            string inputFile = Path.Combine(dataDir, "input.pptx");
            string outputFile = Path.Combine(dataDir, "output.pptx");

            // Verify that the input file exists
            if (!File.Exists(inputFile))
            {
                Console.WriteLine("Input file not found: " + inputFile);
                return;
            }

            // Load the presentation
            Presentation pres = new Presentation(inputFile);

            // Assume the first slide contains the chart
            ISlide slide = pres.Slides[0];
            IChart chart = slide.Shapes[0] as IChart;

            if (chart != null)
            {
                // Retrieve the external workbook path associated with the chart
                string workbookPath = ((IChartData)chart.ChartData).ExternalWorkbookPath;
                Console.WriteLine("External workbook path: " + (workbookPath ?? "None"));
            }
            else
            {
                Console.WriteLine("No chart found on the first slide.");
            }

            // Save the presentation before exiting
            pres.Save(outputFile, SaveFormat.Pptx);
        }
    }
}