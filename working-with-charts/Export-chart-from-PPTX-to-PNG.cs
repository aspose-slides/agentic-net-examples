using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ChartImageExport
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input PPTX file path
            string inputPptxPath = "input.pptx";
            // Define output image file path
            string outputImagePath = "chart.png";
            // Define output PPTX file path (optional, to satisfy save-before-exit rule)
            string outputPptxPath = "output.pptx";

            // Check if the input file exists
            if (!File.Exists(inputPptxPath))
            {
                Console.WriteLine("Error: Input file not found - " + inputPptxPath);
                return;
            }

            // Load the presentation
            Presentation presentation = null;
            try
            {
                presentation = new Presentation(inputPptxPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading presentation: " + ex.Message);
                return;
            }

            // Retrieve the first chart from the first slide
            Aspose.Slides.Charts.IChart chart = null;
            if (presentation.Slides.Count > 0 && presentation.Slides[0].Shapes.Count > 0)
            {
                chart = presentation.Slides[0].Shapes[0] as Aspose.Slides.Charts.IChart;
            }

            if (chart == null)
            {
                Console.WriteLine("Error: No chart found in the presentation.");
                presentation.Dispose();
                return;
            }

            // Get the chart image
            Aspose.Slides.IImage chartImage = chart.GetImage();

            // Save the chart image as PNG
            chartImage.Save(outputImagePath, Aspose.Slides.ImageFormat.Png);

            // Save the presentation (even if unchanged) before exiting
            presentation.Save(outputPptxPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Clean up resources
            presentation.Dispose();

            Console.WriteLine("Chart image saved to: " + outputImagePath);
        }
    }
}