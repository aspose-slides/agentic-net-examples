using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
        string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            Presentation presentation = new Presentation(inputPath);
            int slideIndex = 4; // Slide five (zero-based index)

            if (presentation.Slides.Count <= slideIndex)
            {
                Console.WriteLine("Slide five does not exist.");
                presentation.Dispose();
                return;
            }

            ISlide slide = presentation.Slides[slideIndex];
            foreach (IShape shape in slide.Shapes)
            {
                if (shape.ThreeDFormat != null)
                {
                    shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
                }
            }

            presentation.Save(outputPath, SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}