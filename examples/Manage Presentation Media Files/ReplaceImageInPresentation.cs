using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Load an existing presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Ensure there is at least one image in the collection
        if (presentation.Images.Count > 0)
        {
            // Get the first image from the collection
            Aspose.Slides.IPPImage image = presentation.Images[0];

            // Load new image data from a file
            byte[] newImageData = File.ReadAllBytes("newImage.png");

            // Replace the existing image data with the new image data
            image.ReplaceImage(newImageData);
        }

        // Save the modified presentation
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up resources
        presentation.Dispose();
    }
}