# CustomLayoutExamples

Some examples of creating custom layouts for MAUI. These are intended to demonstrate the sorts of things which are possible, and the basics of creating a custom layout. These are not intended as production-ready layouts.

## Creating Custom Layouts in MAUI

Layouts in MAUI are pretty simple. Most of the work is done by an `ILayoutManager` implementation, which only requires two methods: 

- `Size Measure(double widthConstraint, double heightConstraint)`
- `Size ArrangeChildren(Rectangle bounds)`

A `Measure` implementation should call measure on each `IView` in the layout, and should return the total size of the layout given the constraints.

An `ArrangeChildren` implementation should determine where each `IView` should be placed within the given bounds, and should call `Arrange` on each `IView` with its appropriate bounds. The return value should be the actual size of the layout.

## HorizontalWrapLayout Example

HorizontalWrapLayout works like a horizontal stack layout, except that instead of extending out as far as it needs to the right, it will wrap to a new row when it encounters the right edge of its container. 

So given this XAML:

```
<local:HorizontalWrapLayout Margin="10" Spacing="5">
    <Button Text="One"></Button>
    <Button Text="Two"></Button>
    <Button Text="Three"></Button>
    <Button Text="Four"></Button>
    <Button Text="Five"></Button>
    <Button Text="Six"></Button>
    <Button Text="Seven"></Button>
    <Button Text="Eight"></Button>
    <Button Text="Nine"></Button>
    <Button Text="Ten"></Button>
</local:HorizontalWrapLayout>
```

You'll see something like this:

![A HorizontalWrapLayout](https://raw.githubusercontent.com/hartez/CustomLayoutExamples/main/HorizontalWrapLayout.png? "HorizontalWrapLayout")

## CascadeLayout Example

Cascades the items from top left to bottom right, similar to using the "cascade windows" arrangement in an MDI application.

```
<local:CascadeLayout Margin="10" Spacing="25">
	<Button Text="One"></Button>
	<Button Text="Two"></Button>
	<Button Text="Three"></Button>
	<Button Text="Four"></Button>
	<Button Text="Five"></Button>
	<Button Text="Six"></Button>
	<Button Text="Seven"></Button>
	<Button Text="Eight"></Button>
	<Button Text="Nine"></Button>
	<Button Text="Ten"></Button>
</local:CascadeLayout>
```

![A CascadeLayout](https://raw.githubusercontent.com/hartez/CustomLayoutExamples/main/CascadeLayout.png "HorizontalWrapLayout")

## Single Column Layout

This is [an example of a custom layout](https://github.com/hartez/CustomLayoutExamples/blob/main/CustomLayouts/ColumnLayout.cs) which can accomplish the same things as the old Forms `AndExpand` properties. It's a subclass of VerticalStackLayout which adds an attached property `Fill` that can be applied to one or more children of the layout. It uses a [custom layout manager](https://github.com/hartez/CustomLayoutExamples/blob/main/CustomLayouts/ColumnLayoutManager.cs) which converts the VSL at runtime into a single-column Grid. Each child of the VSL gets its own row in the Grid. Normally the rows are set to a height of `Auto`, but children marked as `Fill` get a row height of `*` instead. 

![A ColumnLayout](https://raw.githubusercontent.com/hartez/CustomLayoutExamples/main/ColumnLayout.png? "ColumnLayout")

## Custom Single Column Pre-Made Layouts

For folks who constantly find themselves building the same layouts out of grids/stacks/etc, [this is an example](https://github.com/hartez/CustomLayoutExamples/blob/main/CustomLayouts/ContentColumnLayout.cs) of creating a custom purpose-built layout class for your own use. It simply subclasses Layout and implements some extra properties/methods from the `IGridLayout` interface. This allows it to be fed into a `GridLayoutManager` to handle the actual layout at runtime. 

The class takes 3 views in its constructor - a header, content, and a footer. All the row/column setup is baked into the custom class, so using it becomes a single line of code wherever we need this fairly standard layout.

![A CustomContentColumn](https://raw.githubusercontent.com/hartez/CustomLayoutExamples/main/CustomContentColumn.png? "CustomContentColumn")

## ZStackLayout

Variation of StackLayout which arranges its children atop one another in order.

Works just like a VerticalStackLayout or HorizontalStackLayout, except along the Z-axis. All children are laid out at the origin; the arrangement area's width is determined by the widest child and the height is determined by the tallest child.

Provides a lower-complexity alternative to using a GridLayout to stack Views along the z-axis (e.g., in order to use an Image as a background for another View).

Example usage:

<ZStackLayout HorizontalOptions="Center" VerticalOptions="Center">
	<Image Source="dotnet_bot.png" WidthRequest="300" HeightRequest="372" HorizontalOptions="Center" />

	<Label Text="Text over the image, aligned to top" FontAttributes="Bold" FontSize="15" TextColor="Orange" HorizontalOptions="Center" VerticalOptions="Start"/>
	<Label Text="Text right in the middle" FontAttributes="Bold" FontSize="20" TextColor="LightGreen" HorizontalOptions="Center" VerticalOptions="Center"/>
	<Label Text="This is an easy way to do captions" FontAttributes="Bold" FontSize="16" TextColor="Red" HorizontalOptions="Center" VerticalOptions="End"/>
</ZStackLayout>

![A ZStack with a robot image and some text over it](https://raw.githubusercontent.com/hartez/CustomLayoutExamples/main/Zstack.png? "ZStack")