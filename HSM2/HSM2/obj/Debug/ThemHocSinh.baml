   M S B A M L   `   `   `  ����?  ;HSM2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:HSM2HSM2  5   	       HSM2.ThemHocSinh   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:HSM2     5   	   V RMaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=nullX TMaterialDesignThemes.MahApps, Version=0.0.11.0, Culture=neutral, PublicKeyToken=nullHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5	   	     � Title$  ThemHocSinh��5   	   $	��550��6   $	��800��6*      MaterialDesignBody#���   5
      $��Regular"�5      $��13(�5      &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignPaper#���  5      $��5q�69   
���   �  MaterialDesignFont#���  5       � 
ResizeMode$ NoResize=�69    � WindowStyle$
 None=�6O    � WindowStartupLocation$ CenterScreen=�6b   .��5      � ��5   
   �� 5       �� ImageSource$4 .image/1403426_530014467091446_1823878259_o.jpg��6   6X    � RowDefinitions 5   
   �� 5      6   �� 5      $��5* �6   6*   �� 5      6   .+�5   
   (  "MaterialDesignThemes.Wpf.ColorZone  -   5        $��TitleBar��5   V   $��0��6h   $��60��6u      Mode$ Inverted=�6�   .��5      � 	 � ColumnDefinitions	 5      �� 5      6)   �� 5      6)   �� 5      6)   .+�5!      �� $��Center=�6   $��30,0,0,0q�67   $
��Left=�6I   $��0��6d    # MaterialDesignHeadlineTextBlock#��[ 5"      Thêm học sinh5$      �� 5%      $��2��6   $��Right=�6-   $��Center=�6I   $��30��6d   
 �� Orientation$
 
Horizontal=�5&      .+�5(      �� -   5        $��btThuNho��5(      +  %MaterialDesignThemes.Wpf.RippleAssist   
IsDisabled . 
���   �
���   � � ToolTip$ 	Thu nhỏ��6�   $��0,0,5,0q�6�   $��Right=�6�   .��5)      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=null]]   Kind$ WindowMinimize=�62   6J   5*      �� 5+      -   5        $��	btPhongTo��5+       . 
���   �
���   �$ 
Thu/Phóng��6�   $��0,0,5,0q�6�   $��Right=�6�   .��5,        $ WindowMaximize=�62   6J   5-      �� 5.      -   5        $��btDong��5.       . 
���   �
���   �$ Đóng��6�   $��0,0,5,0q�6�   $��Right=�6�   .��5/        $ WindowClose=�62   6G   50      51      52      53      #  MaterialDesignThemes.Wpf.Card  56   
    J� Opacity$
 0.84Q�6   $��	10,5,10,0q�6-   $��1��6@   $��Stretch=�6M   .��57      � 	 58      �� 59      $��2* �6'   64   �� 5:      $
��0.5* �6'   66   �� 5;      $��8* �6'   64   .+�5=      � $��0��6    5>      �� 5?      6*   �� 5@      6*   .+�5B      �� -   5        $��hinhLogo��5B      $��15q�6,   $	��Top=�68   $��0��6P   $	��150��6a   $��112.5��6n   %  MaterialDesignThemes.Wpf.Badged  5C      -   5          Name$ CountingBadge��5D      $��1��5C   ,   $��Bottom=�69   $��Center=�6T      BadgeColorZoneMode$ PrimaryDark=�5E      5G      5H      � 5I      $��1��6   .+�5J      �� $��	0,20,0,20q�6!   $��40��64   $��Center=�6@    J� Effect 5K      3  -System.Windows.Media.Effects.DropShadowEffect  5L         
BlurRadius$ 6Q�6/      	Direction$ 10Q�6>      RenderingBias$ Quality=�6M      ShadowDepth$ 5 Q�6e   6x    � LayoutTransform 5N      �� 5O       �� Angle$ 90Q�6.   5Q      5R      � 5S      $��5q�6   $��2��6"    5T      �� 5U      6*   �� 5V      6*   �� 5W      6*   �� 5X      6*   �� 5Z      6*   �� 5[      6*   �� 5\      6*   .+�5^      � $��0��6   	 5_      �� 5`      61   �� 5a      $	��10* �6/   6=   .+�5c        $ Account=�62   $��25��6A   $��35��6L   $��0��6Y   $��Bottom=�6i   $��Right=�6�   $��5q�6�   �� 5d      -   5        $��txtMaHS��5d   "   $��1��61   $��17(�6A   $
��Bold"�6O   )	  #MaterialDesignThemes.Wpf.HintAssist 	  Hint$ Mã số học sinh��5e       % !MaterialDesignFloatingHintTextBox#��[ 5f      5g      � 5i      $��1��6   	 5j      �� 5k      61   �� 5l      $	��10* �6/   6=   .+�5n        $ 	RenameBox=�62   $��25��6C   $��35��6N   $��0��6[   $��Bottom=�6k   $��Right=�6�   $��5q�6�   �� 5p      -   5        $��
txtHoTenHS��5p   "   $��1��64   $��17(�6D   $
��Bold"�6R   $ 	Họ tên��5q      #��[ 5r      5s      � 5u      $��2��6   	 5v      �� 5w      61   �� 5x      $	��10* �6/   6=   .+�5z      �� $��image/calendar-blank.png��6    $��25��6B   $��35��6M   $��0��6Z   $��Bottom=�6j   $��Right=�6�   $��5q�6�   6�   (
  "System.Windows.Controls.DatePicker
  5|      -	   5        $��dpNgaySinhHS��5|   %   $��1��69   $��17(�6I   $
��Bold"�6W   $ 
Ngày sinh��5}      $��28��6.   $��Bottom=�6:    ( $MaterialDesignFloatingHintDatePicker#��[ 5~      5      � 5�      $��3��6   	 5�      �� 5�      61   �� 5�      $	��10* �6/   6=   .+�5�        $��25��62   $��35��6=   $��0��6J   $��Bottom=�6Z   $��Right=�6u   $��5q�6�   $ Approval=�6�   �� 5�      -
   5        $��txtHanhKiem��5�   "   $��1��65   $��17(�6E   $
��Bold"�6S   $  Xếp loại hạnh kiểm��5�      #��[ 5�      5�      � 5�      $��4��6   	 5�      �� 5�      61   �� 5�      $	��10* �6/   6=   .+�5�      �� $��image/map-marker.png��6    $��25��6>   $��35��6I   $��0��6V   $��Bottom=�6f   $��Right=�6�   $��5q�6�   6�   �� 5�      -   5        $��txtDiaChiHS��5�   "   $��1��65   $��17(�6E   $
��Bold"�6S   $ Địa chỉ��5�      #��[ 5�      5�      � 5�      $��5��6   	 5�      �� 5�      61   �� 5�      $	��10* �6/   6=   5�      � 5�      $��5��6   	 5�      �� 5�      61   �� 5�      $	��10* �6/   6=   .+�5�        $
 Home=�62   $��25��6>   $��35��6I   $��0��6V   $��Bottom=�6f   $��Right=�6�   $��5q�6�   �� 5�      -   5        $��txtQueQuanHS��5�   "   $��1��66   $��17(�6F   $
��Bold"�6T   $ 
Quê quán��5�      #��[ 5�      5�      � 5�      $��6��6   	 5�      �� 5�      61   �� 5�      $	��10* �6/   6=   .+�5�      �� $��0��6    $&�� image/book-open-page-variant.png��60   $��25��6Z   $��35��6e   $��Bottom=�6q   $��Right=�6�   $��5q�6�   6�   � 5�      $��1��6   .+�5�      �� -   5        $��
btThemDiem��5�   @   $��Bottom=�6%   $ Thêm điểm học sinh��6R   $��0,0,5,0q�6o   
���   �
���   �.��6�   Thêm điểm cho học sinh5�      5�      5�      5�      5�      5�      � 5�   
   $��2��6   	 5�      �� 5�      6%   �� 5�      6%   .+�5�      �� -   5        $��
btNhapFile��5�      
���2�2�
���2�2�$��0��6V     MaterialDesignRaisedButton#��[ 5�      $	��100��5�      $ Thêm nhiều học sinh��5�      .��6<   Nhập File5�      �� 5�      -   5        $��btHuy��5�      
���  ��
���  ��$��1��6M   #��[ 5�      $	��100��5�      $ Hủy thêm��5�      .��6,   
Hủy bỏ5�      5�      5�      5�      