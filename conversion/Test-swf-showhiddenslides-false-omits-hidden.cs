using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesSwfConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "sample.pptx";
            string outputPath = "output.swf";

            // Ensure the input file exists; if not, create a sample presentation with a hidden slide
            if (!File.Exists(inputPath))
            {
                // Create a new presentation
                Presentation tempPresentation = new Presentation();

                // Add a second slide based on the layout of the first slide
                ISlide secondSlide = tempPresentation.Slides.AddEmptySlide(tempPresentation.Slides[0].LayoutSlide);

                // Hide the second slide
                secondSlide.Hidden = true;

                // Save the temporary presentation to the input path
                tempPresentation.Save(inputPath, SaveFormat.Pptx);
                tempPresentation.Dispose();
            }

            // Load the presentation and convert to SWF with ShowHiddenSlides set to false
            using (Presentation presentation = new Presentation(inputPath))
            {
                SwfOptions swfOptions = new SwfOptions();
                swfOptions.ShowHiddenSlides = false; // Omit hidden slides

                try
                {
                    presentation.Save(outputPath, SaveFormat.Swf, swfOptions);
                }
                catch (NotSupportedException)
                {
                    // The format is not supported
                }
                catch (Exception)
                {
                    // Handle other possible exceptions
                }
            }
        }
    }
}