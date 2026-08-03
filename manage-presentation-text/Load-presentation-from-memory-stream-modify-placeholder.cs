// -----------------------------------------------------------------------------
// Example: Load presentation from memory stream modify placeholder using C#
//
// Description:
// Demonstrates how to load a PowerPoint presentation from a memory stream, 
// locate placeholder shapes on the first slide, and update their text using 
// Aspose.Slides for .NET. The example reads an existing PPTX file into a byte 
// array, creates a MemoryStream, modifies placeholder text, and saves the 
// updated presentation back to a file. This pattern is useful for in‑memory 
// processing of presentations without direct file system manipulation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Load, Presentation, Memory, 
// Stream, Placeholder, Text Modification, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate loading a presentation from a memory stream and updating placeholder text.
// - Build C# tools that modify PPTX content in-memory for web services or APIs.
// - Generate or transform PPTX files dynamically in .NET applications.
// - Validate and test presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            byte[] fileBytes = File.ReadAllBytes(inputPath);
            MemoryStream memoryStream = new MemoryStream(fileBytes);
            try
            {
                Presentation presentation = new Presentation(memoryStream);
                ISlide slide = presentation.Slides[0];
                foreach (IShape shape in slide.Shapes)
                {
                    if (shape.Placeholder != null && shape is IAutoShape)
                    {
                        ((IAutoShape)shape).TextFrame.Text = "Updated Prompt";
                    }
                }

                memoryStream.Position = 0;
                presentation.Save(memoryStream, SaveFormat.Pptx);
                // Optionally write the modified presentation to a file
                File.WriteAllBytes("output.pptx", memoryStream.ToArray());

                presentation.Dispose();
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }
            finally
            {
                memoryStream.Close();
            }
        }
    }
}
