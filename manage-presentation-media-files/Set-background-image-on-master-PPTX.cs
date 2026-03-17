using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SetMasterBackground
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Presentation pres = new Presentation();

                // Load image bytes from file
                byte[] imageBytes = File.ReadAllBytes("background.jpg");

                // Add image to the presentation's image collection
                IPPImage img = pres.Images.AddImage(imageBytes);

                // Access the first master slide
                IMasterSlide master = pres.Masters[0];

                // Set the background to use a picture
                master.Background.Type = BackgroundType.OwnBackground;
                master.Background.FillFormat.FillType = FillType.Picture;
                master.Background.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
                master.Background.FillFormat.PictureFillFormat.Picture.Image = img;

                // Save the presentation
                pres.Save("MasterBackground.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}