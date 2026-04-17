using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace EditHyperlinkTooltip
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                using (Presentation presentation = new Presentation())
                {
                    // Add a new empty slide based on the first layout slide
                    ISlide newSlide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

                    // Add a new section starting with the new slide
                    ISection section = presentation.Sections.AddSection("My Section", newSlide);

                    // Add a rectangle auto shape to the slide
                    IAutoShape shape = (IAutoShape)presentation.Slides[0].Shapes.AddAutoShape(
                        ShapeType.Rectangle, 150, 150, 300, 50, false);

                    // Add a text frame to the shape
                    shape.AddTextFrame("Click Here");

                    // Create a mutable hyperlink pointing to an external URL
                    Hyperlink hyperlink = new Hyperlink("http://example.com");

                    // Assign the hyperlink to the first portion of the first paragraph
                    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = hyperlink;

                    // Build tooltip text with slide number and section title
                    string tooltipText = "Slide " + newSlide.SlideNumber + " - " + section.Name;

                    // Set the tooltip on the hyperlink
                    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick.Tooltip = tooltipText;

                    // Save the presentation
                    presentation.Save("EditedHyperlinkTooltip.pptx", SaveFormat.Pptx);
                }
            }
            catch (PptxEditException ex)
            {
                // Handle presentation edit errors
                Console.WriteLine("Error editing presentation: " + ex.Message);
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., unsupported format, file I/O)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}