using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Presentation pres = new Presentation();

                // Get the first slide
                ISlide slide = pres.Slides[0];

                // Add a rectangle shape
                IShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 50);
                IAutoShape autoShape = (IAutoShape)shape;

                // Add text to the shape
                autoShape.AddTextFrame("Click to open link");

                // Load audio file bytes
                byte[] audioBytes = File.ReadAllBytes("audio.mp3");

                // Add audio to presentation
                IAudio audio = pres.Audios.AddAudio(audioBytes);

                // Create a hyperlink
                Hyperlink hyperlink = new Hyperlink("https://www.example.com");

                // Assign the audio as the sound for the hyperlink
                hyperlink.Sound = audio;

                // Assign the hyperlink to the shape
                shape.HyperlinkClick = hyperlink;

                // Save the presentation
                pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}