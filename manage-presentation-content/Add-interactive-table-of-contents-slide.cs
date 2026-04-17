using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace TableOfContentsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add Table of Contents slide (first slide)
            Aspose.Slides.ISlide tocSlide = presentation.Slides[0];
            Aspose.Slides.IAutoShape tocTitle = (Aspose.Slides.IAutoShape)tocSlide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle, 50, 20, 600, 50);
            tocTitle.AddTextFrame("Table of Contents");

            // Create section slides and collect them
            Aspose.Slides.ISlide[] sectionSlides = new Aspose.Slides.ISlide[3];
            for (int i = 0; i < 3; i++)
            {
                // Add a new empty slide
                Aspose.Slides.ISlide sectionSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
                sectionSlides[i] = sectionSlide;

                // Add a title to the section slide
                Aspose.Slides.IAutoShape sectionTitle = (Aspose.Slides.IAutoShape)sectionSlide.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Rectangle, 50, 50, 600, 50);
                sectionTitle.AddTextFrame("Section " + (i + 1));
            }

            // Add hyperlinks on the TOC slide pointing to each section
            for (int i = 0; i < sectionSlides.Length; i++)
            {
                // Position each entry vertically
                float yPosition = 100 + i * 60;

                Aspose.Slides.IAutoShape linkShape = (Aspose.Slides.IAutoShape)tocSlide.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Rectangle, 50, yPosition, 600, 40);
                linkShape.AddTextFrame("Go to Section " + (i + 1));

                // Set internal hyperlink to the corresponding section slide
                Aspose.Slides.IHyperlinkManager hyperlinkManager = linkShape.TextFrame.Paragraphs[0]
                    .Portions[0].PortionFormat.HyperlinkManager;
                hyperlinkManager.SetInternalHyperlinkClick(sectionSlides[i]);
            }

            // Save the presentation with exception handling for unsupported formats
            try
            {
                presentation.Save("TableOfContents.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Format not supported or other saving error
                Console.WriteLine("Error saving presentation: " + ex.Message);
            }
            finally
            {
                // Ensure resources are released
                presentation.Dispose();
            }
        }
    }
}