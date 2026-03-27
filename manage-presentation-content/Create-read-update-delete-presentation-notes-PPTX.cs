using System;
using System.IO;
using Aspose.Slides.Export;

namespace NotesManagementExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define data directory
            string dataDir = "Data" + Path.DirectorySeparatorChar;
            if (!Directory.Exists(dataDir))
                Directory.CreateDirectory(dataDir);

            // Input presentation path
            string inputPath = Path.Combine(dataDir, "sample.pptx");
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            // -----------------------------------------------------------------
            // 1. Add notes to the first slide and save
            // -----------------------------------------------------------------
            string addNotesPath = Path.Combine(dataDir, "AddNotes.pptx");
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
            {
                Aspose.Slides.INotesSlideManager mgr = pres.Slides[0].NotesSlideManager;
                Aspose.Slides.INotesSlide noteSlide = mgr.AddNotesSlide();
                noteSlide.NotesTextFrame.Text = "Initial notes for slide 1.";
                pres.Save(addNotesPath, SaveFormat.Pptx);
            }

            // -----------------------------------------------------------------
            // 2. Update the existing notes text and save
            // -----------------------------------------------------------------
            string updateNotesPath = Path.Combine(dataDir, "UpdateNotes.pptx");
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(addNotesPath))
            {
                Aspose.Slides.INotesSlideManager mgr = pres.Slides[0].NotesSlideManager;
                if (mgr.NotesSlide != null)
                {
                    mgr.NotesSlide.NotesTextFrame.Text = "Updated notes for slide 1.";
                }
                pres.Save(updateNotesPath, SaveFormat.Pptx);
            }

            // -----------------------------------------------------------------
            // 3. Delete the notes slide from the first slide and save
            // -----------------------------------------------------------------
            string deleteNotesPath = Path.Combine(dataDir, "DeleteNotes.pptx");
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(updateNotesPath))
            {
                Aspose.Slides.INotesSlideManager mgr = pres.Slides[0].NotesSlideManager;
                mgr.RemoveNotesSlide();
                pres.Save(deleteNotesPath, SaveFormat.Pptx);
            }

            Console.WriteLine("Notes management operations completed.");
        }
    }
}