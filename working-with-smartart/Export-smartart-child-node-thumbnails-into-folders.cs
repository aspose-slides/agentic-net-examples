using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace SmartArtThumbnailGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFile = "input.pptx";
            string outputFile = "output.pptx";

            if (!File.Exists(inputFile))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                // Load presentation (creation rule)
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputFile);

                // Add a SmartArt diagram to the first slide (custom-child-nodes-in-smart-art rule)
                Aspose.Slides.SmartArt.ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
                    20f, 20f, 600f, 500f, Aspose.Slides.SmartArt.SmartArtLayoutType.OrganizationChart);

                // Iterate through all nodes in the SmartArt
                foreach (Aspose.Slides.SmartArt.ISmartArtNode node in smartArt.AllNodes)
                {
                    // Iterate through all shapes associated with the node
                    foreach (Aspose.Slides.SmartArt.ISmartArtShape shape in node.Shapes)
                    {
                        // Generate thumbnails for the shape at three predefined sizes
                        GenerateThumbnails(shape, node.Position);
                    }
                }

                // Save presentation before exit (save rule)
                presentation.Save(outputFile, Aspose.Slides.Export.SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling (including possible web service errors)
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        static void GenerateThumbnails(Aspose.Slides.SmartArt.ISmartArtShape shape, int nodeIndex)
        {
            // Define scaling factors for small, medium, and large thumbnails
            float[] scales = new float[] { 0.5f, 1.0f, 2.0f };
            string[] sizeNames = new string[] { "Small", "Medium", "Large" };

            for (int i = 0; i < scales.Length; i++)
            {
                // Create directory for each size if it does not exist
                string folderPath = Path.Combine("Thumbnails", sizeNames[i]);
                Directory.CreateDirectory(folderPath);

                // Generate thumbnail image using shape.GetImage with scaling (compiler-fix rule applied)
                using (Aspose.Slides.IImage image = shape.GetImage(
                    Aspose.Slides.ShapeThumbnailBounds.Shape, scales[i], scales[i]))
                {
                    // Save the image as PNG using fully qualified ImageFormat
                    string fileName = "Node_" + nodeIndex + ".png";
                    string filePath = Path.Combine(folderPath, fileName);
                    image.Save(filePath, Aspose.Slides.ImageFormat.Png);
                }
            }
        }
    }
}