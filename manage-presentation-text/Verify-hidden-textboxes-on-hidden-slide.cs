// -----------------------------------------------------------------------------
// Example: Verify hidden textboxes on hidden slide using C#
//
// Description:
// Demonstrates how to verify hidden textboxes on hidden slide using C# and 
// Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Verify, Hidden, Textboxes, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate verify hidden textboxes on hidden slide.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

class Program
{
    static void Main()
    {
        string filePath = "sample.pptx";
        if (!File.Exists(filePath))
        {
            Console.WriteLine("File does not exist: " + filePath);
            return;
        }

        try
        {
            using (Presentation presentation = new Presentation(filePath))
            {
                foreach (ISlide slide in presentation.Slides)
                {
                    if (slide.Hidden)
                    {
                        ITextFrame[] textFrames = SlideUtil.GetAllTextBoxes(slide);
                        Console.WriteLine("Hidden slide index " + slide.SlideNumber + " contains " + textFrames.Length + " text boxes.");
                    }
                }

                // Save the presentation before exiting
                presentation.Save("output.pptx", SaveFormat.Pptx);
            }
        }
        catch (Aspose.Slides.PptxUnsupportedFormatException)
        {
            // Format not supported
            Console.WriteLine("The file format is not supported.");
        }
        catch (Aspose.Slides.PptUnsupportedFormatException)
        {
            // Format not supported
            Console.WriteLine("The file format is not supported.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
