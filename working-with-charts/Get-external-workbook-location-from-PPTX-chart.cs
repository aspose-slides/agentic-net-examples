using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace GetExternalWorkbookPath
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the input presentation
            string presentationPath = "input.pptx";

            // Verify that the file exists
            if (!File.Exists(presentationPath))
            {
                Console.WriteLine("Presentation file not found: " + presentationPath);
                return;
            }

            // Load the presentation
            using (Presentation pres = new Presentation(presentationPath))
            {
                // Locate the first chart on the first slide
                Aspose.Slides.Charts.IChart chart = null;
                foreach (Aspose.Slides.IShape shape in pres.Slides[0].Shapes)
                {
                    chart = shape as Aspose.Slides.Charts.IChart;
                    if (chart != null)
                    {
                        break;
                    }
                }

                if (chart == null)
                {
                    Console.WriteLine("No chart found on the first slide.");
                }
                else
                {
                    // Retrieve the external workbook path associated with the chart
                    string externalWorkbookPath = chart.ChartData.ExternalWorkbookPath;

                    if (string.IsNullOrEmpty(externalWorkbookPath))
                    {
                        Console.WriteLine("The chart does not use an external workbook.");
                    }
                    else
                    {
                        Console.WriteLine("External workbook path: " + externalWorkbookPath);
                    }
                }

                // Save the presentation before exiting (even if unchanged)
                pres.Save("output.pptx", SaveFormat.Pptx);
            }
        }
    }
}