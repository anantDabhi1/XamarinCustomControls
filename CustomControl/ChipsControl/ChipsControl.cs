using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace CustomControl.ChipsControl
{
    public class ChipsControl : Layout<View>
    {
        public static BindableProperty SpacingProperty = BindableProperty.Create(nameof(Spacing), typeof(Thickness), typeof(ChipsControl), new Thickness(6));
        public static BindableProperty ItemsSourceProperty = BindableProperty.Create(nameof(ItemsSource), typeof(IList), typeof(ChipsControl), propertyChanged: ItemSourcePropertyChangedCallback);
        public static BindableProperty ChipsBackgroundColorProperty = BindableProperty.Create(nameof(ChipsBackgroundColor), typeof(Color), typeof(ChipsControl), Color.FromHex("#FFFFFF"));
        public static BindableProperty SelectedChipsBackgroundColorProperty = BindableProperty.Create(nameof(SelectedChipsBackgroundColor), typeof(Color), typeof(ChipsControl), Color.FromHex("#5949C0"));

        public Thickness Spacing
        {
            get { return (Thickness)GetValue(SpacingProperty); }
            set { SetValue(SpacingProperty, value); InvalidateLayout(); }
        }

        public Color ChipsBackgroundColor
        {
            get { return (Color)GetValue(ChipsBackgroundColorProperty); }
            set { SetValue(ChipsBackgroundColorProperty, value); }
        }
        public Color SelectedChipsBackgroundColor
        {
            get { return (Color)GetValue(SelectedChipsBackgroundColorProperty); }
            set { SetValue(SelectedChipsBackgroundColorProperty, value); }
        }

        private static void ItemSourcePropertyChangedCallback(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue is IList)
            {
                var items = newValue as IList;
                foreach (var item in items)
                {
                    if (item is ChipsItem)
                    {
                        var chipsControl = bindable as ChipsControl;
                        chipsControl.Children.Add(CreateRandomBoxview(item as ChipsItem, chipsControl.ChipsBackgroundColor, chipsControl.SelectedChipsBackgroundColor));  // Creating a chip with one value of ItemList
                    }
                }
            }
        }

        private static Frame CreateRandomBoxview(ChipsItem items, Color backgroundColor, Color selectedBackgroundColor)
        {
            var view = new Frame
            {
                BackgroundColor = (items.IsSelected) ? backgroundColor : selectedBackgroundColor,
                BorderColor = (items.IsSelected) ? selectedBackgroundColor : backgroundColor,
                Padding = new Thickness(20, 10),
                CornerRadius = 20,
                HasShadow = false
            };    // Creating New View for design as chip

            //Chip click event
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) =>
            {
                var frameSender = (Frame)s;
                var labelDemo = (Label)frameSender.Content;
                if (!items.IsSelected)
                {
                    view.BackgroundColor = backgroundColor;
                    labelDemo.TextColor = selectedBackgroundColor;
                    view.BorderColor = selectedBackgroundColor;
                    items.IsSelected = true;
                }
                else if (items.IsSelected)
                {
                    view.BackgroundColor = selectedBackgroundColor;
                    labelDemo.TextColor = backgroundColor;
                    view.BorderColor = backgroundColor;
                    items.IsSelected= false;
                }
            };
            view.GestureRecognizers.Add(tapGestureRecognizer);

            // creating new child that holds the value of item list and add in View
            var label = new Label();
            label.Text = items.ItemName;
            label.TextColor = (items.IsSelected) ? selectedBackgroundColor : backgroundColor;
            label.HorizontalOptions = LayoutOptions.Center;
            label.VerticalOptions = LayoutOptions.Center;
            label.FontSize = 20;
            view.Content = label;
            return view;
        }


        public IList ItemsSource
        {
            get { return (IList)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); InvalidateLayout(); }
        }


        protected override void LayoutChildren(double x, double y, double width, double height)
        {
            var layoutInfo = new LayoutInfo(Spacing);
            layoutInfo.ProcessLayout(Children, width);

            for (int i = 0; i < layoutInfo.Bounds.Count; i++)
            {
                if (!Children[i].IsVisible)
                {
                    continue;
                }
                var bounds = layoutInfo.Bounds[i];
                bounds.Left += x;
                bounds.Top += y;
                LayoutChildIntoBoundingRegion(Children[i], bounds);
            }
        }

        protected override SizeRequest OnMeasure(double widthConstraint, double heightConstraint)
        {
            var layoutInfo = new LayoutInfo(Spacing);
            layoutInfo.ProcessLayout(Children, widthConstraint);
            return new SizeRequest(new Size(widthConstraint, layoutInfo.HeightRequest));
        }

        /// <summary>
        /// Subcalsss for chips control layout
        /// </summary>
        public class LayoutInfo
        {
            double _x = 0;
            double _y = 0;
            double _rowHeight = 0;
            Thickness _spacing;

            public LayoutInfo(Thickness spacing)
            {
                _spacing = spacing;
            }

            public List<Rectangle> Bounds { get; private set; }

            public double HeightRequest { get; private set; }

            public void ProcessLayout(IList<View> views, double widthConstraint)
            {
                Bounds = new List<Rectangle>();
                var sizes = SizeViews(views, widthConstraint);
                LayoutViews(views, sizes, widthConstraint);
            }

            private List<Rectangle> SizeViews(IList<View> views, double widthConstraint)
            {
                var sizes = new List<Rectangle>();
                foreach (var view in views)
                {
                    var sizeRequest = view.Measure(widthConstraint, double.PositiveInfinity).Request;
                    var viewWidth = sizeRequest.Width;
                    var viewHeight = sizeRequest.Height;

                    if (viewWidth > widthConstraint)
                        viewWidth = widthConstraint;

                    sizes.Add(new Rectangle(0, 0, viewWidth, viewHeight));
                }
                return sizes;
            }

            private void LayoutViews(IList<View> views, List<Rectangle> sizes, double widthConstraint)
            {
                Bounds = new List<Rectangle>();
                _x = 0d;
                _y = 0d;
                HeightRequest = 0;

                for (int i = 0; i < views.Count(); i++)
                {
                    if (!views[i].IsVisible)
                    {
                        Bounds.Add(new Rectangle(0, 0, 0, 0));
                        continue;
                    }

                    var sizeRect = sizes[i];

                    CheckNewLine(sizeRect.Width, widthConstraint);
                    UpdateRowHeight(sizeRect.Height);

                    var bound = new Rectangle(_x, _y, sizeRect.Width, sizeRect.Height);
                    Bounds.Add(bound);

                    _x += bound.Width;
                    _x += _spacing.HorizontalThickness;
                }
                HeightRequest += _rowHeight;
            }

            private void CheckNewLine(double viewWidth, double widthConstraint)
            {
                if (_x + viewWidth > widthConstraint)
                {
                    _y += _rowHeight + _spacing.VerticalThickness;
                    HeightRequest = _y;
                    _x = 0;
                    _rowHeight = 0;
                }
            }

            private void UpdateRowHeight(double viewHeight)
            {
                if (viewHeight > _rowHeight)
                    _rowHeight = viewHeight;
            }
        }
    }
}
