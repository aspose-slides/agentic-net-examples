// -----------------------------------------------------------------------------
// Example: Validate picture frame image source existence using C#
//
// Description:
// Demonstrates how to validate picture frame image source existence using C# 
// and Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Validate, Picture, Frame, 
// Image, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate validate picture frame image source existence.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        // Load presentation with exception handling
        Aspose.Slides.Presentation presentation = null;
        try
        {
            presentation = new Aspose.Slides.Presentation(inputPath);
        }
        catch (Exception ex)
        {
            // If the format is not supported, handle accordingly
            // Format not supported
            Console.WriteLine("Error loading presentation: " + ex.Message);
            return;
        }

        // Iterate through slides and picture frames
        foreach (Aspose.Slides.ISlide slide in presentation.Slides)
        {
            foreach (Aspose.Slides.IShape shape in slide.Shapes)
            {
                if (shape is Aspose.Slides.IPictureFrame)
                {
                    Aspose.Slides.IPictureFrame pictureFrame = (Aspose.Slides.IPictureFrame)shape;
                    Aspose.Slides.IPPImage image = pictureFrame.PictureFormat.Picture.Image;

                    // Verify the image exists in the presentation's image collection
                    bool existsInCollection = false;
                    foreach (Aspose.Slides.IPPImage img in presentation.Images)
                    {
                        if (object.ReferenceEquals(img, image))
                        {
                            existsInCollection = true;
                            break;
                        }
                    }

                    if (!existsInCollection)
                    {
                        Console.WriteLine($"Picture frame on slide {slide.SlideNumber} has an image not present in the image collection.");
                    }
                }
            }
        }

        // Save presentation before exit
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}
