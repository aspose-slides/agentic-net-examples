using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                foreach (Aspose.Slides.ISlide slide in presentation.Slides)
                {
                    Aspose.Slides.INotesSlideManager notesMgr = slide.NotesSlideManager;
                    Aspose.Slides.INotesSlide notesSlide = notesMgr.NotesSlide;
                    if (notesSlide == null)
                    {
                        notesSlide = notesMgr.AddNotesSlide();
                    }

                    Aspose.Slides.ITextFrame notesTextFrame = notesSlide.NotesTextFrame;
                    if (notesTextFrame != null)
                    {
                        foreach (Aspose.Slides.IParagraph paragraph in notesTextFrame.Paragraphs)
                        {
                            // Apply custom paragraph spacing
                            paragraph.ParagraphFormat.SpaceWithin = 0.5f;   // 50% line spacing
                            paragraph.ParagraphFormat.SpaceBefore = 0.2f;   // 20% before
                            paragraph.ParagraphFormat.SpaceAfter = 0.2f;    // 20% after
                        }
                    }
                }

                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Aspose.Slides.PptxUnsupportedFormatException)
        {
            // Format not supported
        }
        catch (Aspose.Slides.PptUnsupportedFormatException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}