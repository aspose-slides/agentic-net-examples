using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        using (Presentation presentation = new Presentation(inputPath))
        {
            for (int i = 0; i < presentation.Slides.Count; i++)
            {
                INotesSlideManager notesManager = presentation.Slides[i].NotesSlideManager;
                notesManager.RemoveNotesSlide();
            }

            presentation.Save(outputPath, SaveFormat.Pptx);
        }
    }
}