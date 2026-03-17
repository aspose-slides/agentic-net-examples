using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace BackgroundFillExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Get the first slide
                Aspose.Slides.IBaseSlide slide = presentation.Slides[0];

                // Set background to own background and apply solid fill
                slide.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
                slide.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                slide.Background.FillFormat.SolidFillColor.Color = System.Drawing.Color.Blue;

                // Save the presentation
                presentation.Save("BackgroundColor.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}