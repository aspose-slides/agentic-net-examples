// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Export PPTX slide notes to txt using C#

//

// Description:

// Demonstrates how to extract slide notes from PowerPoint presentations

// (including PPT, PPTX, ODP, etc.) and save each slide's notes as a separate

// text file using C# and Aspose.Slides for .NET. The example processes all

// supported presentation files in a given directory, creates an output

// folder, and writes notes to individual .txt files.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Export, Slide Notes, Text

// Extraction, Batch Processing, Presentation Automation

//

// Use Cases:

// - Batch export slide notes from multiple presentations to text files.

// - Build tools for extracting documentation or speaker notes from PowerPoint.

// - Automate content analysis or translation workflows for slide notes.

// - Integrate slide notes extraction into .NET applications or CI pipelines.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace BatchNotesExtractor

{

    class Program

    {

        static void Main(string[] args)

        {

            // Determine input directory (first argument or current directory)

            string inputDir;

            if (args.Length > 0 && !string.IsNullOrEmpty(args[0]))

            {

                inputDir = args[0];

            }

            else

            {

                inputDir = Directory.GetCurrentDirectory();

            }



            // Verify input directory exists

            if (!Directory.Exists(inputDir))

            {

                Console.WriteLine("Input directory does not exist: " + inputDir);

                return;

            }



            // Create output directory for notes

            string outputDir = Path.Combine(inputDir, "Notes");

            if (!Directory.Exists(outputDir))

            {

                Directory.CreateDirectory(outputDir);

            }



            // Supported presentation extensions

            string[] extensions = new string[] { ".ppt", ".pptx", ".odp", ".pptm", ".potx", ".potm", ".ppsx", ".pps", ".pdf" };



            // Process each file in the input directory

            string[] files = Directory.GetFiles(inputDir);

            foreach (string filePath in files)

            {

                string extension = Path.GetExtension(filePath).ToLowerInvariant();

                if (Array.IndexOf(extensions, extension) < 0)

                {

                    // Skip unsupported file types

                    continue;

                }



                try

                {

                    // Extract raw text (including notes) from the presentation

                    IPresentationText presentationText = PresentationFactory.Instance.GetPresentationText(

                        filePath,

                        Aspose.Slides.TextExtractionArrangingMode.Unarranged);



                    // Iterate through each slide's text

                    for (int i = 0; i < presentationText.SlidesText.Length; i++)

                    {

                        string notes = presentationText.SlidesText[i].NotesText;

                        if (!string.IsNullOrEmpty(notes))

                        {

                            // Build output file name: originalname_slideX.txt

                            string baseFileName = Path.GetFileNameWithoutExtension(filePath);

                            string notesFileName = string.Format("{0}_slide{1}.txt", baseFileName, i + 1);

                            string notesFilePath = Path.Combine(outputDir, notesFileName);



                            // Write notes to text file

                            File.WriteAllText(notesFilePath, notes);

                        }

                    }

                }

                catch (NotSupportedException)

                {

                    // Format not supported – continue with next file

                    // Comment: format not supported

                }

                catch (Exception ex)

                {

                    // General exception handling (e.g., file access issues)

                    Console.WriteLine("Error processing file " + filePath + ": " + ex.Message);

                }

            }

        }

    }

}

