// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Extract hidden slide notes from hidden slides into an encrypted archive using C#

//

// Description:

// Demonstrates how to extract notes from hidden slides in a PowerPoint presentation,

// consolidate them into a single slide, encrypt the resulting presentation with a

// password, and save it as an encrypted PPTX file using Aspose.Slides for .NET.

// The example includes loading a source presentation, iterating hidden slides,

// retrieving notes text, creating an archive presentation, adding a textbox with

// the collected notes, applying password protection, and saving the output.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Extract, Hidden Slides, Slide Notes, 

// Encryption, Password Protection, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate extraction of hidden slide notes for secure archival.

// - Build C# utilities that protect confidential presentation content.

// - Integrate encrypted note extraction into .NET PowerPoint workflows.

// - Validate and safeguard presentation data before distribution.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using System.Text;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace ExtractHiddenSlideNotes

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input and output file paths

            string inputPath = "input.pptx";

            string outputPath = "encrypted_notes.pptx";

            // Password for encryption

            string password = "StrongPassword123";



            // Verify input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            try

            {

                // Load the source presentation

                using (Aspose.Slides.Presentation sourcePresentation = new Aspose.Slides.Presentation(inputPath))

                {

                    // Collect notes from hidden slides

                    StringBuilder notesBuilder = new StringBuilder();



                    for (int index = 0; index < sourcePresentation.Slides.Count; index++)

                    {

                        Aspose.Slides.ISlide slide = sourcePresentation.Slides[index];



                        // Check if the slide is hidden

                        if (slide.Hidden)

                        {

                            Aspose.Slides.INotesSlide notesSlide = slide.NotesSlideManager.NotesSlide;

                            if (notesSlide != null && notesSlide.NotesTextFrame != null)

                            {

                                string slideNotes = notesSlide.NotesTextFrame.Text;

                                notesBuilder.AppendLine("Slide " + (index + 1) + ":");

                                notesBuilder.AppendLine(slideNotes);

                                notesBuilder.AppendLine();

                            }

                        }

                    }



                    // Create a new presentation to store the extracted notes

                    using (Aspose.Slides.Presentation archivePresentation = new Aspose.Slides.Presentation())

                    {

                        // Use the first (default) slide

                        Aspose.Slides.ISlide archiveSlide = archivePresentation.Slides[0];



                        // Add a textbox shape containing all notes

                        Aspose.Slides.IAutoShape textShape = archiveSlide.Shapes.AddAutoShape(

                            Aspose.Slides.ShapeType.Rectangle, 50, 50, 600, 400);

                        textShape.AddTextFrame(notesBuilder.ToString());



                        // Encrypt the presentation with the specified password

                        archivePresentation.ProtectionManager.Encrypt(password);



                        // Save the encrypted presentation

                        archivePresentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

                    }

                }

            }

            // Handle unsupported format exception

            catch (Aspose.Slides.PptxUnsupportedFormatException)

            {

                // Format not supported

                Console.WriteLine("The presentation format is not supported.");

            }

            // General exception handling (including web service or URL errors)

            catch (Exception ex)

            {

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

