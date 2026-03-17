using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace RemoveNotesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string dataDir = "path_to_presentation_directory\\";
            string inputFile = System.IO.Path.Combine(dataDir, "input.pptx");
            string outputFile = System.IO.Path.Combine(dataDir, "output.pptx");

            try
            {
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputFile))
                {
                    // Index of the slide from which notes will be removed (0‑based)
                    int slideIndex = 0;

                    if (slideIndex >= 0 && slideIndex < presentation.Slides.Count)
                    {
                        Aspose.Slides.INotesSlideManager notesManager = presentation.Slides[slideIndex].NotesSlideManager;
                        notesManager.RemoveNotesSlide();
                    }

                    // Save the modified presentation
                    presentation.Save(outputFile, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}