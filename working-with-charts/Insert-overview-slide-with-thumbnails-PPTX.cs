using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace InsertOverviewSlide
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            using (Presentation presentation = new Presentation(inputPath))
            {
                // Remember original slide count before adding the overview slide
                int originalSlideCount = presentation.Slides.Count;

                // Get a master slide (first one) to associate with a new layout
                IMasterSlide master = presentation.Masters[0];

                // Try to get an existing Blank layout; if not present, add a new one
                ILayoutSlide layout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
                if (layout == null)
                {
                    layout = presentation.LayoutSlides.Add(master, SlideLayoutType.Blank, "OverviewLayout");
                }

                // Add a new empty slide that will hold the thumbnails
                ISlide overviewSlide = presentation.Slides.AddEmptySlide(layout);
                overviewSlide.Name = "Overview";

                // Settings for thumbnail placement
                const int thumbWidth = 200;
                const int thumbHeight = 150;
                const int margin = 10;
                const int columns = 4;

                int currentX = margin;
                int currentY = margin;
                int placed = 0;

                // Generate thumbnails for each original slide and place them on the overview slide
                for (int i = 0; i < originalSlideCount; i++)
                {
                    ISlide sourceSlide = presentation.Slides[i];
                    IImage thumbnail = sourceSlide.GetImage(0.5f, 0.5f); // Scale to 50%
                    IPPImage picture = presentation.Images.AddImage(thumbnail);

                    overviewSlide.Shapes.AddPictureFrame(ShapeType.Rectangle, currentX, currentY, thumbWidth, thumbHeight, picture);

                    placed++;
                    currentX += thumbWidth + margin;
                    if (placed % columns == 0)
                    {
                        currentX = margin;
                        currentY += thumbHeight + margin;
                    }
                }

                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
    }
}