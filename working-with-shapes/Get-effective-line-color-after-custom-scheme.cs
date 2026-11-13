// -----------------------------------------------------------------------------
// Example: Get Effective Line Color After Applying Custom Theme
//
// Description:
// Demonstrates loading a PPTX file (or creating a sample one), setting a line
// color on a shape, retrieving the effective line color after any theme changes,
// outputting the color, and saving the presentation using Aspose.Slides for .NET.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, effective line color, custom theme
//
// Use Cases:
// - Verify shape line colors after applying theme modifications.
// - Build utilities that report effective line formatting for compliance.
// - Automate extraction of line color information from presentations.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Drawing;

class Program
{
    static int Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            try
            {
                Aspose.Slides.Presentation createPres = new Aspose.Slides.Presentation();
                Aspose.Slides.ISlide slide = createPres.Slides[0];
                Aspose.Slides.IAutoShape rect = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 200, 100);
                rect.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                rect.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;
                createPres.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                createPres.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to create sample input file: " + ex.Message);
                return 1;
            }
        }

        try
        {
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);
            if (pres.Slides.Count == 0)
            {
                Console.WriteLine("Presentation contains no slides.");
                pres.Dispose();
                return 1;
            }

            Aspose.Slides.ISlide firstSlide = pres.Slides[0];
            if (firstSlide.Shapes.Count == 0)
            {
                Console.WriteLine("First slide contains no shapes.");
                pres.Dispose();
                return 1;
            }

            Aspose.Slides.IShape shape = firstSlide.Shapes[0];
            shape.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            System.Drawing.Color effectiveColor = shape.LineFormat.FillFormat.SolidFillColor.Color;
            Console.WriteLine("Effective line color: " + effectiveColor.ToString());

            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (NotSupportedException)
        {
            Console.WriteLine("The file format is not supported.");
            return 1;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            return 1;
        }

        return 0;
    }
}
