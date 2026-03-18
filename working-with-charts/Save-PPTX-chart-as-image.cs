using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.pptx";
            string chartImagePath = "chart.png";
            string outputPresentationPath = "output.pptx";

            // Load the presentation
            using (Presentation pres = new Presentation(inputPath))
            {
                // Access the first slide
                ISlide slide = pres.Slides[0];

                // Find the first chart on the slide
                IChart chart = null;
                foreach (IShape shape in slide.Shapes)
                {
                    if (shape is IChart)
                    {
                        chart = (IChart)shape;
                        break;
                    }
                }

                if (chart != null)
                {
                    // Export the chart as an image preserving its appearance
                    using (IImage chartImage = chart.GetImage())
                    {
                        chartImage.Save(chartImagePath, Aspose.Slides.ImageFormat.Png);
                    }
                }

                // Save the presentation before exiting
                pres.Save(outputPresentationPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}