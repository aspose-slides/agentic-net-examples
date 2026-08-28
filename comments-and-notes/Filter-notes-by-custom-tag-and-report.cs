// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Filter notes by custom tag and report using C#

//

// Description:

// Demonstrates how to filter slide notes containing a specific custom tag

// (e.g., "[Compliance]") and generate a compliance report using Aspose.Slides for

// .NET. The example loads a PPTX file, scans each slide's notes for the tag,

// writes matching notes to a text report, and saves the (potentially unchanged)

// presentation.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Filter, Notes, Custom Tag, Report,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate extraction of tagged notes for compliance or review purposes.

// - Build C# utilities that generate reports from PowerPoint presentations.

// - Integrate note‑tag validation into .NET workflows before publishing.

// - Create audit trails of presentation content based on custom annotations.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace FilterNotesByTag

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input and output paths

            string inputPath = "input.pptx";

            string outputPath = "output.pptx";

            string reportPath = "ComplianceReport.txt";

            // Custom tag to filter notes

            string customTag = "[Compliance]";



            // Verify input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            try

            {

                // Load presentation

                using (Presentation pres = new Presentation(inputPath))

                {

                    // Prepare report

                    using (StreamWriter writer = new StreamWriter(reportPath, false))

                    {

                        writer.WriteLine("Compliance Report - Tagged Notes");

                        writer.WriteLine("Generated on: " + DateTime.Now);

                        writer.WriteLine();



                        // Iterate through slides

                        for (int i = 0; i < pres.Slides.Count; i++)

                        {

                            ISlide slide = pres.Slides[i];

                            // Access notes slide if it exists

                            INotesSlide notesSlide = slide.NotesSlideManager.NotesSlide;

                            if (notesSlide != null && notesSlide.NotesTextFrame != null)

                            {

                                string noteText = notesSlide.NotesTextFrame.Text;

                                if (!string.IsNullOrEmpty(noteText) && noteText.Contains(customTag))

                                {

                                    writer.WriteLine($"Slide {i + 1}:");

                                    writer.WriteLine(noteText);

                                    writer.WriteLine();

                                }

                            }

                        }

                    }



                    // Save presentation (even if unchanged) before exit

                    pres.Save(outputPath, SaveFormat.Pptx);

                }

            }

            catch (NotSupportedException)

            {

                // Format not supported

                Console.WriteLine("The provided file format is not supported.");

            }

            catch (Exception ex)

            {

                // General exception handling

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

