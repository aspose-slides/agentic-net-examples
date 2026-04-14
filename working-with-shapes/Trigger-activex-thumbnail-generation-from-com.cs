using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Paths for input and output files
        string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
        string outputPptx = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");
        string outputPng = Path.Combine(Directory.GetCurrentDirectory(), "shape_thumbnail.png");

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Iterate through ActiveX controls on the slide
            foreach (Aspose.Slides.IControl control in slide.Controls)
            {
                // Trigger thumbnail generation when a control named "GenerateThumbnail" is found
                if (control.Name == "GenerateThumbnail")
                {
                    // Create a rectangle shape
                    Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 200, 100);
                    shape.FillFormat.FillType = Aspose.Slides.FillType.NoFill;
                    shape.LineFormat.SketchFormat.SketchType = Aspose.Slides.LineSketchType.Scribble;

                    // Generate and save the shape thumbnail
                    Aspose.Slides.IImage shapeImage = shape.GetImage(Aspose.Slides.ShapeThumbnailBounds.Shape, 1f, 1f);
                    shapeImage.Save(outputPng, Aspose.Slides.ImageFormat.Png);
                }
            }

            // Save the presentation without refreshing the thumbnail
            Aspose.Slides.Export.PptxOptions options = new Aspose.Slides.Export.PptxOptions();
            options.RefreshThumbnail = false;
            pres.Save(outputPptx, Aspose.Slides.Export.SaveFormat.Pptx, options);
            pres.Dispose();
        }
        catch (NotSupportedException)
        {
            // Handle unsupported file format
            Console.WriteLine("The file format is not supported.");
        }
        catch (Exception ex)
        {
            // General exception handling
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}