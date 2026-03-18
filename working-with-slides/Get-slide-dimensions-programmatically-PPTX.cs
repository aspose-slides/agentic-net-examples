using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
            // Set custom slide size (width: 800 points, height: 600 points) without scaling existing content
            presentation.SlideSize.SetSize(800f, 600f, Aspose.Slides.SlideSizeScaleType.DoNotScale);
            // Query the current slide dimensions
            System.Drawing.SizeF slideSize = presentation.SlideSize.Size;
            Console.WriteLine("Slide width: " + slideSize.Width);
            Console.WriteLine("Slide height: " + slideSize.Height);
            // Save the presentation
            presentation.Save("ConfiguredSlideSize.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}