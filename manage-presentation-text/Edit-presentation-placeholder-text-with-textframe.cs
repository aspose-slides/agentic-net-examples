// -----------------------------------------------------------------------------
// Example: Edit presentation placeholder text with textframe using C#
//
// Description:
// Demonstrates how to edit placeholder text in a PowerPoint presentation by
// accessing the TextFrame of placeholder shapes using Aspose.Slides for .NET.
// The example loads an existing PPTX file, modifies the text of all placeholder
// auto‑shapes on the first slide, and saves the result as a new PPTX file.
// This pattern can be used to automate placeholder content updates in .NET
// applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Edit, Presentation, Placeholder,
// TextFrame, Text, Presentation Processing, Office Automation
//
// Use Cases:
// - Programmatically update placeholder text in existing presentations.
// - Build tools that customize slide templates before distribution.
// - Integrate placeholder text replacement into automated PPTX workflows.
// - Validate and modify slide content in .NET applications.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
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

        try
        {
            // Load the presentation from the file
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Iterate through shapes to find placeholders and modify their text
            foreach (Aspose.Slides.IShape shape in slide.Shapes)
            {
                if (shape.Placeholder != null && shape is Aspose.Slides.IAutoShape)
                {
                    ((Aspose.Slides.IAutoShape)shape).TextFrame.Text = "Modified Placeholder Text";
                }
            }

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            // Format not supported
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
