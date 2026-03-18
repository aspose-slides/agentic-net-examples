using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            const string inputPath = "input.pptx";
            const string outputPath = "output.pptx";
            const string standardText = "Standardized Text";

            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                for (int i = 0; i < presentation.Slides.Count; i++)
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[i];
                    for (int j = 0; j < slide.Shapes.Count; j++)
                    {
                        Aspose.Slides.IShape shape = slide.Shapes[j];
                        if (shape is Aspose.Slides.IAutoShape)
                        {
                            Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)shape;
                            if (autoShape.TextFrame != null)
                            {
                                autoShape.TextFrame.Text = standardText;
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