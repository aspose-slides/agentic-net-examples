// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Remove empty comments and notes from PPTX using C#

//

// Description:

// Demonstrates how to remove empty comments and notes from a PPTX file using

// C# and Aspose.Slides for .NET. The example loads a presentation, iterates

// through each slide, deletes comments whose text is empty or whitespace, and

// removes notes slides that contain no text. The cleaned presentation is then

// saved as a new PPTX file. This pattern can be used to automate cleanup of

// PowerPoint files before distribution or further processing.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Remove, Empty, Comments, Notes,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate removal of empty comments and notes from PPTX files.

// - Build C# utilities for PowerPoint presentation cleanup.

// - Integrate presentation sanitization into .NET applications.

// - Prepare PPTX files for publishing by ensuring they contain only meaningful content.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace RemoveEmptyCommentsAndNotes

{

    class Program

    {

        static void Main(string[] args)

        {

            string inputPath = "input.pptx";

            string outputPath = "output_cleaned.pptx";



            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            try

            {

                using (Presentation presentation = new Presentation(inputPath))

                {

                    for (int i = 0; i < presentation.Slides.Count; i++)

                    {

                        ISlide slide = presentation.Slides[i];



                        // Remove empty comments

                        IComment[] slideComments = slide.GetSlideComments(null);

                        foreach (IComment comment in slideComments)

                        {

                            if (string.IsNullOrWhiteSpace(comment.Text))

                            {

                                comment.Remove();

                            }

                        }



                        // Remove empty notes

                        INotesSlideManager notesManager = slide.NotesSlideManager;

                        if (notesManager != null && notesManager.NotesSlide != null)

                        {

                            INotesSlide notesSlide = notesManager.NotesSlide;

                            if (notesSlide.NotesTextFrame == null ||

                                string.IsNullOrWhiteSpace(notesSlide.NotesTextFrame.Text))

                            {

                                notesManager.RemoveNotesSlide();

                            }

                        }

                    }



                    // Save the cleaned presentation

                    presentation.Save(outputPath, SaveFormat.Pptx);

                }

            }

            catch (Aspose.Slides.PptxUnsupportedFormatException ex)

            {

                // Format not supported

                Console.WriteLine("Unsupported file format: " + ex.Message);

            }

            catch (Exception ex)

            {

                // General exception handling

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

