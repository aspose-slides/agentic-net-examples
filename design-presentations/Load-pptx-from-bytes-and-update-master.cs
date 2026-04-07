using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            try
            {
                // Read the presentation into a byte array
                byte[] inputBytes = File.ReadAllBytes(inputPath);

                // Process the presentation and obtain the modified byte array
                byte[] outputBytes = ProcessPresentation(inputBytes);

                // Write the modified presentation to the output file
                File.WriteAllBytes(outputPath, outputBytes);
                Console.WriteLine("Presentation processed and saved to: " + outputPath);
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException ex)
            {
                // Handle unsupported PPTX format
                Console.WriteLine("Unsupported PPTX format: " + ex.Message);
            }
            catch (Aspose.Slides.PptUnsupportedFormatException ex)
            {
                // Handle unsupported PPT format
                Console.WriteLine("Unsupported PPT format: " + ex.Message);
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        // Loads a presentation from a byte array, updates the master slide background,
        // and returns the modified presentation as a byte array.
        static byte[] ProcessPresentation(byte[] presentationBytes)
        {
            // Use a memory stream to load the presentation from the byte array
            using (MemoryStream inputStream = new MemoryStream(presentationBytes))
            {
                // Load the presentation
                using (Presentation pres = new Presentation(inputStream))
                {
                    // Ensure there is at least one master slide
                    if (pres.Masters.Count > 0)
                    {
                        // Update the background of the first master slide
                        pres.Masters[0].Background.Type = BackgroundType.OwnBackground;
                        pres.Masters[0].Background.FillFormat.FillType = FillType.Solid;
                        pres.Masters[0].Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;
                    }

                    // Save the modified presentation to a memory stream
                    using (MemoryStream outputStream = new MemoryStream())
                    {
                        pres.Save(outputStream, SaveFormat.Pptx);
                        // Return the byte array of the modified presentation
                        return outputStream.ToArray();
                    }
                }
            }
        }
    }
}