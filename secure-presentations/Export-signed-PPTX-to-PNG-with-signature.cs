using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExportSignedPresentation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the signed presentation file
            string presentationPath = "SignedPresentation.pptx";

            // Verify that the input file exists
            if (!File.Exists(presentationPath))
            {
                Console.WriteLine("Error: The file '" + presentationPath + "' does not exist.");
                return;
            }

            try
            {
                // Load the signed presentation
                using (Presentation pres = new Presentation(presentationPath))
                {
                    // Iterate through each slide and export it as PNG
                    for (int index = 0; index < pres.Slides.Count; index++)
                    {
                        ISlide slide = pres.Slides[index];

                        // Get a full‑scale image of the slide (signature visual is rendered automatically)
                        using (IImage slideImage = slide.GetImage(1f, 1f))
                        {
                            string outputFile = "slide_" + (index + 1) + ".png";

                            // Save the slide image as PNG
                            slideImage.Save(outputFile, ImageFormat.Png);
                        }
                    }

                    // Save the presentation (required by lifecycle rule)
                    pres.Save(presentationPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("Error: The presentation format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other unexpected exceptions (e.g., web service errors)
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
            }
        }
    }
}