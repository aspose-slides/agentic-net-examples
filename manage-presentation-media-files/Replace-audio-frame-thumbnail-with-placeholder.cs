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
            // Paths
            string presentationPath = "input.pptx";
            string placeholderImagePath = "placeholder.png";
            string outputPath = "output.pptx";

            // Verify input files exist
            if (!File.Exists(presentationPath))
            {
                Console.WriteLine("Presentation file not found: " + presentationPath);
                return;
            }

            if (!File.Exists(placeholderImagePath))
            {
                Console.WriteLine("Placeholder image not found: " + placeholderImagePath);
                return;
            }

            try
            {
                // Load presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(presentationPath))
                {
                    // Add placeholder image to presentation resources
                    Aspose.Slides.IPPImage placeholderImage;
                    using (FileStream imgStream = new FileStream(placeholderImagePath, FileMode.Open, FileAccess.Read))
                    {
                        placeholderImage = presentation.Images.AddImage(imgStream, LoadingStreamBehavior.KeepLocked);
                    }

                    // Iterate through all slides and replace audio frame thumbnails
                    for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                    {
                        Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];
                        Aspose.Slides.IShapeCollection shapes = slide.Shapes;

                        for (int shapeIndex = 0; shapeIndex < shapes.Count; shapeIndex++)
                        {
                            Aspose.Slides.IShape shape = shapes[shapeIndex];
                            if (shape is Aspose.Slides.IAudioFrame)
                            {
                                Aspose.Slides.IAudioFrame audioFrame = (Aspose.Slides.IAudioFrame)shape;
                                // Set the placeholder image as the thumbnail
                                audioFrame.PictureFormat.Picture.Image = placeholderImage;
                            }
                        }
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The provided file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}