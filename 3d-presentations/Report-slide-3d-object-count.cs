// -----------------------------------------------------------------------------
// Example: Generate report of 3D object count per slide in a PowerPoint file
//
// Description:
// This console application loads a PPTX file using Aspose.Slides for .NET,
// iterates through each slide, counts shapes that contain 3D formatting,
// and prints a report with slide numbers and 3D object counts. The program
// validates the input file existence, handles unsupported formats, and saves
// the presentation after processing.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, slide number, 3D objects, shape count
//
// Use Cases:
// - Auditing presentations for 3D content before publishing.
// - Generating analytics on slide composition for design reviews.
// - Automating compliance checks for slide standards.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

namespace AsposeSlides3DReport
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath;
            if (args.Length > 0)
            {
                inputPath = args[0];
            }
            else
            {
                inputPath = Path.Combine(Environment.CurrentDirectory, "input.pptx");
            }

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Error: Input file does not exist: " + inputPath);
                return;
            }

            Aspose.Slides.Presentation presentation = null;
            try
            {
                presentation = new Aspose.Slides.Presentation(inputPath);
            }
            catch (Exception ex)
            {
                // Format not supported or other loading error
                Console.WriteLine("Error loading presentation: " + ex.Message);
                return;
            }

            int slideCount = presentation.Slides.Count;
            for (int i = 0; i < slideCount; i++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[i];
                int threeDObjectCount = 0;

                foreach (Aspose.Slides.IShape shape in slide.Shapes)
                {
                    // Check if the shape has a 3D format defined
                    if (shape.ThreeDFormat != null)
                    {
                        // Simple heuristic: consider any shape with a non‑null ThreeDFormat as a 3D object
                        threeDObjectCount++;
                    }
                }

                Console.WriteLine($"Slide {i + 1}: {threeDObjectCount} 3D object(s)");
            }

            // Save the presentation (even if unchanged) to demonstrate proper cleanup
            string outputPath = Path.Combine(Path.GetDirectoryName(inputPath), "output.pptx");
            try
            {
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                Console.WriteLine("Presentation saved to: " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving presentation: " + ex.Message);
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
