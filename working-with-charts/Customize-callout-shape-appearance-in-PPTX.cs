using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Define input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Check if the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        // Load the presentation
        using (Presentation presentation = new Presentation(inputPath))
        {
            // Iterate through all slides
            for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
            {
                ISlide slide = presentation.Slides[slideIndex];

                // Iterate through all shapes on the slide
                for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                {
                    IAutoShape autoShape = slide.Shapes[shapeIndex] as IAutoShape;

                    // Process only AutoShape objects that contain a TextFrame (assumed callout)
                    if (autoShape != null && autoShape.TextFrame != null)
                    {
                        // Set fill color of the callout shape
                        autoShape.FillFormat.FillType = FillType.Solid;
                        autoShape.FillFormat.SolidFillColor.Color = Color.Yellow;

                        // Set line style of the callout shape
                        autoShape.LineFormat.Style = LineStyle.ThickThin;
                        autoShape.LineFormat.Width = 2;
                        autoShape.LineFormat.DashStyle = LineDashStyle.Dash;
                        autoShape.LineFormat.FillFormat.FillType = FillType.Solid;
                        autoShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

                        // Modify text formatting inside the callout
                        IPortion portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
                        portion.PortionFormat.FillFormat.FillType = FillType.Solid;
                        portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
                        portion.PortionFormat.FontHeight = 14;
                    }
                }
            }

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}