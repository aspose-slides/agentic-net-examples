using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Load an existing presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

            // Access the first master slide via the Masters collection
            Aspose.Slides.IMasterSlide masterSlide = presentation.Masters[0];

            // Change the background color of the master slide
            masterSlide.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
            masterSlide.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            masterSlide.Background.FillFormat.SolidFillColor.Color = System.Drawing.Color.LightBlue;

            // Optionally apply an external theme to the master slide and its dependent slides
            // string themePath = "customTheme.thmx";
            // Aspose.Slides.IMasterSlide themedMaster = masterSlide.ApplyExternalThemeToDependingSlides(themePath);

            // Save the modified presentation
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}