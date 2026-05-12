using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ReplaceColorScheme
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Load existing presentation if it exists; otherwise create a new one
            if (File.Exists(inputPath))
            {
                try
                {
                    using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                    {
                        ApplyCorporatePalette(presentation);
                        // Save the modified presentation
                        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                    }
                }
                catch (Exception ex)
                {
                    // Handle exceptions such as unsupported file format
                    // Format not supported
                    Console.WriteLine("Error loading presentation: " + ex.Message);
                }
            }
            else
            {
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
                {
                    ApplyCorporatePalette(presentation);
                    // Save the new presentation
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
        }

        // Method to replace the default color scheme with a corporate palette
        private static void ApplyCorporatePalette(Aspose.Slides.Presentation presentation)
        {
            // Define corporate colors (example RGB values)
            System.Drawing.Color corporateAccent1 = System.Drawing.Color.FromArgb(0, 112, 192);   // Blue
            System.Drawing.Color corporateAccent2 = System.Drawing.Color.FromArgb(255, 192, 0);   // Orange
            System.Drawing.Color corporateAccent3 = System.Drawing.Color.FromArgb(112, 173, 71);  // Green
            System.Drawing.Color corporateAccent4 = System.Drawing.Color.FromArgb(255, 0, 0);     // Red
            System.Drawing.Color corporateAccent5 = System.Drawing.Color.FromArgb(191, 191, 191); // Light Gray
            System.Drawing.Color corporateAccent6 = System.Drawing.Color.FromArgb(0, 0, 0);       // Black
            System.Drawing.Color corporateDark1    = System.Drawing.Color.FromArgb(31, 31, 31);    // Dark Gray
            System.Drawing.Color corporateDark2    = System.Drawing.Color.FromArgb(79, 79, 79);    // Medium Dark Gray
            System.Drawing.Color corporateLight1   = System.Drawing.Color.FromArgb(242, 242, 242); // Very Light Gray
            System.Drawing.Color corporateLight2   = System.Drawing.Color.FromArgb(221, 221, 221); // Light Gray

            // Access the master theme's color scheme
            Aspose.Slides.Theme.IMasterTheme masterTheme = presentation.MasterTheme;
            Aspose.Slides.Theme.IColorScheme colorScheme = masterTheme.ColorScheme;

            // Assign corporate colors to the scheme
            colorScheme.Accent1.Color = corporateAccent1;
            colorScheme.Accent2.Color = corporateAccent2;
            colorScheme.Accent3.Color = corporateAccent3;
            colorScheme.Accent4.Color = corporateAccent4;
            colorScheme.Accent5.Color = corporateAccent5;
            colorScheme.Accent6.Color = corporateAccent6;
            colorScheme.Dark1.Color = corporateDark1;
            colorScheme.Dark2.Color = corporateDark2;
            colorScheme.Light1.Color = corporateLight1;
            colorScheme.Light2.Color = corporateLight2;
        }
    }
}