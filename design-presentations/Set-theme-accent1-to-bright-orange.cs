using Aspose.Slides;
using Aspose.Slides.Export;
using System;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the Accent1 color format from the master theme
        Aspose.Slides.IColorFormat accent1Format = presentation.MasterTheme.ColorScheme.Accent1;

        // Assign bright orange to Accent1
        accent1Format.Color = System.Drawing.Color.FromArgb(255, 165, 0);

        // Output file path
        string outputPath = "Accent1_Orange.pptx";

        try
        {
            // Save the presentation in PPTX format
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // If the format is not supported, handle the exception
            // Format not supported
        }

        // Dispose the presentation object
        presentation.Dispose();
    }
}