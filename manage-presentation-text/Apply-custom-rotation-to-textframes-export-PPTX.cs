using System;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = "input.pptx";
                string outputPath = "output.pptx";

                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    foreach (Aspose.Slides.ISlide slide in presentation.Slides)
                    {
                        foreach (Aspose.Slides.IShape shape in slide.Shapes)
                        {
                            Aspose.Slides.IAutoShape autoShape = shape as Aspose.Slides.IAutoShape;
                            if (autoShape != null && autoShape.TextFrame != null)
                            {
                                Aspose.Slides.ITextFrame textFrame = autoShape.TextFrame;
                                Aspose.Slides.ITextFrameFormat format = textFrame.TextFrameFormat;
                                format.RotationAngle = 45f;
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