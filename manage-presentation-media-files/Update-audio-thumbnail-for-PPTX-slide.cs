using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ReplaceAudioThumbnail
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load the presentation
                using (Presentation pres = new Presentation("input.pptx"))
                {
                    // Access the first slide (adjust index as needed)
                    ISlide slide = pres.Slides[0];

                    // Find the first audio frame on the slide
                    AudioFrame audioFrame = null;
                    foreach (IShape shape in slide.Shapes)
                    {
                        if (shape is AudioFrame)
                        {
                            audioFrame = (AudioFrame)shape;
                            break;
                        }
                    }

                    if (audioFrame != null)
                    {
                        // Generate a new thumbnail image from the slide
                        using (IImage newThumbnail = slide.GetImage())
                        {
                            // Save the thumbnail to a memory stream in JPEG format
                            using (MemoryStream thumbStream = new MemoryStream())
                            {
                                newThumbnail.Save(thumbStream, Aspose.Slides.ImageFormat.Jpeg);
                                thumbStream.Position = 0;

                                // Add the thumbnail image to the presentation's image collection
                                IPPImage thumbnailImage = pres.Images.AddImage(thumbStream);

                                // Replace the audio frame's thumbnail with the new image
                                audioFrame.PictureFormat.Picture.Image = thumbnailImage;
                            }
                        }
                    }

                    // Save the modified presentation
                    pres.Save("output.pptx", SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}