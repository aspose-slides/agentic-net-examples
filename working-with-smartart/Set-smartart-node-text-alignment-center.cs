// -----------------------------------------------------------------------------
// Example: Set smartart node text alignment center using C#
//
// Description:
// Demonstrates how to set the text alignment of all SmartArt nodes to center 
// using C# and Aspose.Slides for .NET. The example loads an existing PPTX file, 
// iterates through each SmartArt shape, updates the paragraph alignment of each 
// node's text frame to center, and saves the modified presentation. This pattern 
// can be used to automate text formatting within SmartArt diagrams in PowerPoint 
// files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, SmartArt, Node, Text, Alignment, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting SmartArt node text alignment to center across a presentation.
// - Build C# utilities for consistent SmartArt formatting in PPTX files.
// - Integrate SmartArt text alignment adjustments into .NET applications.
// - Validate and enforce presentation style guidelines before publishing.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main()
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Iterate through all slides
                    foreach (ISlide slide in pres.Slides)
                    {
                        // Iterate through all shapes on the slide
                        foreach (IShape shape in slide.Shapes)
                        {
                            // Cast shape to SmartArt if possible
                            SmartArt smartArt = shape as SmartArt;
                            if (smartArt != null)
                            {
                                // Iterate through all nodes in the SmartArt diagram
                                foreach (ISmartArtNode node in smartArt.AllNodes)
                                {
                                    // Get the first paragraph of the node's text frame
                                    IParagraph paragraph = node.TextFrame.Paragraphs[0];
                                    // Set paragraph alignment to center
                                    paragraph.ParagraphFormat.Alignment = TextAlignment.Center;
                                }
                            }
                        }
                    }

                    // Save the modified presentation
                    pres.Save(outputPath, SaveFormat.Pptx);
                }
            }
            // Handle unsupported file format exceptions
            catch (PptxUnsupportedFormatException)
            {
                // Format not supported
                Console.WriteLine("The presentation format is not supported (PPTX).");
            }
            catch (PptUnsupportedFormatException)
            {
                // Format not supported
                Console.WriteLine("The presentation format is not supported (PPT).");
            }
            // General exception handling
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
