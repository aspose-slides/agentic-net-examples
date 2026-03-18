using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SetCustomBackground
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                using (Presentation pres = new Presentation())
                {
                    // Apply a solid color background to each slide
                    for (int index = 0; index < pres.Slides.Count; index++)
                    {
                        IBackground background = pres.Slides[index].Background;
                        background.Type = BackgroundType.OwnBackground;
                        background.FillFormat.FillType = FillType.Solid;
                        background.FillFormat.SolidFillColor.Color = Color.LightBlue;
                    }

                    // Save the presentation
                    pres.Save("CustomBackground_out.pptx", SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}