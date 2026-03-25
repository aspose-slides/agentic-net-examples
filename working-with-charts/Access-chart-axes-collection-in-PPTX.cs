using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AxisManipulationExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = args.Length > 0 ? args[0] : "input.pptx";
            string outputPath = "output.pptx";

            Aspose.Slides.Presentation presentation = null;

            try
            {
                if (File.Exists(inputPath))
                {
                    // Load existing presentation
                    presentation = new Aspose.Slides.Presentation(inputPath);
                }
                else
                {
                    // Input file not found – create a new presentation
                    presentation = new Aspose.Slides.Presentation();
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Error: Input file not found. " + ex.Message);
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading presentation: " + ex.Message);
                return;
            }

            // Ensure there is at least one slide
            Aspose.Slides.ISlide slide = null;
            if (presentation.Slides.Count > 0)
            {
                slide = presentation.Slides[0];
            }
            else
            {
                slide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
            }

            // Add a clustered column chart
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn, 50f, 50f, 450f, 300f);

            // Manipulate axes
            // Set the horizontal axis to be positioned between categories
            chart.Axes.HorizontalAxis.AxisBetweenCategories = true;

            // Set label offset for the horizontal axis
            chart.Axes.HorizontalAxis.LabelOffset = (ushort)100; // 10% offset

            // Example: make vertical axis logarithmic
            chart.Axes.VerticalAxis.IsLogarithmic = true;
            chart.Axes.VerticalAxis.LogBase = 10.0;

            // Save the presentation
            try
            {
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                Console.WriteLine("Presentation saved to " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving presentation: " + ex.Message);
            }
            finally
            {
                presentation.Dispose();
            }
        }
    }
}