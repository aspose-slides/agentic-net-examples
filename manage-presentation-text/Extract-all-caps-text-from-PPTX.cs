using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

namespace ExtractAllCapsText
{
    class Program
    {
        static void Main()
        {
            try
            {
                var inputPath = "input.pptx";
                var outputPath = "output.pptx";

                using (var presentation = new Presentation(inputPath))
                {
                    var allTextFrames = SlideUtil.GetAllTextFrames(presentation, false);
                    foreach (var textFrame in allTextFrames)
                    {
                        foreach (var paragraph in textFrame.Paragraphs)
                        {
                            foreach (var portion in paragraph.Portions)
                            {
                                var text = portion.Text;
                                if (!string.IsNullOrEmpty(text) && text == text.ToUpperInvariant())
                                {
                                    Console.WriteLine(text);
                                }
                            }
                        }
                    }

                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}