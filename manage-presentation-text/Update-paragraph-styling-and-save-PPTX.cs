using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideTextEditor
{
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
                        foreach (var shape in slide.Shapes)
                        {
                            if (shape is Aspose.Slides.IAutoShape autoShape && autoShape.TextFrame != null)
                            {
                                var paragraphs = autoShape.TextFrame.Paragraphs;
                                for (var i = 0; i < paragraphs.Count; i++)
                                {
                                    var paragraph = paragraphs[i];
                                    if (paragraph.Portions.Count > 0)
                                    {
                                        var portion = paragraph.Portions[0];
                                        portion.Text = "Edited text";
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
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}