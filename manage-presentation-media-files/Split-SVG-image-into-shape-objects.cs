// -----------------------------------------------------------------------------
// Example: Split SVG image into shape objects using C#
//
// Description:
// Demonstrates how to read an SVG file, insert it into a PowerPoint slide as a
// picture frame, convert the SVG into a group of editable shape objects, and
// save the result as a PPTX file using Aspose.Slides for .NET. The example
// illustrates the required steps for handling SVG content, creating images,
// manipulating shapes, and exporting presentations in a console application.
//
// Keywords:
// C#, Aspose.Slides for .NET, PowerPoint, PPTX, SVG, Split SVG, Shape objects,
// GroupShape, PictureFrame, Presentation processing, Office automation
//
// Use Cases:
// - Convert SVG graphics into editable PowerPoint shapes for further editing.
// - Automate creation of slides from SVG assets in .NET applications.
// - Build tools that transform vector images into presentation-ready content.
// - Integrate SVG-to-PPTX conversion into document generation workflows.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input SVG file path and output PPTX file path
        string inputSvgPath = "input.svg";
        string outputPptxPath = "output.pptx";

        // Verify that the input SVG file exists
        if (!File.Exists(inputSvgPath))
        {
            Console.WriteLine("Input SVG file does not exist.");
            return;
        }

        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Read SVG content
            string svgContent = File.ReadAllText(inputSvgPath);

            // Create an ISvgImage from the SVG content
            Aspose.Slides.ISvgImage svgImage = new Aspose.Slides.SvgImage(svgContent);

            // Add the SVG image to the presentation's image collection
            Aspose.Slides.IPPImage ppImage = pres.Images.AddImage(svgImage);

            // Insert the SVG as a picture frame on the first slide
            Aspose.Slides.PictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(
                Aspose.Slides.ShapeType.Rectangle,
                0,
                0,
                ppImage.Width,
                ppImage.Height,
                ppImage) as Aspose.Slides.PictureFrame;

            // If the picture frame was added successfully, convert it to a group of shapes
            if (pictureFrame != null)
            {
                Aspose.Slides.ISvgImage innerSvg = pictureFrame.PictureFormat.Picture.Image.SvgImage;
                if (innerSvg != null)
                {
                    // Create a group shape from the SVG, splitting it into individual shapes
                    Aspose.Slides.IGroupShape groupShape = pres.Slides[0].Shapes.AddGroupShape(
                        innerSvg,
                        pictureFrame.Frame.X,
                        pictureFrame.Frame.Y,
                        pictureFrame.Frame.Width,
                        pictureFrame.Frame.Height);

                    // Remove the original picture frame
                    pres.Slides[0].Shapes.Remove(pictureFrame);
                }
            }

            // Save the presentation
            pres.Save(outputPptxPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            // Handle other exceptions (e.g., file I/O, Aspose.Slides errors)
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
