using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ExternalWorkbookPathRetriever
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PPTX file path
            string inputFile = "input.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputFile))
            {
                Console.WriteLine("Error: Input file not found - " + inputFile);
                return;
            }

            // Load the presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputFile);

            // Retrieve the first chart on the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];
            Aspose.Slides.IShape shape = slide.Shapes[0];
            Aspose.Slides.Charts.IChart chart = shape as Aspose.Slides.Charts.IChart;

            if (chart == null)
            {
                Console.WriteLine("No chart found on the first slide.");
                pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                return;
            }

            // Get the external workbook path associated with the chart
            Aspose.Slides.Charts.IChartData chartData = chart.ChartData;
            string workbookPath = chartData.ExternalWorkbookPath;

            if (string.IsNullOrEmpty(workbookPath))
            {
                Console.WriteLine("The chart does not have an external workbook linked.");
            }
            else
            {
                Console.WriteLine("External workbook path: " + workbookPath);
            }

            // Save the presentation before exiting
            pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}