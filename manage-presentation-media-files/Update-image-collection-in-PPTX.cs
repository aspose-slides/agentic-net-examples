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
            string sourcePath = "input.pptx";
            string newImagePath = "newImage.png";
            string outputPath = "output.pptx";

            using (Presentation presentation = new Presentation(sourcePath))
            {
                // Load the new image data into a byte array
                byte[] newImageData = File.ReadAllBytes(newImagePath);

                // Replace each image in the presentation with the new image data
                for (int i = 0; i < presentation.Images.Count; i++)
                {
                    IPPImage existingImage = presentation.Images[i];
                    existingImage.ReplaceImage(newImageData);
                }

                // Save the updated presentation in PPTX format
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}