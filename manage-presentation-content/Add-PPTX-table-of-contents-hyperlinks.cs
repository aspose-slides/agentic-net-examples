using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace TableOfContentsExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Get the first slide to serve as Table of Contents
                Aspose.Slides.ISlide tocSlide = presentation.Slides[0];

                // Define section titles
                string[] sectionTitles = new string[] { "Introduction", "Details", "Conclusion" };

                // Keep references to the first slide of each section
                List<Aspose.Slides.ISlide> sectionFirstSlides = new List<Aspose.Slides.ISlide>();

                // Create a slide for each section and add the section to the presentation
                foreach (string title in sectionTitles)
                {
                    // Add a new empty slide using the default layout
                    Aspose.Slides.ISlide sectionSlide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

                    // Add the section, linking it to the newly created slide
                    Aspose.Slides.ISection section = presentation.Sections.AddSection(title, sectionSlide);

                    // Store the first slide of the section for hyperlinking
                    sectionFirstSlides.Add(sectionSlide);

                    // Add placeholder text to the section slide
                    Aspose.Slides.IAutoShape placeholder = (Aspose.Slides.IAutoShape)sectionSlide.Shapes.AddAutoShape(
                        Aspose.Slides.ShapeType.Rectangle, 50, 100, 600, 300);
                    placeholder.AddTextFrame(title + " Content");
                }

                // Add entries to the Table of Contents slide with hyperlinks to each section
                float startY = 100f;
                float spacing = 40f;
                for (int i = 0; i < sectionTitles.Length; i++)
                {
                    // Create a textbox shape for the TOC entry
                    Aspose.Slides.IAutoShape tocEntry = (Aspose.Slides.IAutoShape)tocSlide.Shapes.AddAutoShape(
                        Aspose.Slides.ShapeType.Rectangle, 50, startY + i * spacing, 400, 30);
                    tocEntry.AddTextFrame(sectionTitles[i]);

                    // Set internal hyperlink on the text portion to navigate to the corresponding section slide
                    Aspose.Slides.ITextFrame textFrame = tocEntry.TextFrame;
                    Aspose.Slides.IParagraph paragraph = textFrame.Paragraphs[0];
                    Aspose.Slides.IPortion portion = paragraph.Portions[0];
                    Aspose.Slides.IHyperlinkManager hyperlinkManager = portion.PortionFormat.HyperlinkManager;
                    hyperlinkManager.SetInternalHyperlinkClick(sectionFirstSlides[i]);
                }

                // Save the presentation
                presentation.Save("TableOfContents.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}