using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.AI;

namespace PresentationLocalization
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "localized_output.pptx";

            // Target language for localization (e.g., French)
            string targetLanguage = "fr-FR";

            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Create an AI agent (passing null for IAIWebClient as a placeholder)
            Aspose.Slides.AI.SlidesAIAgent aiAgent = new Aspose.Slides.AI.SlidesAIAgent(null);

            // Translate the presentation to the target language
            aiAgent.Translate(presentation, targetLanguage);

            // Save the localized presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Release resources
            presentation.Dispose();
        }
    }
}