   M S B A M L   `   `   `  ����?  ;HSM2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:HSM2HSM2  5   	       HSM2.ChonLoaiXemAdmin   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:HSM2     5   	   V RMaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=nullX TMaterialDesignThemes.MahApps, Version=0.0.11.0, Culture=neutral, PublicKeyToken=nullHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5
   	     � Title$  ChonLoaiXemAdmin��5   	   $	��270��5	   	   $	��300��6    � 
ResizeMode$ NoResize=�6"    � WindowStyle$
 None=�68      MaterialDesignBody#���   5      $��Regular"�5      $��5q�6'   
���   �$��13(�5      &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5       � WindowStartupLocation$ CenterScreen=�6-      TextRenderingMode$
 Auto=�5        MaterialDesignPaper#���  5        MaterialDesignFont#���  5      .��5      � .+�5   
   �  � RowDefinitions 5      �� 5      6"   �� 5      $
��6.5* �6    60   .+�5      (  "MaterialDesignThemes.Wpf.ColorZone  -   5        $��TitleBar��5   [   
���   �$��0��6k      Mode$ Inverted=�5      $��40��6   .��5      �  � ColumnDefinitions 5      �� 5      6-   �� 5      6-   .+�5!      �� $��Center=�6    $��Center=�6;   $��0��6X    # MaterialDesignHeadlineTextBlock#��[ 5"      
Chọn Xem5$      �� 5%      $��2��6!   $��Right=�61   $��Center=�6M   $��30��6h   	 �� Orientation$	 
Horizontal=�5&      .+�5(      �� -   5        $��btThuNho��5(   !   +  %MaterialDesignThemes.Wpf.RippleAssist
   
IsDisabled
 . 
���   �
���   � � ToolTip$ 	Thu nhỏ��6�   $��0,0,5,0q�6�   $��Right=�6�   .��5)      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=null]]   Kind$ WindowMinimize=�66   6N   5*      �� 5+      -   5        $��btDong��5+   !   
 . 
���   �
���   �$ Đóng��6�   $��0,0,5,0q�6�   $��Right=�6�   .��5,        $ WindowClose=�66   6K   5-      5.      5/      51      � 53      $��1��6   ��54      �� 55       �� Opacity$	 0.5Q�6!    �� ImageSource$G Aimage/gears-of-war-4-wallpapers-1080p-On-Wallpaper-1080p-HD-1.png��6/   6�    57      �� 58      6&   �� 59      6&   .+�5;      �� -   5        $��	cbLoaiXem��5;   .   $��	10,0,10,0q�6   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
Loại xem��5<       & "MaterialDesignFloatingHintComboBox#��[ 5=      .@�5>      �� .��6#   Sửa5@      �� 5A      .��6#   Xóa5C      5D      �� 5E      -   5        $
��btOK��5E   j   $��1��6   $��Center=�6&   $��Center=�6C   $	��100��6^   .��6�   OK6�   5F      5G      5H      5I      