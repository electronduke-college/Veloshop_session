   M S B A M L   `   `   `  ����F  BVeloShopApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:VeloShopApp.PagesVeloShopApp.Pages  5      !    VeloShopApp.Pages.GuestPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:VeloShopApp.Pages     5        N� 
Background
  ����� N� Title$ 	GuestPage��5	      .��5      �  � RowDefinitions 5   
   �� 5      �� 5      $��5* �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   .+�5      ��    text#��[  6   $-��'Магазини велосипедов��66   �� 5      -   5        $��btnBack��5      $"��Авторизоваться��6$     mainBtn#��[ 6=   $
��10 0q�5      $��10 10q�5      $��Center=�5      5      ]� 5   
   $��1��6   .+�5      �� $	��Top=�6   $ 
Horizontal=�6.   .+�5      �� -   5        $��tbCount��5      #��[  5      5      5      �� 5      -   5        $��
lwProducts��5   /   $��Bottom=�6   ��5      �� 5      .R�5      �� 
����  �$��2q�6>   .��5       �� $ 
Horizontal=�6)   .+�5!   "   �� $	��200��6A   ��6(   �� *Image+6A   �� 5#   "   $ Vertical=�6-   $
��15 0q�6D   $	��400��6R   .+�5$   &   �� #��[  60   $
��Bold"�6N   $��16(�6v   ��6`   �� *Name+6v   �� 5%   &   #��[  60   $	��0 5q�6k   ��6N   �� *Description+6k   �� 5&   &   $ 
Horizontal=�61   .+�5'   *   �� $"��Производитель: ��64   #��[  6K   �� 5(   *   #��[  64   ��6R   �� *Manufacturer+5)   '   �� 5*   &   $ 
Horizontal=�61   $	��0 5q�6J   .+�5+   *   �� $��
Цена: ��64   #��[  6B   �� 5,   *   #��[  64   ��6R   �� *Price+�� 5-   *   $�� руб.��64   #��[  6A   5.   '   5/   #   �� 50   "   
����  �$��1q�6@   �� 51   "   $ Vertical=�6-   $��Center=�6D   $	��120��6_   .+�52   &   �� $#��Кол-во на складе��60   #��[  6H   $��Center=�6g   �� 53   &   #��[  60   $��Center=�6e   ��6N   �� *Count+6e   54   #   55      56      57      59      5:      5<      5=      