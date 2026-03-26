using System;
using System.IO;
using Aspose.Slides.Export;

namespace ChartTypeConfigurator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Load existing presentation if it exists; otherwise create a new one
            Aspose.Slides.Presentation presentation;
            if (File.Exists(inputPath))
            {
                // Load presentation from file
                presentation = new Aspose.Slides.Presentation(inputPath);
            }
            else
            {
                // Create a new presentation with a default slide
                presentation = new Aspose.Slides.Presentation();

                // Add a sample chart to the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];
                Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);
                // Optional: set a title for clarity
                chart.HasTitle = true;
                chart.ChartTitle.AddTextFrameForOverriding("Sample Chart");
            }

            // Access the first slide
            Aspose.Slides.ISlide firstSlide = presentation.Slides[0];

            // Find the first chart shape on the slide
            Aspose.Slides.Charts.IChart targetChart = null;
            foreach (Aspose.Slides.IShape shape in firstSlide.Shapes)
            {
                if (shape is Aspose.Slides.Charts.IChart)
                {
                    targetChart = (Aspose.Slides.Charts.IChart)shape;
                    break;
                }
            }

            if (targetChart != null)
            {
                // Change the chart type to Pie
                targetChart.Type = Aspose.Slides.Charts.ChartType.Pie;
            }
            else
            {
                Console.WriteLine("No chart found on the first slide.");
            }

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Clean up resources
            presentation.Dispose();

            Console.WriteLine("Presentation saved to " + outputPath);
        }
    }
}