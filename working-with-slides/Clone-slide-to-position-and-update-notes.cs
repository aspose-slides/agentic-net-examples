using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.AI;

namespace CloneSlideWithNotes
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourcePath = "source.pptx";
            string destinationPath = "destination.pptx";
            string outputPath = "result.pptx";

            if (!File.Exists(sourcePath))
            {
                Console.WriteLine("Source file does not exist: " + sourcePath);
                return;
            }

            try
            {
                // Load source presentation
                Aspose.Slides.Presentation srcPres = new Aspose.Slides.Presentation(sourcePath);
                // Create destination presentation
                Aspose.Slides.Presentation destPres = new Aspose.Slides.Presentation();

                // Clone slide from source to destination at specific position (index 1)
                int insertPosition = 1; // zero‑based index where the slide will be inserted
                int sourceSlideIndex = 0; // index of slide to clone in source presentation
                destPres.Slides.InsertClone(insertPosition, srcPres.Slides[sourceSlideIndex]);

                // Access the newly cloned slide
                Aspose.Slides.ISlide clonedSlide = destPres.Slides[insertPosition];

                // Add notes to the cloned slide
                Aspose.Slides.INotesSlideManager notesManager = clonedSlide.NotesSlideManager;
                Aspose.Slides.INotesSlide notesSlide = notesManager.AddNotesSlide();
                notesSlide.NotesTextFrame.Text = "Original notes text";

                // Translate the entire presentation (including notes) to French
                // SlidesAIAgent requires an IAIWebClient; passing null for simplicity (replace with actual client if needed)
                Aspose.Slides.AI.SlidesAIAgent aiAgent = new Aspose.Slides.AI.SlidesAIAgent(null);
                aiAgent.Translate(destPres, "fr");

                // Save the destination presentation
                destPres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

                // Dispose presentations
                srcPres.Dispose();
                destPres.Dispose();

                Console.WriteLine("Presentation processed and saved to: " + outputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}