// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Duplicate PPTX slide with comments and notes using C#

//

// Description:

// Demonstrates how to duplicate PPTX slide with comments and notes using C# 

// and Aspose.Slides for .NET. The example shows the required 

// presentation-processing steps for PowerPoint files and produces the 

// requested output in a standalone console application. Developers can use 

// this pattern to automate PPTX workflows, validate results, or integrate 

// presentation logic into .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Duplicate, Pptx, Slide, 

// Comments, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate duplicate PPTX slide with comments and notes.

// - Build C# tools for PowerPoint presentation processing.

// - Generate or transform PPTX files in .NET applications.

// - Validate presentation workflows before publishing or integration.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using System.Drawing;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace SlideCloneExample

{

    class Program

    {

        static void Main(string[] args)

        {

            string inputPath = "input.pptx";

            string outputPath = "output.pptx";



            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist.");

                return;

            }



            try

            {

                Presentation pres = new Presentation(inputPath);

                ISlideCollection slides = pres.Slides;



                // Clone the first slide to the end of the collection

                ISlide newSlide = slides.AddClone(slides[0]);



                // Copy comments from the source slide to the new slide

                IComment[] sourceComments = slides[0].GetSlideComments(null);

                if (sourceComments != null && sourceComments.Length > 0)

                {

                    // Ensure there is at least one author to attach comments to

                    ICommentAuthor author = pres.CommentAuthors.AddAuthor("Author", "A");

                    foreach (IComment srcComment in sourceComments)

                    {

                        author.Comments.AddModernComment(

                            srcComment.Text,

                            newSlide,

                            null,

                            srcComment.Position,

                            DateTime.Now);

                    }

                }



                // Copy notes from the source slide to the new slide

                INotesSlideManager srcNotesMgr = slides[0].NotesSlideManager;

                INotesSlide srcNotes = srcNotesMgr.NotesSlide;

                if (srcNotes != null && srcNotes.NotesTextFrame != null)

                {

                    INotesSlideManager destNotesMgr = newSlide.NotesSlideManager;

                    INotesSlide destNotes = destNotesMgr.AddNotesSlide();

                    destNotes.NotesTextFrame.Text = srcNotes.NotesTextFrame.Text;

                }



                // Save the presentation

                pres.Save(outputPath, SaveFormat.Pptx);

                pres.Dispose();

                Console.WriteLine("Slide duplicated with comments and notes successfully.");

            }

            catch (Exception ex)

            {

                // Handle unsupported format or other errors

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

