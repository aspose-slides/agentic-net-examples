using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation (contains one default slide)
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Define desired aspect ratio (16:9) and calculate dimensions in points
            float width = 960f;                         // width in points
            float height = width * 9f / 16f;            // height maintaining 16:9 ratio

            // Apply the custom slide size without scaling existing content
            presentation.SlideSize.SetSize(width, height, Aspose.Slides.SlideSizeScaleType.DoNotScale);

            // Save the modified presentation
            presentation.Save("ConfiguredSlides.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}