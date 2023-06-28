﻿using KeyPressMaster.Controllers;
using KeyPressMaster.Model;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Media;

namespace KeyPressMaster.View.Controls
{
    public partial class ContextModalForm : UserControl
    {
        public ContextModalForm()
        {
            InitializeComponent();

            AppController.instance.ContextModal.Opened += ContextModalOpened;
            AppController.instance.ContextModal.Closed += ContextModalClosed;
        }

        private void ContextModalOpened(object? sender, EventArgs e)
        {
            MainForm.Visibility = Visibility.Visible;

            if (sender is ContextModalParams param)
            {
                ModalBorder.VerticalAlignment = param.VerticalAlignment;
                ModalBorder.HorizontalAlignment = param.HorizontalAlignment;

                var thickness = new Thickness();
                
                switch (param.VerticalAlignment)
                {
                    case VerticalAlignment.Top: thickness.Top = param.Y; break;
                    case VerticalAlignment.Bottom: thickness.Bottom = param.Y; break;
                }

                switch (param.HorizontalAlignment)
                {
                    case HorizontalAlignment.Left: thickness.Left = param.X; break;
                    case HorizontalAlignment.Right: thickness.Right = param.X; break;
                }

                ModalBorder.Margin = thickness;

              //  ModalBorder.Margin = new Thickness(param.X, param.Y, 0, 0);
                ModalContent.Content = param.Content;
                ModalBorder.RenderTransformOrigin = param.RenderTransformOrigin;

                ShowStoryboard_BeginStoryboard.Storyboard.Begin();
              
            }
        }

        private void ContextModalClosed(object? sender, EventArgs e)
        {
            MainForm.Visibility = Visibility.Collapsed;
        }

        private void BackMouseDown(object sender, MouseButtonEventArgs e)
        {
            AppController.instance.ContextModal.Close();
        }
    }
}
