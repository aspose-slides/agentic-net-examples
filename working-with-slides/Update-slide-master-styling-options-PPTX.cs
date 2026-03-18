using System;
using System.Drawing;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Load the existing presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

            // Access the first master slide
            Aspose.Slides.IMasterSlide masterSlide = presentation.Masters[0];

            // Modify the master slide background color
            masterSlide.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
            masterSlide.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            masterSlide.Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

            // Save the updated presentation
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}