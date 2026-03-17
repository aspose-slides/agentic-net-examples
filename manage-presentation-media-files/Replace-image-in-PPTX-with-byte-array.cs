using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Paths to the source and destination presentations
            string sourcePath = "input.pptx";
            string destinationPath = "output.pptx";

            // Load the new image data from a file (could be any byte array source)
            byte[] newImageData = File.ReadAllBytes("newImage.png");

            // Load the presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(sourcePath))
            {
                // Ensure there is at least one image in the presentation
                if (presentation.Images.Count > 0)
                {
                    // Get the first image (replace with the desired index as needed)
                    Aspose.Slides.IPPImage image = presentation.Images[0];

                    // Replace the image data with the new byte array
                    image.ReplaceImage(newImageData);
                }

                // Save the modified presentation
                presentation.Save(destinationPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Output any errors that occur during processing
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}