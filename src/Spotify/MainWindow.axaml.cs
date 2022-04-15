using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using JaisAppCore;

namespace Spotify;

[App("Spotify", "/Assets/Icon.png")]
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}