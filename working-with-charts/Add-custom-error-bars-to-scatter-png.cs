using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AddCustomErrorBarsAndExportPng
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output directories
            string inputDirectory = "InputPptx";
            string outputPresentationDirectory = "OutputPptx";
            string outputPngDirectory = "OutputPng";

            // Ensure directories exist
            if (!Directory.Exists(inputDirectory))
            {
                // Input directory does not exist – nothing to process
                return;
            }
            if (!Directory.Exists(outputPresentationDirectory))
            {
                Directory.CreateDirectory(outputPresentationDirectory);
            }
            if (!Directory.Exists(outputPngDirectory))
            {
                Directory.CreateDirectory(outputPngDirectory);
            }

            // Process each PPTX file in the input directory
            string[] pptxFiles = Directory.GetFiles(inputDirectory, "*.pptx", SearchOption.TopDirectoryOnly);
            foreach (string pptxFilePath in pptxFiles)
            {
                try
                {
                    // Load the presentation
                    using (Presentation presentation = new Presentation(pptxFilePath))
                    {
                        // Iterate through all slides
                        foreach (ISlide slide in presentation.Slides)
                        {
                            // Iterate through all shapes on the slide
                            foreach (IShape shape in slide.Shapes)
                            {
                                // Process only chart shapes
                                if (shape is IChart)
                                {
                                    IChart chart = (IChart)shape;

                                    // Check if the chart is a scatter type
                                    if (ChartTypeCharacterizer.IsChartTypeScatter(chart.Type))
                                    {
                                        // Ensure there is at least one series
                                        if (chart.ChartData.Series.Count > 0)
                                        {
                                            // Use the first series for demonstration
                                            IChartSeries series = chart.ChartData.Series[0];

                                            // Access error bars formats for X and Y directions
                                            IErrorBarsFormat errBarX = series.ErrorBarsXFormat;
                                            IErrorBarsFormat errBarY = series.ErrorBarsYFormat;

                                            // Make error bars visible and set custom value type
                                            errBarX.IsVisible = true;
                                            errBarY.IsVisible = true;
                                            errBarX.ValueType = ErrorBarValueType.Custom;
                                            errBarY.ValueType = ErrorBarValueType.Custom;

                                            // Configure data source types for custom error values
                                            IChartDataPointCollection points = series.DataPoints;
                                            points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXPlusValues = DataSourceType.DoubleLiterals;
                                            points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXMinusValues = DataSourceType.DoubleLiterals;
                                            points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYPlusValues = DataSourceType.DoubleLiterals;
                                            points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYMinusValues = DataSourceType.DoubleLiterals;

                                            // Assign custom error values (example: incremental values)
                                            for (int i = 0; i < points.Count; i++)
                                            {
                                                points[i].ErrorBarsCustomValues.XMinus.AsLiteralDouble = i + 1;
                                                points[i].ErrorBarsCustomValues.XPlus.AsLiteralDouble = i + 1;
                                                points[i].ErrorBarsCustomValues.YMinus.AsLiteralDouble = i + 1;
                                                points[i].ErrorBarsCustomValues.YPlus.AsLiteralDouble = i + 1;
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        // Save the modified presentation
                        string presentationFileName = Path.GetFileNameWithoutExtension(pptxFilePath);
                        string outputPresentationPath = Path.Combine(outputPresentationDirectory, presentationFileName + "_modified.pptx");
                        presentation.Save(outputPresentationPath, SaveFormat.Pptx);

                        // Export each slide as a PNG image
                        for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                        {
                            IImage slideImage = presentation.Slides[slideIndex].GetImage();
                            string pngFileName = presentationFileName + "_slide" + (slideIndex + 1) + ".png";
                            string pngFilePath = Path.Combine(outputPngDirectory, pngFileName);
                            slideImage.Save(pngFilePath, ImageFormat.Png);
                        }
                    }
                }
                catch (PptxUnsupportedFormatException)
                {
                    // Format not supported – skip this file
                }
                catch (Exception)
                {
                    // General exception handling (e.g., I/O errors) – continue with next file
                }
            }
        }
    }
}