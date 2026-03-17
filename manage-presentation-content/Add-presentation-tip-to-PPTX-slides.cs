using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AddPresentationTip
{
    class Program
    {
        static void Main(string[] args)
        {
            Aspose.Slides.Presentation presentation = null;
            try
            {
                // Define output directory
                string outDir = "Output";
                if (!Directory.Exists(outDir))
                {
                    Directory.CreateDirectory(outDir);
                }

                // Create a new presentation
                presentation = new Aspose.Slides.Presentation();

                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a rectangle shape to hold the tip text
                Aspose.Slides.IAutoShape autoShape = slide.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100);

                // Access the text frame of the shape
                Aspose.Slides.ITextFrame textFrame = autoShape.TextFrame;

                // Remove any default paragraph
                if (textFrame.Paragraphs.Count > 0)
                {
                    textFrame.Paragraphs.RemoveAt(0);
                }

                // Create a new paragraph
                Aspose.Slides.Paragraph paragraph = new Aspose.Slides.Paragraph();

                // Create a portion with the tip text
                Aspose.Slides.IPortion portion = new Aspose.Slides.Portion();
                portion.Text = "Tip: Review the presentation before sharing.";

                // Add the portion to the paragraph and the paragraph to the text frame
                paragraph.Portions.Add(portion);
                textFrame.Paragraphs.Add(paragraph);

                // Save the presentation in PPTX format
                string outPath = Path.Combine(outDir, "PresentationWithTip.pptx");
                presentation.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                // Ensure the presentation is disposed
                if (presentation != null)
                {
                    presentation.Dispose();
                }
            }
        }
    }
}