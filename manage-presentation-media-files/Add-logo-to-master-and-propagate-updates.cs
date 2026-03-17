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
            var presentationPath = "input.pptx";
            var logoPath = "logo.png";
            var outputPath = "output.pptx";

            using (var pres = new Presentation(presentationPath))
            {
                // Access the first master slide
                var master = pres.Masters[0];

                // Load logo image bytes and add to presentation's image collection
                var imageBytes = File.ReadAllBytes(logoPath);
                var image = pres.Images.AddImage(imageBytes);

                // Add the logo as a picture frame on the master slide
                master.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);

                // Save the updated presentation
                pres.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}