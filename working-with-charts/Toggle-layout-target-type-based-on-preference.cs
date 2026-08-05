// -----------------------------------------------------------------------------
// Example: Toggle layout target type based on preference using C#
//
// Description:
// Demonstrates how to toggle the LayoutTargetType of a chart's PlotArea 
// (inner or outer) based on a command‑line preference using Aspose.Slides for .NET. 
// The example loads or creates a presentation, ensures a chart exists, sets a 
// manual layout for the PlotArea and applies the requested LayoutTargetType, 
// then saves the result as a PPTX file.
//
// Keywords:
// C#, Aspose.Slides, Chart, PlotArea, LayoutTargetType, Inner, Outer, PPTX, 
// Presentation Automation, Office Automation
//
// Use Cases:
// - Programmatically switch a chart's layout target between inner and outer bounds.
// - Build command‑line tools that adjust chart formatting in PowerPoint files.
// - Automate PPTX generation or modification with specific chart layout settings.
// - Validate chart layout behavior before publishing presentations.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Expect three arguments: inputPath, outputPath, layoutPreference ("inner" or "outer")
            if (args.Length < 3)
            {
                Console.WriteLine("Usage: <inputPath> <outputPath> <inner|outer>");
                return;
            }

            string inputPath = args[0];
            string outputPath = args[1];
            string layoutPreference = args[2];

            Presentation presentation = null;
            try
            {
                if (File.Exists(inputPath))
                {
                    // Load existing presentation
                    presentation = new Presentation(inputPath);
                }
                else
                {
                    // Create a new presentation if input file does not exist
                    presentation = new Presentation();
                }

                // Ensure there is at least one slide
                ISlide slide = presentation.Slides.Count > 0 ? presentation.Slides[0] : presentation.Slides.AddEmptySlide(presentation.Masters[0].LayoutSlides[0]);

                // Add a chart if none exists on the slide
                IChart chart = null;
                foreach (IShape shape in slide.Shapes)
                {
                    if (shape is IChart existingChart)
                    {
                        chart = existingChart;
                        break;
                    }
                }

                if (chart == null)
                {
                    // Add a clustered column chart
                    chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
                }

                // Set manual layout for the plot area
                chart.PlotArea.AsILayoutable.X = 0.2f;
                chart.PlotArea.AsILayoutable.Y = 0.2f;
                chart.PlotArea.AsILayoutable.Width = 0.7f;
                chart.PlotArea.AsILayoutable.Height = 0.7f;

                // Toggle LayoutTargetType based on user preference
                if (string.Equals(layoutPreference, "inner", StringComparison.OrdinalIgnoreCase))
                {
                    chart.PlotArea.LayoutTargetType = LayoutTargetType.Inner;
                }
                else if (string.Equals(layoutPreference, "outer", StringComparison.OrdinalIgnoreCase))
                {
                    chart.PlotArea.LayoutTargetType = LayoutTargetType.Outer;
                }
                else
                {
                    Console.WriteLine("Invalid layout preference. Use 'inner' or 'outer'.");
                }

                // Save the presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Handle unsupported format scenario here
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., external URL issues)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            finally
            {
                if (presentation != null)
                {
                    presentation.Dispose();
                }
            }
        }
    }
}
