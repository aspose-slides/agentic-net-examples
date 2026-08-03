// -----------------------------------------------------------------------------
// Example: Generate table of contents from slide titles using C#
//
// Description:
// Demonstrates how to generate a table of contents slide by extracting
// titles from existing slides using Aspose.Slides for .NET. The example
// loads a presentation, collects CenteredTitle placeholder text, creates a
// new slide, inserts a rectangle shape with the compiled TOC, and saves the
// result. This pattern can be used to automate PPTX workflows, add navigation
// aids, or prepare presentations programmatically.
//
// Keywords:
// C#, Aspose.Slides for .NET, PPTX, PowerPoint, Table of Contents, Slide Titles,
// Presentation Processing, Automation, Office Automation
//
// Use Cases:
// - Automatically create a TOC slide for existing presentations.
// - Build .NET tools that analyze and augment PowerPoint files.
// - Generate navigation aids for large slide decks.
// - Validate and transform PPTX content in batch processes.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

namespace GenerateTableOfContents
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output_with_toc.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Load the presentation inside a using block to ensure proper disposal
            try
            {
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Collect slide titles from placeholders of type CenteredTitle
                    List<string> slideTitles = new List<string>();
                    for (int i = 0; i < presentation.Slides.Count; i++)
                    {
                        ISlide slide = presentation.Slides[i];
                        // Find all shapes that are CenteredTitle placeholders
                        IShape[] titlePlaceholders = SlideUtil.FindShapesByPlaceholderType(slide, PlaceholderType.CenteredTitle);
                        foreach (IShape shape in titlePlaceholders)
                        {
                            if (shape is IAutoShape)
                            {
                                IAutoShape autoShape = (IAutoShape)shape;
                                string titleText = autoShape.TextFrame.Text;
                                if (!string.IsNullOrEmpty(titleText))
                                {
                                    slideTitles.Add(titleText);
                                }
                            }
                        }
                    }

                    // Create a new slide for the Table of Contents using the first layout slide
                    ILayoutSlide layoutSlide = presentation.LayoutSlides[0];
                    ISlide tocSlide = presentation.Slides.AddEmptySlide(layoutSlide);

                    // Add a rectangle shape that will hold the TOC text
                    IAutoShape tocShape = (IAutoShape)tocSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 600, 400);
                    // Build the TOC content (each title on a new line)
                    string tocContent = "Table of Contents\n\n";
                    for (int index = 0; index < slideTitles.Count; index++)
                    {
                        tocContent += (index + 1).ToString() + ". " + slideTitles[index] + "\n";
                    }
                    // Add a text frame with the TOC content
                    tocShape.AddTextFrame(tocContent);

                    // Save the modified presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions such as unsupported format or loading errors
                Console.WriteLine("An error occurred: " + ex.Message);
                // If the exception is due to an unsupported format, you could add a comment here
                // Format not supported.
            }
        }
    }
}
