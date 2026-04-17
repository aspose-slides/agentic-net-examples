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