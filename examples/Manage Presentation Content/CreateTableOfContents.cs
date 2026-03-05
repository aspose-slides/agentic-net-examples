using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Use the first slide as Table of Contents
        Aspose.Slides.ISlide tocSlide = presentation.Slides[0];

        // Add a title to the TOC slide
        Aspose.Slides.IShape titleShape = tocSlide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 20, 600, 50);
        Aspose.Slides.IAutoShape titleAutoShape = (Aspose.Slides.IAutoShape)titleShape;
        titleAutoShape.AddTextFrame("Table of Contents");
        titleAutoShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 32;

        // Define titles for content slides
        string[] slideTitles = new string[] { "Introduction", "Details", "Conclusion" };

        for (int i = 0; i < slideTitles.Length; i++)
        {
            // Add a new content slide based on the layout of the first slide
            Aspose.Slides.ISlide contentSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);

            // Add a title to the content slide
            Aspose.Slides.IShape contentTitleShape = contentSlide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 20, 600, 50);
            Aspose.Slides.IAutoShape contentTitleAutoShape = (Aspose.Slides.IAutoShape)contentTitleShape;
            contentTitleAutoShape.AddTextFrame(slideTitles[i]);
            contentTitleAutoShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 28;

            // Add an entry to the TOC slide
            Aspose.Slides.IShape entryShape = tocSlide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 70, 80 + i * 40, 500, 30);
            Aspose.Slides.IAutoShape entryAutoShape = (Aspose.Slides.IAutoShape)entryShape;
            entryAutoShape.AddTextFrame(slideTitles[i]);

            // Set hyperlink on the TOC entry to the corresponding content slide
            Aspose.Slides.ITextFrame entryTextFrame = entryAutoShape.TextFrame;
            Aspose.Slides.IParagraph paragraph = entryTextFrame.Paragraphs[0];
            Aspose.Slides.IPortion portion = paragraph.Portions[0];
            Aspose.Slides.IHyperlinkManager hyperlinkManager = portion.PortionFormat.HyperlinkManager;
            hyperlinkManager.SetInternalHyperlinkClick(contentSlide);
        }

        // Save the presentation
        presentation.Save("TableOfContents.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}