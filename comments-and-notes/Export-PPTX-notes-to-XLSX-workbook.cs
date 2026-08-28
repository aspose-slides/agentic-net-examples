// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Export PPTX notes to CSV file using C#

//

// Description:

// Demonstrates how to extract slide notes from a PPTX presentation and

// export them to a CSV file that can be opened in Microsoft Excel using

// Aspose.Slides for .NET. The example iterates through each slide, retrieves

// the associated notes text (if any), and writes each note as a separate

// quoted entry in the CSV output. This pattern can be used to automate notes

// extraction, generate reports, or integrate PowerPoint content into .NET

// applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Export, Notes, CSV, Excel,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate extraction of PPTX slide notes to CSV for reporting.

// - Build C# utilities for PowerPoint presentation analysis.

// - Convert presentation notes into a format consumable by Excel.

// - Validate and process slide notes before publishing or integration.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using System.Collections.Generic;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace ExportNotesToExcel

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input PowerPoint file path

            string presentationPath = "input.pptx";

            // Output CSV file path (Excel can open CSV)

            string csvPath = "NotesExport.csv";



            // Verify that the presentation file exists

            if (!File.Exists(presentationPath))

            {

                Console.WriteLine("Presentation file not found: " + presentationPath);

                return;

            }



            try

            {

                // Load the presentation

                using (Presentation presentation = new Presentation(presentationPath))

                {

                    // Collect notes from each slide

                    List<string> notesList = new List<string>();



                    for (int i = 0; i < presentation.Slides.Count; i++)

                    {

                        // Access the notes slide manager for the current slide

                        INotesSlideManager notesManager = presentation.Slides[i].NotesSlideManager;

                        // Retrieve the notes slide (may be null)

                        INotesSlide notesSlide = notesManager.NotesSlide;

                        if (notesSlide != null && notesSlide.NotesTextFrame != null)

                        {

                            string noteText = notesSlide.NotesTextFrame.Text;

                            notesList.Add(noteText);

                        }

                        else

                        {

                            // If no notes, add an empty string to keep cell order

                            notesList.Add(string.Empty);

                        }

                    }



                    // Write notes to CSV (each note in a separate cell/row)

                    using (StreamWriter writer = new StreamWriter(csvPath, false))

                    {

                        foreach (string note in notesList)

                        {

                            // Escape double quotes by doubling them

                            string escaped = note.Replace("\"", "\"\"");

                            writer.WriteLine("\"" + escaped + "\"");

                        }

                    }



                    // Save the presentation before exiting (no modifications made)

                    presentation.Save(presentationPath, SaveFormat.Pptx);

                }



                Console.WriteLine("Notes exported successfully to: " + csvPath);

            }

            catch (NotSupportedException)

            {

                // Format not supported

                // Comment: The provided file format is not supported by Aspose.Slides.

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

