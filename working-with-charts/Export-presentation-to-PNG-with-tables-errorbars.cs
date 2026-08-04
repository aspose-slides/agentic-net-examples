// -----------------------------------------------------------------------------
// Example: Export presentation to PNG with tables and errorbars using C#
//
// Description:
// Demonstrates how to export each slide of a PowerPoint presentation to PNG
// images while preserving tables and error bars. The example loads an existing
// PPTX file, iterates through its slides, saves each slide as a PNG file, and
// finally saves the presentation back to disk. This pattern can be used in
// console applications to automate PPTX processing, verify visual elements,
// or generate image assets from presentations.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PNG, Export, Presentation,
// Tables, Errorbars, Charts, Image Conversion, Office Automation
//
// Use Cases:
// - Automate conversion of PPTX slides to PNG for documentation or web use.
// - Validate that tables and error bars render correctly after processing.
// - Build .NET tools that generate image assets from PowerPoint files.
// - Integrate slide‑to‑image conversion into larger presentation workflows.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExportPresentationToPng
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFile = "input.pptx";

            if (!File.Exists(inputFile))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputFile))
                {
                    // Export each slide as PNG to verify tables and error bars
                    for (int index = 0; index < presentation.Slides.Count; index++)
                    {
                        Aspose.Slides.IImage slideImage = presentation.Slides[index].GetImage();
                        string outputFile = $"slide_{index + 1}.png";
                        slideImage.Save(outputFile, Aspose.Slides.ImageFormat.Png);
                    }

                    // Save the presentation before exiting
                    string savedPresentation = "output_saved.pptx";
                    presentation.Save(savedPresentation, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException ex)
            {
                // Format not supported
                Console.WriteLine("Unsupported file format: " + ex.Message);
            }
            catch (Aspose.Slides.PptUnsupportedFormatException ex)
            {
                // Format not supported
                Console.WriteLine("Unsupported file format: " + ex.Message);
            }
            catch (Exception ex)
            {
                // General error handling
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
