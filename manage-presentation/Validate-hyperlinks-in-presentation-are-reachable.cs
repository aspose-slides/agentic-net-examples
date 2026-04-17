using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace HyperlinkValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "validated_output.pptx";

            // Check if input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Load presentation
            Presentation presentation = null;
            try
            {
                presentation = new Presentation(inputPath);
            }
            catch (Exception ex)
            {
                // Handle unsupported format exception
                // Format not supported
                Console.WriteLine("Failed to load presentation: " + ex.Message);
                return;
            }

            // Validate hyperlinks
            HttpClient httpClient = new HttpClient();
            foreach (IHyperlinkContainer container in presentation.HyperlinkQueries.GetHyperlinkClicks())
            {
                IHyperlink hyperlink = container.HyperlinkClick;
                if (hyperlink != null && !string.IsNullOrEmpty(hyperlink.ExternalUrl))
                {
                    string url = hyperlink.ExternalUrl;
                    try
                    {
                        HttpResponseMessage response = httpClient.GetAsync(url).Result;
                        if (!response.IsSuccessStatusCode)
                        {
                            Console.WriteLine("Unreachable URL: " + url + " (Status: " + response.StatusCode + ")");
                        }
                    }
                    catch (HttpRequestException)
                    {
                        // Handle exception for external URL request
                        Console.WriteLine("Failed to reach URL: " + url);
                    }
                    catch (AggregateException aggEx) when (aggEx.InnerException is HttpRequestException)
                    {
                        Console.WriteLine("Failed to reach URL: " + url);
                    }
                }
            }

            // Save presentation before exit
            try
            {
                presentation.Save(outputPath, SaveFormat.Pptx);
                Console.WriteLine("Presentation saved to: " + outputPath);
            }
            catch (Exception ex)
            {
                // Handle save exceptions
                Console.WriteLine("Failed to save presentation: " + ex.Message);
            }
            finally
            {
                if (presentation != null)
                {
                    presentation.Dispose();
                }
                httpClient.Dispose();
            }
        }
    }
}