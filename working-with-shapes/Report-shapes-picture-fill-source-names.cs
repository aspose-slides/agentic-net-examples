// -----------------------------------------------------------------------------
// Example: Report shapes picture fill source names using C#
//
// Description:
// Demonstrates how to report shapes picture fill source names using C# and 
// Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Report, Shapes, Picture, Fill, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate report shapes picture fill source names.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesReport
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define paths
            string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            string inputPath = Path.Combine(dataDir, "input.pptx");
            string reportPath = Path.Combine(dataDir, "PictureFillReport.txt");
            string outputPath = Path.Combine(dataDir, "output.pptx");

            // Ensure data directory exists
            if (!Directory.Exists(dataDir))
            {
                Directory.CreateDirectory(dataDir);
            }

            // Check if input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Prepare report lines
                    string[] reportLines = new string[pres.Slides.Count * 10];
                    int lineIndex = 0;

                    // Iterate through slides
                    for (int slideIdx = 0; slideIdx < pres.Slides.Count; slideIdx++)
                    {
                        ISlide slide = pres.Slides[slideIdx];
                        // Iterate through shapes
                        for (int shapeIdx = 0; shapeIdx < slide.Shapes.Count; shapeIdx++)
                        {
                            IShape shape = slide.Shapes[shapeIdx];
                            // Check if shape has a picture fill
                            if (shape.FillFormat != null && shape.FillFormat.FillType == FillType.Picture)
                            {
                                IPictureFillFormat picFill = shape.FillFormat.PictureFillFormat;
                                if (picFill != null && picFill.Picture != null && picFill.Picture.Image != null)
                                {
                                    IPPImage img = picFill.Picture.Image;
                                    // Find image index in the presentation's image collection
                                    int imageIndex = -1;
                                    for (int imgIdx = 0; imgIdx < pres.Images.Count; imgIdx++)
                                    {
                                        if (pres.Images[imgIdx] == img)
                                        {
                                            imageIndex = imgIdx;
                                            break;
                                        }
                                    }

                                    string shapeInfo = $"Slide {slideIdx + 1}, Shape {shapeIdx + 1} ('{shape.Name}') uses picture fill. Image index: {imageIndex}";
                                    reportLines[lineIndex++] = shapeInfo;
                                }
                            }
                        }
                    }

                    // Trim the array to actual size
                    string[] finalReport = new string[lineIndex];
                    Array.Copy(reportLines, finalReport, lineIndex);
                    File.WriteAllLines(reportPath, finalReport);

                    // Save presentation (no modifications made, but required by rules)
                    pres.Save(outputPath, SaveFormat.Pptx);
                }

                Console.WriteLine("Report generated at: " + reportPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The provided file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
