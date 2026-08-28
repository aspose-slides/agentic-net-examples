// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Detect and remove consecutive duplicate PPTX notes using C#

//

// Description:

// Demonstrates how to detect and remove consecutive duplicate PPTX notes using 

// C# and Aspose.Slides for .NET. The example loads a presentation, iterates 

// through its slides, compares each slide's notes with the previous slide's 

// notes, removes the notes from any slide that has identical consecutive notes, 

// and saves the modified presentation. This pattern can be used to automate 

// PPTX note cleanup in .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Detect, Remove, Consecutive, 

// Duplicate, Notes, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate detection and removal of consecutive duplicate notes in PPTX files.

// - Build C# utilities for cleaning up PowerPoint presentations.

// - Integrate note deduplication into larger .NET document processing workflows.

// - Ensure presentation consistency before publishing or distribution.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace DetectAndRemoveDuplicateNotes

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input and output file paths

            string inputPath = args.Length > 0 ? args[0] : "input.pptx";

            string outputPath = "output.pptx";



            // Verify that the input file exists

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

                    // Keep track of the previous slide's notes text

                    string previousNotesText = null;



                    // Iterate through slides in order

                    for (int i = 0; i < presentation.Slides.Count; i++)

                    {

                        // Retrieve the current slide as ISlide (compiler rule)

                        Aspose.Slides.ISlide currentSlide = presentation.Slides[i];



                        // Access the notes manager for the current slide

                        Aspose.Slides.INotesSlideManager notesManager = currentSlide.NotesSlideManager;



                        // Get the notes slide if it exists

                        Aspose.Slides.INotesSlide notesSlide = notesManager.NotesSlide;



                        // Extract the notes text (may be null)

                        string currentNotesText = null;

                        if (notesSlide != null && notesSlide.NotesTextFrame != null)

                        {

                            currentNotesText = notesSlide.NotesTextFrame.Text;

                        }



                        // Compare with previous slide's notes

                        if (previousNotesText != null && currentNotesText != null && previousNotesText.Equals(currentNotesText, StringComparison.Ordinal))

                        {

                            // Duplicate notes found – remove notes from the current slide

                            notesManager.RemoveNotesSlide();

                            Console.WriteLine($"Removed duplicate notes from slide {i + 1}");

                        }



                        // Update previous notes text for next iteration

                        previousNotesText = currentNotesText;

                    }



                    // Save the modified presentation

                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

                    Console.WriteLine("Presentation saved to: " + outputPath);

                }

            }

            catch (Aspose.Slides.PptxUnsupportedFormatException)

            {

                // Handle unsupported file format

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

