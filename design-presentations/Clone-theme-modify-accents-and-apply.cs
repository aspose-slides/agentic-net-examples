using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ThemeCloneExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Access the first master slide
                Aspose.Slides.IMasterSlide masterSlide = presentation.Masters[0];

                // Clone the master slide by applying an external theme (could be the same theme file)
                // For demonstration, assume an external theme file "theme.thmx" exists in the same directory
                string externalThemePath = "theme.thmx";
                if (File.Exists(externalThemePath))
                {
                    Aspose.Slides.IMasterSlide newMaster = masterSlide.ApplyExternalThemeToDependingSlides(externalThemePath);
                    // The new master slide is now applied to dependent slides
                }

                // Modify accent colors of the presentation's master theme
                Aspose.Slides.Theme.IMasterTheme masterTheme = presentation.MasterTheme;
                // Change Accent1 to Red
                masterTheme.ColorScheme.Accent1.Color = Color.Red;
                // Change Accent2 to Green
                masterTheme.ColorScheme.Accent2.Color = Color.Green;
                // Change Accent3 to Blue
                masterTheme.ColorScheme.Accent3.Color = Color.Blue;

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Aspose.Slides.PptxReadException ex)
            {
                // Handle unsupported format or theme read errors
                Console.WriteLine("Error reading presentation or theme: " + ex.Message);
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}