using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace InsertLogoToMaster
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define data directory
            string dataDir = "Data";
            if (!Directory.Exists(dataDir))
            {
                Directory.CreateDirectory(dataDir);
            }

            // Path to the company logo image
            string logoPath = Path.Combine(dataDir, "logo.png");

            // Verify that the logo file exists
            if (!File.Exists(logoPath))
            {
                Console.WriteLine("Logo file not found: " + logoPath);
                return;
            }

            try
            {
                // Create a new presentation
                Presentation pres = new Presentation();

                // Get the first slide and its master slide
                ISlide firstSlide = pres.Slides[0];
                IMasterSlide masterSlide = firstSlide.LayoutSlide.MasterSlide;

                // Load the logo image and add it to the presentation's image collection
                IImage logoImage = Images.FromFile(logoPath);
                IPPImage logoPpImage = pres.Images.AddImage(logoImage);

                // Insert the logo onto the master slide; it will appear on all derived slides
                masterSlide.Shapes.AddPictureFrame(
                    ShapeType.Rectangle,
                    10,               // X position
                    10,               // Y position
                    logoPpImage.Width,
                    logoPpImage.Height,
                    logoPpImage);

                // Save the presentation
                string outPath = Path.Combine(dataDir, "PresentationWithLogo.pptx");
                pres.Save(outPath, SaveFormat.Pptx);
                pres.Dispose();

                Console.WriteLine("Presentation saved to: " + outPath);
            }
            catch (Aspose.Slides.PptxReadException)
            {
                // Handle unsupported file format
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}