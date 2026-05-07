using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Export.Xaml;

class Program
{
    static void Main(string[] args)
    {
        // Paths for input presentation and external theme file
        string inputPath = "input.pptx";
        string themePath = "custom.thmx";

        // Verify that the input presentation exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input presentation file not found.");
            return;
        }

        // Verify that the external theme file exists
        if (!File.Exists(themePath))
        {
            Console.WriteLine("External theme file not found.");
            return;
        }

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

            // Apply the external theme to each master slide and its dependent slides
            for (int i = 0; i < pres.Masters.Count; i++)
            {
                Aspose.Slides.IMasterSlide master = pres.Masters[i];
                master.ApplyExternalThemeToDependingSlides(themePath);
            }

            // Save the presentation as XAML files
            Aspose.Slides.Export.Xaml.XamlOptions xamlOptions = new Aspose.Slides.Export.Xaml.XamlOptions();
            pres.Save(xamlOptions);
        }
        catch (Aspose.Slides.PptxReadException ex)
        {
            // Handle errors related to applying the external theme
            Console.WriteLine("Failed to apply external theme: " + ex.Message);
        }
        catch (NotSupportedException ex)
        {
            // Format not supported
            // format not supported
            Console.WriteLine("Operation not supported: " + ex.Message);
        }
        catch (Exception ex)
        {
            // General error handling
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}