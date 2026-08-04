// -----------------------------------------------------------------------------
// Example: Export all charts to zip PNG using C#
//
// Description:
// Demonstrates how to export all charts from a PowerPoint presentation into a
// ZIP archive containing PNG images using C# and Aspose.Slides for .NET.
// The example loads a presentation, iterates through its slides and chart
// shapes, renders each chart as a PNG image, and adds the images to a ZIP file.
// It also saves the presentation after processing.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PNG, Export, Charts, ZIP,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate exporting all charts from a presentation to a ZIP of PNG files.
// - Build C# utilities for PowerPoint chart extraction and archiving.
// - Integrate chart image generation into .NET applications.
// - Validate and process presentation content before publishing.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.IO.Compression;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartExportExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the input presentation
            string inputPath = "input.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                // Load the presentation
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

                // Define the output ZIP file path
                string zipPath = Path.Combine(Path.GetDirectoryName(inputPath), "ChartsExport.zip");

                // Create the ZIP archive and add chart images
                using (FileStream zipToOpen = new FileStream(zipPath, FileMode.Create))
                {
                    using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Update))
                    {
                        for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
                        {
                            Aspose.Slides.ISlide slide = pres.Slides[slideIndex];
                            for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                            {
                                Aspose.Slides.Charts.IChart chart = slide.Shapes[shapeIndex] as Aspose.Slides.Charts.IChart;
                                if (chart != null)
                                {
                                    // Render chart to an image
                                    Aspose.Slides.IImage chartImage = chart.GetImage();

                                    // Prepare entry name for the ZIP file
                                    string entryName = $"Chart_Slide{slideIndex + 1}_Shape{shapeIndex + 1}.png";

                                    // Save image to a memory stream and add to ZIP
                                    using (MemoryStream imgStream = new MemoryStream())
                                    {
                                        chartImage.Save(imgStream, Aspose.Slides.ImageFormat.Png);
                                        imgStream.Position = 0;
                                        ZipArchiveEntry entry = archive.CreateEntry(entryName);
                                        using (Stream entryStream = entry.Open())
                                        {
                                            imgStream.CopyTo(entryStream);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                // Save the presentation before exiting (required by rule)
                string outputPath = Path.Combine(Path.GetDirectoryName(inputPath), "output.pptx");
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
