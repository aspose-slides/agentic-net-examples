using System;

class Program
{
    static void Main()
    {
        // Scaling factors for the thumbnail (full size)
        int scaleX = 1;
        int scaleY = scaleX;

        // Path to the source PPTX file
        System.String inputPath = "input.pptx";

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Export each slide as a JPEG image
        foreach (Aspose.Slides.ISlide slide in presentation.Slides)
        {
            using (Aspose.Slides.IImage thumbnail = slide.GetImage(scaleX, scaleY))
            {
                System.String imageFileName = System.String.Format("Slide_{0}.jpg", slide.SlideNumber);
                thumbnail.Save(imageFileName, Aspose.Slides.ImageFormat.Jpeg);
            }
        }

        // Save the presentation (required by authoring rules)
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}