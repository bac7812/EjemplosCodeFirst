   M S B A M L   `   `   `  ����E  AEjercicio1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Ejercicio1
Ejercicio1  5   	   !    Ejercicio1.CategoriasWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:Ejercicio1     5   	     � Title$  Consultar categorías��5      $	��300��6%   $	��300��62    � 	Resources 5	         HeaderStyle �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader �� Property �� Value��%�   &	        �� 5
   
   "  6$   .�5      ��  � ��
 ��ح�6+   �� 5       � ��
 ��  �6,   �� 5       � ��$ 0��6)   �� 5       � ��$ 30��6*   �� 5       � ��$ 5q�6(   5      5      .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $��30 �6   6*   �� 5      6   .+�5   
   �� -   5         ��Name$ consultarCategoriasLabel��5      $��
Consultar:��62   $��0��6G   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$! consultarCategoriasDataGrid��5         CanUserAddRows .  	   ColumnHeaderStyle#	 [  6y   
   AutoGenerateColumns
 .  $��1��6�    � DataContext 6O   ��  �� Source$ 
Categorias��   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   ��  �� Path$ categoriaId�  5      $ Nombre��6%    65   �� $ nombre�  5      $ 	Apellidos��6%    68   �� $ descripcion�5      5       5!      