using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Load an existing presentation
            using (Presentation presentation = new Presentation("input.pptx"))
            {
                // Iterate through all slides
                int slideCount = presentation.Slides.Count;
                for (int i = 0; i < slideCount; i++)
                {
                    // Retrieve slide as ISlide (avoid CS0266)
                    ISlide slide = presentation.Slides[i];

                    // Example manipulation: set slide background to LightGray
                    slide.Background.Type = BackgroundType.OwnBackground;
                    slide.Background.FillFormat.FillType = FillType.Solid;
                    slide.Background.FillFormat.SolidFillColor.Color = Color.LightGray;
                }

                // Save the modified presentation (must save before exit)
                presentation.Save("output.pptx", SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}