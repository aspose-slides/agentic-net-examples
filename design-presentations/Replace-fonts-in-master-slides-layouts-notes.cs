// -----------------------------------------------------------------------------
// Example: Replace fonts in master slide layouts notes using C#
//
// Description:
// Demonstrates how to replace a specific font used in the notes of master slide
// layouts with another font using Aspose.Slides for .NET. The example loads a
// presentation, iterates through each master slide, accesses its layout slides,
// and updates the font in any associated notes slide. The modified presentation
// is then saved as a new PPTX file. This pattern helps developers automate
// font‑standardisation tasks for master slide notes in PowerPoint files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Replace Font, Master Slides,
// Layout Slides, Notes Slide, Presentation Processing, Office Automation
//
// Use Cases:
// - Standardise fonts in notes of master slide layouts across a presentation.
// - Build C# utilities for PowerPoint master slide maintenance.
// - Automate font migration in corporate slide templates.
// - Validate and enforce branding guidelines in PPTX files before distribution.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        var inputPath = "input.pptx";
        var outputPath = "output.pptx";

        if (!System.IO.File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            using (var presentation = new Presentation(inputPath))
            {
                string sourceFontName = "Arial";
                string destFontName = "Calibri";

                // Iterate through each master slide
                foreach (IMasterSlide master in presentation.Masters)
                {
                    // Iterate through each layout slide within the master
                    foreach (ILayoutSlide layout in master.LayoutSlides)
                    {
                        // Access the notes slide of the layout (if it exists)
                        INotesSlide notes = layout.NotesSlide;
                        if (notes?.TextFrame == null)
                            continue;

                        // Replace the font in all portions of all paragraphs
                        foreach (IParagraph paragraph in notes.TextFrame.Paragraphs)
                        {
                            foreach (IPortion portion in paragraph.Portions)
                            {
                                // Check if the portion uses the source font
                                if (portion.PortionFormat?.LatinFont?.FontName == sourceFontName)
                                {
                                    portion.PortionFormat.LatinFont = new FontData(destFontName);
                                }
                            }
                        }
                    }
                }

                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
