using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main(string[] args)
    {
        // Output file path
        string outputPath = "CustomChartAxis.pptx";

        // Determine if an input presentation should be loaded
        string inputPath = args.Length > 0 ? args[0] : null;
        Presentation presentation = null;

        try
        {
            if (!string.IsNullOrEmpty(inputPath))
            {
                // Verify that the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.WriteLine("Input file not found: " + inputPath);
                    return;
                }

                // Load existing presentation
                presentation = new Presentation(inputPath);
            }
            else
            {
                // Create a new presentation from scratch
                presentation = new Presentation();
            }

            // Access the first slide
            ISlide slide = presentation.Slides[0];

            // Add a clustered column chart (using the showing-display-unit-label rule)
            IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);

            // Set vertical axis display unit to Millions
            chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Millions;

            // Set category axis label distance (using the set-category-axis-label-distance rule)
            chart.Axes.HorizontalAxis.LabelOffset = (ushort)200;

            // Position the horizontal axis between categories (using the setting-position-axis rule)
            chart.Axes.HorizontalAxis.AxisBetweenCategories = true;

            // Save the presentation before exiting (lifecycle rule)
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
        finally
        {
            // Ensure resources are released
            if (presentation != null)
            {
                presentation.Dispose();
            }
        }
    }
}