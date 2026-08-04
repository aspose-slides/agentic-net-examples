// -----------------------------------------------------------------------------
// Example: Add error bars to scatter charts and export PNGs using C#
//
// Description:
// Demonstrates how to add custom error bars to scatter charts within a PowerPoint
// presentation using Aspose.Slides for .NET, then export each slide as a PNG image.
// The example processes all PPTX files in a specified input folder, modifies the
// charts, saves the updated presentation, and generates PNG files for each slide.
// This pattern can be used for batch automation of chart enhancements and image
// extraction from presentations.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PNG, Error Bars, Scatter Chart,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding custom error bars to scatter charts in multiple presentations.
// - Batch convert PPTX slides to PNG images after chart modifications.
// - Build .NET tools for PowerPoint chart enhancement and image export.
// - Validate and preview presentation changes in automated workflows.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace BatchProcessErrorBars
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output directories
            string inputDir = "InputPptx";
            string outputDir = "OutputPng";

            // Ensure the output directory exists
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Verify input directory exists
            if (!Directory.Exists(inputDir))
            {
                Console.WriteLine("Input directory does not exist: " + inputDir);
                return;
            }

            // Get all PPTX files in the input directory
            string[] pptxFiles = Directory.GetFiles(inputDir, "*.pptx", SearchOption.TopDirectoryOnly);

            foreach (string pptxPath in pptxFiles)
            {
                try
                {
                    // Load the presentation
                    Presentation pres = new Presentation(pptxPath);

                    // Iterate through all slides
                    for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
                    {
                        ISlide slide = pres.Slides[slideIndex];

                        // Iterate through all shapes on the slide
                        for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                        {
                            IShape shape = slide.Shapes[shapeIndex];
                            IChart chart = shape as IChart;

                            // Process only scatter charts
                            if (chart != null && ChartTypeCharacterizer.IsChartTypeScatter(chart.Type))
                            {
                                // Add custom error bars to each series in the chart
                                for (int seriesIndex = 0; seriesIndex < chart.ChartData.Series.Count; seriesIndex++)
                                {
                                    IChartSeries series = chart.ChartData.Series[seriesIndex];
                                    IErrorBarsFormat errBarX = series.ErrorBarsXFormat;
                                    IErrorBarsFormat errBarY = series.ErrorBarsYFormat;

                                    // Make error bars visible and set them to custom type
                                    errBarX.IsVisible = true;
                                    errBarY.IsVisible = true;
                                    errBarX.ValueType = ErrorBarValueType.Custom;
                                    errBarY.ValueType = ErrorBarValueType.Custom;

                                    // Configure data source type for custom error values
                                    IChartDataPointCollection points = series.DataPoints;
                                    IDataSourceTypeForErrorBarsCustomValues ds = points.DataSourceTypeForErrorBarsCustomValues;
                                    ds.DataSourceTypeForXMinusValues = DataSourceType.DoubleLiterals;
                                    ds.DataSourceTypeForXPlusValues = DataSourceType.DoubleLiterals;
                                    ds.DataSourceTypeForYMinusValues = DataSourceType.DoubleLiterals;
                                    ds.DataSourceTypeForYPlusValues = DataSourceType.DoubleLiterals;

                                    // Assign custom error values for each data point
                                    for (int pointIndex = 0; pointIndex < points.Count; pointIndex++)
                                    {
                                        points[pointIndex].ErrorBarsCustomValues.XMinus.AsLiteralDouble = pointIndex + 1;
                                        points[pointIndex].ErrorBarsCustomValues.XPlus.AsLiteralDouble = pointIndex + 1;
                                        points[pointIndex].ErrorBarsCustomValues.YMinus.AsLiteralDouble = pointIndex + 1;
                                        points[pointIndex].ErrorBarsCustomValues.YPlus.AsLiteralDouble = pointIndex + 1;
                                    }
                                }
                            }
                        }
                    }

                    // Save the modified presentation (required before exit)
                    string fileNameWithoutExt = Path.GetFileNameWithoutExtension(pptxPath);
                    string presOutputPath = Path.Combine(outputDir, fileNameWithoutExt + "_modified.pptx");
                    pres.Save(presOutputPath, SaveFormat.Pptx);

                    // Export each slide as a PNG image
                    for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
                    {
                        ISlide slide = pres.Slides[slideIndex];
                        IImage slideImage = slide.GetImage();
                        string pngPath = Path.Combine(outputDir, fileNameWithoutExt + "_slide" + slideIndex + ".png");
                        slideImage.Save(pngPath, ImageFormat.Png);
                    }

                    // Dispose the presentation
                    pres.Dispose();
                }
                catch (DirectoryNotFoundException dirEx)
                {
                    // Handle missing directory errors
                    Console.WriteLine("Directory not found: " + dirEx.Message);
                }
                catch (PptxUnsupportedFormatException)
                {
                    // Format not supported
                }
                catch (Exception ex)
                {
                    // General exception handling
                    Console.WriteLine("Error processing file '" + pptxPath + "': " + ex.Message);
                }
            }
        }
    }
}
