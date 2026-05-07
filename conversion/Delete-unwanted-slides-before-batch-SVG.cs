using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation file
            string inputPath = "input.pptx";
            // Output presentation after slide removal
            string outputPath = "output.pptx";
            // Folder to store exported SVG files
            string svgOutputFolder = "SvgSlides";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Ensure the SVG output folder exists
            if (!Directory.Exists(svgOutputFolder))
            {
                Directory.CreateDirectory(svgOutputFolder);
            }

            try
            {
                // Load the presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Example: remove unwanted slides by index (remove higher indices first)
                    if (presentation.Slides.Count > 2)
                    {
                        presentation.Slides.RemoveAt(2);
                    }
                    if (presentation.Slides.Count > 0)
                    {
                        presentation.Slides.RemoveAt(0);
                    }

                    // Export remaining slides to SVG
                    for (int i = 0; i < presentation.Slides.Count; i++)
                    {
                        Aspose.Slides.ISlide slide = presentation.Slides[i];
                        string svgFilePath = Path.Combine(svgOutputFolder, "slide_" + (i + 1) + ".svg");
                        using (FileStream svgStream = new FileStream(svgFilePath, FileMode.Create, FileAccess.Write))
                        {
                            slide.WriteAsSvg(svgStream);
                        }
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
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
            catch (NotSupportedException ex)
            {
                // Handle other not supported operations
                Console.WriteLine("Operation not supported: " + ex.Message);
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}