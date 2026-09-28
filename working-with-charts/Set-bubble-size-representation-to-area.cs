// -----------------------------------------------------------------------------
// Example: Set Bubble Size Representation to Area in PowerPoint using Aspose.Slides for .NET
//
// Description:
// This console application loads an existing PPTX file, adds a bubble chart,
// and sets the bubble size representation to Area. It demonstrates how to
// manipulate chart properties with Aspose.Slides for .NET and saves the
// modified presentation as a new PPTX file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, bubble chart, size representation, area
//
// Use Cases:
// - Automate chart formatting in financial or scientific reports
// - Ensure consistent bubble size scaling across multiple presentations
// - Integrate chart customization into .NET backend services
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

namespace AsposeSlidesBubbleSizeArea
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output_area.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            try
            {
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[0];

                    Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                        Aspose.Slides.Charts.ChartType.Bubble,
                        50f,
                        150f,
                        500f,
                        400f);

                    chart.ChartData.SeriesGroups[0].BubbleSizeRepresentation = Aspose.Slides.Charts.BubbleSizeRepresentationType.Area;

                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }

                Console.WriteLine("Presentation saved successfully to " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
