using System;
using Aspose.Slides;

namespace TableOfContentsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add a Table of Contents slide (first slide)
            Aspose.Slides.IAutoShape tocShape = presentation.Slides[0].Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle, 50, 30, 600, 50);
            tocShape.AddTextFrame("Table of Contents");
            tocShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 24;

            // Number of content slides to create
            int contentSlideCount = 3;

            // Loop to create content slides and corresponding TOC entries
            for (int i = 1; i <= contentSlideCount; i++)
            {
                // Add a new empty slide using the layout of the first slide
                Aspose.Slides.ISlide contentSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);

                // Add a title shape to the content slide
                Aspose.Slides.IAutoShape titleShape = contentSlide.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Rectangle, 100, 100, 400, 50);
                titleShape.AddTextFrame("Content of Slide " + i);
                titleShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 20;

                // Add an entry on the TOC slide for this content slide
                float entryY = 100 + (i - 1) * 30;
                Aspose.Slides.IAutoShape entryShape = presentation.Slides[0].Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Rectangle, 100, entryY, 300, 20);
                entryShape.AddTextFrame("Go to Slide " + i);
                entryShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 16;

                // Set internal hyperlink on the TOC entry to navigate to the content slide
                Aspose.Slides.IHyperlinkManager hyperlinkManager = entryShape.TextFrame.Paragraphs[0]
                    .Portions[0].PortionFormat.HyperlinkManager;
                hyperlinkManager.SetInternalHyperlinkClick(contentSlide);
            }

            // Save the presentation
            presentation.Save("TableOfContents.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}