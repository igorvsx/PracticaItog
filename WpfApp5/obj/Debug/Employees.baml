   M S B A M L   `   `   `  ����B  >WpfApp5, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp5WpfApp5  5          WpfApp5.Employees   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:WpfApp5     5        N� Title$  	Employees��5	      .��5      �  � RowDefinitions 5   
   �� 5      $��2* �6   �� 5      $
��0.5* �6   �� 5      $
��0.5* �6   �� 5      $
��0.5* �6    � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ datagrid��5      $��0��6%   $��1��62   $��3��6C   6W   �� 5   
   $��0��6   $��Имя��6    $��Center=�6.   $��1��6K   $��Center=�6X   �� 5   
   $��1��6   $��Фамилия��6    $��Center=�62   $��1��6O   $��Center=�6\   �� 5   
   $��2��6   $��Роль��6    $��Center=�6/   $��1��6L   $��Center=�6Y   �� 5   
   -   5         ��Name$ AddBtn��5      $#��Добавить запись��6!   $��Center=�6;   $��10q�6X   $��3��6d   $��0��6q    � Cursor$
 Hand��6�   6�   �� 5   
   -   5        $ 	ChangeBtn��5      $#��Изменить запись��6$   $��Center=�6>   $��10q�6[   $��3��6g   $��1��6t   $
 Hand��6�   6�   �� 5   
   -   5        $ 	DeleteBtn��5      $!��Удалить запись��6$   $��Center=�6=   $��10q�6Z   $��3��6f   $��2��6s   $
 Hand��6�   6�   �� 5   
   -   5         ��Name$ EmployeeNameBox��5      $��10q�6+   $��0��67   $��2��6G    �� TextWrapping$
 Wrap=�6T   $�� ��6h   $��Center=�6p   �� 5   
   -   5        $ EmployeeLastBox��5      $��10q�6+   $��1��67   $��2��6G   $
 Wrap=�6T   $�� ��6h   $��Center=�6p   �� 5    
   -   5         ��Name$ RolesBox��5       $��10q�6%   $��2��61   $��2��6A   $��Center=�6N   5!      5"      