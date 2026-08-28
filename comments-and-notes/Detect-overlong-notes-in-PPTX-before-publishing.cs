// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Detect overlong notes in PPTX before publishing using C#

//

// Description:

// Demonstrates how to scan a PowerPoint presentation for notes slides that

// contain more lines than a defined maximum, reporting any overlong notes.

// The example loads a PPTX file with Aspose.Slides for .NET, checks each notes

// slide, writes a warning to the console for slides that exceed the limit, and

// saves the (unmodified) presentation. This pattern can be used to enforce

// note length guidelines before publishing or distribution.

//

// Keywords:

// C#, Aspose.Slides, PowerPoint, PPTX, Notes, Overlong, Validation, Presentation Processing, .NET

//

// Use Cases:

// - Validate that presenter notes do not exceed a line count limit before release.

// - Integrate notes length checks into automated PowerPoint publishing pipelines.

// - Build command‑line tools for PowerPoint quality assurance.

// - Ensure compliance with corporate presentation standards.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace DetectOverlongNotes

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input and output file paths

            string inputPath = "input.pptx";

            string outputPath = "output.pptx";



            // Maximum allowed number of lines in a notes slide

            int maxLines = 5;



            // Verify that the input file exists

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

                    // Iterate through all slides

                    for (int i = 0; i < presentation.Slides.Count; i++)

                    {

                        Aspose.Slides.ISlide slide = presentation.Slides[i];



                        // Access the notes slide (if any)

                        Aspose.Slides.INotesSlide notesSlide = slide.NotesSlideManager.NotesSlide;

                        if (notesSlide != null)

                        {

                            // Retrieve the notes text

                            string notesText = notesSlide.NotesTextFrame.Text;



                            // Count the number of lines in the notes

                            int lineCount = notesText.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None).Length;



                            // Flag slides with notes exceeding the maximum line count

                            if (lineCount > maxLines)

                            {

                                Console.WriteLine($"Slide {i + 1} has {lineCount} lines in notes (exceeds {maxLines}).");

                            }

                        }

                    }



                    // Save the (potentially modified) presentation before exiting

                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

                }

            }

            // Handle unsupported file format

            catch (NotSupportedException)

            {

                // Format not supported

                Console.WriteLine("The file format is not supported.");

            }

            // General exception handling

            catch (Exception ex)

            {

                Console.WriteLine("Error: " + ex.Message);

            }

        }

    }

}

