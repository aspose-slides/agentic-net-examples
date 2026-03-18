using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var presentation = new Aspose.Slides.Presentation();
            // Set custom slide dimensions (width: 1024 points, height: 768 points) without scaling existing content
            presentation.SlideSize.SetSize(1024f, 768f, Aspose.Slides.SlideSizeScaleType.DoNotScale);
            // Save the presentation
            presentation.Save("CustomSizePresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}