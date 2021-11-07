# CustomLayoutExamples
Some examples of creating custom layouts for MAUI

## Creating Custom Layouts in MAUI

Layouts in MAUI are pretty simple. Most of the work is done by an `ILayoutManager` implementation, which only requires two methods: 

- `Size Measure(double widthConstraint, double heightConstraint)`
- `Size ArrangeChildren(Rectangle bounds)`

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

![A HorizontalWrapLayout](https://github.com/hartez/CustomLayoutExamples/blob/19d2edfed5a0d7764334f05a490d06be85d75049/HorizontalWrapLayout.png "HorizontalWrapLayout")


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

![A CascadeLayout](https://github.com/hartez/CustomLayoutExamples/blob/19d2edfed5a0d7764334f05a490d06be85d75049/HorizontalWrapLayout.png "HorizontalWrapLayout")