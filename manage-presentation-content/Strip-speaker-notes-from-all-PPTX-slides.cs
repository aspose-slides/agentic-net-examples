using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found.");
            return;
        }

        // Load the presentation from the input file
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
        {
            // Iterate through each slide and remove its notes slide
            for (int index = 0; index < presentation.Slides.Count; index++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[index];
                Aspose.Slides.INotesSlideManager notesManager = slide.NotesSlideManager;
                notesManager.RemoveNotesSlide();
            }

            // Save the presentation after removing all speaker notes
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}