// -----------------------------------------------------------------------------
// Example: Load PowerPoint and Handle Corrupted 3D Data Exceptions
//
// Description:
// This console application demonstrates how to open a PPTX file using
// Aspose.Slides for .NET, iterate through its slides and shapes, and safely
// access 3D format data. It includes checks for file existence and robust
// exception handling for unsupported formats and corrupted 3D data.
// The presentation is saved after processing.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, corrupted 3D data, exception handling
//
// Use Cases:
// - Validate and repair presentations that contain broken 3D objects.
// - Automate batch processing of PPTX files while skipping corrupted content.
// - Integrate into a larger workflow that extracts or modifies slide visuals.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

namespace AsposeSlides3DExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string inputPath;
            if (args != null && args.Length > 0 && !string.IsNullOrWhiteSpace(args[0]))
            {
                inputPath = args[0];
            }
            else
            {
                inputPath = "input.pptx";
            }

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            Aspose.Slides.Presentation presentation = null;
            try
            {
                presentation = new Aspose.Slides.Presentation(inputPath);
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException ex)
            {
                Console.WriteLine("The file format is not supported (PPTX): " + ex.Message);
                // Format not supported – cannot continue.
                return;
            }
            catch (Aspose.Slides.PptUnsupportedFormatException ex)
            {
                Console.WriteLine("The file format is not supported (PPT): " + ex.Message);
                // Format not supported – cannot continue.
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to load presentation: " + ex.Message);
                return;
            }

            try
            {
                foreach (Aspose.Slides.ISlide slide in presentation.Slides)
                {
                    foreach (Aspose.Slides.IShape shape in slide.Shapes)
                    {
                        // Attempt to access 3D format data; this may throw if data is corrupted.
                        try
                        {
                            Aspose.Slides.IThreeDFormat threeD = shape.ThreeDFormat;
                            // Example: read depth property (if available)
                            double depth = threeD.Depth;
                            // No further action needed for this example.
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Corrupted 3D data in shape ID {shape.Name}: {ex.Message}");
                            // Continue processing other shapes.
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while processing slides: " + ex.Message);
            }

            string outputPath = "output.pptx";
            try
            {
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                Console.WriteLine("Presentation saved successfully to " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to save presentation: " + ex.Message);
            }
            finally
            {
                if (presentation != null)
                {
                    presentation.Dispose();
                }
            }
        }
    }
}
