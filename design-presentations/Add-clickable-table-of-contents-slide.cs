using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation (slide 0 will be the TOC)
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // ----- TOC slide (slide 0) -----
        Aspose.Slides.ISlide tocSlide = presentation.Slides[0];
        Aspose.Slides.IAutoShape tocShape = (Aspose.Slides.IAutoShape)tocSlide.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle, 50, 50, 600, 300);
        tocShape.AddTextFrame("Table of Contents");

        // ----- Section 1 slide -----
        Aspose.Slides.ISlide sectionSlide1 = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
        Aspose.Slides.IAutoShape titleShape1 = (Aspose.Slides.IAutoShape)sectionSlide1.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle, 50, 50, 600, 100);
        titleShape1.AddTextFrame("Section 1");

        // ----- Section 2 slide -----
        Aspose.Slides.ISlide sectionSlide2 = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
        Aspose.Slides.IAutoShape titleShape2 = (Aspose.Slides.IAutoShape)sectionSlide2.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle, 50, 50, 600, 100);
        titleShape2.AddTextFrame("Section 2");

        // ----- Section 3 slide -----
        Aspose.Slides.ISlide sectionSlide3 = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
        Aspose.Slides.IAutoShape titleShape3 = (Aspose.Slides.IAutoShape)sectionSlide3.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle, 50, 50, 600, 100);
        titleShape3.AddTextFrame("Section 3");

        // ----- Add TOC entries with internal hyperlinks -----
        // Entry for Section 1
        tocShape.TextFrame.Paragraphs.Add(new Aspose.Slides.Paragraph());
        tocShape.TextFrame.Paragraphs[1].Portions.Add(new Aspose.Slides.Portion());
        tocShape.TextFrame.Paragraphs[1].Portions[0].Text = "Section 1";
        Aspose.Slides.IHyperlinkManager hlManager1 = tocShape.TextFrame.Paragraphs[1].Portions[0].PortionFormat.HyperlinkManager;
        hlManager1.SetInternalHyperlinkClick(sectionSlide1);

        // Entry for Section 2
        tocShape.TextFrame.Paragraphs.Add(new Aspose.Slides.Paragraph());
        tocShape.TextFrame.Paragraphs[2].Portions.Add(new Aspose.Slides.Portion());
        tocShape.TextFrame.Paragraphs[2].Portions[0].Text = "Section 2";
        Aspose.Slides.IHyperlinkManager hlManager2 = tocShape.TextFrame.Paragraphs[2].Portions[0].PortionFormat.HyperlinkManager;
        hlManager2.SetInternalHyperlinkClick(sectionSlide2);

        // Entry for Section 3
        tocShape.TextFrame.Paragraphs.Add(new Aspose.Slides.Paragraph());
        tocShape.TextFrame.Paragraphs[3].Portions.Add(new Aspose.Slides.Portion());
        tocShape.TextFrame.Paragraphs[3].Portions[0].Text = "Section 3";
        Aspose.Slides.IHyperlinkManager hlManager3 = tocShape.TextFrame.Paragraphs[3].Portions[0].PortionFormat.HyperlinkManager;
        hlManager3.SetInternalHyperlinkClick(sectionSlide3);

        // Save the presentation
        string outputPath = "TableOfContents.pptx";
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Dispose the presentation
        presentation.Dispose();
    }
}