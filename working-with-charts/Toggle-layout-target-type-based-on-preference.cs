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