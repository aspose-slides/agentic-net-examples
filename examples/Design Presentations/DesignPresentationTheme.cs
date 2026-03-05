using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Modify the master theme's first line style to have a solid blue fill
        presentation.MasterTheme.FormatScheme.LineStyles[0].FillFormat.SolidFillColor.Color = Color.Blue;

        // Apply an external theme file to the first master slide and all dependent slides
        Aspose.Slides.IMasterSlide masterSlide = presentation.Masters[0];
        masterSlide.ApplyExternalThemeToDependingSlides("ExternalTheme.thmx");

        // Save the presentation
        presentation.Save("PresentationWithTheme_out.pptx", SaveFormat.Pptx);
    }
}