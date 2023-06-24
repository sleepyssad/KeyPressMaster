using KeyPressMaster.Model.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KeyPressMaster.Resources
{
    public static class ThemeManager
    {
        private static string GetFileName(string source)
        {
            try
            {
                return Path.GetFileNameWithoutExtension(source);
            }
            catch
            {
                return string.Empty;
            }
        }

        public static void Update(AppTheme theme)
        {
            try
            {
                var currentThemeResource = App.Current.Resources.MergedDictionaries.FirstOrDefault((res) =>
                {
                    return GetFileName(res.Source.OriginalString) == Storage.Default.CurrentTheme.ToString();
                });

                if (currentThemeResource is ResourceDictionary)
                {
                    App.Current.Resources.MergedDictionaries.Remove(currentThemeResource);
                }

                App.Current.Resources.MergedDictionaries.Add(new ResourceDictionary
                {
                    Source = new Uri($"Resources/Brushes/{theme}Brushes.xaml", UriKind.RelativeOrAbsolute)
                });

                SaveToStorage(theme);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void SaveToStorage(AppTheme theme)
        {
            try
            {
                Storage.Default.CurrentTheme = theme;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
