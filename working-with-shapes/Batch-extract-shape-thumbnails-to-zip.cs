// -----------------------------------------------------------------------------
// Example: Batch extract shape thumbnails to zip using C#
//
// Description:
// Demonstrates how to batch extract shape thumbnails from PowerPoint files
// and store them in a ZIP archive using C# and Aspose.Slides for .NET. The
// example processes all PPT/PPTX files in a specified input folder, creates
// PNG thumbnails for each shape on every slide, and packages them into a
// single ZIP file. This pattern can be used to automate thumbnail generation
// for presentations in .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Batch, Extract, Shape,
// Thumbnails, ZIP, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate batch extraction of shape thumbnails into a ZIP archive.
// - Build tools for PowerPoint content analysis or preview generation.
// - Integrate shape thumbnail creation into .NET workflows.
// - Prepare assets for documentation, reporting, or web publishing.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using System.IO.Compression;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input folder containing PPT/PPTX files
        string inputDirectory = "InputPpts";
        // Output ZIP file path
        string outputZipPath = "ShapeThumbnails.zip";

        // Verify input directory exists
        if (!Directory.Exists(inputDirectory))
        {
            Console.WriteLine("Input directory does not exist.");
            return;
        }

        // Create ZIP archive for thumbnails
        using (FileStream zipFileStream = new FileStream(outputZipPath, FileMode.Create))
        using (ZipArchive zipArchive = new ZipArchive(zipFileStream, ZipArchiveMode.Create))
        {
            // Get all PowerPoint files in the directory
            string[] pptFiles = Directory.GetFiles(inputDirectory, "*.ppt*");
            foreach (string pptFile in pptFiles)
            {
                // Ensure the file exists
                if (!File.Exists(pptFile))
                {
                    continue;
                }

                try
                {
                    // Load the presentation
                    Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(pptFile);

                    // Iterate through slides
                    for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
                    {
                        Aspose.Slides.ISlide slide = pres.Slides[slideIndex];

                        // Iterate through shapes on the slide
                        for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                        {
                            Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];

                            // Generate thumbnail for the shape
                            Aspose.Slides.IImage shapeImage = shape.GetImage(Aspose.Slides.ShapeThumbnailBounds.Shape, 1f, 1f);

                            // Define entry name inside the ZIP
                            string entryName = $"{Path.GetFileNameWithoutExtension(pptFile)}_slide{slideIndex + 1}_shape{shapeIndex + 1}.png";

                            // Add image to ZIP archive
                            ZipArchiveEntry entry = zipArchive.CreateEntry(entryName);
                            using (Stream entryStream = entry.Open())
                            {
                                shapeImage.Save(entryStream, Aspose.Slides.ImageFormat.Png);
                            }
                        }
                    }

                    // Save presentation before exiting (no modifications made)
                    string tempSavePath = Path.Combine(Path.GetDirectoryName(pptFile), Path.GetFileNameWithoutExtension(pptFile) + "_temp.pptx");
                    pres.Save(tempSavePath, Aspose.Slides.Export.SaveFormat.Pptx);
                    pres.Dispose();
                }
                catch (NotSupportedException)
                {
                    // Format not supported
                }
                catch (Exception)
                {
                    // Handle other exceptions if necessary
                }
            }
        }
    }
}
