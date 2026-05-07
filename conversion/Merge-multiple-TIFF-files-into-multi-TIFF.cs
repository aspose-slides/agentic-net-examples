using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

public class Program
{
    public static void Main(string[] args)
    {
        string[] inputFiles;
        if (args != null && args.Length > 0)
        {
            inputFiles = args;
        }
        else
        {
            inputFiles = new string[] { "input1.tiff", "input2.tiff", "input3.tiff" };
        }

        string outputFile = "merged_output.tiff";

        try
        {
            // Verify that all input files exist
            foreach (string filePath in inputFiles)
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("File not found: " + filePath);
                    return;
                }
            }

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Ensure there is at least one layout slide to use
            if (presentation.LayoutSlides.Count == 0)
            {
                Console.WriteLine("No layout slides available.");
                presentation.Dispose();
                return;
            }

            // Add each TIFF image as a separate slide
            foreach (string filePath in inputFiles)
            {
                byte[] imageData = File.ReadAllBytes(filePath);
                Aspose.Slides.IPPImage image = presentation.Images.AddImage(imageData);
                Aspose.Slides.ISlide slide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
                slide.Shapes.AddPictureFrame(
                    Aspose.Slides.ShapeType.Rectangle,
                    0,
                    0,
                    presentation.SlideSize.Size.Width,
                    presentation.SlideSize.Size.Height,
                    image);
            }

            // Prepare TIFF save options (default options are sufficient for multi‑page TIFF)
            Aspose.Slides.Export.TiffOptions tiffOptions = new Aspose.Slides.Export.TiffOptions();

            // Save the presentation as a multi‑page TIFF document
            presentation.Save(outputFile, Aspose.Slides.Export.SaveFormat.Tiff, tiffOptions);
            presentation.Dispose();
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