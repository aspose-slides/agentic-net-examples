// -----------------------------------------------------------------------------
// Example: Batch update placeholder text across slides using C#
//
// Description:
// Demonstrates how to batch update placeholder text across slides using C# and 
// Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Batch, Update, Placeholder, 
// Text, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate batch update placeholder text across slides.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                int slideCount = presentation.Slides.Count;
                for (int i = 0; i < slideCount; i++)
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[i];
                    foreach (Aspose.Slides.IShape shape in slide.Shapes)
                    {
                        if (shape.Placeholder != null && shape is Aspose.Slides.IAutoShape)
                        {
                            ((Aspose.Slides.IAutoShape)shape).TextFrame.Text = "Updated Placeholder";
                        }
                    }
                }

                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
