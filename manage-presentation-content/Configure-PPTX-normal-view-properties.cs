using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConfigureNormalView
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation())
                {
                    // Access the read‑only NormalViewProperties and modify its settable members
                    Aspose.Slides.INormalViewProperties normalProps = pres.ViewProperties.NormalViewProperties;

                    // Set the state of the horizontal splitter bar
                    normalProps.HorizontalBarState = Aspose.Slides.SplitterBarStateType.Restored;

                    // Set the state of the vertical splitter bar
                    normalProps.VerticalBarState = Aspose.Slides.SplitterBarStateType.Maximized;

                    // Prefer a single content region view
                    normalProps.PreferSingleView = true;

                    // Show outline icons in the normal view
                    normalProps.ShowOutlineIcons = true;

                    // Save the presentation (using the correct SaveFormat enum from Aspose.Slides.Export)
                    pres.Save("ConfiguredNormalView.pptx", SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Simple error handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}