using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

namespace ApplySolidBackground
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Apply solid blue background to each slide
                for (int i = 0; i < presentation.Slides.Count; i++)
                {
                    presentation.Slides[i].Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
                    presentation.Slides[i].Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                    presentation.Slides[i].Background.FillFormat.SolidFillColor.Color = Color.Blue;
                }

                // Save the presentation
                presentation.Save("SolidBackgroundPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}