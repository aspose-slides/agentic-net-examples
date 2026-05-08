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
                    Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(pptxPath);

                    // Iterate through all slides
                    for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
                    {
                        Aspose.Slides.ISlide slide = pres.Slides[slideIndex];

                        // Iterate through all shapes on the slide
                        for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                        {
                            Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];
                            Aspose.Slides.Charts.IChart chart = shape as Aspose.Slides.Charts.IChart;

                            // Process only scatter charts
                            if (chart != null && Aspose.Slides.Charts.ChartTypeCharacterizer.IsChartTypeScatter(chart.Type))
                            {
                                // Add custom error bars to each series in the chart
                                for (int seriesIndex = 0; seriesIndex < chart.ChartData.Series.Count; seriesIndex++)
                                {
                                    Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[seriesIndex];
                                    Aspose.Slides.Charts.IErrorBarsFormat errBarX = series.ErrorBarsXFormat;
                                    Aspose.Slides.Charts.IErrorBarsFormat errBarY = series.ErrorBarsYFormat;

                                    // Make error bars visible and set them to custom type
                                    errBarX.IsVisible = true;
                                    errBarY.IsVisible = true;
                                    errBarX.ValueType = Aspose.Slides.Charts.ErrorBarValueType.Custom;
                                    errBarY.ValueType = Aspose.Slides.Charts.ErrorBarValueType.Custom;

                                    // Configure data source type for custom error values
                                    Aspose.Slides.Charts.IChartDataPointCollection points = series.DataPoints;
                                    Aspose.Slides.Charts.IDataSourceTypeForErrorBarsCustomValues ds = points.DataSourceTypeForErrorBarsCustomValues;
                                    ds.DataSourceTypeForXMinusValues = Aspose.Slides.Charts.DataSourceType.DoubleLiterals;
                                    ds.DataSourceTypeForXPlusValues = Aspose.Slides.Charts.DataSourceType.DoubleLiterals;
                                    ds.DataSourceTypeForYMinusValues = Aspose.Slides.Charts.DataSourceType.DoubleLiterals;
                                    ds.DataSourceTypeForYPlusValues = Aspose.Slides.Charts.DataSourceType.DoubleLiterals;

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
                    pres.Save(presOutputPath, Aspose.Slides.Export.SaveFormat.Pptx);

                    // Export each slide as a PNG image
                    for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
                    {
                        Aspose.Slides.ISlide slide = pres.Slides[slideIndex];
                        Aspose.Slides.IImage slideImage = slide.GetImage();
                        string pngPath = Path.Combine(outputDir, fileNameWithoutExt + "_slide" + slideIndex + ".png");
                        slideImage.Save(pngPath, Aspose.Slides.ImageFormat.Png);
                    }

                    // Dispose the presentation
                    pres.Dispose();
                }
                catch (System.IO.DirectoryNotFoundException dirEx)
                {
                    // Handle missing directory errors
                    Console.WriteLine("Directory not found: " + dirEx.Message);
                }
                catch (Aspose.Slides.PptxUnsupportedFormatException)
                {
                    // Format not supported
                    // format not supported
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