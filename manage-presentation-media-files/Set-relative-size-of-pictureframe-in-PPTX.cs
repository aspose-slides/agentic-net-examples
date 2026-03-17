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
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[0];

                    using (FileStream imageStream = new FileStream("sample.jpg", FileMode.Open, FileAccess.Read))
                    {
                        Aspose.Slides.IPPImage image = presentation.Images.AddImage(imageStream);

                        Aspose.Slides.IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(
                            Aspose.Slides.ShapeType.Rectangle,
                            100f,
                            100f,
                            400f,
                            300f,
                            image);

                        pictureFrame.RelativeScaleWidth = 0.8f;   // 80% of original width
                        pictureFrame.RelativeScaleHeight = 0.6f; // 60% of original height
                    }

                    presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}