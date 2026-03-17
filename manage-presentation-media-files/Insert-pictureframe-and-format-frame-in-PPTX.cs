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
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Load image from file and add to presentation resources
            using (FileStream imageStream = new FileStream("example.jpg", FileMode.Open, FileAccess.Read))
            {
                Aspose.Slides.IPPImage image = presentation.Images.AddImage(imageStream, Aspose.Slides.LoadingStreamBehavior.KeepLocked);

                // Insert picture frame onto the slide
                Aspose.Slides.IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(
                    Aspose.Slides.ShapeType.Rectangle,
                    100f, 100f, 400f, 300f,
                    image);

                // Apply formatting to the picture frame
                pictureFrame.Rotation = 15f;
                pictureFrame.LineFormat.Width = 5f;
                pictureFrame.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.Blue;
                pictureFrame.AlternativeText = "Sample picture";
            }

            // Save the presentation
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}