using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace CustomizeNotesFormatting
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PPTX file path (first argument or default)
            string inputPath = args.Length > 0 ? args[0] : "input.pptx";

            // Verify that the file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            // Load the presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Iterate through all slides
                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

                    // Ensure the slide has a notes slide (create if missing)
                    Aspose.Slides.INotesSlide notesSlide = slide.NotesSlideManager.AddNotesSlide();

                    // Get the notes text frame
                    Aspose.Slides.ITextFrame notesTextFrame = notesSlide.NotesTextFrame;
                    if (notesTextFrame == null)
                    {
                        // If there is no text frame, create one
                        notesTextFrame = notesSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 500, 200).TextFrame;
                    }

                    // Apply formatting to each portion in the notes
                    for (int paraIndex = 0; paraIndex < notesTextFrame.Paragraphs.Count; paraIndex++)
                    {
                        Aspose.Slides.IParagraph paragraph = notesTextFrame.Paragraphs[paraIndex];
                        for (int portionIndex = 0; portionIndex < paragraph.Portions.Count; portionIndex++)
                        {
                            Aspose.Slides.IPortion portion = paragraph.Portions[portionIndex];
                            // Set desired formatting on the portion
                            portion.PortionFormat.FontHeight = 14f;
                            portion.PortionFormat.FontBold = NullableBool.True;
                            portion.PortionFormat.FontItalic = NullableBool.False;
                            portion.PortionFormat.FontUnderline = TextUnderlineType.Single;
                        }
                    }
                }

                // Save the modified presentation
                string outputPath = "output.pptx";
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                Console.WriteLine("Presentation saved to: " + outputPath);
            }
        }
    }
}