using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            try
            {
                // Load the existing presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a rectangle AutoShape to host the text
                Aspose.Slides.IAutoShape autoShape = slide.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Rectangle, 100, 100, 300, 50);

                // Add an empty TextFrame to the shape
                Aspose.Slides.ITextFrame textFrame = autoShape.AddTextFrame(" ");

                // Create a new paragraph
                Aspose.Slides.IParagraph newParagraph = new Aspose.Slides.Paragraph();
                // Optionally set paragraph text
                newParagraph.Text = "Inserted paragraph using Aspose.Slides";

                // Insert the new paragraph into the TextFrame's paragraph collection
                // (AddParagraph method does not exist; using Add instead)
                textFrame.Paragraphs.Add(newParagraph);

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                presentation.Dispose();
                Console.WriteLine("Presentation saved successfully to " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}