   M S B A M L   `   `   `  ����B  >WpfApp5, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp5WpfApp5  5          WpfApp5.Histories   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:WpfApp5     5        N� Title$  	Histories��5	      .��5      �  � RowDefinitions 5   
   �� 5      $��2* �6   �� 5      $
��0.5* �6   �� 5      $
��0.5* �6   �� 5      $
��0.5* �6    � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ datagrid��5      $��0��6%   $��1��62   $��6��6C   6W   �� 5   
   $��0��6   $��Животное��6    $��Center=�63   $��1��6P   $��Center=�6]   �� 5   
   $��1��6   $��Владелец��6    $��Center=�63   $��1��6P   $��Center=�6]   �� 5   
   $��2��6   $��Дата��6    $��Center=�6/   $��1��6L   $��2��6Y   $��Center=�6m   �� 5   
   $��4��6   $��Тип��6    $��Center=�6.   $��1��6K   $��Center=�6X   �� 5   
   $��5��6   $��Описание��6    $��Center=�63   $��1��6P   $��Center=�6]   �� 5!   
   -   5         ��Name$ AddBtn��5!      $#��Добавить запись��6!   $��Center=�6;   $��10q�6X   $��3��6d   $��0��6q   $��2��6�    � Cursor$
 Hand��6�   6�   �� 5"   
   -   5        $ 	ChangeBtn��5"      $#��Изменить запись��6$   $��Center=�6>   $��10q�6[   $��3��6g   $��2��6t   $��2��6�   $
 Hand��6�   6�   �� 5#   
   -   5        $ 	DeleteBtn��5#      $!��Удалить запись��6$   $��Center=�6=   $��10q�6Z   $��3��6f   $��4��6s   $
 Hand��6�   $��2��6�   6�   �� 5$   
   -   5         ��Name$ 	AnimalBox��5$      $��10q�6&   $��0��62   $��2��6B   $��Center=�6O   �� 5%   
   -   5        $ OwnerBox��5%      $��10q�6%   $��1��61   $��2��6A   $��Center=�6N   (  "System.Windows.Controls.DatePicker  5&   
   -   5          Name$ HistDateBox��5&      $��10q�6*   $��2��66   $��2��6F   $��2��6S   $��Center=�6g   �� 5'   
   -   5         ��Name$ HistTypeBox��5'      $��10q�6'   $��4��63   $��2��6C   	 �� TextWrapping$
	 Wrap=�6P   $�� ��6d   $��Center=�6l   �� 5(   
   -	   5        $ HistDescBox��5(      $��10q�6'   $��5��63   $��2��6C   $
	 Wrap=�6P   $�� ��6d   $��Center=�6l   5*      5+      