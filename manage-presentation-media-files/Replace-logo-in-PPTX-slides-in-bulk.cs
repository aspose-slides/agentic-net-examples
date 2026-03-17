using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ReplaceLogoInPptx
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Paths to the source presentation, new logo image, and output file
                string sourcePresentationPath = "input.pptx";
                string newLogoPath = "newlogo.png";
                string outputPresentationPath = "output.pptx";

                // Load new logo image data into a byte array
                byte[] newLogoData = File.ReadAllBytes(newLogoPath);

                // Open the presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(sourcePresentationPath))
                {
                    // Iterate through all images in the presentation and replace them with the new logo
                    for (int index = 0; index < presentation.Images.Count; index++)
                    {
                        Aspose.Slides.IPPImage existingImage = presentation.Images[index];
                        // Replace the image data; this updates all occurrences of the image across slides
                        existingImage.ReplaceImage(newLogoData);
                    }

                    // Save the modified presentation
                    presentation.Save(outputPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Output any errors that occur during processing
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}