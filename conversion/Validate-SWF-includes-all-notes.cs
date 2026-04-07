using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputSwfPath = "output.swf";
        string tempPptxPath = "temp_output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        Aspose.Slides.Presentation presentation = null;
        try
        {
            presentation = new Aspose.Slides.Presentation(inputPath);
        }
        catch (Exception ex)
        {
            // Handle unsupported format or loading errors
            Console.WriteLine("Failed to load presentation: " + ex.Message);
            return;
        }

        // Add simple notes to each slide
        for (int i = 0; i < presentation.Slides.Count; i++)
        {
            Aspose.Slides.INotesSlideManager notesManager = presentation.Slides[i].NotesSlideManager;
            Aspose.Slides.INotesSlide notesSlide = notesManager.AddNotesSlide();
            notesSlide.NotesTextFrame.Text = "Notes for slide " + (i + 1);
        }

        // Save the presentation before exiting (as required)
        try
        {
            presentation.Save(tempPptxPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to save intermediate PPTX: " + ex.Message);
        }

        // Configure SWF options with notes and comments layout
        Aspose.Slides.Export.SwfOptions swfOptions = new Aspose.Slides.Export.SwfOptions();
        swfOptions.SlidesLayoutOptions = new Aspose.Slides.Export.NotesCommentsLayoutingOptions
        {
            NotesPosition = Aspose.Slides.Export.NotesPositions.BottomFull,
            CommentsPosition = Aspose.Slides.Export.CommentsPositions.Right
        };

        try
        {
            presentation.Save(outputSwfPath, Aspose.Slides.Export.SaveFormat.Swf, swfOptions);
            // Validation: In a real scenario, inspect the generated SWF to ensure notes are included.
            Console.WriteLine("SWF file saved with notes and comments layout.");
        }
        catch (Exception ex)
        {
            // Handle format not supported or other saving errors
            Console.WriteLine("Failed to save SWF: " + ex.Message);
        }
        finally
        {
            if (presentation != null)
            {
                presentation.Dispose();
            }
        }
    }
}