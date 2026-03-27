using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        using (Presentation presentation = new Presentation(inputPath))
        {
            // Desired notes formatting
            float desiredFontHeight = 14f;
            NullableBool desiredBold = NullableBool.True;
            NullableBool desiredItalic = NullableBool.False;
            TextUnderlineType desiredUnderline = TextUnderlineType.Single;

            // Apply formatting to notes of each slide
            for (int i = 0; i < presentation.Slides.Count; i++)
            {
                ISlide slide = presentation.Slides[i];
                INotesSlideManager notesMgr = slide.NotesSlideManager;
                INotesSlide notesSlide = notesMgr.AddNotesSlide();

                ITextFrame notesTextFrame = notesSlide.NotesTextFrame;
                if (notesTextFrame == null)
                    continue;

                for (int p = 0; p < notesTextFrame.Paragraphs.Count; p++)
                {
                    IParagraph paragraph = notesTextFrame.Paragraphs[p];
                    for (int pt = 0; pt < paragraph.Portions.Count; pt++)
                    {
                        IPortion portion = paragraph.Portions[pt];
                        portion.PortionFormat.FontHeight = desiredFontHeight;
                        portion.PortionFormat.FontBold = desiredBold;
                        portion.PortionFormat.FontItalic = desiredItalic;
                        portion.PortionFormat.FontUnderline = desiredUnderline;
                    }
                }
            }

            // Save the modified presentation
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
    }
}