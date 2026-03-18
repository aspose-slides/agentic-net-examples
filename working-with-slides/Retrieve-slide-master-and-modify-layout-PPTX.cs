using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

namespace RetrieveSlideMaster
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the source presentation
            string sourcePath = "input.pptx";
            // Path for the modified presentation
            string outputPath = "output.pptx";

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(sourcePath))
                {
                    // Retrieve the first master slide
                    IMasterSlide masterSlide = presentation.Masters[0];

                    // Modify the background of the master slide
                    masterSlide.Background.Type = BackgroundType.OwnBackground;
                    masterSlide.Background.FillFormat.FillType = FillType.Solid;
                    masterSlide.Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

                    // Example: Change a format scheme property via MasterTheme
                    // Set the first line style color to Red
                    masterSlide.ThemeManager.OverrideTheme = presentation.MasterTheme;
                    masterSlide.ThemeManager.OverrideTheme.FormatScheme.LineStyles[0].FillFormat.SolidFillColor.Color = Color.Red;

                    // Save the modified presentation
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}