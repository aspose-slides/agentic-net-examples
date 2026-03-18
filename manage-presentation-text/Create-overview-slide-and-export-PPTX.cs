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
            using (Presentation presentation = new Presentation())
            {
                // Use the first slide as the overview slide
                ISlide overviewSlide = presentation.Slides[0];

                // Add a rectangle AutoShape to the slide
                IAutoShape titleShape = overviewSlide.Shapes.AddAutoShape(
                    ShapeType.Rectangle, 50, 50, 600, 100);

                // Add a TextFrame with the overview title
                ITextFrame textFrame = titleShape.AddTextFrame("Overview Slide");

                // Save the presentation as PPTX
                presentation.Save("OverviewPresentation.pptx",
                    Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}