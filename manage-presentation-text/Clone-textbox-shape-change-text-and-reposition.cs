// -----------------------------------------------------------------------------
// Example: Clone textbox shape change text and reposition using C#
//
// Description:
// Demonstrates how to clone a textbox shape, modify its text, and reposition it
// within a slide using C# and Aspose.Slides for .NET. The example loads an
// existing presentation, locates the first textbox, creates a clone at new
// coordinates, updates the cloned shape's text, and saves the result as a new
// PPTX file. This pattern can be used to automate PowerPoint content updates
// and layout adjustments.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Clone, Textbox, Shape, Change,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate cloning of textbox shapes with updated content.
// - Build tools for repositioning and editing shapes in PowerPoint files.
// - Generate or transform PPTX presentations programmatically in .NET.
// - Validate and test presentation workflows before deployment.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesCloneTextbox
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Get the first slide
                    ISlide slide = presentation.Slides[0];

                    // Find the first textbox shape on the slide
                    IAutoShape sourceShape = null;
                    foreach (IShape shape in slide.Shapes)
                    {
                        IAutoShape autoShape = shape as IAutoShape;
                        if (autoShape != null && autoShape.IsTextBox)
                        {
                            sourceShape = autoShape;
                            break;
                        }
                    }

                    if (sourceShape == null)
                    {
                        Console.WriteLine("No textbox shape found on the slide.");
                        return;
                    }

                    // Clone the textbox shape and position it at new coordinates (e.g., 200, 150)
                    IShape clonedShape = slide.Shapes.AddClone(sourceShape, 200, 150);

                    // Change the text of the cloned shape
                    IAutoShape clonedAutoShape = clonedShape as IAutoShape;
                    if (clonedAutoShape != null && clonedAutoShape.TextFrame != null)
                    {
                        clonedAutoShape.TextFrame.Text = "Cloned and Updated Text";
                    }

                    // Save the presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException)
            {
                // Format not supported
                Console.WriteLine("The presentation format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
