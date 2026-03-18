using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideProcessing
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Input and output file paths
                string inputPath = "input.pptx";
                string outputPath = "output.pptx";

                // Load the presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Retrieve the slide collection
                    Aspose.Slides.ISlideCollection slides = presentation.Slides;

                    // Iterate through each slide for processing
                    for (int i = 0; i < slides.Count; i++)
                    {
                        Aspose.Slides.ISlide slide = slides[i];
                        // Example processing: display slide number
                        Console.WriteLine("Processing slide number: " + slide.SlideNumber);
                    }

                    // Save the presentation before exiting
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during processing
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}