using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = Path.Combine(Environment.CurrentDirectory, "input.pptx");
            string thumbnailPath = Path.Combine(Environment.CurrentDirectory, "newThumbnail.jpg");
            string outputPath = Path.Combine(Environment.CurrentDirectory, "output.pptx");

            // Load the presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Access the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Locate the first audio frame on the slide
                Aspose.Slides.IAudioFrame audioFrame = null;
                foreach (Aspose.Slides.IShape shape in slide.Shapes)
                {
                    audioFrame = shape as Aspose.Slides.IAudioFrame;
                    if (audioFrame != null)
                    {
                        break;
                    }
                }

                if (audioFrame != null)
                {
                    // Add the new thumbnail image to the presentation's image collection
                    Aspose.Slides.IPPImage newThumbnail = presentation.Images.AddImage(File.ReadAllBytes(thumbnailPath));

                    // Replace the audio frame's thumbnail image
                    audioFrame.PictureFormat.Picture.Image = newThumbnail;
                }

                // Save the presentation, refreshing the thumbnail
                Aspose.Slides.Export.PptxOptions saveOptions = new Aspose.Slides.Export.PptxOptions();
                saveOptions.RefreshThumbnail = true;
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx, saveOptions);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}