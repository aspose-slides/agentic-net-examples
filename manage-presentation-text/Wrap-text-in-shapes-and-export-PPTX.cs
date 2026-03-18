using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace TextWrapExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = "input.pptx";
                string outputPath = "output.pptx";

                using (Presentation presentation = new Presentation(inputPath))
                {
                    int slideCount = presentation.Slides.Count;
                    for (int i = 0; i < slideCount; i++)
                    {
                        ISlide slide = presentation.Slides[i];
                        int shapeCount = slide.Shapes.Count;
                        for (int j = 0; j < shapeCount; j++)
                        {
                            IShape shape = slide.Shapes[j];
                            IAutoShape autoShape = shape as IAutoShape;
                            if (autoShape != null && autoShape.TextFrame != null)
                            {
                                ITextFrameFormat tfFormat = autoShape.TextFrame.TextFrameFormat;
                                tfFormat.WrapText = NullableBool.True;
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