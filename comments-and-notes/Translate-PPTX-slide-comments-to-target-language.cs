using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.AI;
using Aspose.Slides.Export;

namespace TranslateCommentsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output_translated.pptx";
            // Target language code (e.g., "fr" for French)
            string targetLanguage = "fr";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Initialize the AI web client (replace placeholders with real credentials)
                    OpenAIWebClient aiClient = new OpenAIWebClient("YOUR_API_KEY", "YOUR_ORG_ID", "YOUR_MODEL");
                    // Create the Slides AI agent
                    SlidesAIAgent aiAgent = new SlidesAIAgent(aiClient);
                    // Translate the entire presentation (including comments) to the target language
                    aiAgent.Translate(pres, targetLanguage);
                    // Save the translated presentation
                    pres.Save(outputPath, SaveFormat.Pptx);
                }
            }
            // Handle unsupported file format exceptions
            catch (Aspose.Slides.PptxUnsupportedFormatException)
            {
                // Format not supported
                Console.WriteLine("The provided file format is not supported for translation.");
            }
            // Handle AI web client related exceptions
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}