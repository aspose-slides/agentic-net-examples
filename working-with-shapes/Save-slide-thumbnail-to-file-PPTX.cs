using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Get presentation file path from the user
            Console.Write("Enter the path to the presentation file: ");
            string presentationPath = Console.ReadLine();

            // Get desired output image file name from the user
            Console.Write("Enter the output image file name (e.g., slide.png): ");
            string outputImagePath = Console.ReadLine();

            // Load the presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(presentationPath))
            {
                // Access the first slide (index 0)
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Generate a thumbnail image for the slide
                Aspose.Slides.IImage slideImage = slide.GetImage();

                // Save the thumbnail image to the specified file in PNG format
                slideImage.Save(outputImagePath, Aspose.Slides.ImageFormat.Png);

                // Save the presentation before exiting (required by the task)
                presentation.Save("SavedPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Output any errors that occur
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}