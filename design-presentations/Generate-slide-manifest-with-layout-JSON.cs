using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Add a new slide based on the first layout slide
            ISlide slide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

            // Add a rectangle shape with a text frame containing the word keyword
            string sampleText = "This is a sample keyword text.";
            IAutoShape rectangle = (IAutoShape)slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 50);
            rectangle.AddTextFrame(sampleText);

            // Search for text boxes that contain the specified word
            string keyword = "keyword";
            List<ITextFrame> matchingFrames = new List<ITextFrame>();
            foreach (ITextFrame textFrame in SlideUtil.GetTextBoxesContainsText(slide, keyword, true))
            {
                matchingFrames.Add(textFrame);
            }

            // Find placeholders of type CenteredTitle
            List<IShape> centeredPlaceholders = new List<IShape>();
            foreach (IShape placeholder in SlideUtil.FindShapesByPlaceholderType(slide, PlaceholderType.CenteredTitle))
            {
                centeredPlaceholders.Add(placeholder);
            }

            // Build JSON manifest describing each slide's layout, shapes, and text content
            List<object> slideManifests = new List<object>();
            int slideIndex = 0;
            foreach (ISlide sld in presentation.Slides)
            {
                List<object> shapeInfos = new List<object>();
                foreach (IShape shp in sld.Shapes)
                {
                    string shapeType = shp.GetType().Name;
                    string text = string.Empty;
                    IAutoShape autoShape = shp as IAutoShape;
                    if (autoShape != null && autoShape.TextFrame != null)
                    {
                        text = autoShape.TextFrame.Text;
                    }
                    shapeInfos.Add(new { Type = shapeType, Text = text });
                }
                slideManifests.Add(new { SlideIndex = slideIndex, Shapes = shapeInfos });
                slideIndex++;
            }

            string jsonManifest = JsonSerializer.Serialize(slideManifests, new JsonSerializerOptions { WriteIndented = true });
            string manifestPath = "manifest.json";
            File.WriteAllText(manifestPath, jsonManifest);

            // Save the presentation (handle unsupported format)
            try
            {
                presentation.Save("output.pptx", SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }
        }
    }
}