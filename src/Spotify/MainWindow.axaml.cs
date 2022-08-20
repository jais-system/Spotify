using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using JaisAppCore;
using Spotify.Services;
using Spotify.ViewModels;

namespace Spotify;

[App("Spotify", "/Assets/Icon.png")]
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainViewModel(new TokenService());
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}