using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace RestoreNormalViewPropertiesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation())
            {
                // Set normal view properties
                pres.ViewProperties.NormalViewProperties.HorizontalBarState = Aspose.Slides.SplitterBarStateType.Restored;
                pres.ViewProperties.NormalViewProperties.VerticalBarState = Aspose.Slides.SplitterBarStateType.Maximized;
                pres.ViewProperties.NormalViewProperties.RestoredTop.AutoAdjust = true;
                pres.ViewProperties.NormalViewProperties.RestoredTop.DimensionSize = 80f;
                pres.ViewProperties.NormalViewProperties.ShowOutlineIcons = true;

                // Save the presentation in PPT format
                pres.Save("RestoredNormalView.ppt", Aspose.Slides.Export.SaveFormat.Ppt);
            }
        }
    }
}