   M S B A M L   `   `   `  ����B  >WpfApp3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:WpfApp3.ViewsWpfApp3.Views  5   	   %    WpfApp3.Views.GestionareStocuri   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:WpfApp3.Views     5   	     � Title$  Gestionare Stocuri��5   	   $	��700��6$   $	��600��61   ���	#FFF7F3F7.��5
      � .+�5   
   �� $��20q�6   .+�5      �� $��Stoc ID:��6   ���	#FF555555$��14(�6?   $
��Bold"�6M   $��20��6_   �� 5      -   5         ��Name$ 	txtStocId��5      $��30��6)   $��0,5,0,10q�65   $��14(�6G   ���	#FFFDE7E96U   �� 5      $��
Produs ID:��6   ���	#FF555555$��14(�6A   $
��Bold"�6O   �� 5      -   5        $ txtProdusId��5      $��30��6+   $��0,5,0,10q�67   $��14(�6I   ���	#FFFDE7E96W   �� 5      $��
Cantitate:��6   ���	#FF555555$��14(�6A   $
��Bold"�6O   �� 5      -   5        $ txtCantitate��5      $��30��6,   $��0,5,0,10q�68   $��14(�6J   ���	#FFFDE7E96X   �� 5      $��Unitate de Măsură:��6   ���	#FF555555$��14(�6I   $
��Bold"�6W   �� 5      -   5        $ txtUnitateDeMasura��5      $��30��62   $��0,5,0,10q�6>   $��14(�6P   ���	#FFFDE7E96^   �� 5      $��Data Aprovizionării:��6   ���	#FF555555$��14(�6K   $
��Bold"�6Y   (  "System.Windows.Controls.DatePicker  5      -   5          Name$ dpDataAprovizionarii��5      $��30��67   $��0,5,0,10q�6C   $��14(�6U   ���	#FFFDE7E96c   �� 5      $��Data Expirării:��6   ���	#FF555555$��14(�6F   $
��Bold"�6T     5      -   5        $ dpDataExpirarii��5      $��30��62   $��0,5,0,10q�6>   $��14(�6P   ���	#FFFDE7E96^   �� 5      $��Preț Achiziție:��6   ���	#FF555555$��14(�6F   $
��Bold"�6T   �� 5       -   5        $ txtPretAchizitie��5       $��30��60   $��0,5,0,10q�6<   $��14(�6N   ���	#FFFDE7E96\   �� 5"       �� Orientation$ 
Horizontal=�6   $��Center=�62   $��0,10,0,0q�6O   .+�5#      �� -   5        $��Adaugă��5#      ���	#FFFD79A6
�������$
��Bold"�6m   $��16(�6   $��10q�6�   $��	10,0,10,0q�6�   �� 5$      -	   5        $��Actualizează��5$      ���	#FFFD79A6
�������$
��Bold"�6y   $��16(�6�   $��10q�6�   $��	10,0,10,0q�6�   �� 5%      -
   5        $��Șterge��5%      ���	#FFFD79A6
�������$
��Bold"�6m   $��16(�6   $��10q�6�   $��	10,0,10,0q�6�   �� 5&      -   5        $��
Afișează��5&      ���	#FFFD79A6
�������$
��Bold"�6t   $��16(�6�   $��10q�6�   5'      5(      5)      5*      