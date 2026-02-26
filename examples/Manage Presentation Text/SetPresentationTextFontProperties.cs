using System;
using System.Drawing;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputPath = "input.pptx";
            var outputPath = "output.pptx";

            using (var presentation = new Aspose.Slides.Presentation(inputPath))
            {
                foreach (var slide in presentation.Slides)
                {
                    foreach (var shape in slide.Shapes)
                    {
                        if (shape is Aspose.Slides.IAutoShape autoShape && autoShape.TextFrame != null)
                        {
                            var textFrame = autoShape.TextFrame;
                            foreach (var paragraph in textFrame.Paragraphs)
                            {
                                foreach (var portion in paragraph.Portions)
                                {
                                    var format = portion.PortionFormat;
                                    format.FontHeight = 24;
                                    format.FontBold = Aspose.Slides.NullableBool.True;
                                    format.FontItalic = Aspose.Slides.NullableBool.True;
                                    format.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                                    format.FillFormat.SolidFillColor.Color = Color.Blue;
                                }
                            }
                        }
                    }
                }

                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}