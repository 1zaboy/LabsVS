   M S B A M L   `   `   `  ����?  ;Lab2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:Lab2Lab2  5   	       Lab2.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:Lab2     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��300��6)   .��5	      �  � RowDefinitions 5
   
   �� 5      6   �� 5      $
��30px �6   6,   �� 5      $��100px �6   6-   .+�5   
   �  � ColumnDefinitions 5      �� 5      6%   �� 5      6%   .+�5      � $��0��6    5      �� 5      $
��30px �6$   64   �� 5      $
��30px �6$   64   �� 5      $
��30px �6$   64   �� 5      $
��30px �6$   64   .+�5      �� $��10px 0 10px 0q�6   $��0��6/   $��0��6?   $
��30px��6L   $	��Top=�6Z   $��Value X:��6r   6�   �� 5      -   5         ��Name$
 val1��5   1   $��10px 0 10px 0q�6   $��0��6?   $��1��6O   $
��30px��6\   $	��Top=�6j   6�   �� 5      $��10px 0 10px 0q�6   $��0��6/   $��2��6?   $
��30px��6L   $	��Top=�6Z   $��Value P:��6r   6�   �� 5       -   5        $
 val2��5    1   $��10px 0 10px 0q�6   $��0��6?   $��3��6O   $
��30px��6\   $	��Top=�6j   6�   5!      � 5"      $��1��6   $��10px 0px 10px 0pxq�6#    5#      �� 5$      $
��30px �6$   64   �� 5%      $��* �6$   61   .+�5'      �� $��0��6   $��	Function:��6%   $��Stretch=�69   $��0,5,5,5q�6W   6k   �� 5(      -   5         ��Name$ 
stackPanel��5(   *   $��1��6   .+�5)      	� -   5        $
��fun1��5)   �   $��1��6"    	� 	GroupName$ Function��6/   $��Sh(x)��6D    d� 	IsChecked$
 TrueY�6T   6�   	� 5*      -   5        $
��fun2��5*   p   $��2��6"   $ Function��6/   $	��x^2��6D   6~   	� 5+      -   5        $
��fun3��5+   p   $��3��6"   $ Function��6/   $	��e^x��6D   6~   5,      5-      5.      �� 50   
   -   5        $��1��50      $��Center=�6   $
��Calc��69   $��10px 0 10px 0q�6H   6v   �� 51   
   -   5         ��Name$	 res��51   �   $��10px 0 10px 0q�6   $��2��6+   $
��50px��68   $
��45px(�6F   $��Center=�6V    �� TextAlignment$ Center=�6q   6�   52      53      