   M S B A M L   `   `   `  ����F  BProjectQLBH, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:ProjectQLBHProjectQLBH  5   	       ProjectQLBH.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:ProjectQLBH     5   	   c _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a:Icon-http://metro.mahapps.com/winfx/xaml/iconpacks   5   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  6D     � Title$  
MainWindow��5
   	   $	��950��6   $
��1560��6)    � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�5   	    � AllowsTransparency$
 True��5   	   
������  � WindowState$ 	Maximized=�6<    � 	Resources 5         	BoolToVis��%   &	        �� 5   
   6;   5      .��5      �� ���#eff2f7 �� CornerRadius$ 30��6"   ._�5   
   �  � ColumnDefinitions 5      �� 5      $	��250 �6#   �� 5      $��* �6#   .+�5      �  � RowDefinitions 5      �� 5      $
��auto �6$   �� 5      $��* �6$   .+�5       �� $��
20 28 0 35q�6     	topButton#��[ 6-   .��5!      .  (MahApps.Metro.IconPacks.PackIconMaterial  	   Kind$
	 Menu=�6,   $��15��68   $��15��6C   5#      �� 5%      $��1��6   ���#07bf96$ 	0 50 0 30��6;   ._�5&      ]� .+�5'      �� $��80��6!   $��80��6,   
 �� Padding$
 3q�68   
�������$	 100��6W   $	��Top=�5(   !   $
��Left=�66   $��
20 -30 0 0q�6Q   ._�5)      A� ��5*   "   �� 5,   &    �� ImageSource$ Images/CODER.png��61   5.      5/      �� 52      $��Trần Huy Anh��6$   
�������$��22(�6K   $��SemiBold"�6Y   $	��Top=�53   $    �� TextAlignment$ Center=�69   $��	5 25 0 10q�6P   �� 54      $��Admin��6$   ���#ffff$��14(�6D   $��SemiBold"�6R   $	��Top=�55   $   $ Center=�69   �� 59      $��25q�6$   $	��Top=�60   $	��0.8��6E   ���#ffff6R   �� 5;      $	��Top=�6%   .+�5<      �� -   5          
menuButton#��[ 5<   %   .��5=   "   ��  �� Orientation$ 
Horizontal=�6-   .+�5>   &     $	 CurrencyUsd=�6<     menuButtonIcon#��[ 6O   �� 5?   &   $��	Dashbroad��60   5@   #   5A      �� 5C      -   5        #��[ 5C   %   .��5D   "   �� $ 
Horizontal=�6-   .+�5E   &     $	 Shopping=�6<   #��[ 6L   �� 5F   &   $��Products��60   5G   #   5H      �� 5I      -   5        #��[ 5I   %   .��5J   "   �� $ 
Horizontal=�6-   .+�5K   &     $
	 Cart=�6<   #��[ 6H   �� 5L   &   $��Order��60   5M   #   5N      �� 5O      -   5        #��[ 5O   %   .��5P   "   �� $ 
Horizontal=�6-   .+�5Q   &     $	 Timeline=�6<   #��[ 6L   �� 5R   &   $��Event��60   5S   #   5T      �� 5V      -   5        #��[ 5V   %   $��Bottom=�6I   $��Bottom=�6d   $��
15 0 15 20q�6|   .��5W   "   �� $ 
Horizontal=�6-   .+�5X   &     $	 Logout=�6<   #��[ 6J   �� 5Y   &   $��Logout��60   5Z   #   5[      5\      5b      5c      5e      � 5h      -   5        $��RenderPages��5h   8   $��1��6   ���#eff2f7$	��750��6K   $
��1200��6X   .+�5|      � .+�5}      �� -   5         ��Name$ RenderPages1��5}   %   $��0 0 0 0q�6;   5~      5�      5�      5�      5�      