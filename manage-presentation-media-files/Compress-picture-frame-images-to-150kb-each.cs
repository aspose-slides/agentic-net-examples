// -----------------------------------------------------------------------------
// Example: Compress picture frame images using C#
//
// Description:
// Demonstrates how to compress picture frame images in a PowerPoint presentation
// using C# and Aspose.Slides for .NET. The example shows how to iterate through
// slides and picture frames, apply maximum compression, and save the updated
// presentation. Developers can use this pattern to automate PPTX workflows,
// reduce file size, or integrate presentation processing into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Compress, Picture, Frame,
// Images, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate compression of picture frame images in presentations.
// - Build C# tools for PowerPoint presentation size optimization.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
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
            using (Presentation presentation = new Presentation(inputPath))
            {
                foreach (ISlide slide in presentation.Slides)
                {
                    foreach (IShape shape in slide.Shapes)
                    {
                        IPictureFrame pictureFrame = shape as IPictureFrame;
                        if (pictureFrame != null)
                        {
                            // Compress each picture frame image, delete cropped areas, use maximum compression (DPI 96)
                            pictureFrame.PictureFormat.CompressImage(true, Aspose.Slides.Export.PicturesCompression.Dpi96);
                        }
                    }
                }

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The file format is not supported.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
