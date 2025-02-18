using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Markup.Xaml.Templates;
using Avalonia.Metadata;

namespace Fluentcord.Controls;

public class LazyLoad : Control {
    private Control? _control;

    public static readonly StyledProperty<bool> LoadProperty = AvaloniaProperty.Register<LazyLoad, bool>("Load");

    public bool Load {
        get => GetValue(LoadProperty);
        set => SetValue(LoadProperty, value);
    }

    [Content] [TemplateContent] public required object DeferredContent { get; set; }

    public Control? Control => _control;
    
    static LazyLoad() {
        LoadProperty.Changed.AddClassHandler<LazyLoad>((c, e) => {
            if (e.NewValue is true) {
                c.DoLoad();
            }
        });
    }

    protected override Size MeasureOverride(Size availableSize) => LayoutHelper.MeasureChild(_control, availableSize, default);

    protected override Size ArrangeOverride(Size finalSize) => LayoutHelper.ArrangeChild(_control, finalSize, default);

    private void DoLoad() {
        _control = TemplateContent.Load(DeferredContent)!.Result;
        ((ISetLogicalParent)_control).SetParent(this);
        VisualChildren.Add(_control);
        LogicalChildren.Add(_control);

        InvalidateMeasure();
    }
}