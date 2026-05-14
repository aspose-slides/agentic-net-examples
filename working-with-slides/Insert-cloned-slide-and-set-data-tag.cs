using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace InsertCloneSlideExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "source.pptx";
            string outputPath = "result.pptx";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Clone the first slide and insert it at the end of the collection
                    ISlideCollection slides = presentation.Slides;
                    ISlide clonedSlide = slides.InsertClone(slides.Count, slides[0]);

                    // Set a custom document property to identify the cloned slide
                    IDocumentProperties docProps = presentation.DocumentProperties;
                    docProps.SetCustomPropertyValue("ClonedSlideId", clonedSlide.SlideId);

                    // Save the modified presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (PptxUnsupportedFormatException)
            {
                // Format not supported
                Console.WriteLine("The presentation format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}