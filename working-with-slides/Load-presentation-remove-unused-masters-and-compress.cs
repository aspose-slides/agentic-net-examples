// -----------------------------------------------------------------------------
// Example: Load presentation remove unused masters and compress using C#
//
// Description:
// Demonstrates how to load a PowerPoint presentation, remove unused master
// slides, compress embedded images, and save the file with ZIP64 support using
// Aspose.Slides for .NET. The example includes error handling for missing files
// and unsupported formats, making it suitable for automation of PPTX
// optimization tasks.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Load, Presentation, Remove Unused Masters, Image Compression, ZIP64, Office Automation
//
// Use Cases:
// - Optimize PPTX files by removing unused masters and reducing image size.
// - Automate presentation processing in .NET applications.
// - Ensure large presentations are saved with ZIP64 when necessary.
// - Integrate PPTX cleanup steps into build or deployment pipelines.
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
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Remove unused master slides
                presentation.Masters.RemoveUnused(false);

                // Compress images in all slides
                foreach (Aspose.Slides.ISlide slide in presentation.Slides)
                {
                    foreach (Aspose.Slides.IShape shape in slide.Shapes)
                    {
                        Aspose.Slides.IPictureFrame pictureFrame = shape as Aspose.Slides.IPictureFrame;
                        if (pictureFrame != null)
                        {
                            pictureFrame.PictureFormat.CompressImage(true, Aspose.Slides.Export.PicturesCompression.Dpi96);
                        }
                    }
                }

                // Save with PPTX options (ZIP64 mode)
                Aspose.Slides.Export.PptxOptions saveOptions = new Aspose.Slides.Export.PptxOptions();
                saveOptions.Zip64Mode = Aspose.Slides.Export.Zip64Mode.IfNecessary;
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx, saveOptions);
            }
        }
        catch (Aspose.Slides.PptxUnsupportedFormatException)
        {
            // Format not supported
            Console.WriteLine("The presentation format is not supported.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
