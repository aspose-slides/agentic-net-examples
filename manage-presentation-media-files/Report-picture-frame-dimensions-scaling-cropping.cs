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