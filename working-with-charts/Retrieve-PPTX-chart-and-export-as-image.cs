using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartExportExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Paths for input presentation and output chart image
                string presentationPath = "input.pptx";
                string chartImagePath = "chart.png";
                string savedPresentationPath = "output.pptx";

                // Load the presentation
                using (Presentation presentation = new Presentation(presentationPath))
                {
                    // Access the first slide (adjust index as needed)
                    ISlide slide = presentation.Slides[0];

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
                        // Export the chart as an image
                        IImage chartImage = chart.GetImage();
                        chartImage.Save(chartImagePath, Aspose.Slides.ImageFormat.Png);
                    }
                    else
                    {
                        Console.WriteLine("No chart found on the first slide.");
                    }

                    // Save the presentation before exiting
                    presentation.Save(savedPresentationPath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}