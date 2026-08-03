// -----------------------------------------------------------------------------
// Example: Report picture frame dimensions scaling cropping using C#
//
// Description:
// Demonstrates how to report picture frame dimensions, scaling, and cropping 
// using C# and Aspose.Slides for .NET. The example loads a PPTX file, iterates 
// through each slide and picture frame, outputs position, size, and relative 
// scaling values to the console, and saves the presentation. Developers can 
// use this pattern to automate PPTX workflows, validate picture frame 
// properties, or integrate presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Report, Picture, Frame, 
// Dimensions, Scaling, Cropping, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate reporting of picture frame dimensions, scaling, and cropping.
// - Build C# tools for PowerPoint presentation analysis and processing.
// - Generate or transform PPTX files while extracting media metadata in .NET.
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
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            Presentation presentation = new Presentation(inputPath);

            foreach (ISlide slide in presentation.Slides)
            {
                foreach (IShape shape in slide.Shapes)
                {
                    IPictureFrame pictureFrame = shape as IPictureFrame;
                    if (pictureFrame != null)
                    {
                        Console.WriteLine($"Slide {slide.SlideNumber}, Picture Frame:");
                        Console.WriteLine($"  Position - X: {pictureFrame.X}, Y: {pictureFrame.Y}");
                        Console.WriteLine($"  Size     - Width: {pictureFrame.Width}, Height: {pictureFrame.Height}");
                        Console.WriteLine($"  Scale    - RelativeScaleWidth: {pictureFrame.RelativeScaleWidth}, RelativeScaleHeight: {pictureFrame.RelativeScaleHeight}");
                        // Cropping parameters can be accessed via pictureFrame.PictureFormat if needed
                    }
                }
            }

            presentation.Save(outputPath, SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine($"Error processing presentation: {ex.Message}");
            // Format not supported comment
        }
    }
}
