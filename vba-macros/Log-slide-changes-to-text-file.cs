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
                        // Example: log placeholder title if present
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