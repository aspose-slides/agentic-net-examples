// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Validate PPTX slide note length using C#

//

// Description:

// Demonstrates how to validate PPTX slide note length using C# and 

// Aspose.Slides for .NET. The example loads a presentation, checks each slide's

// notes for a maximum character limit, aborts if any notes exceed the limit,

// and saves the validated presentation. This pattern can be used to automate

// PPTX workflows, enforce content guidelines, or integrate presentation validation

// into .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Validate, Slide, Note, 

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate validation of PPTX slide note length.

// - Build C# tools for PowerPoint presentation processing with content checks.

// - Enforce note length policies before publishing or integration.

// - Integrate slide note validation into CI/CD pipelines for presentation assets.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace ValidateNotesLength

{

    class Program

    {

        static void Main(string[] args)

        {

            // Define input and output file paths

            string inputPath = args.Length > 0 ? args[0] : "input.pptx";

            string outputPath = args.Length > 1 ? args[1] : "output.pptx";



            // Define maximum allowed characters for notes

            int maxNotesLength = 200;



            // Verify that the input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            try

            {

                // Load the presentation

                using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))

                {

                    // Iterate through each slide and validate notes length

                    for (int i = 0; i < pres.Slides.Count; i++)

                    {

                        Aspose.Slides.INotesSlide notesSlide = pres.Slides[i].NotesSlideManager.NotesSlide;

                        if (notesSlide != null && notesSlide.NotesTextFrame != null && notesSlide.NotesTextFrame.Text != null)

                        {

                            string notesText = notesSlide.NotesTextFrame.Text;

                            if (notesText.Length > maxNotesLength)

                            {

                                Console.WriteLine($"Slide {i + 1} notes exceed the maximum length of {maxNotesLength} characters.");

                                // Abort saving due to validation failure

                                return;

                            }

                        }

                    }



                    // Save the presentation after successful validation

                    pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

                }

            }

            catch (NotSupportedException)

            {

                // Format not supported

                Console.WriteLine("The file format is not supported for saving.");

            }

            catch (Exception ex)

            {

                // General exception handling

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

