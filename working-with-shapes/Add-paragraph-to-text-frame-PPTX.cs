using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var presentationPath = "input.pptx";
            using (var presentation = new Aspose.Slides.Presentation(presentationPath))
            {
                var slide = presentation.Slides[0];
                Aspose.Slides.IAutoShape autoShape = null;
                foreach (var shape in slide.Shapes)
                {
                    if (shape is Aspose.Slides.IAutoShape)
                    {
                        var candidate = (Aspose.Slides.IAutoShape)shape;
                        if (candidate.TextFrame != null)
                        {
                            autoShape = candidate;
                            break;
                        }
                    }
                }

                if (autoShape != null)
                {
                    var textFrame = autoShape.TextFrame;
                    var sourcePortion = textFrame.Paragraphs[0].Portions[0];
                    var sourceFormat = sourcePortion.PortionFormat;

                    var newParagraph = new Aspose.Slides.Paragraph();
                    var newPortion = new Aspose.Slides.Portion("Additional paragraph text.");
                    newPortion.PortionFormat.FontHeight = sourceFormat.FontHeight;
                    newPortion.PortionFormat.FontBold = sourceFormat.FontBold;
                    newPortion.PortionFormat.FontItalic = sourceFormat.FontItalic;
                    newPortion.PortionFormat.FillFormat.SolidFillColor.Color = sourceFormat.FillFormat.SolidFillColor.Color;

                    newParagraph.Portions.Add(newPortion);
                    textFrame.Paragraphs.Add(newParagraph);
                }

                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}