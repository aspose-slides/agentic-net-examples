using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace MyPresentationApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load the presentation from a file
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

                // Iterate over each slide in the presentation
                for (int i = 0; i < presentation.Slides.Count; i++)
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[i];

                    // Example modification: set a solid light gray background for each slide
                    slide.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
                    slide.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                    slide.Background.FillFormat.SolidFillColor.Color = Color.LightGray;
                }

                // Save the modified presentation
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}