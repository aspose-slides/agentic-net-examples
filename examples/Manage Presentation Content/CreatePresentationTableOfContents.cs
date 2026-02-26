using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add three content slides
        Aspose.Slides.ISlide slide1 = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
        Aspose.Slides.IShape shape1 = slide1.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 100, 600, 50);
        ((Aspose.Slides.IAutoShape)shape1).AddTextFrame("Slide 1 Content");

        Aspose.Slides.ISlide slide2 = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
        Aspose.Slides.IShape shape2 = slide2.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 100, 600, 50);
        ((Aspose.Slides.IAutoShape)shape2).AddTextFrame("Slide 2 Content");

        Aspose.Slides.ISlide slide3 = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
        Aspose.Slides.IShape shape3 = slide3.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 100, 600, 50);
        ((Aspose.Slides.IAutoShape)shape3).AddTextFrame("Slide 3 Content");

        // The first slide will serve as the Table of Contents (TOC)
        Aspose.Slides.ISlide tocSlide = presentation.Slides[0];

        // Add a title to the TOC slide
        Aspose.Slides.IShape titleShape = tocSlide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 30, 600, 50);
        ((Aspose.Slides.IAutoShape)titleShape).AddTextFrame("Table of Contents");

        // Add TOC entry linking to Slide 1
        Aspose.Slides.IShape entry1 = tocSlide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 500, 30);
        Aspose.Slides.IAutoShape autoEntry1 = (Aspose.Slides.IAutoShape)entry1;
        autoEntry1.AddTextFrame("Go to Slide 1");
        Aspose.Slides.IParagraph para1 = autoEntry1.TextFrame.Paragraphs[0];
        Aspose.Slides.IPortion portion1 = para1.Portions[0];
        Aspose.Slides.IHyperlinkManager hlManager1 = portion1.PortionFormat.HyperlinkManager;
        hlManager1.SetInternalHyperlinkClick(slide1);

        // Add TOC entry linking to Slide 2
        Aspose.Slides.IShape entry2 = tocSlide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 150, 500, 30);
        Aspose.Slides.IAutoShape autoEntry2 = (Aspose.Slides.IAutoShape)entry2;
        autoEntry2.AddTextFrame("Go to Slide 2");
        Aspose.Slides.IParagraph para2 = autoEntry2.TextFrame.Paragraphs[0];
        Aspose.Slides.IPortion portion2 = para2.Portions[0];
        Aspose.Slides.IHyperlinkManager hlManager2 = portion2.PortionFormat.HyperlinkManager;
        hlManager2.SetInternalHyperlinkClick(slide2);

        // Add TOC entry linking to Slide 3
        Aspose.Slides.IShape entry3 = tocSlide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 200, 500, 30);
        Aspose.Slides.IAutoShape autoEntry3 = (Aspose.Slides.IAutoShape)entry3;
        autoEntry3.AddTextFrame("Go to Slide 3");
        Aspose.Slides.IParagraph para3 = autoEntry3.TextFrame.Paragraphs[0];
        Aspose.Slides.IPortion portion3 = para3.Portions[0];
        Aspose.Slides.IHyperlinkManager hlManager3 = portion3.PortionFormat.HyperlinkManager;
        hlManager3.SetInternalHyperlinkClick(slide3);

        // Save the presentation
        presentation.Save("TableOfContents.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}