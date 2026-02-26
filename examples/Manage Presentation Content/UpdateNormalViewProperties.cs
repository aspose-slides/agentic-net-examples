using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ManageNormalViewProperties
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation())
            {
                // Set horizontal splitter bar state to Restored
                pres.ViewProperties.NormalViewProperties.HorizontalBarState = Aspose.Slides.SplitterBarStateType.Restored;

                // Set vertical splitter bar state to Maximized
                pres.ViewProperties.NormalViewProperties.VerticalBarState = Aspose.Slides.SplitterBarStateType.Maximized;

                // Configure the restored top region
                pres.ViewProperties.NormalViewProperties.RestoredTop.AutoAdjust = true;
                pres.ViewProperties.NormalViewProperties.RestoredTop.DimensionSize = 80f;

                // Show outline icons
                pres.ViewProperties.NormalViewProperties.ShowOutlineIcons = true;

                // Save the presentation in PPTX format
                pres.Save("NormalViewProperties_Output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}