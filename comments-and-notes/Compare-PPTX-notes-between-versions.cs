using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string firstPath = "PresentationV1.pptx";
        string secondPath = "PresentationV2.pptx";

        // Verify that both files exist
        if (!File.Exists(firstPath))
        {
            Console.WriteLine($"File not found: {firstPath}");
            return;
        }
        if (!File.Exists(secondPath))
        {
            Console.WriteLine($"File not found: {secondPath}");
            return;
        }

        try
        {
            using (Presentation firstPres = new Presentation(firstPath))
            using (Presentation secondPres = new Presentation(secondPath))
            {
                int slideCount = Math.Min(firstPres.Slides.Count, secondPres.Slides.Count);

                for (int i = 0; i < slideCount; i++)
                {
                    ISlide firstSlide = firstPres.Slides[i];
                    ISlide secondSlide = secondPres.Slides[i];

                    // Access notes via NotesSlideManager
                    INotesSlide firstNotes = firstSlide.NotesSlideManager.NotesSlide;
                    INotesSlide secondNotes = secondSlide.NotesSlideManager.NotesSlide;

                    string firstText = (firstNotes != null && firstNotes.NotesTextFrame != null) ? firstNotes.NotesTextFrame.Text : string.Empty;
                    string secondText = (secondNotes != null && secondNotes.NotesTextFrame != null) ? secondNotes.NotesTextFrame.Text : string.Empty;

                    if (!string.Equals(firstText, secondText))
                    {
                        Console.WriteLine($"Slide {i + 1} notes differ:");
                        Console.WriteLine($"  Version 1: {firstText}");
                        Console.WriteLine($"  Version 2: {secondText}");
                    }
                }

                // Save presentations before exiting (no modifications made)
                firstPres.Save("PresentationV1_saved.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                secondPres.Save("PresentationV2_saved.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}