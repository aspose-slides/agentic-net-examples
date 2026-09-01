// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Extract speaker notes to text with TIFF using C#

//

// Description:

// Demonstrates how to extract speaker notes to text and generate TIFF images

// for each slide using C# and Aspose.Slides for .NET. The example loads a PPTX

// file, creates a TIFF image per slide, writes the speaker notes to text files,

// and saves a copy of the processed presentation. This pattern can be used to

// automate PowerPoint content extraction, create documentation assets, or

// integrate slide processing into .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Extract, Speaker, Notes, Text,

// TIFF, Image, Conversion, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate extraction of speaker notes and slide images as TIFF files.

// - Build C# tools for PowerPoint presentation processing and documentation.

// - Generate visual and textual assets from PPTX files for reporting or archiving.

// - Validate and transform presentation content before publishing or integration.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace ExtractNotesAndImages

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input presentation path

            string inputPath = Path.Combine(Environment.CurrentDirectory, "input.pptx");

            // Output directory for images and notes

            string outputDir = Path.Combine(Environment.CurrentDirectory, "Output");



            // Verify input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            // Ensure output directory exists

            if (!Directory.Exists(outputDir))

            {

                Directory.CreateDirectory(outputDir);

            }



            try

            {

                // Load presentation

                using (Presentation pres = new Presentation(inputPath))

                {

                    // Iterate through each slide

                    for (int i = 0; i < pres.Slides.Count; i++)

                    {

                        // Get slide reference

                        ISlide slide = pres.Slides[i];



                        // Generate TIFF image for the slide

                        using (IImage image = slide.GetImage())

                        {

                            string imagePath = Path.Combine(outputDir, $"Slide_{i + 1}.tiff");

                            image.Save(imagePath, ImageFormat.Tiff);

                        }



                        // Extract speaker notes text if available

                        INotesSlide notesSlide = slide.NotesSlideManager.NotesSlide;

                        if (notesSlide != null && notesSlide.NotesTextFrame != null)

                        {

                            string notesText = notesSlide.NotesTextFrame.Text;

                            string notesPath = Path.Combine(outputDir, $"Slide_{i + 1}_Notes.txt");

                            File.WriteAllText(notesPath, notesText);

                        }

                    }



                    // Save presentation (no changes made, but required by lifecycle rule)

                    string savedPath = Path.Combine(outputDir, "ProcessedPresentation.pptx");

                    pres.Save(savedPath, SaveFormat.Pptx);

                }

            }

            catch (NotSupportedException)

            {

                // Format not supported

                Console.WriteLine("The presentation format is not supported for the requested operation.");

            }

            catch (Exception ex)

            {

                // General exception handling

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

