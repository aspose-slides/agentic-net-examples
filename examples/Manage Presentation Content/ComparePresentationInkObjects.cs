using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a regular line shape to the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];
        slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Line, 50, 150, 300, 0);

        // NOTE: Adding an actual Ink object to the slide requires complex handling.
        // For this example we focus on how to control Ink visibility during export.

        // Create rendering options that hide Ink objects
        Aspose.Slides.Export.RenderingOptions hideInkOptions = new Aspose.Slides.Export.RenderingOptions();
        hideInkOptions.InkOptions.HideInk = true;

        // Save the presentation as PPT with Ink hidden
        presentation.Save("Presentation_HideInk.ppt", Aspose.Slides.Export.SaveFormat.Ppt, hideInkOptions);

        // Create rendering options that show Ink objects
        Aspose.Slides.Export.RenderingOptions showInkOptions = new Aspose.Slides.Export.RenderingOptions();
        showInkOptions.InkOptions.HideInk = false;
        showInkOptions.InkOptions.InterpretMaskOpAsOpacity = false;

        // Save the presentation as PPT with Ink visible
        presentation.Save("Presentation_ShowInk.ppt", Aspose.Slides.Export.SaveFormat.Ppt, showInkOptions);

        // Dispose the presentation object
        presentation.Dispose();
    }
}