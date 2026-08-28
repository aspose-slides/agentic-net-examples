// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Export PPTX notes to CSV with authors using C#

//

// Description:

// Demonstrates how to export notes from a PPTX file to a CSV file, including

// slide numbers, note text, and a placeholder for author identifiers using

// Aspose.Slides for .NET. The example loads a presentation, iterates through

// each slide's notes, writes the data to CSV, and saves an unchanged copy of

// the presentation.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Export, CSV, Notes, Authors,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate extraction of slide notes to CSV for reporting or analysis.

// - Build tools that need note text alongside slide identifiers.

// - Integrate note export functionality into .NET applications.

// - Prepare data for downstream processing where author information may be added.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        // Define data directory and ensure it exists

        string dataDir = "Data";

        if (!Directory.Exists(dataDir))

        {

            Directory.CreateDirectory(dataDir);

        }



        // Input presentation and output CSV paths

        string inputPath = Path.Combine(dataDir, "input.pptx");

        string outputCsv = Path.Combine(dataDir, "notes.csv");



        // Verify input file exists

        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist: " + inputPath);

            return;

        }



        try

        {

            // Load the presentation

            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))

            {

                // Create CSV file with header

                using (StreamWriter writer = new StreamWriter(outputCsv, false))

                {

                    writer.WriteLine("SlideNumber,NoteText,AuthorId");



                    // Iterate through slides and extract notes

                    for (int i = 0; i < presentation.Slides.Count; i++)

                    {

                        Aspose.Slides.INotesSlide notesSlide = presentation.Slides[i].NotesSlideManager.NotesSlide;

                        if (notesSlide != null && notesSlide.NotesTextFrame != null)

                        {

                            string noteText = notesSlide.NotesTextFrame.Text;

                            // Author identifier not available in notes; leave empty

                            string authorId = "";

                            // Escape double quotes in note text

                            string escapedNote = noteText.Replace("\"", "\"\"");

                            writer.WriteLine($"{i + 1},\"{escapedNote}\",{authorId}");

                        }

                    }

                }



                // Save the presentation (no modifications made) before exiting

                string savedPath = Path.Combine(dataDir, "output.pptx");

                presentation.Save(savedPath, SaveFormat.Pptx);

            }

        }

        catch (Exception ex)

        {

            // Handle any errors (e.g., unsupported format, I/O issues)

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}

