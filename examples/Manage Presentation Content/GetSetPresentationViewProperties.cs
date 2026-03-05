using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = "input.ppt";
        string outputPath = "output.ppt";

        // Load the presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

        // Retrieve current view properties
        Aspose.Slides.ViewType currentLastView = pres.ViewProperties.LastView;
        float currentGridSpacing = pres.ViewProperties.GridSpacing;
        bool currentShowMediaControls = pres.SlideShowSettings.ShowMediaControls;
        Aspose.Slides.SplitterBarStateType currentHorizontalBarState = pres.ViewProperties.NormalViewProperties.HorizontalBarState;
        Aspose.Slides.SplitterBarStateType currentVerticalBarState = pres.ViewProperties.NormalViewProperties.VerticalBarState;
        bool currentShowOutlineIcons = pres.ViewProperties.NormalViewProperties.ShowOutlineIcons;

        // Update view properties
        pres.ViewProperties.LastView = Aspose.Slides.ViewType.SlideMasterView;
        pres.ViewProperties.GridSpacing = 72f;
        pres.SlideShowSettings.ShowMediaControls = true;
        pres.ViewProperties.NormalViewProperties.HorizontalBarState = Aspose.Slides.SplitterBarStateType.Restored;
        pres.ViewProperties.NormalViewProperties.VerticalBarState = Aspose.Slides.SplitterBarStateType.Maximized;
        pres.ViewProperties.NormalViewProperties.RestoredTop.AutoAdjust = true;
        pres.ViewProperties.NormalViewProperties.RestoredTop.DimensionSize = 80f;
        pres.ViewProperties.NormalViewProperties.ShowOutlineIcons = true;

        // Save the updated presentation in PPT format
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Ppt);
        pres.Dispose();
    }
}