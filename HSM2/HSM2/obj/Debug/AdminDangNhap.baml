   M S B A M L   `   `   `  ����?  ;HSM2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:HSM2HSM2  5   	       HSM2.AdminDangNhap   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:HSM2     5   	   V RMaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=nullX TMaterialDesignThemes.MahApps, Version=0.0.11.0, Culture=neutral, PublicKeyToken=nullHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5	   	     � Title$  AdminDangNhap��5   	   $	��300��6   $	��500��6,      MaterialDesignBody#���   5
   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	   $��5q�6<   
���  ��  MaterialDesignFont#���  5   	    � WindowStartupLocation$ CenterScreen=�6;    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	   .��5      � ��5   
   �� 5       �� ImageSource$G Aimage/gears-of-war-4-wallpapers-1080p-On-Wallpaper-1080p-HD-1.png��6   6l    � RowDefinitions 5   
   �� 5      6   �� 5      $��6* �6   6*   .+�5   
   (  "MaterialDesignThemes.Wpf.ColorZone  -   5        $��TitleBar��5   Y   
���  ��$��0��6i      Mode$ Inverted=�5      $��40��6   .��5      � 	 � ColumnDefinitions	 5       �� 5!      6)   �� 5"      6)   �� 5#      6)   .+�5%      �� $��Center=�6   $��Center=�67   $��0��6T    # MaterialDesignHeadlineTextBlock#��[ 5&      ADMIN5(      �� 5)      $��2��6   $��Right=�6-   $��Center=�6I   $��30��6d   
 �� Orientation$
 
Horizontal=�5*      .+�5,      �� -   5        $��btThuNho��5,      +  %MaterialDesignThemes.Wpf.RippleAssist   
IsDisabled . 
���   �
���   � � ToolTip$ 	Thu nhỏ��6�   $��0,0,5,0q�6�   $��Right=�6�   .��5-      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=null]]   Kind$ WindowMinimize=�62   6J   5.      �� 5/      -   5        $��btDong��5/       . 
���   �
���   �$ Đóng��6�   $��0,0,5,0q�6�   $��Right=�6�   .��50        $ WindowClose=�62   6G   51      52      53      55      #  MaterialDesignThemes.Wpf.Card  57   
    J� Opacity$	 0.8Q�6   $��5q�6,   $��1��67   $��Stretch=�6D   $��Stretch=�6`   .��58      �  5:      �� 5;      6&   �� 5<      6&   �� 5=      6&   .+�5?      � $��15,10,15,10q�6   $��0��6,   	 5@      �� 5A      6-   �� 5B      $
��9.5* �6+   6:   .+�5D        $��25��6.   $��25��69   $ Account=�6E   $��0��6U   $��Bottom=�6e   $��Center=�6�   $��10q�6�   �� 5E      -   5        $��txtDangNhap��5E      $��1��61   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ ADMIN:��5F       % !MaterialDesignFloatingHintTextBox#��[ 5G      5H      � 5I      $��15,10,15,10q�6   $��1��6,   	 5J      �� 5K      6-   �� 5L      $
��9.5* �6+   6:   .+�5N        $��25��6.   $��25��69   $	 Key=�6E   $��0��6Q   $��Bottom=�6a   $��Center=�6|   $��10q�6�   G� 5O      -   5         G�Name$ 
txtMatKhau��5P      $��1��5O   #   $ Mật khẩu:��5Q       ) %MaterialDesignFloatingHintPasswordBox#��[ 5R      5S      � 5U      $��3��6   	 5V      �� 5W      6-   �� 5X      6-   �� 5Y      6-   .+�5[      � $��15q�6   $��0��6'   � 5\      $��15q�6   $��1��6'   .+�5]      �� -   5        $��btDongY��5]   !   
���   �
���   � $  MaterialDesignRaisedAccentButton#��[ 5^      $	��100��5_      
�������$ Đăng nhập��5`      .��6G   
Đồng ý5b      5c      � 5d      $��5q�6   $��2��6&   5e      5f      5g      5h      5i      