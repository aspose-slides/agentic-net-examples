using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

namespace ApplyCustomNotesStyle
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.pptx";
                string outputPath = "output.pptx";

                using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
                {
                    // Apply the same notes formatting to every slide
                    for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
                    {
                        // Ensure a notes slide exists
                        Aspose.Slides.INotesSlide notesSlide = pres.Slides[slideIndex].NotesSlideManager.AddNotesSlide();

                        // Get the notes text frame (created by AddNotesSlide)
                        Aspose.Slides.ITextFrame notesTextFrame = notesSlide.NotesTextFrame;

                        // Clear any existing content
                        notesTextFrame.Paragraphs.Clear();

                        // Create a new paragraph
                        Aspose.Slides.IParagraph paragraph = new Aspose.Slides.Paragraph();
                        notesTextFrame.Paragraphs.Add(paragraph);

                        // Add a portion with sample note text
                        Aspose.Slides.IPortion portion = new Aspose.Slides.Portion("This is a custom note.");
                        paragraph.Portions.Add(portion);

                        // Apply consistent formatting
                        portion.PortionFormat.FontHeight = 14f;
                        portion.PortionFormat.FontBold = Aspose.Slides.NullableBool.True;
                        portion.PortionFormat.FontItalic = Aspose.Slides.NullableBool.True;
                        portion.PortionFormat.FontUnderline = Aspose.Slides.TextUnderlineType.Single;
                        portion.PortionFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                        portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.DarkGreen;
                    }

                    // Save the presentation with the updated notes
                    pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}