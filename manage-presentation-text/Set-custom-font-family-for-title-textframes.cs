// -----------------------------------------------------------------------------
// Example: Set custom font family for title textframes using C#
//
// Description:
// Demonstrates how to set a custom font family for title textframes in a PowerPoint
// presentation using Aspose.Slides for .NET. The example updates the master theme
// font scheme and explicitly applies the font to each title placeholder shape,
// then saves the modified presentation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Custom Font, Font Family, Title,
// TextFrames, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting a custom font family for title textframes across slides.
// - Build .NET tools for PowerPoint presentation styling.
// - Generate or transform PPTX files with consistent title fonts.
// - Validate and enforce branding guidelines in presentation workflows.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides.Export;
using Aspose.Slides.Theme;

class Program
{
    static void Main()
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
                // Set custom font for title placeholders via the master theme
                Aspose.Slides.Theme.IFontScheme fontScheme = presentation.MasterTheme.FontScheme;
                fontScheme.Major.LatinFont = new Aspose.Slides.FontData("Arial Black");

                // Ensure each title shape explicitly uses the new font
                foreach (Aspose.Slides.ISlide slide in presentation.Slides)
                {
                    foreach (Aspose.Slides.IShape shape in slide.Shapes)
                    {
                        Aspose.Slides.IAutoShape autoShape = shape as Aspose.Slides.IAutoShape;
                        if (autoShape != null && autoShape.TextFrame != null && autoShape.Placeholder != null && autoShape.Placeholder.Type == Aspose.Slides.PlaceholderType.Title)
                        {
                            foreach (Aspose.Slides.IParagraph paragraph in autoShape.TextFrame.Paragraphs)
                            {
                                foreach (Aspose.Slides.IPortion portion in paragraph.Portions)
                                {
                                    portion.PortionFormat.LatinFont = new Aspose.Slides.FontData("Arial Black");
                                }
                            }
                        }
                    }
                }

                // Save the presentation before exit
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Handle unsupported format exception
            // Format not supported
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
