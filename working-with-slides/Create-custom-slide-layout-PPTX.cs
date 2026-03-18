using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first master slide
            Aspose.Slides.IMasterSlide masterSlide = presentation.Masters[0];

            // Add a custom layout slide to the presentation
            Aspose.Slides.ILayoutSlide customLayout = presentation.LayoutSlides.Add(
                masterSlide,
                Aspose.Slides.SlideLayoutType.Custom,
                "MyCustomLayout");

            // Add a rectangle shape to the custom layout (optional)
            customLayout.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle,
                50,
                50,
                400,
                100);

            // Add a new slide that uses the custom layout
            Aspose.Slides.ISlide newSlide = presentation.Slides.AddEmptySlide(customLayout);

            // Save the presentation
            presentation.Save("CustomLayoutPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}