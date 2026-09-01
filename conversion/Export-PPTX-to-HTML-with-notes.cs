// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Export PPTX to HTML with notes using C#

//

// Description:

// Demonstrates how to export a PPTX file to a simple HTML document that

// includes slide numbers and associated notes using C# and Aspose.Slides for .NET.

// The example loads a presentation, extracts notes from each slide (creating

// a notes slide if missing), builds an HTML string, writes it to a file, and

// saves the original presentation.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, HTML, Export, Notes, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate export of PPTX to HTML with slide notes.

// - Build .NET tools for PowerPoint presentation processing.

// - Generate HTML previews of presentations for web publishing.

// - Validate and transform PPTX files in automated workflows.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using System.Text;

using System.Net;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace HtmlFromPptx

{

    class Program

    {

        static void Main(string[] args)

        {

            // Define input and output paths

            var inputPath = Path.Combine(Environment.CurrentDirectory, "input.pptx");

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file not found.");

                return;

            }



            try

            {

                // Load presentation

                var presentation = new Presentation(inputPath);



                // Build HTML content

                var sb = new StringBuilder();

                sb.AppendLine("<html><body>");



                for (int i = 0; i < presentation.Slides.Count; i++)

                {

                    var slide = presentation.Slides[i];

                    sb.AppendLine($"<h2>Slide {i + 1}</h2>");



                    // Retrieve or create notes slide

                    var notesManager = slide.NotesSlideManager;

                    var notesSlide = notesManager.NotesSlide;

                    if (notesSlide == null)

                    {

                        notesSlide = notesManager.AddNotesSlide();

                    }



                    var notesText = notesSlide?.NotesTextFrame?.Text ?? string.Empty;

                    sb.AppendLine("<div class=\"notes\">");

                    sb.AppendLine(WebUtility.HtmlEncode(notesText));

                    sb.AppendLine("</div>");

                }



                sb.AppendLine("</body></html>");



                // Write HTML to file

                var outputPath = Path.Combine(Environment.CurrentDirectory, "output.html");

                File.WriteAllText(outputPath, sb.ToString());



                // Save presentation before exit (optional, retains any changes)

                presentation.Save(inputPath, SaveFormat.Pptx);

                presentation.Dispose();



                Console.WriteLine("HTML generated at " + outputPath);

            }

            catch (Exception ex)

            {

                // Handle unsupported format or other errors

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

