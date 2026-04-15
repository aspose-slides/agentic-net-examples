using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string sourcePath = "source.pptx";
        string outputPath = "cloned_output.pptx";

        if (!File.Exists(sourcePath))
        {
            Console.WriteLine("Source file does not exist.");
            return;
        }

        try
        {
            // Load source presentation
            Presentation srcPres = new Presentation(sourcePath);
            // Create destination presentation
            Presentation destPres = new Presentation();

            // Clone slide from source to destination at specified position
            int insertPosition = 0; // position in destination
            int sourceSlideIndex = 0; // slide index in source
            ISlide clonedSlide = destPres.Slides.InsertClone(insertPosition, srcPres.Slides[sourceSlideIndex]);

            // Add translated notes to the cloned slide
            INotesSlideManager notesMgr = clonedSlide.NotesSlideManager;
            INotesSlide notesSlide = notesMgr.AddNotesSlide();
            notesSlide.NotesTextFrame.Text = "Translated notes text";

            // Save the destination presentation
            destPres.Save(outputPath, SaveFormat.Pptx);

            // Dispose presentations
            srcPres.Dispose();
            destPres.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}