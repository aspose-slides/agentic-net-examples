using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Ink;

class Program
{
    static void Main()
    {
        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Assume the first shape on the slide is an Ink shape
            Aspose.Slides.IShape shape = slide.Shapes[0];
            Aspose.Slides.Ink.IInk ink = shape as Aspose.Slides.Ink.IInk;

            if (ink != null && ink.Traces.Length > 0)
            {
                Aspose.Slides.Ink.IInkBrush brush = ink.Traces[0].Brush;
                brush.Color = System.Drawing.Color.Blue;
            }

            presentation.Save("InkColorPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}