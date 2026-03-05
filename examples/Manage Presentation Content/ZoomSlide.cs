using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Ensure there are at least two slides: the first slide already exists, add a second empty slide
        Aspose.Slides.ISlide slide1 = pres.Slides[0];
        Aspose.Slides.ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

        // Add a zoom frame on the first slide that links to the second slide
        Aspose.Slides.IZoomFrame zoomFrame = slide1.Shapes.AddZoomFrame(150, 20, 100, 100, slide2);
        zoomFrame.ReturnToParent = true; // Enable return to parent navigation

        // Set view zoom percentages for slide view and notes view
        pres.ViewProperties.SlideViewProperties.Scale = 100;
        pres.ViewProperties.NotesViewProperties.Scale = 100;

        // Save the presentation in PPT format
        string outPath = Path.Combine(Directory.GetCurrentDirectory(), "ZoomPresentation.ppt");
        pres.Save(outPath, Aspose.Slides.Export.SaveFormat.Ppt);
    }
}