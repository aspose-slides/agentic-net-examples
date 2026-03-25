using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartCustomizationExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Error: Input file \"{inputPath}\" not found.");
                return;
            }

            // Load the presentation
            Presentation pres = null;
            try
            {
                pres = new Presentation(inputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading presentation: {ex.Message}");
                return;
            }

            // Access the first slide
            ISlide slide = pres.Slides[0];

            // Add a Pie chart to the slide
            IChart chart = slide.Shapes.AddChart(ChartType.Pie, 50f, 50f, 400f, 300f);

            // Customize data label appearance
            // Show leader lines for the first series
            chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLeaderLines = true;

            // Show value and category name for the first label of the first series
            chart.ChartData.Series[0].Labels[0].DataLabelFormat.ShowValue = true;
            chart.ChartData.Series[0].Labels[0].DataLabelFormat.ShowCategoryName = true;

            // Set a custom separator for the data label
            chart.ChartData.Series[0].Labels[0].DataLabelFormat.Separator = ", ";

            // Save the modified presentation
            try
            {
                pres.Save(outputPath, SaveFormat.Pptx);
                Console.WriteLine($"Presentation saved successfully to \"{outputPath}\".");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving presentation: {ex.Message}");
            }
            finally
            {
                // Ensure resources are released
                pres.Dispose();
            }
        }
    }
}