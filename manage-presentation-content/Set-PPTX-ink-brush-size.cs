using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Ink;

class Program
{
    static void Main()
    {
        try
        {
            var pres = new Aspose.Slides.Presentation("input.pptx");
            var slide = pres.Slides[0];
            var inkShape = slide.Shapes[0] as Aspose.Slides.Ink.Ink;
            if (inkShape != null)
            {
                var ink = (Aspose.Slides.Ink.IInk)inkShape;
                var traces = ink.Traces;
                if (traces.Length > 0)
                {
                    var brush = traces[0].Brush;
                    // Adjust stroke thickness
                    brush.Size = new SizeF(5f, 10f);
                }
            }
            pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}