using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Define data directory
            string dataDir = Path.GetFullPath("Data");
            if (!Directory.Exists(dataDir))
                Directory.CreateDirectory(dataDir);

            // Input and output file paths
            string inputPath = Path.Combine(dataDir, "input.pptx");
            string outputPath = Path.Combine(dataDir, "output.pptm");

            // Load the presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

            // Access the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Access the first ActiveX control on the slide
            Aspose.Slides.IControl control = slide.Controls[0];

            // Desired dimensions
            float desiredWidth = 200f;   // points
            float desiredHeight = 100f;  // points

            // Preserve existing frame properties except width and height
            Aspose.Slides.IShapeFrame oldFrame = control.Frame;
            control.Frame = new Aspose.Slides.ShapeFrame(
                oldFrame.X,
                oldFrame.Y,
                desiredWidth,
                desiredHeight,
                Aspose.Slides.NullableBool.False,
                Aspose.Slides.NullableBool.False,
                oldFrame.Rotation);

            // Save the modified presentation
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptm);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}