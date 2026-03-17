using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
            {
                // Retrieve the master theme (read‑only property)
                Aspose.Slides.Theme.IMasterTheme masterTheme = presentation.MasterTheme;

                // Modify a line style color in the master theme
                masterTheme.FormatScheme.LineStyles[0].FillFormat.SolidFillColor.Color = Color.Red;

                // Access the first master slide and set its OverrideTheme to the modified master theme
                Aspose.Slides.IMasterSlide firstMaster = presentation.Masters[0];
                firstMaster.ThemeManager.OverrideTheme = masterTheme;

                // Save the presentation before exiting
                presentation.Save("OutputPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}