// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Detect and merge consecutive duplicate PPTX notes using C#

//

// Description:

// Demonstrates how to detect and merge consecutive duplicate PPTX notes using 

// C# and Aspose.Slides for .NET. The example shows the required 

// presentation-processing steps for PowerPoint files and produces the 

// requested output in a standalone console application. Developers can use 

// this pattern to automate PPTX workflows, validate results, or integrate 

// presentation logic into .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Detect, Merge, Consecutive, 

// Duplicate, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate detect and merge consecutive duplicate PPTX notes.

// - Build C# tools for PowerPoint presentation processing.

// - Generate or transform PPTX files in .NET applications.

// - Validate presentation workflows before publishing or integration.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace DuplicateNotesMerger

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input and output file paths

            string inputFilePath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");

            string outputFilePath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");



            // Verify input file exists

            if (!File.Exists(inputFilePath))

            {

                Console.WriteLine("Input file does not exist: " + inputFilePath);

                return;

            }



            try

            {

                // Load presentation

                using (Presentation presentation = new Presentation(inputFilePath))

                {

                    // Iterate through slides and compare notes of consecutive slides

                    for (int i = 0; i < presentation.Slides.Count - 1; i++)

                    {

                        // Get notes text of current slide

                        INotesSlideManager currentManager = presentation.Slides[i].NotesSlideManager;

                        INotesSlide currentNotesSlide = currentManager.NotesSlide;

                        string currentNotesText = string.Empty;

                        if (currentNotesSlide != null && currentNotesSlide.NotesTextFrame != null)

                        {

                            currentNotesText = currentNotesSlide.NotesTextFrame.Text;

                        }



                        // Get notes text of next slide

                        INotesSlideManager nextManager = presentation.Slides[i + 1].NotesSlideManager;

                        INotesSlide nextNotesSlide = nextManager.NotesSlide;

                        string nextNotesText = string.Empty;

                        if (nextNotesSlide != null && nextNotesSlide.NotesTextFrame != null)

                        {

                            nextNotesText = nextNotesSlide.NotesTextFrame.Text;

                        }



                        // If notes are identical and not empty, remove notes from the next slide

                        if (!string.IsNullOrEmpty(currentNotesText) &&

                            currentNotesText.Equals(nextNotesText, StringComparison.Ordinal))

                        {

                            // Remove duplicate notes slide

                            nextManager.RemoveNotesSlide();

                            Console.WriteLine($"Removed duplicate notes from slide {i + 2}");

                        }

                    }



                    // Save the modified presentation

                    presentation.Save(outputFilePath, SaveFormat.Pptx);

                }

            }

            catch (NotSupportedException)

            {

                // Format not supported

                // Handle unsupported file format

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

