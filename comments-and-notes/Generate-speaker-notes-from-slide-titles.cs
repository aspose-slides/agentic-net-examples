// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Generate speaker notes from slide titles using C#

//

// Description:

// Demonstrates how to generate speaker notes from slide titles and bullet

// points using C# and Aspose.Slides for .NET. The example shows the required

// presentation-processing steps for PowerPoint files and produces the

// requested output in a standalone console application. Developers can use

// this pattern to automate PPTX workflows, validate results, or integrate

// presentation logic into .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Generate, Speaker, Notes,

// Slide, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate generation of speaker notes from slide titles and bullet points.

// - Build C# tools for PowerPoint presentation processing.

// - Generate or transform PPTX files in .NET applications.

// - Validate presentation workflows before publishing or integration.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace SpeakerNotesGenerator

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input and output file paths

            var inputPath = "input.pptx";

            var outputPath = "output_with_notes.pptx";



            // Verify input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            try

            {

                // Load presentation

                using (Presentation presentation = new Presentation(inputPath))

                {

                    // Iterate through each slide

                    for (int i = 0; i < presentation.Slides.Count; i++)

                    {

                        var slide = presentation.Slides[i];



                        // Collect title and bullet points

                        string title = string.Empty;

                        System.Text.StringBuilder bulletPoints = new System.Text.StringBuilder();



                        foreach (var shape in slide.Shapes)

                        {

                            if (shape is IAutoShape autoShape && autoShape.TextFrame != null)

                            {

                                var text = autoShape.TextFrame.Text;

                                if (string.IsNullOrWhiteSpace(title))

                                {

                                    title = text; // Assume first text shape is the title

                                }

                                else

                                {

                                    bulletPoints.AppendLine(text);

                                }

                            }

                        }



                        // Generate speaker notes content

                        var notesContent = "Title: " + title + Environment.NewLine + "Points:" + Environment.NewLine + bulletPoints.ToString();



                        // Add or retrieve notes slide

                        var notesManager = slide.NotesSlideManager;

                        var notesSlide = notesManager.AddNotesSlide();



                        // Set notes text

                        notesSlide.NotesTextFrame.Text = notesContent;

                    }



                    // Save the presentation with notes

                    presentation.Save(outputPath, SaveFormat.Pptx);

                }

            }

            catch (NotSupportedException)

            {

                // Format not supported

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

