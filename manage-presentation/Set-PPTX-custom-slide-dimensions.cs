using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Set custom slide dimensions (width: 1024 points, height: 768 points) without scaling existing content
            presentation.SlideSize.SetSize(1024f, 768f, Aspose.Slides.SlideSizeScaleType.DoNotScale);

            // Save the presentation to a PPTX file
            presentation.Save("CustomSlideSize.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Output any errors that occur
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}