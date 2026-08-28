// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Load HTML notes into PPTX slides using C#

//

// Description:

// Demonstrates how to read an HTML file containing note sections delimited by

// <h1> tags, parse the headings and note bodies, and assign them to the notes

// slides of an existing PPTX presentation using Aspose.Slides for .NET. The

// example loads a source presentation, creates notes slides where necessary,

// populates them with the extracted HTML content, and saves the updated

// presentation.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, HTML, Load, Html, Notes, Pptx,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate the import of HTML‑based speaker notes into PowerPoint files.

// - Build .NET utilities that convert structured HTML notes to PPTX notes.

// - Integrate note‑loading functionality into larger presentation‑processing

//   pipelines.

// - Validate and preview note content before publishing a presentation.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace NotesFromHtml

{

    class Program

    {

        static void Main(string[] args)

        {

            // Paths

            string presentationPath = "input.pptx";

            string htmlPath = "notes.html";

            string outputPath = "output.pptx";



            // Check if files exist

            if (!File.Exists(presentationPath))

            {

                Console.WriteLine("Presentation file not found: " + presentationPath);

                return;

            }



            if (!File.Exists(htmlPath))

            {

                Console.WriteLine("HTML file not found: " + htmlPath);

                return;

            }



            // Load HTML content

            string htmlContent;

            try

            {

                htmlContent = File.ReadAllText(htmlPath);

            }

            catch (Exception ex)

            {

                Console.WriteLine("Error reading HTML file: " + ex.Message);

                return;

            }



            // Simple parsing: split by <h1> tags

            string[] sections = htmlContent.Split(new string[] { "<h1>" }, StringSplitOptions.RemoveEmptyEntries);

            // Each section: heading text up to </h1>, then notes up to next <h1>

            string[] headings = new string[sections.Length];

            string[] notes = new string[sections.Length];



            for (int i = 0; i < sections.Length; i++)

            {

                int endHeading = sections[i].IndexOf("</h1>", StringComparison.OrdinalIgnoreCase);

                if (endHeading >= 0)

                {

                    headings[i] = sections[i].Substring(0, endHeading).Trim();

                    notes[i] = sections[i].Substring(endHeading + 5).Trim(); // 5 = length of </h1>

                }

                else

                {

                    headings[i] = "Untitled";

                    notes[i] = sections[i].Trim();

                }

            }



            // Load presentation

            Presentation presentation;

            try

            {

                presentation = new Presentation(presentationPath);

            }

            catch (Exception ex)

            {

                // Comment: format not supported

                Console.WriteLine("Failed to load presentation (unsupported format?): " + ex.Message);

                return;

            }



            // Distribute notes to slides based on headings

            int slideCount = presentation.Slides.Count;

            int noteCount = headings.Length;

            int count = Math.Min(slideCount, noteCount);



            for (int i = 0; i < count; i++)

            {

                // Get notes manager for the slide

                INotesSlideManager notesManager = presentation.Slides[i].NotesSlideManager;

                // Ensure a notes slide exists

                INotesSlide notesSlide = notesManager.AddNotesSlide();

                // Set notes text

                notesSlide.NotesTextFrame.Text = headings[i] + Environment.NewLine + notes[i];

            }



            // Save presentation

            try

            {

                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            }

            catch (Exception ex)

            {

                Console.WriteLine("Error saving presentation: " + ex.Message);

            }

            finally

            {

                presentation.Dispose();

            }



            Console.WriteLine("Notes distributed and presentation saved to: " + outputPath);

        }

    }

}

