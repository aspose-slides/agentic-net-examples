using System;
using System.IO;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle shape that will hold the hyperlink
        Aspose.Slides.IShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 200, 50);

        // Cast the shape to AutoShape to access its text frame
        Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)shape;
        autoShape.AddTextFrame("Click me");

        // Retrieve the hyperlink object associated with the shape
        Aspose.Slides.IHyperlink hyperlink = autoShape.HyperlinkClick;

        // Load an audio file and add it to the presentation's audio collection
        byte[] audioBytes = File.ReadAllBytes("sound.mp3");
        Aspose.Slides.IAudio audio = presentation.Audios.AddAudio(audioBytes);

        // Assign the audio to the hyperlink's sound property
        hyperlink.Sound = audio;

        // Optionally set a tooltip for the hyperlink
        hyperlink.Tooltip = "Play sound";

        // Save the presentation in PPT format
        presentation.Save("HyperlinkSound.ppt", Aspose.Slides.Export.SaveFormat.Ppt);

        // Release resources
        presentation.Dispose();
    }
}