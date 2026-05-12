using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Theme;
using System.Drawing;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            using (Presentation pres = new Presentation())
            {
                // Access the master theme's color scheme
                IMasterTheme masterTheme = pres.MasterTheme;
                IColorScheme colorScheme = masterTheme.ColorScheme;

                // Map the Hyperlink scheme color to a custom teal color (RGB 0,128,128)
                colorScheme.Hyperlink.Color = Color.FromArgb(0, 128, 128);

                // Optionally set the FollowedHyperlink color as well
                colorScheme.FollowedHyperlink.Color = Color.FromArgb(0, 100, 100);

                // Save the presentation before exiting
                pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine("File not found: " + ex.Message);
        }
        catch (NotSupportedException ex)
        {
            // Format not supported
            Console.WriteLine("Format not supported: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}