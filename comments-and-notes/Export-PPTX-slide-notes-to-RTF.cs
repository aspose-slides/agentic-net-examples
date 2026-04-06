using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input presentation path
        string inputPath = "input.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

            // Iterate through each slide and export its notes to an RTF file
            for (int i = 0; i < pres.Slides.Count; i++)
            {
                // Get the notes slide (if it exists)
                Aspose.Slides.INotesSlide notesSlide = pres.Slides[i].NotesSlideManager.NotesSlide;
                if (notesSlide == null)
                {
                    continue; // No notes for this slide
                }

                // Retrieve the notes text (preserves formatting tags in the text)
                string notesText = notesSlide.NotesTextFrame.Text;

                // Simple RTF wrapper to preserve basic formatting tags
                string rtfContent = @"{\rtf1\ansi " + notesText + "}";

                // Define output RTF file name
                string outputRtfPath = $"Slide_{i + 1}_Notes.rtf";

                // Write the RTF content to file
                File.WriteAllText(outputRtfPath, rtfContent);
            }

            // Save the presentation before exiting
            pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (NotSupportedException)
        {
            // Comment: The requested format is not supported.
        }
        catch (Exception ex)
        {
            // Handle other exceptions (e.g., I/O errors)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}