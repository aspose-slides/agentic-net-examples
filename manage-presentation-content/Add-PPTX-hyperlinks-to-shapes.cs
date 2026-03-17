using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle AutoShape with text
            Aspose.Slides.IShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 150, 150, 150, 50);
            Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)shape;
            autoShape.AddTextFrame("Click here");
            Aspose.Slides.ITextFrame textFrame = autoShape.TextFrame;
            Aspose.Slides.IParagraph paragraph = textFrame.Paragraphs[0];
            Aspose.Slides.IPortion portion = paragraph.Portions[0];
            Aspose.Slides.IHyperlinkManager hyperlinkManager = portion.PortionFormat.HyperlinkManager;
            hyperlinkManager.SetExternalHyperlinkClick("https://www.example.com");

            // Add an image and set a hyperlink on the picture frame
            byte[] imageBytes = File.ReadAllBytes("image.png");
            Aspose.Slides.IPPImage img = presentation.Images.AddImage(imageBytes);
            Aspose.Slides.IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(Aspose.Slides.ShapeType.Rectangle, 10, 10, 100, 100, img);
            pictureFrame.HyperlinkManager.SetExternalHyperlinkClick("https://www.example.com/pic");

            // Save the presentation
            presentation.Save("HyperlinkPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}