using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first master slide
        Aspose.Slides.IMasterSlide masterSlide = presentation.Masters[0];

        // Set the background of the master slide to a solid light blue color
        masterSlide.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
        masterSlide.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        masterSlide.Background.FillFormat.SolidFillColor.Color = Color.LightBlue;

        // Add an image to the master slide
        Aspose.Slides.IPPImage image = presentation.Images.AddImage(System.IO.File.ReadAllBytes("image.png"));
        masterSlide.Shapes.AddPictureFrame(Aspose.Slides.ShapeType.Rectangle, 50, 50, 200, 150, image);

        // Save the presentation
        presentation.Save("MasterSlideExample.pptx", SaveFormat.Pptx);
    }
}