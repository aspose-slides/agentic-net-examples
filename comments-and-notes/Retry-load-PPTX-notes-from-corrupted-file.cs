// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Retry load PPTX notes from corrupted file using C#

//

// Description:

// Demonstrates how to implement a retry mechanism for loading a possibly

// corrupted PPTX file using Aspose.Slides for .NET, extract slide notes, and

// save the presentation. The example shows the required presentation-processing

// steps for PowerPoint files and produces the requested output in a standalone

// console application. Developers can use this pattern to automate PPTX workflows,

// handle corrupted files, and integrate presentation logic into .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Retry, Load, Corrupted File, Notes,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Implement retry logic when loading potentially corrupted PPTX files.

// - Extract and display notes from each slide in a presentation.

// - Build C# tools for PowerPoint presentation processing and recovery.

// - Save processed presentations after handling errors.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main(string[] args)

    {

        // Define input and output file paths

        string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "corrupted.pptx");

        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist.");

            return;

        }



        const int maxRetries = 3;

        int attempt = 0;

        Aspose.Slides.Presentation presentation = null;



        // Retry mechanism for loading a possibly corrupted presentation

        while (attempt < maxRetries)

        {

            try

            {

                presentation = new Aspose.Slides.Presentation(inputPath);

                break; // Loaded successfully

            }

            catch (Aspose.Slides.PptCorruptFileException ex)

            {

                attempt++;

                Console.WriteLine($"Attempt {attempt} failed: {ex.Message}");

                if (attempt >= maxRetries)

                {

                    Console.WriteLine("Maximum retry attempts reached. Unable to load presentation.");

                    return;

                }

                // Optionally wait before retrying

            }

            catch (Exception ex)

            {

                Console.WriteLine($"Unexpected error: {ex.Message}");

                return;

            }

        }



        // Process notes from each slide

        if (presentation != null)

        {

            for (int i = 0; i < presentation.Slides.Count; i++)

            {

                Aspose.Slides.INotesSlide notesSlide = presentation.Slides[i].NotesSlideManager.NotesSlide;

                if (notesSlide != null && notesSlide.NotesTextFrame != null)

                {

                    string notesText = notesSlide.NotesTextFrame.Text;

                    Console.WriteLine($"Slide {i + 1} notes: {notesText}");

                }

            }



            // Save the presentation before exiting

            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");

            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            presentation.Dispose();

        }

    }

}

