using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace SmartArtOpacityExample
{
    class Program
    {
        static void Main()
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Read the input file into a byte array
            byte[] inputBytes = File.ReadAllBytes(inputPath);

            // Load the presentation from a memory stream
            using (MemoryStream inputStream = new MemoryStream(inputBytes))
            using (Presentation presentation = new Presentation(inputStream))
            {
                // Access the first slide
                ISlide slide = presentation.Slides[0];

                // Find the first SmartArt shape on the slide
                SmartArt smartArt = null;
                foreach (IShape shape in slide.Shapes)
                {
                    if (shape is SmartArt)
                    {
                        smartArt = (SmartArt)shape;
                        break;
                    }
                }

                if (smartArt == null)
                {
                    Console.WriteLine("No SmartArt found on the first slide.");
                    return;
                }

                // Modify the fill opacity of the first node's shapes
                ISmartArtNode node = smartArt.AllNodes[0];
                foreach (ISmartArtShape nodeShape in node.Shapes)
                {
                    // Set fill type to solid
                    nodeShape.FillFormat.FillType = FillType.Solid;

                    // Set fill color with desired opacity (e.g., 50% transparent red)
                    nodeShape.FillFormat.SolidFillColor.Color = Color.FromArgb(128, Color.Red);
                }

                // Save the modified presentation back to a memory stream
                using (MemoryStream outputStream = new MemoryStream())
                {
                    presentation.Save(outputStream, SaveFormat.Pptx);

                    // Write the output stream to a file
                    File.WriteAllBytes(outputPath, outputStream.ToArray());
                }

                // Ensure the presentation is saved before exiting
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
    }
}