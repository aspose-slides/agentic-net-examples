using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Load an existing presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Assume the first shape is an AutoShape containing text
            Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)slide.Shapes[0];
            Aspose.Slides.ITextFrame textFrame = autoShape.TextFrame;

            // Get the first paragraph of the text frame
            Aspose.Slides.IParagraph paragraph = textFrame.Paragraphs[0];

            // Set default tab size (in points)
            paragraph.ParagraphFormat.DefaultTabSize = 72f;

            // Add a left-aligned tab at position 100 points
            paragraph.ParagraphFormat.Tabs.Add(new Aspose.Slides.Tab(100.0, Aspose.Slides.TabAlignment.Left));

            // Create PPTX save options using the factory
            Aspose.Slides.Export.SaveOptionsFactory optionsFactory = new Aspose.Slides.Export.SaveOptionsFactory();
            Aspose.Slides.Export.IPptxOptions pptxOptions = optionsFactory.CreatePptxOptions();

            // Save the modified presentation as PPTX
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx, pptxOptions);

            // Dispose the presentation
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}