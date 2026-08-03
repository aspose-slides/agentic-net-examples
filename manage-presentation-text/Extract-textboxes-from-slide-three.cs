// -----------------------------------------------------------------------------
// Example: Extract textboxes from slide three using C#
//
// Description:
// Demonstrates how to extract all textboxes from the third slide of a PowerPoint
// presentation using C# and Aspose.Slides for .NET. The example loads an input
// PPTX file, checks for the presence of a third slide, retrieves every text
// frame on that slide, outputs the contained text to the console, and finally
// saves the (unchanged) presentation to an output file. This pattern can be
// used to automate PPTX text extraction, validate slide content, or integrate
// presentation processing into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Extract, Textboxes, Slide,
// Three, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate extraction of textbox content from slide three.
// - Build C# utilities for PowerPoint presentation analysis.
// - Generate reports or perform validation on specific slides in PPTX files.
// - Integrate slide text extraction into larger .NET workflows or services.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Util;
using Aspose.Slides.Export;

namespace TextExtractionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "input.pptx");
            if (!System.IO.File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

                if (pres.Slides.Count < 3)
                {
                    Console.WriteLine("Presentation does not contain slide three.");
                }
                else
                {
                    Aspose.Slides.ITextFrame[] textFrames = Aspose.Slides.Util.SlideUtil.GetAllTextBoxes(pres.Slides[2]);
                    foreach (Aspose.Slides.ITextFrame textFrame in textFrames)
                    {
                        if (textFrame != null && !String.IsNullOrEmpty(textFrame.Text))
                        {
                            Console.WriteLine(textFrame.Text);
                        }
                    }
                }

                // Save the presentation before exiting
                string outputPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "output.pptx");
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // If the file format is not supported, an exception will be thrown.
                Console.WriteLine("Error processing presentation: " + ex.Message);
            }
        }
    }
}
