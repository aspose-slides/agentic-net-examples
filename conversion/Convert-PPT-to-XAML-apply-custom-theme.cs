using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Export.Xaml;
using Aspose.Slides.Theme;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string themePath = "customTheme.thmx";
        string outputPptxPath = "output_modified.pptx";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            if (!File.Exists(themePath))
            {
                Console.WriteLine("Theme file does not exist: " + themePath);
                return;
            }

            // Load the presentation
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Apply external theme to each master slide
                foreach (IMasterSlide masterSlide in presentation.Masters)
                {
                    IMasterSlide newMaster = masterSlide.ApplyExternalThemeToDependingSlides(themePath);

                    // Modify the color scheme of the master theme (e.g., change Accent1 to Red)
                    IColorScheme colorScheme = presentation.MasterTheme.ColorScheme;
                    if (colorScheme != null)
                    {
                        colorScheme.Accent1.Color = Color.Red;
                    }
                }

                // Save the modified presentation (required before exit)
                presentation.Save(outputPptxPath, SaveFormat.Pptx);

                // Export the presentation to XAML files
                XamlOptions xamlOptions = new XamlOptions();
                xamlOptions.ExportHiddenSlides = true;
                presentation.Save(xamlOptions);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}