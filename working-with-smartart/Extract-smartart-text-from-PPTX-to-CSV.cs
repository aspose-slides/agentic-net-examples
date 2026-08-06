// -----------------------------------------------------------------------------
// Example: Extract smartart text from pptx to csv using C#
//
// Description:
// Demonstrates how to extract SmartArt text from PPTX files to a CSV file using
// C# and Aspose.Slides for .NET. The example loads each presentation in an
// input folder, iterates through its slides and SmartArt shapes, extracts the
// text from each SmartArt node, and writes the results to a CSV file. This
// pattern can be used to automate PowerPoint content analysis, generate reports,
// or integrate SmartArt processing into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Extract, SmartArt, Text, CSV,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate extraction of SmartArt text from multiple PPTX files.
// - Build C# tools for analyzing or reporting on PowerPoint presentations.
// - Integrate SmartArt content extraction into larger .NET workflows.
// - Validate SmartArt data before publishing or further processing.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace SmartArtExtractor
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input directory containing presentations
            string inputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Input");
            // Define output CSV file path
            string outputCsvPath = Path.Combine(Directory.GetCurrentDirectory(), "SmartArtText.csv");

            // Ensure input directory exists
            if (!Directory.Exists(inputDirectory))
            {
                Console.WriteLine("Input directory does not exist: " + inputDirectory);
                return;
            }

            // Create CSV file and write header
            using (StreamWriter csvWriter = new StreamWriter(outputCsvPath, false))
            {
                csvWriter.WriteLine("Presentation,SlideIndex,SmartArtText");

                // Process each file in the input directory
                string[] presentationFiles = Directory.GetFiles(inputDirectory);
                foreach (string filePath in presentationFiles)
                {
                    // Verify file existence
                    if (!File.Exists(filePath))
                    {
                        continue;
                    }

                    try
                    {
                        // Load presentation
                        Presentation presentation = new Presentation(filePath);

                        // Iterate through slides
                        for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                        {
                            ISlide slide = presentation.Slides[slideIndex];

                            // Iterate through shapes on the slide
                            foreach (IShape shape in slide.Shapes)
                            {
                                // Check if shape is SmartArt
                                if (shape is ISmartArt)
                                {
                                    ISmartArt smartArt = (ISmartArt)shape;
                                    ISmartArtNodeCollection nodes = smartArt.AllNodes;

                                    // Iterate through SmartArt nodes
                                    foreach (ISmartArtNode node in nodes)
                                    {
                                        // Iterate through shapes within each node
                                        foreach (ISmartArtShape nodeShape in node.Shapes)
                                        {
                                            // Extract text if TextFrame is present
                                            if (nodeShape.TextFrame != null)
                                            {
                                                string text = nodeShape.TextFrame.Text;
                                                csvWriter.WriteLine($"{Path.GetFileName(filePath)},{slideIndex},{text}");
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        // Save presentation before exiting (preserve original format as PPTX)
                        presentation.Save(filePath, SaveFormat.Pptx);
                        presentation.Dispose();
                    }
                    catch (Exception ex)
                    {
                        // Handle unsupported format or other errors
                        // Format not supported
                        Console.WriteLine($"Error processing file '{filePath}': {ex.Message}");
                    }
                }
            }

            Console.WriteLine("SmartArt text extraction completed. Results saved to: " + outputCsvPath);
        }
    }
}
