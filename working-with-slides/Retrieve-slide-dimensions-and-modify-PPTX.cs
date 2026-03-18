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

            // Set custom slide size (width: 800 points, height: 600 points) without scaling content
            presentation.SlideSize.SetSize(800f, 600f, Aspose.Slides.SlideSizeScaleType.DoNotScale);

            // Retrieve the current slide size
            Aspose.Slides.ISlideSize slideSize = presentation.SlideSize;
            float width = slideSize.Size.Width;
            float height = slideSize.Size.Height;

            Console.WriteLine("Slide width: " + width);
            Console.WriteLine("Slide height: " + height);

            // Save the presentation before exiting
            presentation.Save("ModifiedSlideSize.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}