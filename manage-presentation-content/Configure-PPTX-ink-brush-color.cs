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
            var presentation = new Presentation();
            var slide = presentation.Slides[0];

            // Assume the first shape on the slide is an Ink shape
            var shape = slide.Shapes[0];
            var ink = shape as IInk;
            if (ink != null && ink.Traces.Length > 0)
            {
                var brush = ink.Traces[0].Brush;
                brush.Color = System.Drawing.Color.Blue; // Set ink brush color
            }

            presentation.Save("InkColorDemo.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}