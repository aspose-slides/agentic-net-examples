using System;
using System.IO;
using System.Net.Http;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

namespace InsertGifExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // URL of the GIF image to insert
            string gifUrl = "https://example.com/sample.gif";

            // Create a new presentation
            using (Presentation presentation = new Presentation())
            {
                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Download the GIF image
                byte[] gifData = null;
                try
                {
                    using (HttpClient httpClient = new HttpClient())
                    {
                        HttpResponseMessage response = httpClient.GetAsync(gifUrl).Result;
                        response.EnsureSuccessStatusCode();
                        gifData = response.Content.ReadAsByteArrayAsync().Result;
                    }
                }
                catch (HttpRequestException)
                {
                    // Handle web request errors
                    Console.WriteLine("Failed to download the GIF image from the URL.");
                    return;
                }

                // Add the GIF image to the presentation's image collection
                IPPImage gifImage = presentation.Images.AddImage(gifData);

                // Add a picture frame containing the GIF to the slide
                // Parameters: shape type, X, Y, width, height, image
                IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 400, 300, gifImage);

                // Add an animation effect to play the GIF once
                // Use MediaPlay effect for media content
                IEffect effect = slide.Timeline.MainSequence.AddEffect(
                    pictureFrame,
                    EffectType.MediaPlay,
                    EffectSubtype.None,
                    EffectTriggerType.AfterPrevious);

                // Ensure the effect does not repeat
                effect.Timing.RepeatUntilEndSlide = false;

                // Save the presentation
                try
                {
                    presentation.Save("OutputPresentation.pptx", SaveFormat.Pptx);
                }
                catch (Aspose.Slides.PptxUnsupportedFormatException)
                {
                    // Handle unsupported format exception
                    Console.WriteLine("The specified format is not supported for saving.");
                }
                catch (Aspose.Slides.PptUnsupportedFormatException)
                {
                    // Handle unsupported format exception
                    Console.WriteLine("The specified format is not supported for saving.");
                }
            }
        }
    }
}