using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation())
            {
                // Add a second slide to the presentation
                Aspose.Slides.ISlide secondSlide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

                // Load a custom image from file and add it to the presentation's image collection
                string imagePath = "customImage.png";
                Aspose.Slides.IPPImage customImage = pres.Images.AddImage(File.ReadAllBytes(imagePath));

                // Add a zoom frame on the first slide that links to the second slide and uses the custom image
                Aspose.Slides.IZoomFrame zoom = pres.Slides[0].Shapes.AddZoomFrame(150, 20, 100, 100, secondSlide, customImage);

                // Save the presentation to a PPTX file
                string outPath = Path.Combine(Directory.GetCurrentDirectory(), "ZoomPresentation.pptx");
                pres.Save(outPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}