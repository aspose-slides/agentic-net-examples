using System;
using System.IO;
using Aspose.Slides.Export;
using Aspose.Slides.Util;
using System.Drawing;

class Program
{
    static void Main(string[] args)
    {
        string sourcePath = "input.pptx";
        string logoPath = "newlogo.png";
        string outputPath = "output.pptx";

        // Load the presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(sourcePath))
        {
            // Load the new logo image into the presentation's image collection
            using (FileStream logoStream = new FileStream(logoPath, FileMode.Open, FileAccess.Read))
            {
                Aspose.Slides.IPPImage newLogoImage = presentation.Images.AddImage(logoStream, Aspose.Slides.LoadingStreamBehavior.KeepLocked);

                // Iterate through all slides
                foreach (Aspose.Slides.ISlide slide in presentation.Slides)
                {
                    // Iterate through all shapes on the slide
                    foreach (Aspose.Slides.IShape shape in slide.Shapes)
                    {
                        Aspose.Slides.IPictureFrame pictureFrame = shape as Aspose.Slides.IPictureFrame;
                        if (pictureFrame != null)
                        {
                            // Identify the logo shape by its alternative text or name
                            if (pictureFrame.AlternativeText == "Logo" || pictureFrame.Name == "Logo")
                            {
                                pictureFrame.PictureFormat.Picture.Image = newLogoImage;
                            }
                        }
                    }
                }
            }

            // Save the updated presentation
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
    }
}