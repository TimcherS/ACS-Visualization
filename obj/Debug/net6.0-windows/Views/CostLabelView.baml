   M S B A M L   `   `   `  ����K  GACSVisualization, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:ACSVisualization.ViewsACSVisualization.Views  5      *    $ACSVisualization.Views.CostLabelView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      6views$clr-namespace:ACSVisualization.Views     5      -   5          >�Name$  	CostLabel��5      
������ ��5	      �� 5
   
    �� 
TargetType" >�6    �� Triggers 5      P� 5       P� Property �@J�IsMouseOver P� Value$
 True��61   . �5      ��  �� Property �@K�ZIndex �� Value$ 1��65   5      5      .��5      � -   5        
������  � ColumnDefinitions 5   
   �� 5      $��3 �6   �� 5      $��* �6   �� 5      $��3 �6   .+�5   
   �� -   5         ��Name$ CostLabelBorder��5      $��1��5      $��4��5      $��4��5       
�������
���   �$	��0.2q�5#      ��5$      �� 5%      " ��6   .�5&      ��  �@��CornerRadius$ 1��65    5'      �� 5(      	 �� Binding	 6&   �� 
 �� ElementName$
 	CostLabel�� �� Path$ 	IsHovered� �� Value True6`   .a�5)      ��  �@��CornerRadius$ 0��6=   5*      5,      ._�5.      �� -   5         ��Name$ CostLabelText��5/       �� Padding$	 1,0q�50      $��Center=�51      $��Center=�52      $��2(�53      $��SemiBold"�54       �� TextAlignment$ Center=�56      ��55      �� *Cost+56      57      �� 59   
   $��0��5:      $��3��5;      
�������$��-��5>       � Cursor$
 Hand��5?      ��5=      �� *DecrementCostCommand+y�5@      �� *	IsHovered+ �� RelativeSource ��  �� AncestorType*   $ACSVisualization.Views.CostLabelView"     BoolToVisibility �� 	Converter# [  ��5A      �� 5B      " ��6   .�5C      ��  � �� 5D      �� 5E      .R�5F   "   �� #��z��5G   %   
���   �$��0.2,0.2,0,0.2q�5I   %    �� CornerRadius$ 1 0 0 1��5J   %   ._�5K   &   �� $��
0,-0.5,0,0q�5L   )   $��Center=�5M   )   $��Center=�5N   )   $��3(�5O   )   $��SemiBold"�5P   )   $ Center=�5R   )   ��5Q   )   �� *	Content+ �� *TemplatedParent+5R   )   5S   #   5T      5V      5W      5Y      �� 5[   
   $��2��5\      $��3��5]      
�������$��+��5`      $
 Hand��5a      ��5_      �� *IncrementCostCommand+y�5b      �� *	IsHovered+ �� "  # [  ��5c      �� 5d      " ��6   .�5e      ��  � �� 5f      �� 5g      .R�5h   "   �� #��z��5i   %   
���   �$��0,0.2,0.2,0.2q�5k   %   $ 0 1 1 0��5l   %   ._�5m   &   �� $��
0,-0.5,0,0q�5n   )   $��Center=�5o   )   $��Center=�5p   )   $��3(�5q   )   $��SemiBold"�5r   )   $ Center=�5t   )   ��5s   )   �� *	Content+ �� *TemplatedParent+5t   )   5u   #   5v      5x      5y      5{      5}      5~      