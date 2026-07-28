// -----------------------------------------------------------------------------
// Example: Update hyperlink tooltip with slide number using C#
//
// Description:
// Demonstrates how to update the tooltip (ScreenTip) of all hyperlinks in a
// presentation to include the slide number using C# and Aspose.Slides for .NET.
// The example loads presentations, iterates through each slide and shape, updates
// hyperlink tooltips, and saves the modified files to an organized output folder.
// Developers can use this pattern to automate PPTX workflows, ensure consistent
// hyperlink information, or integrate presentation processing into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Update, Hyperlink, Tooltip, 
// Slide Number, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate updating hyperlink tooltips with slide numbers.
// - Build C# tools for PowerPoint presentation processing and quality checks.
// - Generate or transform PPTX files with consistent hyperlink metadata.
// - Validate and enhance presentation navigation before publishing.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input and output directories
        string inputDir = Path.Combine(Environment.CurrentDirectory, "InputPresentations");
        string outputBaseDir = Path.Combine(Environment.CurrentDirectory, "OrganizedPresentations");
        if (!Directory.Exists(outputBaseDir))
            Directory.CreateDirectory(outputBaseDir);

        // List of presentation files to process
        string[] presentationFiles = new string[]
        {
            Path.Combine(inputDir, "Pres1.pptx"),
            Path.Combine(inputDir, "Pres2.pptx")
        };

        foreach (string filePath in presentationFiles)
        {
            // Check if the file exists
            if (!File.Exists(filePath))
            {
                Console.WriteLine("File not found: " + filePath);
                continue;
            }

            try
            {
                // Load the presentation
                using (Presentation pres = new Presentation(filePath))
                {
                    // Update hyperlink tooltips with slide numbers
                    foreach (ISlide slide in pres.Slides)
                    {
                        foreach (IShape shape in slide.Shapes)
                        {
                            // Update shape-level hyperlink tooltip
                            if (shape.HyperlinkClick != null)
                            {
                                shape.HyperlinkClick.ScreenTip = $"Slide {slide.SlideNumber}";
                            }

                            // Update text portion hyperlinks tooltip
                            if (shape is IAutoShape autoShape && autoShape.TextFrame != null)
                            {
                                foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs)
                                {
                                    foreach (IPortion portion in paragraph.Portions)
                                    {
                                        if (portion.PortionFormat?.HyperlinkClick != null)
                                        {
                                            portion.PortionFormat.HyperlinkClick.ScreenTip = $"Slide {slide.SlideNumber}";
                                        }
                                    }
                                }
                            }
                        }
                    }

                    // Retrieve the Category property for organizing output
                    IDocumentProperties docProps = pres.DocumentProperties;
                    string category = docProps.Category;
                    if (string.IsNullOrEmpty(category))
                        category = "Uncategorized";

                    // Create target folder based on category
                    string targetDir = Path.Combine(outputBaseDir, category);
                    if (!Directory.Exists(targetDir))
                        Directory.CreateDirectory(targetDir);

                    // Define destination path
                    string fileName = Path.GetFileName(filePath);
                    string destPath = Path.Combine(targetDir, fileName);

                    // Save the updated presentation
                    pres.Save(destPath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Handle unsupported formats or other errors
                Console.WriteLine("Error processing file " + filePath + ": " + ex.Message);
            }
        }
    }
}
