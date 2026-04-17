using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Add a rectangle AutoShape
                IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);

                // Add a TextFrame with initial text
                ITextFrame textFrame = autoShape.AddTextFrame("Sample text");

                // Access the first paragraph's first portion
                IParagraph paragraph = textFrame.Paragraphs[0];
                IPortion portion = paragraph.Portions[0];

                // Set the language ID to French
                portion.PortionFormat.LanguageId = "fr-FR";

                // Save the presentation
                string outputPath = "OutputPresentation.pptx";
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (System.IO.FileNotFoundException ex)
            {
                // Handle missing input file scenario
                Console.WriteLine("Input file not found: " + ex.Message);
            }
            catch (NotSupportedException ex)
            {
                // Format not supported
                // Format not supported.
                Console.WriteLine("Format not supported: " + ex.Message);
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}