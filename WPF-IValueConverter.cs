In App.xaml
-----------

      <Application x:Class="WpfApp3.App"
                 xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                 xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
                 xmlns:local="clr-namespace:WpfApp3"
                 StartupUri="MainWindow.xaml">
            <Application.Resources>
                <local:MeinConverter x:Key="MeinConverter" />
            </Application.Resources>        -------------
      </Application>

*******************************************************************************************************************************************************************

In MainWindow.xaml
------------------

    <StackPanel>
        <CheckBox Margin="0 100" Name="checkbox1" HorizontalAlignment="Center" IsChecked="True" VerticalAlignment="Center"/>
        <Button Margin="10" Content="Button" Width="50" IsEnabled="{Binding ElementName=checkbox1, Path=IsChecked, Converter={StaticResource MeinConverter}}"/>                                                                                                                                     -------------
    </StackPanel>                                                                                                                            -------------
    
*******************************************************************************************************************************************************************   
    
In MainWindow.xaml.cs
---------------------
    
    //Einfach IValueConverter bei einer eigenen Klasse Einbinden und die zwei Interface Methoden Reinschreiben. B)
    public class MeinConverter : IValueConverter
    {            -------------
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Hier wird nur der boolean umgekehrt und zurückgeschickt! ;)
            return !(bool)value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

**********************************************************************************************************************************************************************
