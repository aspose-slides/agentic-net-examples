using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.AI;

namespace LocalizePresentation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output_localized.pptx";
            // Target language for localization (e.g., French)
            string targetLanguage = "fr-FR";

            try
            {
                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Initialize the AI web client (replace placeholders with real credentials)
                Aspose.Slides.AI.OpenAIWebClient aiClient = new Aspose.Slides.AI.OpenAIWebClient(
                    "gpt-4o-mini",          // Model
                    "YOUR_API_KEY",         // API Key
                    "YOUR_ORG_ID"           // Organization ID (optional)
                );

                // Create the Slides AI agent
                Aspose.Slides.AI.SlidesAIAgent aiAgent = new Aspose.Slides.AI.SlidesAIAgent(aiClient);

                // Translate the entire presentation to the target language
                aiAgent.Translate(presentation, targetLanguage);

                // Ensure all fonts used in the presentation are embedded
                Aspose.Slides.IFontData[] allFonts = presentation.FontsManager.GetFonts();
                Aspose.Slides.IFontData[] embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();

                foreach (Aspose.Slides.IFontData font in allFonts)
                {
                    bool isEmbedded = false;
                    foreach (Aspose.Slides.IFontData ef in embeddedFonts)
                    {
                        if (ef.Equals(font))
                        {
                            isEmbedded = true;
                            break;
                        }
                    }

                    if (!isEmbedded)
                    {
                        presentation.FontsManager.AddEmbeddedFont(font, Aspose.Slides.Export.EmbedFontCharacters.All);
                    }
                }

                // Save the localized presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

                // Release resources
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}