   M S B A M L   `   `   `  ����B  >WpfApp5, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp5WpfApp5  5   	       WpfApp5.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   _ [MaterialDesignThemes.Wpf, Version=4.8.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp5     5   	     � Title$  
MainWindow��5	   	   $	��470��6   $	��800��6)   .��5
      �  � RowDefinitions 5   
   �� 5      $
��0.5* �6   �� 5      $��2* �6   �� 5      $
��0.5* �6    � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      .+�5   
   �� -   5         ��Name$ RolesBtn��5      $��0��6#   $��0��60   $��Роли��6@    � Cursor$
 Hand��6O   6]   �� 5   
   -   5        $ EmployessBtn��5      $��0��6'   $��1��64   $��Сотрудники��6D   $
 Hand��6Y   6g   �� 5   
   -   5        $ AuthBtn��5      $��0��6"   $��2��6/   $0��*Данные для авторизации��6?   $
 Hand��6`   6n   �� 5   
   -   5        $ TableBtn��5      $��0��6#   $��3��60   $��Таблицы��6@   $
 Hand��6R   6`    � 5   
   -   5          �Name$ 	PageFrame��5      $��1��6#   $��2��60   $��4��6A     � NavigationUIVisibility$ Hidden=�6U   5      5      