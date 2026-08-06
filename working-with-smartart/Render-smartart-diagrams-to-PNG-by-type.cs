// -----------------------------------------------------------------------------
// Example: Render smartart diagrams to PNG by type using C#
//
// Description:
// Demonstrates how to render smartart diagrams to PNG by type using C# and 
// Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PNG, Render, Smartart, 
// Diagrams, Type, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate render smartart diagrams to PNG by type.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

class Program
{
    static void Main()
    {
        // Path to the source presentation
        string inputPath = "input.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("The input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

            // Iterate through all slides
            foreach (Aspose.Slides.ISlide slide in pres.Slides)
            {
                // Iterate through all shapes on the slide
                foreach (Aspose.Slides.IShape shape in slide.Shapes)
                {
                    // Identify SmartArt shapes
                    if (shape is Aspose.Slides.SmartArt.ISmartArt)
                    {
                        Aspose.Slides.SmartArt.ISmartArt smartArt = (Aspose.Slides.SmartArt.ISmartArt)shape;

                        // Use the layout type as part of the output file name
                        Aspose.Slides.SmartArt.SmartArtLayoutType layout = smartArt.Layout;
                        string layoutName = layout.ToString();

                        // Define high‑resolution scaling factors
                        float scaleX = 2f;
                        float scaleY = 2f;

                        // Generate the thumbnail image using the correct overload (fixes CS7036)
                        Aspose.Slides.IImage smartArtImage = smartArt.GetImage(Aspose.Slides.ShapeThumbnailBounds.Shape, scaleX, scaleY);

                        // Construct the output PNG file name
                        string outputFileName = String.Format("{0}_{1}.png", Path.GetFileNameWithoutExtension(inputPath), layoutName);

                        // Save the image as PNG
                        smartArtImage.Save(outputFileName, Aspose.Slides.ImageFormat.Png);
                    }
                }
            }

            // Save the (potentially unchanged) presentation before exiting
            string outputPresentation = "output.pptx";
            pres.Save(outputPresentation, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // Format not supported – comment for clarity
            // The provided file format is not supported by Aspose.Slides.
        }
        catch (Exception ex)
        {
            // General exception handling
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
