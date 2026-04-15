using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

class Program
{
    static void Main()
    {
        string imagesFolder = "Images";
        if (!Directory.Exists(imagesFolder))
        {
            Console.WriteLine("Images folder does not exist.");
            return;
        }

        // Create a new presentation
        Presentation presentation = new Presentation();

        // Add a new empty slide
        ISlide newSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);

        // Add picture organization chart smart art
        ISmartArt smartArt = newSlide.Shapes.AddSmartArt(50, 50, 600, 400, SmartArtLayoutType.PictureOrganizationChart);

        // Add images from the specified folder to the presentation
        string[] imageFiles = Directory.GetFiles(imagesFolder);
        foreach (string imagePath in imageFiles)
        {
            try
            {
                using (FileStream fileStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                {
                    IPPImage img = presentation.Images.AddImage(fileStream, LoadingStreamBehavior.KeepLocked);
                    // Image added to presentation; further assignment to smart art nodes can be done here if needed
                }
            }
            catch (Exception ex)
            {
                // Handle image loading exceptions
                Console.WriteLine("Error loading image: " + ex.Message);
            }
        }

        // Save the presentation
        string outputPath = "PictureOrganizationChart.pptx";
        try
        {
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Format not supported
            Console.WriteLine("Error saving presentation: " + ex.Message);
        }
    }
}