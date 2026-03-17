using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace HyperlinkAudioExample
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
                    // Get the first slide
                    var slide = pres.Slides[0];

                    // Add a rectangle shape with text
                    var shape = slide.Shapes.AddAutoShape(
                        Aspose.Slides.ShapeType.Rectangle, 100, 100, 200, 50);
                    shape.TextFrame.Text = "Click to play sound";

                    // Load audio file bytes
                    var audioBytes = File.ReadAllBytes("audio.mp3");

                    // Add audio to the presentation's audio collection
                    var audio = pres.Audios.AddAudio(audioBytes);

                    // Set the hyperlink click sound to the added audio
                    var hyperlink = shape.HyperlinkClick;
                    hyperlink.Sound = audio;
                    hyperlink.Tooltip = "Play embedded audio";

                    // Save the presentation
                    pres.Save("HyperlinkAudio.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}