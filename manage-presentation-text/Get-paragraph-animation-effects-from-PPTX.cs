using System;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var inputPath = "input.pptx";
            var outputPath = "output.pptx";

            using (var presentation = new Aspose.Slides.Presentation(inputPath))
            {
                foreach (var slide in presentation.Slides)
                {
                    var mainSequence = slide.Timeline.MainSequence;

                    foreach (var shape in slide.Shapes)
                    {
                        if (shape is Aspose.Slides.IAutoShape autoShape && autoShape.TextFrame != null)
                        {
                            foreach (var paragraph in autoShape.TextFrame.Paragraphs)
                            {
                                var effects = mainSequence.GetEffectsByParagraph(paragraph);
                                foreach (var effect in effects)
                                {
                                    Console.WriteLine($"Slide {slide.SlideNumber}, Shape \"{shape.Name}\", Effect Type: {effect.Type}, Subtype: {effect.Subtype}");
                                }
                            }
                        }
                    }
                }

                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}