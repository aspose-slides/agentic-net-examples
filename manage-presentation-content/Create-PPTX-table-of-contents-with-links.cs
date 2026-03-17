using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            using (var presentation = new Aspose.Slides.Presentation())
            {
                // Table of Contents slide (first slide)
                var tocSlide = presentation.Slides[0];
                var titleShape = tocSlide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 20, 600, 50);
                titleShape.TextFrame.Text = "Table of Contents";

                // Create content slides and corresponding TOC entries
                for (int i = 1; i <= 3; i++)
                {
                    // Add a new empty slide
                    var contentSlide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

                    // Add some placeholder text to the content slide
                    var contentShape = contentSlide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 100, 600, 50);
                    contentShape.TextFrame.Text = $"Content of Slide {i}";

                    // Add an entry to the TOC slide
                    var entryShape = tocSlide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 80 + i * 30, 600, 30);
                    entryShape.TextFrame.Text = $"Go to Slide {i + 1}";

                    // Set internal hyperlink on the TOC entry to navigate to the content slide
                    var portion = entryShape.TextFrame.Paragraphs[0].Portions[0];
                    portion.PortionFormat.HyperlinkManager.SetInternalHyperlinkClick(contentSlide);
                }

                // Save the presentation
                presentation.Save("HyperlinkedTOC.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}