using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Export.Xaml;

namespace EmbedFontsInXaml
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output paths
            string inputPath = "input.pptx";
            string outputFolder = "output_xaml";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Get all fonts used in the presentation
                Aspose.Slides.IFontData[] allFonts = presentation.FontsManager.GetFonts();

                // Get fonts that are already embedded
                Aspose.Slides.IFontData[] embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();

                // Embed missing fonts
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
                        // Use the correct enum namespace as per the compiler‑fix rule
                        presentation.FontsManager.AddEmbeddedFont(font, Aspose.Slides.Export.EmbedFontCharacters.All);
                    }
                }

                // Prepare XAML save options
                Aspose.Slides.Export.Xaml.XamlOptions xamlOptions = new Aspose.Slides.Export.Xaml.XamlOptions();
                xamlOptions.ExportHiddenSlides = true;

                // Ensure the output folder exists
                if (!Directory.Exists(outputFolder))
                {
                    Directory.CreateDirectory(outputFolder);
                }

                // Set the output saver to write XAML files into the specified folder
                // (OutputSaver implementation is part of Aspose.Slides; using default behavior here)
                // Save the presentation as XAML
                presentation.Save(xamlOptions);

                // Dispose the presentation
                presentation.Dispose();

                Console.WriteLine("Presentation saved as XAML with embedded fonts.");
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The requested format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}