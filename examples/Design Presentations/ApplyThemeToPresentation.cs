using System;
using Aspose.Slides;
using Aspose.Slides.Theme;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Apply an external theme to the first master slide and to all dependent slides
        Aspose.Slides.IMasterSlide masterSlide = presentation.Masters[0];
        Aspose.Slides.IMasterSlide themedMaster = masterSlide.ApplyExternalThemeToDependingSlides("MyTheme.thmx");

        // Modify a property of the master theme (example: change line style color)
        Aspose.Slides.Theme.IMasterTheme masterTheme = presentation.MasterTheme;
        masterTheme.FormatScheme.LineStyles[0].FillFormat.SolidFillColor.Color = System.Drawing.Color.Blue;

        // Save the presentation before exiting
        presentation.Save("ThemedPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}