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
            // Input PPTX file path
            string inputPptxPath = "input.pptx";
            // Output image file path
            string outputImagePath = "chart.png";
            // Output PPTX file path (optional, can be same as input)
            string outputPptxPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPptxPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPptxPath);
                return;
            }

            // Load the presentation
            using (Presentation presentation = new Presentation(inputPptxPath))
            {
                // Retrieve the first chart on the first slide
                Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes[0] as Aspose.Slides.Charts.IChart;
                if (chart == null)
                {
                    Console.WriteLine("No chart found on the first slide.");
                    return;
                }

                // Get the chart image
                Aspose.Slides.IImage chartImage = chart.GetImage();

                // Save the chart image as PNG
                chartImage.Save(outputImagePath, Aspose.Slides.ImageFormat.Png);

                // Save the presentation (optional, in case of any modifications)
                presentation.Save(outputPptxPath, SaveFormat.Pptx);
            }

            Console.WriteLine("Chart image exported successfully to " + outputImagePath);
        }
    }
}