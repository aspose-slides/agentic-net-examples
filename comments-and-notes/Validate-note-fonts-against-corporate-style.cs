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
        string corporateFont = "Arial";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            using (Presentation presentation = new Presentation(inputPath))
            {
                bool allNotesConform = true;

                for (int i = 0; i < presentation.Slides.Count; i++)
                {
                    ISlide slide = presentation.Slides[i];
                    INotesSlide notesSlide = slide.NotesSlideManager.NotesSlide;

                    if (notesSlide != null && notesSlide.NotesTextFrame != null)
                    {
                        foreach (IParagraph paragraph in notesSlide.NotesTextFrame.Paragraphs)
                        {
                            foreach (IPortion portion in paragraph.Portions)
                            {
                                string fontName = portion.PortionFormat.LatinFont?.FontName;
                                if (!string.Equals(fontName, corporateFont, StringComparison.OrdinalIgnoreCase))
                                {
                                    allNotesConform = false;
                                    Console.WriteLine($"Slide {i + 1} note uses non‑corporate font: {fontName}");
                                }
                            }
                        }
                    }
                }

                if (!allNotesConform)
                {
                    Console.WriteLine("Presentation contains notes with non‑corporate fonts. Export aborted.");
                    return;
                }

                presentation.Save(outputPath, SaveFormat.Pptx);
                Console.WriteLine("Presentation exported successfully.");
            }
        }
        catch (Aspose.Slides.PptxUnsupportedFormatException)
        {
            // Format not supported
            Console.WriteLine("The file format is not supported.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}