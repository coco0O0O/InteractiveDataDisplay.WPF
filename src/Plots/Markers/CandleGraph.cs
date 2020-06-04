using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Media;

// ReSharper disable once CheckNamespace
namespace InteractiveDataDisplay.WPF
{
    /// <summary>
    /// Displays bar chart graph as a particular case of marker graph. Has a set of data series: 
    /// X <see cref="DataSeries"/> defining x coordinates of the center of each bar,
    /// Y <see cref="DataSeries"/> defining the value for each bar,
    /// <see cref="ColorSeries"/> (key 'C') and <see cref="DataSeries"/> (key 'W') to set width of each bar. 
    /// </summary>
    [Description("Represents a bar chart")]
    public class CandleGraph : MarkerGraph
    {
        public CandleGraph()
        {
            Sources.Add(new DataSeries
            {
                Key = "X",
                Description = "日期"
            });
            Sources.Add(new DataSeries
            {
                Key = "Open",
                Description = "开盘"
            });
            Sources.Add(new DataSeries
            {
                Key = "Close",
                Description = "收盘"
            });
            Sources.Add(new DataSeries
            {
                Key = "High",
                Description = "最高"
            });
            Sources.Add(new DataSeries
            {
                Key = "Low",
                Description = "最低"
            });
            Sources.Add(new DataSeries
            {
                Key = "W",
                Description = "Width",
                Data = 1.0
            });
            Sources.Add(new ColorSeries());
            Sources["C"].Data = "Blue";

            LegendTemplate = BarGraphLegend;
            TooltipTemplate = Resources["CandleGraphTooltip"] as DataTemplate; 
            MarkerTemplate = Resources["CandleGraph"] as DataTemplate;

            StrokeThickness = 0; // To compensate layout subpixel rounding
            UseLayoutRounding = false;
        }

        #region X
        /// <summary>
        /// Identifies the <see cref="X"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty XProperty = DependencyProperty.Register(
            "X", typeof(object), typeof(CandleGraph), new PropertyMetadata(null, OnXChanged));

        /// <summary>
        /// Gets or sets the data of X <see cref="DataSeries"/> defining x coordinates of the center of bars.
        /// <para>Can be a single value (to draw one marker or markers with the same x coordinates) 
        /// or an array or IEnumerable (to draw a set of different markers) of any numeric type. 
        /// Can be null then x coordinates will be a sequence of integers starting with zero.</para>
        /// <para>Default value is null.</para>
        /// </summary>
        [Category("InteractiveDataDisplay")]
        [Description("DateTime")]
        public object X
        {
            get { return (object)GetValue(XProperty); }
            set { SetValue(XProperty, value); }
        }

        private static void OnXChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CandleGraph mg = (CandleGraph)d;
            mg.Sources["X"].Data = e.NewValue;
        }
        #endregion
        #region Open
        /// <summary>
        /// Identifies the <see cref="Y"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty OpenProperty = DependencyProperty.Register(
            "Open", typeof(object), typeof(CandleGraph), new PropertyMetadata(null, OnOpenChanged));

        /// <summary>
        /// Gets or sets the data for Y <see cref="DataSeries"/> defining the value of bars.
        /// <para>Can be a single value (to draw one marker or markers with the same y values) 
        /// or an array or IEnumerable (to draw markers with different y values) of any numeric type. 
        /// Can be null then no markers will be drawn.</para>
        /// <para>Default value is null.</para>
        /// </summary>
        [Category("InteractiveDataDisplay")]
        [Description("Open Price")]
        public object Open
        {
            get { return (object)GetValue(OpenProperty); }
            set { SetValue(OpenProperty, value); }
        }

        private static void OnOpenChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CandleGraph mg = (CandleGraph)d;
            mg.Sources["Open"].Data = e.NewValue;

        }
        #endregion

        #region Close
        /// <summary>
        /// Identifies the <see cref="Y"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CloseProperty = DependencyProperty.Register(
            "Close", typeof(object), typeof(CandleGraph), new PropertyMetadata(null, OnCloseChanged));

        /// <summary>
        /// Gets or sets the data for Y <see cref="DataSeries"/> defining the value of bars.
        /// <para>Can be a single value (to draw one marker or markers with the same y values) 
        /// or an array or IEnumerable (to draw markers with different y values) of any numeric type. 
        /// Can be null then no markers will be drawn.</para>
        /// <para>Default value is null.</para>
        /// </summary>
        [Category("InteractiveDataDisplay")]
        [Description("Close Price")]
        public object Close
        {
            get { return (object)GetValue(CloseProperty); }
            set { SetValue(CloseProperty, value); }
        }

        private static void OnCloseChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CandleGraph mg = (CandleGraph)d;
            mg.Sources["Close"].Data = e.NewValue;

        }
        #endregion


        #region High
        /// <summary>
        /// Identifies the <see cref="Y"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty HighProperty = DependencyProperty.Register(
            "High", typeof(object), typeof(CandleGraph), new PropertyMetadata(null, OnHighChanged));

        /// <summary>
        /// Gets or sets the data for Y <see cref="DataSeries"/> defining the value of bars.
        /// <para>Can be a single value (to draw one marker or markers with the same y values) 
        /// or an array or IEnumerable (to draw markers with different y values) of any numeric type. 
        /// Can be null then no markers will be drawn.</para>
        /// <para>Default value is null.</para>
        /// </summary>
        [Category("InteractiveDataDisplay")]
        [Description("High Price")]
        public object High
        {
            get { return (object)GetValue(HighProperty); }
            set { SetValue(HighProperty, value); }
        }

        private static void OnHighChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CandleGraph mg = (CandleGraph)d;
            mg.Sources["High"].Data = e.NewValue;

        }
        #endregion

        #region Low
        /// <summary>
        /// Identifies the <see cref="Y"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty LowProperty = DependencyProperty.Register(
            "Low", typeof(object), typeof(CandleGraph), new PropertyMetadata(null, OnLowChanged));

        /// <summary>
        /// Gets or sets the data for Y <see cref="DataSeries"/> defining the value of bars.
        /// <para>Can be a single value (to draw one marker or markers with the same y values) 
        /// or an array or IEnumerable (to draw markers with different y values) of any numeric type. 
        /// Can be null then no markers will be drawn.</para>
        /// <para>Default value is null.</para>
        /// </summary>
        [Category("InteractiveDataDisplay")]
        [Description("Low Price")]
        public object Low
        {
            get { return (object)GetValue(LowProperty); }
            set { SetValue(LowProperty, value); }
        }

        private static void OnLowChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CandleGraph mg = (CandleGraph)d;
            mg.Sources["Low"].Data = e.NewValue;

        }
        #endregion

        #region Description
        /// <summary>
        /// Identifies the <see cref="Description"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty DescriptionProperty = DependencyProperty.Register(
            "Description", typeof(string), typeof(CandleGraph), new PropertyMetadata(null, OnDescriptionChanged));

        /// <summary>
        /// Gets or sets the description of Y <see cref="DataSeries"/>. Is frequently used in legend and tooltip.
        /// <para>Default value is null.</para>
        /// </summary>
        [Category("InteractiveDataDisplay")]
        [Description("Text for legend and tooltip")]
        public string Description
        {
            get { return (string)GetValue(DescriptionProperty); }
            set { SetValue(DescriptionProperty, value); }
        }

        private static void OnDescriptionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CandleGraph mg = (CandleGraph)d;
            mg.Sources["Close"].Description = (string)e.NewValue;
        }
        #endregion    
        #region BarsWidth
        /// <summary>
        /// Identifies the <see cref="BarsWidth"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty BarsWidthProperty = DependencyProperty.Register(
            "BarsWidth", typeof(object), typeof(CandleGraph), new PropertyMetadata(1.0, OnBarsWidthChanged));

        /// <summary>
        /// Gets or sets the data for <see cref="DataSeries"/> (key 'W') of width of bars in plot coordinates.
        /// <para>Can be a single value (to draw markers of one width) or an array or IEnumerable 
        /// (to draw markers with different widths) of any numeric type.</para>
        /// <para>Default value is 1.</para>
        /// </summary>
        [Category("InteractiveDataDisplay")]
        [Description("Widths of bars in plot coordinates")]
        public object BarsWidth
        {
            get { return (object)GetValue(BarsWidthProperty); }
            set { SetValue(BarsWidthProperty, value); }
        }

        private static void OnBarsWidthChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CandleGraph mg = (CandleGraph)d;
            mg.Sources["W"].Data = e.NewValue;
        }
        #endregion
        #region Color
        /// <summary>
        /// Identifies the <see cref="Color"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ColorProperty = DependencyProperty.Register(
            "Color", typeof(SolidColorBrush), typeof(CandleGraph), new PropertyMetadata(new SolidColorBrush(Colors.Blue), OnColorChanged));

        /// <summary>
        /// Gets or sets the color of bars.
        /// <para>Default value is blue color.</para>
        /// </summary>
        [Category("InteractiveDataDisplay")]
        [Description("Bars fill color")]
        public SolidColorBrush Color
        {
            get { return (SolidColorBrush)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }

        private static void OnColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CandleGraph mg = (CandleGraph)d;
            mg.Sources["C"].Data = e.NewValue;
        }
        #endregion

        public long PlotCandle(object x, object open,object close,object high,object low)
        {
            return Plot(x, open,close,high,low, BarsWidth, Color);
        }
    }
}
