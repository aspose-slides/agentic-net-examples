using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = "input.pptx";
                string outputPath = "output.pptx";

                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                Aspose.Slides.ISlide slide = presentation.Slides[0];

                Aspose.Slides.IAutoShape autoShape = slide.Shapes[0] as Aspose.Slides.IAutoShape;

                if (autoShape != null && autoShape.TextFrame != null)
                {
                    autoShape.TextFrame.Text = "Your prompt text";
                }

                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}