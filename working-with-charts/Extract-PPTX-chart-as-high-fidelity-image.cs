using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ExtractChartImage
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputImagePath = "chart.png";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            using (Presentation presentation = new Presentation(inputPath))
            {
                // Attempt to retrieve the first chart on the first slide
                IChart chart = presentation.Slides[0].Shapes[0] as IChart;
                if (chart == null)
                {
                    Console.WriteLine("No chart found on the first slide.");
                    return;
                }

                // Render the chart to an image
                IImage chartImage = chart.GetImage();

                // Save the chart image preserving visual fidelity
                chartImage.Save(outputImagePath, ImageFormat.Png);

                // Save the presentation before exiting (as required)
                presentation.Save("output.pptx", SaveFormat.Pptx);
            }
        }
    }
}