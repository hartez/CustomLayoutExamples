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