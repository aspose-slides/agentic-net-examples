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
            string sourcePath = "Template.pptx";
            string outputPath = "Result.pptx";

            using (Presentation presentation = new Presentation(sourcePath))
            {
                // Access the first master slide
                IMasterSlide masterSlide = presentation.Masters[0];

                // Customize the master slide background
                masterSlide.Background.Type = BackgroundType.OwnBackground;
                masterSlide.Background.FillFormat.FillType = FillType.Solid;
                masterSlide.Background.FillFormat.SolidFillColor.Color = Color.LightBlue;

                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}