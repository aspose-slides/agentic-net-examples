// -----------------------------------------------------------------------------
// Example: Save presentation to memory stream with saveoptions using C#
//
// Description:
// Demonstrates how to load a PPTX file, modify it by adding a rectangle shape 
// with text, and then save the presentation to a memory stream using 
// Aspose.Slides Export.PptxOptions to preserve text formatting. The example 
// also shows how to write the memory stream contents to an output file. This 
// standalone console application illustrates the essential steps for 
// presentation manipulation and memory‑based saving with Aspose.Slides for .NET.
//
// Keywords:
// C#, Aspose.Slides for .NET, PPTX, SaveFormat, PptxOptions, MemoryStream, 
// Shape, Rectangle, TextFrame, Presentation Processing, Office Automation
//
// Use Cases:
// - Modify a PowerPoint presentation programmatically and save it to memory.
// - Preserve text formatting while saving using specific save options.
// - Build .NET tools that process PPTX files without intermediate disk files.
// - Automate generation or transformation of presentations in memory.
// -----------------------------------------------------------------------------
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
            string inputPath = "input.pptx";
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found.");
                return;
            }

            try
            {
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Modify the presentation (add a rectangle with text)
                Aspose.Slides.ISlide slide = presentation.Slides[0];
                Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 200, 100);
                shape.TextFrame.Text = "Modified";

                // Prepare memory stream and save options to preserve text formatting
                MemoryStream memoryStream = new MemoryStream();
                Aspose.Slides.Export.PptxOptions pptxOptions = new Aspose.Slides.Export.PptxOptions();

                // Save to memory stream with options
                presentation.Save(memoryStream, Aspose.Slides.Export.SaveFormat.Pptx, pptxOptions);

                // Optionally write the memory stream to a file
                byte[] outputBytes = memoryStream.ToArray();
                File.WriteAllBytes("output.pptx", outputBytes);

                // Clean up
                memoryStream.Close();
                presentation.Dispose();
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The specified format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
