using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                for (int i = 0; i < presentation.Slides.Count; i++)
                {
                    Aspose.Slides.INotesSlideManager notesMgr = presentation.Slides[i].NotesSlideManager;
                    Aspose.Slides.INotesSlide notesSlide = notesMgr.NotesSlide;
                    if (notesSlide == null)
                    {
                        notesSlide = notesMgr.AddNotesSlide();
                    }

                    string title = "";
                    if (presentation.Slides[i].Shapes.Count > 0 && presentation.Slides[i].Shapes[0] is Aspose.Slides.IAutoShape)
                    {
                        Aspose.Slides.IAutoShape shape = (Aspose.Slides.IAutoShape)presentation.Slides[i].Shapes[0];
                        if (shape.TextFrame != null)
                        {
                            title = shape.TextFrame.Text;
                        }
                    }

                    notesSlide.NotesTextFrame.Text = "Notes for slide " + (i + 1) + ": " + title;
                }

                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Aspose.Slides.PptxEditException ex)
        {
            Console.WriteLine("Presentation edit error: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}