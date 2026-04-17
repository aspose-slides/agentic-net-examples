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