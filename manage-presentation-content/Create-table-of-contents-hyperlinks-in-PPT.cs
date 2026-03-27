using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace HyperlinkedTOCExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Output file path
            string outputPath = "HyperlinkedTOC.pptx";

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the default first slide to serve as Table of Contents (TOC)
            Aspose.Slides.ISlide tocSlide = presentation.Slides[0];

            // Add a title to the TOC slide
            Aspose.Slides.IAutoShape tocTitle = tocSlide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle, 50, 20, 600, 50);
            tocTitle.AddTextFrame("Table of Contents");
            tocTitle.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 24;

            // Number of content slides to create
            int contentSlideCount = 3;

            // Loop to create content slides and corresponding TOC entries
            for (int i = 1; i <= contentSlideCount; i++)
            {
                // Add a new empty slide (using the layout of the first slide)
                Aspose.Slides.ISlide contentSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);

                // Add a title shape to the content slide
                Aspose.Slides.IAutoShape contentTitle = contentSlide.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Rectangle, 50, 100, 600, 50);
                string slideTitleText = $"Slide {i} Title";
                contentTitle.AddTextFrame(slideTitleText);
                contentTitle.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 20;

                // Add an entry on the TOC slide linking to this content slide
                Aspose.Slides.IAutoShape tocEntry = tocSlide.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Rectangle, 70, 80 + (i * 40), 500, 30);
                string tocEntryText = $"Go to {slideTitleText}";
                tocEntry.AddTextFrame(tocEntryText);
                // Set hyperlink to the target slide
                tocEntry.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick =
                    new Aspose.Slides.Hyperlink(contentSlide);
                // Optional tooltip and font size
                tocEntry.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick.Tooltip = $"Navigate to Slide {i}";
                tocEntry.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 16;
            }

            // Save the presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}