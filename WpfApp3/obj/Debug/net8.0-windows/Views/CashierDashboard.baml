   M S B A M L   `   `   `  ����  WpfApp3$    WpfApp3.Views.CashierDashboard   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  CashierView��5   	   $	��600��6   $	��800��6*    � 	Resources 5         LightPinkColor  	PinkColor  DarkPinkColor  LightPinkBrush �� Color  	PinkBrush  DarkPinkBrush��%�   &	        &	      &	 >     &	 ]     7   &	 u     7  &	 �     7  ��5   
   #FFB6C1��60   ��5   
   #FFC0CB��6+   ��5	   
   #FF69B4��6/   �� 5   
   8   61   �� 5   
   8   6,   �� 5   
   8   60   5      .��5      � #��[ 6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��Caută��6   $��210,-3,426,536q�6I   $��2��6a   ��6!   �� *CautăProduseCommand+6a   �� 5   
    �� Orientation$ 
Horizontal=�6   $
��Left=�6.   $	��Top=�6I   $��10q�6a   .+�5      �� -   5        $��SearchTextBox��5      $	��200��6+   $��25��67   $��0,0,10,0q�6C   #��[ 5   
   
���������5   
   �� *SearchQuery+ �� UpdateSourceTrigger$ PropertyChanged=�5      &   System.Windows.Controls.DataGrid  5    
      AutoGenerateColumns$ False��63   $��1��6O   #��[ 5!         RowBackground# [ 5"         AlternatingRowBackground# [ 5#      
���   ���5       �� *	Produse+	   Columns	 5%      0  *System.Windows.Controls.DataGridTextColumn  5&      ,  &System.Windows.Controls.DataGridColumn
   Header$

 Nume��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   �� *Nume_produs+  5'      $
 Cod de Bare��6%    6:   �� *Cod_de_bare+  5(      $
 
Producator��6%    69   �� *Nume_producator+5*      5+      5,      