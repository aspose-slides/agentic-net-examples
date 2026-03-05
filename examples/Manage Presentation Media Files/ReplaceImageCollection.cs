using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Paths for the source presentation, the new image, and the output presentation
        string inputPptxPath = "input.pptx";
        string newImagePath = "newImage.png";
        string outputPptxPath = "output.pptx";

        // Load the existing presentation
        var presentation = new Aspose.Slides.Presentation(inputPptxPath);

        // Read the new image data
        var newImageData = File.ReadAllBytes(newImagePath);

        // Replace the first image in the image collection, if any
        if (presentation.Images.Count > 0)
        {
            var existingImage = presentation.Images[0];
            existingImage.ReplaceImage(newImageData);
        }

        // Save the modified presentation
        presentation.Save(outputPptxPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}