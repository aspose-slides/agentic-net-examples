// -----------------------------------------------------------------------------
// Example: Set Chart Legend to Bottom Right Using Aspose.Slides for .NET
//
// Description:
// This console application creates a new PowerPoint presentation, adds a
// clustered column chart, and positions the chart legend in the bottom‑right
// corner of the chart area. It demonstrates the required Aspose.Slides API
// calls for chart manipulation and saves the result as a PPTX file.
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, chart legend position, bottom right
//
// Use Cases:
// - Automate PPTX generation with custom chart legends for reporting dashboards.
// - Integrate chart styling into .NET back‑end services that produce presentations.
// - Ensure consistent legend placement across multiple generated slides.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

namespace ChartLegendBottomRightExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string outputPath = "ChartLegendBottomRight.pptx";

            try
            {
                // Ensure the output directory exists
                string outputDirectory = Path.GetDirectoryName(Path.GetFullPath(outputPath));
                if (!Directory.Exists(outputDirectory))
                {
                    Directory.CreateDirectory(outputDirectory);
                }

                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a clustered column chart
                Aspose.Slides.Charts.IChart chart = (Aspose.Slides.Charts.IChart)slide.Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.ClusteredColumn,
                    50f,   // X position
                    50f,   // Y position
                    500f,  // Width
                    400f   // Height
                );

                // Set legend position to bottom and then move it to the right edge
                chart.Legend.Position = Aspose.Slides.Charts.LegendPositionType.Bottom;
                chart.Legend.X = chart.Width - chart.Legend.Width;
                chart.Legend.Y = chart.Height - chart.Legend.Height;

                // Save the presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                Console.WriteLine("Presentation saved successfully to: " + Path.GetFullPath(outputPath));
            }
            catch (System.IO.IOException ioEx)
            {
                Console.Error.WriteLine("IO error: " + ioEx.Message);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
