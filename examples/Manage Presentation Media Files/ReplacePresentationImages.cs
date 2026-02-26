using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Path to the source presentation
        string sourcePresentationPath = "input.pptx";
        // Path to the new image that will replace existing images
        string replacementImagePath = "newImage.png";

        // Load the presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(sourcePresentationPath))
        {
            // Read the replacement image data into a byte array
            byte[] replacementImageData = File.ReadAllBytes(replacementImagePath);

            // Get the collection of images in the presentation
            Aspose.Slides.IImageCollection imageCollection = presentation.Images;

            // Iterate through each image and replace its data
            for (int index = 0; index < imageCollection.Count; index++)
            {
                Aspose.Slides.IPPImage image = imageCollection[index];
                image.ReplaceImage(replacementImageData);
            }

            // Save the modified presentation
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}