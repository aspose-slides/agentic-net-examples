// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Translate PPTX slide notes to french using C#

//

// Description:

// Demonstrates how to translate PPTX slide notes to french using C# and 

// Aspose.Slides for .NET. The example shows the required 

// presentation-processing steps for PowerPoint files and produces the 

// requested output in a standalone console application. Developers can use 

// this pattern to automate PPTX workflows, validate results, or integrate 

// presentation logic into .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Translate, Pptx, Slide, Notes, 

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate translate PPTX slide notes to french.

// - Build C# tools for PowerPoint presentation processing.

// - Generate or transform PPTX files in .NET applications.

// - Validate presentation workflows before publishing or integration.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using System.Collections.Generic;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace TranslateNotes

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input and output file paths

            string inputPath = "input.pptx";

            string outputPath = "output_fr.pptx";



            // Verify that the input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            try

            {

                // Load the presentation

                using (Presentation presentation = new Presentation(inputPath))

                {

                    // Simple English‑to‑French dictionary for demonstration

                    Dictionary<string, string> translationDictionary = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)

                    {

                        { "Hello", "Bonjour" },

                        { "World", "Monde" },

                        { "Slide", "Diapositive" },

                        { "Note", "Note" }

                        // Add more word mappings as needed

                    };



                    // Iterate through all slides

                    foreach (ISlide slide in presentation.Slides)

                    {

                        // Get the notes slide (if any)

                        INotesSlide notesSlide = slide.NotesSlideManager.NotesSlide;

                        if (notesSlide == null)

                            continue;



                        // Get the text frame that contains the notes

                        ITextFrame notesTextFrame = notesSlide.NotesTextFrame;

                        if (notesTextFrame == null)

                            continue;



                        // Translate the notes text using the dictionary

                        string originalText = notesTextFrame.Text;

                        string translatedText = originalText;



                        foreach (KeyValuePair<string, string> entry in translationDictionary)

                        {

                            translatedText = translatedText.Replace(entry.Key, entry.Value);

                        }



                        // Replace the original notes with the translated text

                        notesTextFrame.Text = translatedText;

                    }



                    // Save the modified presentation

                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

                }

            }

            // Handle unsupported file format

            catch (NotSupportedException)

            {

                // Format not supported

                Console.WriteLine("The provided file format is not supported.");

            }

            // General exception handling

            catch (Exception ex)

            {

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

