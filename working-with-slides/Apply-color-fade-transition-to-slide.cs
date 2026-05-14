using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Set the background color of the first slide to a specified color (e.g., Red)
        presentation.Slides[0].Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
        presentation.Slides[0].Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        presentation.Slides[0].Background.FillFormat.SolidFillColor.Color = System.Drawing.Color.Red;

        // Apply a fade transition to the first slide
        presentation.Slides[0].SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Fade;
        presentation.Slides[0].SlideShowTransition.AdvanceOnClick = true;
        presentation.Slides[0].SlideShowTransition.AdvanceAfterTime = 3000; // 3 seconds

        // Save the presentation (handle unsupported format exception)
        try
        {
            presentation.Save("CustomFadeTransition.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Format not supported or other saving error
            Console.WriteLine("Error saving presentation: " + ex.Message);
        }

        // Dispose the presentation
        presentation.Dispose();
    }
}