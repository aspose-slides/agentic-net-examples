using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path
            string inputPath = "input.pptx";
            // Output presentation path
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Iterate through all master slides
                    for (int i = 0; i < pres.Masters.Count; i++)
                    {
                        IMasterSlide masterSlide = pres.Masters[i];

                        // Iterate through all shapes on the master slide
                        for (int j = 0; j < masterSlide.Shapes.Count; j++)
                        {
                            IShape shape = masterSlide.Shapes[j];

                            // Check if the shape has a line format
                            if (shape.LineFormat != null)
                            {
                                // Set the line dash style to DashDot
                                shape.LineFormat.DashStyle = Aspose.Slides.LineDashStyle.DashDot;
                            }
                        }
                    }

                    // Save the modified presentation
                    pres.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException)
            {
                // Handle unsupported PPTX format
                Console.WriteLine("The file format is not supported (PPTX).");
            }
            catch (Aspose.Slides.PptUnsupportedFormatException)
            {
                // Handle unsupported PPT format
                Console.WriteLine("The file format is not supported (PPT).");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}