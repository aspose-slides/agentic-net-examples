using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputImagePath = "shape_thumbnail.png";
            string outputPresentationPath = "output.pptx";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            // Read presentation into a byte array
            byte[] presentationData = File.ReadAllBytes(inputPath);

            // Load presentation from byte array
            Presentation pres = null;
            try
            {
                using (MemoryStream ms = new MemoryStream(presentationData))
                {
                    pres = new Presentation(ms);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to load presentation: " + ex.Message);
                return;
            }

            // Extract thumbnail of the first shape
            try
            {
                if (pres.Slides.Count > 0 && pres.Slides[0].Shapes.Count > 0)
                {
                    IShape shape = pres.Slides[0].Shapes[0];
                    IImage shapeImage = shape.GetImage();
                    shapeImage.Save(outputImagePath, Aspose.Slides.ImageFormat.Png);
                }
                else
                {
                    Console.WriteLine("No shape found in the first slide.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to extract shape thumbnail: " + ex.Message);
            }

            // Save the presentation before exiting
            try
            {
                pres.Save(outputPresentationPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to save presentation: " + ex.Message);
            }
            finally
            {
                if (pres != null)
                {
                    pres.Dispose();
                }
            }
        }
    }
}