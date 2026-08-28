// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Synchronize PPTX slide notes with external CMS using C#

//

// Description:

// Demonstrates how to load a PPTX presentation, iterate through its slides,

// ensure each slide has a notes slide, retrieve the notes text, and post the

// notes to an external CMS via a REST API using HttpClient. The updated

// presentation is then saved. This pattern can be used to automate notes

// extraction and synchronization in .NET applications with Aspose.Slides for .NET.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Slide Notes, REST API, CMS,

// HttpClient, Presentation Processing, Office Automation

//

// Use Cases:

// - Synchronize slide notes with an external content management system.

// - Automate extraction and upload of PowerPoint notes in .NET tools.

// - Build C# utilities for PowerPoint presentation processing and integration.

// - Validate and update slide notes programmatically before publishing.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using System.Net.Http;

using System.Threading.Tasks;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace SlidesNotesSync

{

    class Program

    {

        static void Main(string[] args)

        {

            // Define paths

            string dataDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Data");

            string inputPath = Path.Combine(dataDirectory, "input.pptx");

            string outputPath = Path.Combine(dataDirectory, "output.pptx");



            // Verify input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input presentation not found: " + inputPath);

                return;

            }



            try

            {

                // Load presentation

                using (Presentation presentation = new Presentation(inputPath))

                {

                    // Iterate through slides

                    for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)

                    {

                        // Access notes slide manager

                        INotesSlideManager notesManager = presentation.Slides[slideIndex].NotesSlideManager;

                        INotesSlide notesSlide = notesManager.NotesSlide;



                        // Ensure a notes slide exists

                        if (notesSlide == null)

                        {

                            notesSlide = notesManager.AddNotesSlide();

                        }



                        // Get current notes text

                        string notesText = notesSlide.NotesTextFrame.Text;



                        // Synchronize with external CMS via REST API

                        try

                        {

                            using (HttpClient httpClient = new HttpClient())

                            {

                                HttpContent httpContent = new StringContent(notesText);

                                Task<HttpResponseMessage> postTask = httpClient.PostAsync("https://example.com/api/notes", httpContent);

                                postTask.Wait();

                                HttpResponseMessage response = postTask.Result;



                                // Optionally handle response (omitted for brevity)

                            }

                        }

                        catch (HttpRequestException)

                        {

                            // Handle external URL or web service exception

                            Console.WriteLine("Failed to reach the external CMS for slide " + (slideIndex + 1));

                        }

                    }



                    // Save the updated presentation

                    presentation.Save(outputPath, SaveFormat.Pptx);

                }

            }

            catch (NotSupportedException)

            {

                // Format not supported

                Console.WriteLine("The presentation format is not supported.");

            }

            catch (Exception ex)

            {

                // General exception handling

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

