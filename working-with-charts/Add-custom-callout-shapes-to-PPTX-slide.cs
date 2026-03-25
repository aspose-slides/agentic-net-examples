using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace CalloutExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output_with_callout.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Error: Input file not found - " + inputPath);
                return;
            }

            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);
            try
            {
                // Access the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a pie chart to the slide (using the provided rule)
                Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.Pie,
                    100f,   // X position
                    100f,   // Y position
                    400f,   // Width
                    300f    // Height
                );

                // Enable data labels and set them as callouts
                chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
                chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLabelAsDataCallout = true;

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                Console.WriteLine("Presentation saved successfully to " + outputPath);
            }
            finally
            {
                // Ensure resources are released
                presentation.Dispose();
            }
        }
    }
}