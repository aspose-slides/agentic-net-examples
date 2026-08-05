// -----------------------------------------------------------------------------
// Example: Export charts to zip archive PNG using C#
//
// Description:
// Demonstrates how to extract chart objects from a PowerPoint presentation,
// render each chart as a PNG image, and store the images in a ZIP archive using
// Aspose.Slides for .NET. The example also shows optional saving of the
// presentation after processing. This pattern can be used to automate chart
// extraction, create image archives, or integrate chart handling into .NET
// applications.
//
// Keywords:
// C#, Aspose.Slides for .NET, PNG, ZipArchive, Charts, Export, PowerPoint,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Extract and archive all charts from a PPTX as PNG files.
// - Build tools that generate image collections from presentations.
// - Automate reporting workflows that require chart images.
// - Integrate chart image extraction into larger .NET solutions.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.IO.Compression;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputZipPath = "charts.zip";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Create a ZIP archive to store chart images
                using (FileStream zipFile = new FileStream(outputZipPath, FileMode.Create))
                {
                    using (ZipArchive archive = new ZipArchive(zipFile, ZipArchiveMode.Update))
                    {
                        int chartCounter = 0;

                        // Iterate through all slides and shapes to find charts
                        foreach (Aspose.Slides.ISlide slide in presentation.Slides)
                        {
                            foreach (Aspose.Slides.IShape shape in slide.Shapes)
                            {
                                Aspose.Slides.Charts.IChart chart = shape as Aspose.Slides.Charts.IChart;
                                if (chart != null)
                                {
                                    // Export chart as PNG image
                                    Aspose.Slides.IImage chartImage = chart.GetImage();
                                    string entryName = "chart_" + chartCounter + ".png";
                                    ZipArchiveEntry entry = archive.CreateEntry(entryName);
                                    using (Stream entryStream = entry.Open())
                                    {
                                        chartImage.Save(entryStream, Aspose.Slides.ImageFormat.Png);
                                    }
                                    chartCounter++;
                                }
                            }
                        }
                    }
                }

                // Save the presentation before exiting (optional)
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The presentation format is not supported.");
        }
        catch (Exception ex)
        {
            // Handle other exceptions (e.g., external URLs or I/O errors)
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
