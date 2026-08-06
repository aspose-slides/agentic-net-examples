// -----------------------------------------------------------------------------
// Example: Create thumbnails of smartart child nodes zip using C#
//
// Description:
// Demonstrates how to create thumbnails of smartart child nodes zip using C# 
// and Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Thumbnails, Smartart, Child, 
// Nodes, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate create thumbnails of smartart child nodes zip.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
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
        string outputPptx = "output.pptx";
        string zipPath = "thumbnails.zip";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);
            Aspose.Slides.ISlide slide = presentation.Slides[0];
            Aspose.Slides.SmartArt.ISmartArt smartArt = null;

            foreach (Aspose.Slides.IShape shape in slide.Shapes)
            {
                if (shape is Aspose.Slides.SmartArt.SmartArt)
                {
                    smartArt = (Aspose.Slides.SmartArt.SmartArt)shape;
                    break;
                }
            }

            if (smartArt == null)
            {
                Console.WriteLine("No SmartArt found.");
                presentation.Save(outputPptx, Aspose.Slides.Export.SaveFormat.Pptx);
                return;
            }

            using (FileStream zipToOpen = new FileStream(zipPath, FileMode.Create))
            {
                using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Update))
                {
                    int nodeIndex = 0;
                    foreach (Aspose.Slides.SmartArt.ISmartArtNode node in smartArt.AllNodes)
                    {
                        int shapeIndex = 0;
                        foreach (Aspose.Slides.SmartArt.ISmartArtShape shape in node.Shapes)
                        {
                            Aspose.Slides.IImage image = shape.GetImage();
                            string entryName = $"node_{nodeIndex}_shape_{shapeIndex}.png";
                            ZipArchiveEntry entry = archive.CreateEntry(entryName);
                            using (Stream entryStream = entry.Open())
                            {
                                image.Save(entryStream, Aspose.Slides.ImageFormat.Png);
                            }
                            shapeIndex++;
                        }
                        nodeIndex++;
                    }
                }
            }

            presentation.Save(outputPptx, Aspose.Slides.Export.SaveFormat.Pptx);
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
