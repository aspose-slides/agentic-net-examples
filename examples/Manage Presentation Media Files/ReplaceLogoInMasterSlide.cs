using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ReplaceLogoInMasterSlide
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths for the original logo, the replacement logo and the output presentation
            string originalLogoPath = "logo.png";
            string replacementLogoPath = "newlogo.png";
            string outputPresentationPath = "output.pptx";

            // Load logo image bytes
            byte[] originalLogoData = File.ReadAllBytes(originalLogoPath);

            // Create a new presentation
            Presentation pres = new Presentation();

            // Add the original logo to the presentation's image collection
            IPPImage originalLogoImage = pres.Images.AddImage(originalLogoData);

            // Ensure there is at least one slide to work with
            ISlide slide;
            if (pres.Slides.Count > 0)
            {
                slide = pres.Slides[0];
            }
            else
            {
                slide = pres.Slides.AddEmptySlide(pres.LayoutSlides.GetByType(SlideLayoutType.Blank));
            }

            // Add the logo as a picture frame on the first slide (covers the whole slide)
            slide.Shapes.AddPictureFrame(
                ShapeType.Rectangle,
                0,
                0,
                pres.SlideSize.Size.Width,
                pres.SlideSize.Size.Height,
                originalLogoImage);

            // Add the logo to the master slide so it appears on all slides that use this master
            IMasterSlide masterSlide = pres.Masters[0];
            IPPImage masterLogoImage = pres.Images.AddImage(originalLogoData);
            masterSlide.Shapes.AddPictureFrame(
                ShapeType.Rectangle,
                10,   // X position on master
                10,   // Y position on master
                100,  // Width of logo
                100,  // Height of logo
                masterLogoImage);

            // Replace the logo image in the presentation's image collection
            byte[] replacementLogoData = File.ReadAllBytes(replacementLogoPath);
            masterLogoImage.ReplaceImage(replacementLogoData);

            // Save the presentation in PPTX format
            pres.Save(outputPresentationPath, SaveFormat.Pptx);
        }
    }
}