// -----------------------------------------------------------------------------
// Example: Batch Update Line Widths to 1.5pt While Preserving Dash Styles
//
// Description:
// This console program loads a PPTX file, iterates through all shapes, updates each defined line width to 1.5 points, and keeps any existing dash style unchanged. If the input file is missing, a simple sample presentation is created automatically. The modified presentation is saved as a new PPTX file.
// 
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, line width, dash style
//
// Use Cases:
// - Standardize line thickness across an entire presentation.
// - Maintain visual consistency while preserving custom dash patterns.
// - Automate styling adjustments in bulk for corporate slide decks.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        try
        {
            if (!File.Exists(inputPath))
            {
                Aspose.Slides.Presentation samplePresentation = new Aspose.Slides.Presentation();
                Aspose.Slides.ISlide sampleSlide = samplePresentation.Slides[0];
                Aspose.Slides.IAutoShape sampleShape = (Aspose.Slides.IAutoShape)sampleSlide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 300, 150);
                sampleShape.LineFormat.Width = 2.0f;
                samplePresentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                samplePresentation.Dispose();
            }

            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);
            foreach (Aspose.Slides.ISlide slide in presentation.Slides)
            {
                foreach (Aspose.Slides.IShape shape in slide.Shapes)
                {
                    Aspose.Slides.ILineFormat lineFormat = shape.LineFormat;
                    if (lineFormat != null && !lineFormat.IsFormatNotDefined)
                    {
                        lineFormat.Width = 1.5f;
                    }
                }
            }

            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();

            Console.WriteLine("Line widths updated successfully. Output saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            Environment.Exit(1);
        }
    }
}
