// -----------------------------------------------------------------------------
// Example: Log slide indices and shape text to a text file using C#
//
// Description:
// Demonstrates how to iterate through all slides in a PowerPoint presentation,
// record each slide index and any text contained in AutoShape shapes, and write
// this information to a plain‑text log file. The example also shows how to load
// a presentation, optionally save it, and handle common errors using Aspose.Slides
// for .NET in a console application.
//
// Keywords:
// C#, Aspose.Slides for .NET, PowerPoint, PPTX, slide index, shape text, logging,
// text file, presentation processing, automation
//
// Use Cases:
// - Create audit logs of slide content for review or compliance.
// - Build utilities that extract slide metadata and text.
// - Automate documentation of presentation structure in .NET projects.
// - Validate or debug slide contents during PPTX processing workflows.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideChangeLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";
            string logPath = "slide_changes.log";

            // Check if the input presentation exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Open a log file for writing slide change information
                using (StreamWriter logWriter = new StreamWriter(logPath, false))
                {
                    // Iterate through slides and log their indices
                    for (int i = 0; i < presentation.Slides.Count; i++)
                    {
                        Aspose.Slides.ISlide slide = presentation.Slides[i];
                        logWriter.WriteLine("Slide index accessed: " + i);
                        // Log text of any AutoShape shapes on the slide
                        foreach (Aspose.Slides.IShape shape in slide.Shapes)
                        {
                            if (shape is Aspose.Slides.IAutoShape autoShape && autoShape.TextFrame != null)
                            {
                                string text = autoShape.TextFrame.Text;
                                if (!string.IsNullOrEmpty(text))
                                {
                                    logWriter.WriteLine("  Shape text: " + text);
                                }
                            }
                        }
                    }
                }

                // Save the presentation (even if unchanged) before exiting
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The provided file format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., external URLs or web services)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
