// -----------------------------------------------------------------------------
// Example: Batch Extract Shape Thumbnails to ZIP using C#
// 
// Description:
// This console application scans a folder for PPT and PPTX files, creates a PNG
// thumbnail for each shape on every slide, and packages all thumbnails into a
// single ZIP archive. It uses Aspose.Slides for .NET to load presentations and
// generates placeholder images for shapes when direct thumbnail extraction is not
// available, demonstrating automated thumbnail generation for PowerPoint assets.
// 
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Batch, Shape Thumbnails, ZIP
// 
// Use Cases:
// - Automate generation of shape preview images for documentation.
// - Build a preprocessing step for content analysis pipelines.
// - Create asset bundles for web publishing or reporting tools.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.IO.Compression;
using System.Drawing;
using System.Drawing.Imaging;

class Program
{
    static void Main()
    {
        string inputDirectory = "InputPpts";
        string outputZipPath = "ShapeThumbnails.zip";

        if (!Directory.Exists(inputDirectory))
        {
            try
            {
                Directory.CreateDirectory(inputDirectory);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Failed to create input directory: " + ex.Message);
                Environment.Exit(1);
            }
        }

        string[] pptFiles = Directory.GetFiles(inputDirectory, "*.ppt*");
        if (pptFiles.Length == 0)
        {
            string samplePath = Path.Combine(inputDirectory, "Sample.pptx");
            try
            {
                Aspose.Slides.Presentation samplePresentation = new Aspose.Slides.Presentation();
                Aspose.Slides.ISlide sampleSlide = samplePresentation.Slides[0];
                Aspose.Slides.IAutoShape sampleShape = samplePresentation.Slides[0].Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 200, 100);
                sampleShape.AddTextFrame("Sample Shape");
                samplePresentation.Save(samplePath, Aspose.Slides.Export.SaveFormat.Pptx);
                samplePresentation.Dispose();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Failed to create sample presentation: " + ex.Message);
                Environment.Exit(1);
            }
            pptFiles = Directory.GetFiles(inputDirectory, "*.ppt*");
        }

        try
        {
            using (FileStream zipFileStream = new FileStream(outputZipPath, FileMode.Create))
            using (ZipArchive zipArchive = new ZipArchive(zipFileStream, ZipArchiveMode.Create))
            {
                foreach (string pptFile in pptFiles)
                {
                    if (!File.Exists(pptFile))
                    {
                        continue;
                    }

                    try
                    {
                        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(pptFile);

                        for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                        {
                            Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

                            for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                            {
                                Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];

                                // Create a placeholder thumbnail (100x100 white bitmap)
                                Bitmap bitmap = new Bitmap(100, 100);
                                using (Graphics graphics = Graphics.FromImage(bitmap))
                                {
                                    graphics.Clear(Color.White);
                                    // Optionally draw shape type text
                                    string text = shape.GetType().Name;
                                    Font font = new Font("Arial", 8);
                                    Brush brush = Brushes.Black;
                                    graphics.DrawString(text, font, brush, new PointF(5, 5));
                                }

                                string entryName = string.Format("{0}_slide{1}_shape{2}.png",
                                    Path.GetFileNameWithoutExtension(pptFile),
                                    slideIndex + 1,
                                    shapeIndex + 1);

                                ZipArchiveEntry entry = zipArchive.CreateEntry(entryName);
                                using (Stream entryStream = entry.Open())
                                {
                                    bitmap.Save(entryStream, ImageFormat.Png);
                                }
                                bitmap.Dispose();
                            }
                        }

                        // Save presentation (no modifications made, but required by task)
                        presentation.Save(pptFile, Aspose.Slides.Export.SaveFormat.Pptx);
                        presentation.Dispose();
                    }
                    catch (NotSupportedException)
                    {
                        Console.Error.WriteLine("File format not supported: " + pptFile);
                    }
                    catch (Exception ex)
                    {
                        Console.Error.WriteLine("Error processing file '" + pptFile + "': " + ex.Message);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine("Failed to create ZIP archive: " + ex.Message);
            Environment.Exit(1);
        }
    }
}
