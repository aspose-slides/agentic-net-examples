using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace HyperlinkSoundDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle shape that will hold the hyperlink
            Aspose.Slides.IShape shape = slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle, 100, 100, 200, 50);

            // Create an external hyperlink and assign it to the shape
            Aspose.Slides.Hyperlink hyperlink = new Aspose.Slides.Hyperlink("https://www.aspose.com");
            shape.HyperlinkClick = hyperlink;

            // Load audio data from a file and add it to the presentation's audio collection
            byte[] audioBytes = File.ReadAllBytes("sound.wav");
            Aspose.Slides.IAudio audio = presentation.Audios.AddAudio(audioBytes);

            // Assign the audio as the sound to be played when the hyperlink is clicked
            shape.HyperlinkClick.Sound = audio;

            // Save the presentation in PPT format
            presentation.Save("HyperlinkWithSound.ppt", Aspose.Slides.Export.SaveFormat.Ppt);
        }
    }
}