using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string outputPath = "EllipseRadialGradient.pptx";

        // Ensure the output directory exists
        string outputDir = Path.GetDirectoryName(outputPath);
        if (!String.IsNullOrEmpty(outputDir) && !Directory.Exists(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        // Create a new presentation
        using (Presentation pres = new Presentation())
        {
            // Add an ellipse with radial gradient to each slide
            for (int i = 0; i < pres.Slides.Count; i++)
            {
                ISlide slide = pres.Slides[i];

                // Add an ellipse shape covering the whole slide
                IShape ellipse = slide.Shapes.AddAutoShape(
                    ShapeType.Ellipse,
                    0,
                    0,
                    pres.SlideSize.Size.Width,
                    pres.SlideSize.Size.Height);

                // Configure radial gradient fill
                ellipse.FillFormat.FillType = FillType.Gradient;
                ellipse.FillFormat.GradientFormat.GradientShape = GradientShape.Radial;
                ellipse.FillFormat.GradientFormat.GradientDirection = GradientDirection.FromCenter;
                ellipse.FillFormat.GradientFormat.GradientStops.Add(0f, PresetColor.Purple);
                ellipse.FillFormat.GradientFormat.GradientStops.Add(1f, PresetColor.Red);
            }

            // Save the presentation with format support handling
            try
            {
                pres.Save(outputPath, SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The specified save format is not supported.");
            }
        }
    }
}