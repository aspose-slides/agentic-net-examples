using System;
using System.IO;
using Aspose.Slides.Export;

namespace AsposeSlidesAxisPosition
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
                Console.WriteLine("Error: Input file not found: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation from the input file
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Access the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a clustered column chart to the slide
                Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.ClusteredColumn,
                    50f, 50f, 500f, 400f);

                // Set the position of the horizontal (category) axis to the bottom
                chart.Axes.HorizontalAxis.Position = Aspose.Slides.Charts.AxisPositionType.Bottom;

                // Set the position of the vertical (value) axis to the left
                chart.Axes.VerticalAxis.Position = Aspose.Slides.Charts.AxisPositionType.Left;

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

                // Clean up resources
                presentation.Dispose();

                Console.WriteLine("Presentation saved successfully to: " + outputPath);
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during processing
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}