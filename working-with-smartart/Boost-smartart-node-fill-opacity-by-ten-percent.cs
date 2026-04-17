using System;
using System.IO;
using System.Drawing;
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
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

                for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                {
                    Aspose.Slides.SmartArt.ISmartArt smartArt = slide.Shapes[shapeIndex] as Aspose.Slides.SmartArt.ISmartArt;
                    if (smartArt != null)
                    {
                        Aspose.Slides.SmartArt.ISmartArtNodeCollection allNodes = smartArt.AllNodes;
                        foreach (Aspose.Slides.SmartArt.ISmartArtNode node in allNodes)
                        {
                            Aspose.Slides.SmartArt.ISmartArtShapeCollection nodeShapes = node.Shapes;
                            foreach (Aspose.Slides.SmartArt.ISmartArtShape shape in nodeShapes)
                            {
                                Aspose.Slides.IFillFormat fillFormat = shape.FillFormat;
                                if (fillFormat != null)
                                {
                                    fillFormat.FillType = Aspose.Slides.FillType.Solid;
                                    Color originalColor = fillFormat.SolidFillColor.Color;
                                    int originalAlpha = originalColor.A;
                                    int increasedAlpha = originalAlpha + (int)(255 * 0.10);
                                    if (increasedAlpha > 255) increasedAlpha = 255;
                                    Color newColor = Color.FromArgb(increasedAlpha, originalColor);
                                    fillFormat.SolidFillColor.Color = newColor;
                                }
                            }
                        }
                    }
                }
            }

            presentation.Save(outputPath, SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported.
        }
        catch (Exception)
        {
            // Handle other exceptions.
        }
    }
}