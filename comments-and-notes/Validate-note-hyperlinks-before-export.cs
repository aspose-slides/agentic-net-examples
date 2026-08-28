// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Validate note hyperlinks before export using C#

//

// Description:

// Demonstrates how to validate note hyperlinks before export using C# and 

// Aspose.Slides for .NET. The example shows the required 

// presentation-processing steps for PowerPoint files and produces the 

// requested output in a standalone console application. Developers can use 

// this pattern to automate PPTX workflows, validate results, or integrate 

// presentation logic into .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Validate, Note, Hyperlinks, 

// Before, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate validate note hyperlinks before export.

// - Build C# tools for PowerPoint presentation processing.

// - Generate or transform PPTX files in .NET applications.

// - Validate presentation workflows before publishing or integration.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace ValidateNoteHyperlinks

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input and output file paths

            string inputPath = "input.pptx";

            string outputPath = "output.pptx";



            // Verify that the input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            // Load the presentation with exception handling

            Aspose.Slides.Presentation presentation = null;

            try

            {

                presentation = new Aspose.Slides.Presentation(inputPath);

            }

            catch (Aspose.Slides.PptxUnsupportedFormatException)

            {

                // Format not supported (PPTX)

                Console.WriteLine("The file format is not supported (PPTX).");

                return;

            }

            catch (Aspose.Slides.PptUnsupportedFormatException)

            {

                // Format not supported (PPT)

                Console.WriteLine("The file format is not supported (PPT).");

                return;

            }

            catch (Exception ex)

            {

                // Handle other exceptions such as network errors if a URL was used to load the file

                Console.WriteLine("An error occurred while loading the presentation: " + ex.Message);

                return;

            }



            // Validate that each notes slide contains at least one hyperlink

            bool allNotesContainHyperlink = true;

            Aspose.Slides.ISlideCollection slides = presentation.Slides;

            for (int i = 0; i < slides.Count; i++)

            {

                Aspose.Slides.ISlide slide = slides[i];

                Aspose.Slides.INotesSlide notesSlide = slide.NotesSlideManager.NotesSlide;

                if (notesSlide != null)

                {

                    Aspose.Slides.IHyperlinkQueries hyperlinkQueries = notesSlide.HyperlinkQueries;

                    // Get any hyperlinks (click or mouse over) in the notes slide

                    System.Collections.Generic.IEnumerable<Aspose.Slides.IHyperlinkContainer> anyLinks = hyperlinkQueries.GetAnyHyperlinks();

                    bool hasLink = false;

                    foreach (Aspose.Slides.IHyperlinkContainer container in anyLinks)

                    {

                        if (container.HyperlinkClick != null || container.HyperlinkMouseOver != null)

                        {

                            hasLink = true;

                            break;

                        }

                    }



                    if (!hasLink)

                    {

                        allNotesContainHyperlink = false;

                        Console.WriteLine("Notes slide for slide index " + i + " does not contain any hyperlink.");

                    }

                }

                else

                {

                    // No notes slide; depending on requirements this may be acceptable

                    Console.WriteLine("Slide index " + i + " does not have a notes slide.");

                }

            }



            // Export only if validation passed

            if (allNotesContainHyperlink)

            {

                try

                {

                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

                    Console.WriteLine("Presentation saved successfully to: " + outputPath);

                }

                catch (Exception ex)

                {

                    // Handle any errors during saving

                    Console.WriteLine("An error occurred while saving the presentation: " + ex.Message);

                }

            }

            else

            {

                Console.WriteLine("Export aborted because some notes slides lack hyperlinks.");

            }



            // Ensure the presentation is disposed before exiting

            if (presentation != null)

            {

                presentation.Dispose();

            }

        }

    }

}

