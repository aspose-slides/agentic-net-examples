using System;
using System.IO;
using System.Drawing;
using System.Drawing.Text;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the input presentation
            string inputPath = "input.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Desired default regular font (could be passed via args)
            string desiredFont = "NonExistentFont";
            // System fallback font
            string fallbackFont = "Arial";

            // Check if the desired font is installed on the system
            bool isDesiredFontInstalled = false;
            try
            {
                InstalledFontCollection fontsCollection = new InstalledFontCollection();
                foreach (FontFamily family in fontsCollection.Families)
                {
                    if (string.Equals(family.Name, desiredFont, StringComparison.OrdinalIgnoreCase))
                    {
                        isDesiredFontInstalled = true;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                // If checking fonts fails, default to fallback font
                Console.WriteLine("Failed to check installed fonts: " + ex.Message);
                isDesiredFontInstalled = false;
            }

            // Configure load options with appropriate default regular font
            LoadOptions loadOptions = new LoadOptions();
            if (isDesiredFontInstalled)
            {
                loadOptions.DefaultRegularFont = desiredFont;
            }
            else
            {
                loadOptions.DefaultRegularFont = fallbackFont;
            }

            // Load the presentation using the configured load options
            Presentation presentation = null;
            try
            {
                presentation = new Presentation(inputPath, loadOptions);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // (Comment: The provided file format is not supported by Aspose.Slides.)
                Console.WriteLine("The file format is not supported.");
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading presentation: " + ex.Message);
                return;
            }

            // Perform any required operations on the presentation here
            // ...

            // Save the presentation before exiting
            try
            {
                string outputPath = "output.pptx";
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                Console.WriteLine("Presentation saved to: " + outputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported during save
                // (Comment: The requested save format is not supported.)
                Console.WriteLine("The save format is not supported.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving presentation: " + ex.Message);
            }
            finally
            {
                if (presentation != null)
                {
                    presentation.Dispose();
                }
            }
        }
    }
}