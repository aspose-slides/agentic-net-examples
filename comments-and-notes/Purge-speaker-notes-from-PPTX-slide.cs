using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: program <input.pptx> <slideIndex>");
            return;
        }

        string inputPath = args[0];
        int slideIndex;
        if (!int.TryParse(args[1], out slideIndex))
        {
            Console.WriteLine("Invalid slide index.");
            return;
        }

        try
        {
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                if (slideIndex < 0 || slideIndex >= presentation.Slides.Count)
                {
                    Console.WriteLine("Slide index out of range.");
                }
                else
                {
                    Aspose.Slides.INotesSlideManager notesMgr = presentation.Slides[slideIndex].NotesSlideManager;
                    notesMgr.RemoveNotesSlide();
                }

                string outputPath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(inputPath), "NoNotes_" + System.IO.Path.GetFileName(inputPath));
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                Console.WriteLine("Presentation saved to " + outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}