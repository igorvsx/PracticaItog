   M S B A M L   `   `   `  ����B  >WpfApp5, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp5WpfApp5  5          WpfApp5.LoginData   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:WpfApp5     5        N� Title$  	LoginData��5	      .��5      �  � RowDefinitions 5   
   �� 5      $��2* �6   �� 5      $
��0.5* �6   �� 5      $
��0.5* �6   �� 5      $
��0.5* �6    � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ datagrid��5      $��0��6%   $��1��62   $��7��6C   6W   �� 5   
   $��1��6   $��Название роли��6    $��Center=�68   $��1��6U   $��Center=�6b   �� 5   
   -   5         ��Name$ AddBtn��5      $#��Добавить запись��6!   $��Center=�6;   $��10q�6X   $��3��6d   $��0��6q    � Cursor$
 Hand��6�   6�   �� 5   
   -   5        $ 	ChangeBtn��5      $#��Изменить запись��6$   $��Center=�6>   $��10q�6[   $��3��6g   $��1��6t   $
 Hand��6�   6�   �� 5   
   -   5        $ 	DeleteBtn��5      $!��Удалить запись��6$   $��Center=�6=   $��10q�6Z   $��3��6f   $��2��6s   $
 Hand��6�   6�   �� 5   
   -   5         ��Name$ LoginBox��5      $��10q�6$   $��0��60   $��2��6@    �� TextWrapping$
 Wrap=�6M   $�� ��6a   $��Center=�6i   G� 5   
   -   5         G�Name$ PassBox��5      $��10q�6'   $��1��63   $��2��6C   $��Center=�6P   �� 5   
   -   5        	 ��Name$	 RolesBox��5      $��10q�6%   $��6��61   $��2��6A   $��Center=�6N   5      5       