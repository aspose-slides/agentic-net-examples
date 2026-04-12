using System;
using System.IO;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        Aspose.Slides.Presentation presentation = null;
        try
        {
            if (File.Exists(inputPath))
            {
                presentation = new Aspose.Slides.Presentation(inputPath);
            }
            else
            {
                presentation = new Aspose.Slides.Presentation();
            }
        }
        catch (Exception ex)
        {
            // Handle unsupported format
            Console.WriteLine("Error loading presentation: " + ex.Message);
            return;
        }

        foreach (Aspose.Slides.ISlide slide in presentation.Slides)
        {
            foreach (Aspose.Slides.IShape shape in slide.Shapes)
            {
                if (shape.Placeholder != null && shape.Placeholder.Type == Aspose.Slides.PlaceholderType.Subtitle && shape is Aspose.Slides.IAutoShape)
                {
                    Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)shape;
                    if (autoShape.TextFrame != null && autoShape.TextFrame.Paragraphs.Count > 0 && autoShape.TextFrame.Paragraphs[0].Portions.Count > 0)
                    {
                        Aspose.Slides.IPortionFormat portionFormat = autoShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
                        Aspose.Slides.IEffectFormat effectFormat = portionFormat.EffectFormat;
                        effectFormat.EnableOuterShadowEffect();
                        Aspose.Slides.Effects.IOuterShadow outerShadow = effectFormat.OuterShadowEffect;
                        outerShadow.Direction = 45.0f;
                        outerShadow.Distance = 5.0;
                        outerShadow.BlurRadius = 5.0;
                        outerShadow.ShadowColor.Color = Color.Black;
                    }
                }
            }
        }

        try
        {
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle save errors
            Console.WriteLine("Error saving presentation: " + ex.Message);
        }
    }
}