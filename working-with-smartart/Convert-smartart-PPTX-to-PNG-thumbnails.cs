// -----------------------------------------------------------------------------
// Example: Convert smartart PPTX to PNG thumbnails using C#
//
// Description:
// Demonstrates how to convert smartart PPTX to PNG thumbnails using C# and 
// Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PNG, Convert, Smartart, Pptx, 
// Thumbnails, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate convert smartart PPTX to PNG thumbnails.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SmartArtThumbnailBatch
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input folder containing PPTX files
            string inputFolder = Path.Combine(Directory.GetCurrentDirectory(), "InputPptx");
            // Output folder for generated thumbnails
            string outputFolder = Path.Combine(Directory.GetCurrentDirectory(), "OutputThumbnails");

            // Verify input folder exists
            if (!Directory.Exists(inputFolder))
            {
                Console.WriteLine("Input folder does not exist: " + inputFolder);
                return;
            }

            // Ensure output folder exists
            if (!Directory.Exists(outputFolder))
            {
                Directory.CreateDirectory(outputFolder);
            }

            // Get all PPTX files in the input folder
            string[] pptxFiles = Directory.GetFiles(inputFolder, "*.pptx", SearchOption.TopDirectoryOnly);

            foreach (string pptxFile in pptxFiles)
            {
                try
                {
                    // Load presentation
                    using (Presentation presentation = new Presentation(pptxFile))
                    {
                        // Folder for thumbnails of this presentation
                        string presentationName = Path.GetFileNameWithoutExtension(pptxFile);
                        string presentationThumbFolder = Path.Combine(outputFolder, presentationName);
                        if (!Directory.Exists(presentationThumbFolder))
                        {
                            Directory.CreateDirectory(presentationThumbFolder);
                        }

                        // Iterate through slides
                        for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                        {
                            ISlide slide = presentation.Slides[slideIndex];

                            // Iterate through shapes on the slide
                            foreach (IShape shape in slide.Shapes)
                            {
                                // Check if the shape is a SmartArt diagram
                                if (shape is Aspose.Slides.SmartArt.ISmartArt)
                                {
                                    // Cast to SmartArt
                                    Aspose.Slides.SmartArt.ISmartArt smartArt = (Aspose.Slides.SmartArt.ISmartArt)shape;

                                    // Export SmartArt thumbnail using GetImage inside a using block
                                    using (IImage image = shape.GetImage())
                                    {
                                        string imageFileName = string.Format("Slide{0}_Shape{1}.png", slide.SlideNumber, shape.Name);
                                        string imagePath = Path.Combine(presentationThumbFolder, imageFileName);
                                        image.Save(imagePath, Aspose.Slides.ImageFormat.Png);
                                    }
                                }
                            }
                        }

                        // Save the presentation (even if unchanged) before exiting
                        string savedPresentationPath = Path.Combine(outputFolder, presentationName + "_saved.pptx");
                        presentation.Save(savedPresentationPath, SaveFormat.Pptx);
                    }
                }
                catch (NotSupportedException)
                {
                    // Format not supported comment
                    Console.WriteLine("File format not supported: " + pptxFile);
                }
                catch (Exception ex)
                {
                    // General exception handling (e.g., file access issues)
                    Console.WriteLine("Error processing file: " + pptxFile);
                    Console.WriteLine("Exception: " + ex.Message);
                }
            }

            Console.WriteLine("Processing completed.");
        }
    }
}
