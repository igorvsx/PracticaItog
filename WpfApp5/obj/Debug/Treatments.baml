   M S B A M L   `   `   `  ����B  >WpfApp5, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp5WpfApp5  5          WpfApp5.Treatments   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:WpfApp5     5        N� Title$  
Treatments��5	      .��5      �  � RowDefinitions 5   
   �� 5      $��2* �6   �� 5      $
��0.5* �6   �� 5      $
��0.5* �6   �� 5      $
��0.5* �6    � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ datagrid��5      $��0��6%   $��1��62   $��6��6C   6W   �� 5   
   $��0��6   $��Животное��6    $��Center=�63   $��1��6P   $��Center=�6]   �� 5   
   $��1��6   $��Ветеринар��6    $��Center=�64   $��1��6Q   $��Center=�6^   �� 5   
   $��2��6   $��Дата начала��6    $��Center=�66   $��1��6S   $��2��6`   $��Center=�6t   �� 5   
   $��4��6   $!��Дата окончания��6    $��Center=�69   $��1��6V   $��Center=�6c   �� 5   
   $��5��6   $��Описание��6    $��Center=�63   $��1��6P   $��Center=�6]   �� 5    
   -   5         ��Name$ AddBtn��5       $#��Добавить запись��6!   $��Center=�6;   $��10q�6X   $��3��6d   $��0��6q   $��2��6�    � Cursor$
 Hand��6�   6�   �� 5!   
   -   5        $ 	ChangeBtn��5!      $#��Изменить запись��6$   $��Center=�6>   $��10q�6[   $��3��6g   $��2��6t   $��2��6�   $
 Hand��6�   6�   �� 5"   
   -   5        $ 	DeleteBtn��5"      $!��Удалить запись��6$   $��Center=�6=   $��10q�6Z   $��3��6f   $��4��6s   $
 Hand��6�   $��2��6�   6�   �� 5#   
   -   5         ��Name$ 	AnimalBox��5#      $��10q�6&   $��0��62   $��2��6B   $��Center=�6O   �� 5$   
   -   5        $ VeterinarsBox��5$      $��10q�6*   $��1��66   $��2��6F   $��Center=�6S   (  "System.Windows.Controls.DatePicker  5%   
   -   5          Name$ TreatStartDateBox��5%      $��10q�60   $��2��6<   $��2��6L   $��2��6`   $��Center=�6m     5&   
   -   5        $ TreatEndDateBox��5&      $��10q�6.   $��4��6:   $��2��6J   $��Center=�6W   �� 5'   
   -	   5         ��Name$ TreatDescBox��5'      $��10q�6(   $��5��64   $��2��6D   	 �� TextWrapping$
	 Wrap=�6Q   $�� ��6e   $��Center=�6m   5*      5+      