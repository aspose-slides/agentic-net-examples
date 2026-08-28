// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Set paragraph spacing for PPTX slide notes using C#

//

// Description:

// Demonstrates how to set custom paragraph spacing (line spacing, space before,

// and space after) for slide notes in a PPTX file using C# and Aspose.Slides for .NET.

// The example loads an existing presentation, ensures each slide has a notes

// slide, modifies the paragraph formatting of the notes text, and saves the

// result as a new PPTX file. This pattern can be used to automate notes formatting

// in PowerPoint presentations.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Paragraph, Spacing, Notes, Slide, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate paragraph spacing adjustments for slide notes in PPTX files.

// - Build .NET tools that standardize notes formatting across presentations.

// - Generate or transform PPTX files with customized notes layout.

// - Validate and enforce presentation style guidelines before publishing.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides.Export;



class Program

{

    static void Main()

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

            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))

            {

                foreach (Aspose.Slides.ISlide slide in presentation.Slides)

                {

                    Aspose.Slides.INotesSlideManager notesMgr = slide.NotesSlideManager;

                    Aspose.Slides.INotesSlide notesSlide = notesMgr.NotesSlide;

                    if (notesSlide == null)

                    {

                        notesSlide = notesMgr.AddNotesSlide();

                    }



                    Aspose.Slides.ITextFrame notesTextFrame = notesSlide.NotesTextFrame;

                    if (notesTextFrame != null)

                    {

                        foreach (Aspose.Slides.IParagraph paragraph in notesTextFrame.Paragraphs)

                        {

                            // Apply custom paragraph spacing

                            paragraph.ParagraphFormat.SpaceWithin = 0.5f;   // 50% line spacing

                            paragraph.ParagraphFormat.SpaceBefore = 0.2f;   // 20% before

                            paragraph.ParagraphFormat.SpaceAfter = 0.2f;    // 20% after

                        }

                    }

                }



                presentation.Save(outputPath, SaveFormat.Pptx);

            }

        }

        catch (Aspose.Slides.PptxUnsupportedFormatException)

        {

            // Format not supported

        }

        catch (Aspose.Slides.PptUnsupportedFormatException)

        {

            // Format not supported

        }

        catch (Exception ex)

        {

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}

