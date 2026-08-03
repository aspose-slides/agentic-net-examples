// -----------------------------------------------------------------------------
// Example: Set superscript formatting for chemical formula using C#
//
// Description:
// Demonstrates how to set superscript formatting for a chemical formula using C#
// and Aspose.Slides for .NET. The example creates a new presentation, adds a
// rectangle shape with a text frame, and formats the superscript portion of the
// formula (e.g., the charge symbol) using the Escapement property. The resulting
// PPTX file is saved and opened, illustrating a typical workflow for
// presentation automation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Superscript, Formatting,
// Chemical, Formula, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate superscript formatting for chemical formulas in PowerPoint slides.
// - Build C# utilities for creating or editing PPTX files with specialized text
//   styling.
// - Integrate chemical notation handling into .NET presentation generation
//   pipelines.
// - Validate and preview formatted chemical content before distribution.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SuperscriptExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle shape with a text frame
            Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle, 100, 100, 400, 100);

            // Get the text frame and clear any existing paragraphs
            Aspose.Slides.ITextFrame textFrame = shape.TextFrame;
            textFrame.Paragraphs.Clear();

            // Create a paragraph for the chemical formula with superscript
            Aspose.Slides.IParagraph formulaParagraph = new Aspose.Slides.Paragraph();

            // Base portion (e.g., "Na")
            Aspose.Slides.IPortion basePortion = new Aspose.Slides.Portion();
            basePortion.Text = "Na";
            formulaParagraph.Portions.Add(basePortion);

            // Superscript portion (e.g., "+")
            Aspose.Slides.IPortion superscriptPortion = new Aspose.Slides.Portion();
            superscriptPortion.PortionFormat.Escapement = 100; // 100% superscript
            superscriptPortion.Text = "+";
            formulaParagraph.Portions.Add(superscriptPortion);

            // Add the paragraph to the text frame
            textFrame.Paragraphs.Add(formulaParagraph);

            // Define output path
            string outPath = "SuperscriptChemicalFormula.pptx";

            try
            {
                // Save the presentation
                presentation.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle format not supported or other save errors
                // Format not supported
                Console.WriteLine("Error saving presentation: " + ex.Message);
            }

            // Dispose the presentation
            presentation.Dispose();

            // Open the saved file
            if (File.Exists(outPath))
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(outPath) { UseShellExecute = true });
            }
        }
    }
}
