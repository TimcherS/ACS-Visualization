   M S B A M L   `   `   `  ����K  GACSVisualization, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:ACSVisualization.Models.EnumsACSVisualization.Models.Enums  5      ?$clr-namespace:ACSVisualization.ViewsACSVisualization.Views  5      &     ACSVisualization.Views.ShellView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      =enums+clr-namespace:ACSVisualization.Models.Enums     5      6views$clr-namespace:ACSVisualization.Views     5        � Title$2  ,ACS в задаче коммивояжера��5      $	��800��5      $	��450��5	      .��5
      � .+�5      '   !ACSVisualization.Views.CameraView     
AreaHeight$
 1500Q�5         	AreaWidth$
 2500Q�5         	ZoomScale$ 3Q�5         ContentToDisplay 5      &    ACSVisualization.Views.GraphView  5         CellSize$ 10��5         Columns$	 160��5         Rows$ 90��5      ��5      �� 5       �� 
TargetType"  6   .�5      �� 	 �� Property	 � y�
 �� Value$
 	Collapsed=�6$    �� Triggers 5      �� 5      .   (ACSVisualization.Models.Enums.ActiveView   Graph �� Value# Z 6}    �� Binding 6   �� *DataContext.ActiveView+ �� RelativeSource ��  �� AncestorType" �.a�5   	   �� 	 � y�$
 Visible=�6&   5   	   5      5        5!      $
 1500Q�5"      $
 2500Q�5#      $ 3Q�5$       5%      0   *ACSVisualization.Views.AdjacencyMatrixView  5&      ��5(      �� 5)      "  6   .�5*      �� 	 � y�$
 	Collapsed=�6$    5+      �� 5,         AdjacencyMatrix# Z 6}    6   �� *DataContext.ActiveView+ �� " �.a�5-   	   �� 	 � y�$
 Visible=�6&   5.   	   50      52        54      $
 2500Q�55      $
 1500Q�56      $ 3Q�57       58      .   (ACSVisualization.Views.AdjacencyListView  59      ��5;      �� 5<      "  6   .�5=      �� 	 � y�$
 	Collapsed=�6$    5>      �� 5?         AdjacencyList# Z 6}    6   �� *DataContext.ActiveView+ �� " �.a�5@   	   �� 	 � y�$
 Visible=�6&   5A   	   5C      5E      � 5G      $	��200��5H      $��65��5I      $��8q�5J      $
��Left=�5K      $	��Top=�5L      .+�5M      �� 
������� �� CornerRadius$ 10��5O       J� Opacity$	 0.3Q�5P      � 5Q      $��8q�6    � Orientation$ Vertical=�6   .+�5R      �� �� 5S       �� Command 6   �� *ViewGraphCommand+.�66   .�5T      �� 
���   �$��Граф��6%   5U      5V      �� 5W      �� 5X       6   �� *ViewAdjacencyMatrixCommand+.�6@   .�5Y      �� 
���   �$��Матрица��6%   5Z      5[      �� 5\      �� 5]       6   �� *OpenParamCommand+.�66   .�5^      �� 
���   �$��Параметры��6%   5_      5`      �� 5a      $
��10,0q�6   �� 5b       6   �� *SaveGraphCommand+.�66   .�5c      �� 
���   �$��Сохранить��6%   5d      5e      �� 5f      $
��10,0q�6   �� 5g       6   �� *LoadGraphCommand+.�66   .�5h      �� 
���   �$��Загрузить��6%   5i      5j      5p      5r      5t      5u      