// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Export notes to LaTeX document using C#

//

// Description:

// Demonstrates how to export slide notes from a PowerPoint presentation to a

// LaTeX document using C# and Aspose.Slides for .NET. The example loads a PPTX

// file, iterates through its sections and slides, extracts plain‑text notes,

// and writes them into a properly formatted LaTeX file. It also shows basic

// error handling and how to preserve presentation hierarchy in the output.

// Developers can use this pattern to automate notes extraction, generate

// documentation, or integrate PowerPoint processing into .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Export, Notes, LaTeX, Document,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate export of slide notes to a LaTeX document.

// - Build C# utilities for extracting and formatting PowerPoint notes.

// - Generate LaTeX‑based documentation or handouts from presentations.

// - Validate and review presentation notes before publishing or integration.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace ExportNotesToLatex

{

    class Program

    {

        static void Main(string[] args)

        {

            // Define input and output paths

            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");

            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "notes.tex");



            // Check if the input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file not found: " + inputPath);

                return;

            }



            try

            {

                // Load the presentation

                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))

                {

                    // Create LaTeX file

                    using (StreamWriter writer = new StreamWriter(outputPath, false))

                    {

                        // LaTeX document preamble

                        writer.WriteLine("\\documentclass{article}");

                        writer.WriteLine("\\usepackage[utf8]{inputenc}");

                        writer.WriteLine("\\begin{document}");



                        // Iterate through sections to preserve hierarchy

                        for (int secIdx = 0; secIdx < presentation.Sections.Count; secIdx++)

                        {

                            Aspose.Slides.ISection section = presentation.Sections[secIdx];

                            // Write section title

                            writer.WriteLine("\\section{" + section.Name + "}");

                        }



                        // Iterate through slides and export notes

                        for (int slideIdx = 0; slideIdx < presentation.Slides.Count; slideIdx++)

                        {

                            Aspose.Slides.ISlide slide = presentation.Slides[slideIdx];

                            Aspose.Slides.INotesSlideManager notesManager = slide.NotesSlideManager;

                            Aspose.Slides.INotesSlide notesSlide = notesManager.NotesSlide;



                            // Write slide heading

                            writer.WriteLine("\\subsection{Slide " + (slideIdx + 1) + " Notes}");



                            if (notesSlide != null && notesSlide.NotesTextFrame != null && notesSlide.NotesTextFrame.Text != null)

                            {

                                // Export plain text notes

                                writer.WriteLine(notesSlide.NotesTextFrame.Text);

                            }

                            else

                            {

                                writer.WriteLine("% No notes for this slide");

                            }



                            writer.WriteLine(); // Add an empty line

                        }



                        // End of LaTeX document

                        writer.WriteLine("\\end{document}");

                    }



                    // Save the presentation before exiting (as per requirement)

                    presentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);

                }



                Console.WriteLine("Notes exported to LaTeX file: " + outputPath);

            }

            catch (NotSupportedException)

            {

                // Format not supported

                // The presentation format is not supported for the requested operation.

                Console.WriteLine("The file format is not supported for this operation.");

            }

            catch (Exception ex)

            {

                // General exception handling

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

