   M S B A M L   `   `   `  ����B  >WpfApp5, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp5WpfApp5  5          WpfApp5.Vaccinations   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:WpfApp5     5        N� Title$  Vaccinations��5	      .��5      �  � RowDefinitions 5   
   �� 5      $��2* �6   �� 5      $
��0.5* �6   �� 5      $
��0.5* �6   �� 5      $
��0.5* �6    � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ datagrid��5      $��0��6%   $��1��62   $��4��6C   6W   �� 5   
   $��0��6   $��Животное��6    $��Center=�63   $��1��6P   $��Center=�6]   �� 5   
   $��1��6   $��Ветеринар��6    $��Center=�64   $��1��6Q   $��Center=�6^   �� 5   
   $��2��6   $��Дата��6    $��Center=�6/   $��1��6L   $��Center=�6Y   �� 5   
   $��3��6   $��Описание��6    $��Center=�63   $��1��6P   $��Center=�6]   �� 5   
   -   5         ��Name$ AddBtn��5      $#��Добавить запись��6!   $��Center=�6;   $��10q�6X   $��3��6d   $��0��6q    � Cursor$
 Hand��6�   6�   �� 5   
   -   5        $ 	ChangeBtn��5      $#��Изменить запись��6$   $��Center=�6>   $��10q�6[   $��3��6g   $��1��6t   $��2��6�   $
 Hand��6�   6�   �� 5   
   -   5        $ 	DeleteBtn��5      $!��Удалить запись��6$   $��Center=�6=   $��10q�6Z   $��3��6f   $��3��6s   $
 Hand��6�   6�   �� 5    
   -   5         ��Name$ 	AnimalBox��5       $��10q�6&   $��0��62   $��2��6B   $��Center=�6O   �� 5!   
   -   5        $ VeterinarsBox��5!      $��10q�6*   $��1��66   $��2��6F   $��Center=�6S   (  "System.Windows.Controls.DatePicker  5"   
   -   5          Name$ 
VacDateBox��5"      $��10q�6)   $��2��65   $��2��6E   $��Center=�6R   �� 5#   
   -   5         ��Name$ 
VacDescBox��5#      $��10q�6&   $��3��62   $��2��6B   	 �� TextWrapping$
	 Wrap=�6O   $�� ��6c   $��Center=�6k   5&      5'      