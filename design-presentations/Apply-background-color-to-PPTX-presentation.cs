using System;
using System.Drawing;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Set the background color of the first slide to blue
            presentation.Slides[0].Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
            presentation.Slides[0].Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            presentation.Slides[0].Background.FillFormat.SolidFillColor.Color = Color.Blue;

            // Save the presentation
            presentation.Save("BackgroundColorPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}