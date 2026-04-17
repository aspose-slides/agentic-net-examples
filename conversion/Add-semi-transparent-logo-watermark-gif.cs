using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesGifWatermark
{
    class Program
    {
        static void Main(string[] args)
        {
            // Expected arguments: input presentation path, logo image path, output GIF path
            if (args.Length < 3)
            {
                Console.WriteLine("Usage: AsposeSlidesGifWatermark <input.pptx> <logo.png> <output.gif>");
                return;
            }

            string inputPath = args[0];
            string logoPath = args[1];
            string outputPath = args[2];

            // Verify that the input files exist
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input presentation file does not exist: " + inputPath);
                return;
            }

            if (!File.Exists(logoPath))
            {
                Console.WriteLine("Logo image file does not exist: " + logoPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Ensure there is at least one master slide
                    if (pres.Masters.Count == 0)
                    {
                        Console.WriteLine("The presentation does not contain any master slides.");
                        return;
                    }

                    // Get the first master slide
                    IMasterSlide master = pres.Masters[0];

                    // Load the logo image into the presentation's image collection
                    byte[] logoBytes = File.ReadAllBytes(logoPath);
                    IPPImage logoImg = pres.Images.AddImage(logoBytes);

                    // Add the logo as a picture frame on the master slide
                    // Position (10,10) and size (100,100) are examples; adjust as needed
                    IPictureFrame picture = master.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, logoImg);

                    // Apply semi‑transparent fill to the picture frame
                    picture.FillFormat.FillType = FillType.Solid;
                    // 50% transparent white overlay (alpha = 128)
                    picture.FillFormat.SolidFillColor.Color = Color.FromArgb(128, Color.White);

                    // Configure GIF export options
                    GifOptions gifOptions = new GifOptions();
                    // Example frame size; adjust as needed
                    gifOptions.FrameSize = new Size(960, 720);
                    gifOptions.DefaultDelay = 2000; // 2 seconds per frame
                    gifOptions.TransitionFps = 30;   // 30 frames per second

                    // Save the presentation as an animated GIF
                    pres.Save(outputPath, SaveFormat.Gif, gifOptions);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: The requested output format is not supported by Aspose.Slides.
            }
            catch (Exception ex)
            {
                // General exception handling (e.g., I/O errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}