   M S B A M L   `   `   `  ����U  QFolderProtectionToolMaster, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:FolderProtectionToolMasterFolderProtectionToolMaster  5   	   +    %FolderProtectionToolMaster.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   :local(clr-namespace:FolderProtectionToolMaster     5   	   -   5          � WindowStartupLocation$  CenterScreen=�5   	    � 
ResizeMode$ CanMinimize=�5	   	    � Title$ 文件加密工具��5
   	   $	��240��5   	   $	��650��5   	   .��5      �  � RowDefinitions 5   
   �� 5      �� 5      $��3* �6   .+�5   
   � .+�5      �� -   5         ��Name$ Info_Txt��5      $��Bottom=�5      $��Center=�5      $��32(�5      5      �� 5   
   $��2��6   $��90��5      $��文件夹状态��5      $��90��5      $
��Bold"�5      $
��Left=�5      .��5      �� $��Center=�6   .+�5       �� -   5         ��Name$ Picture��5       $��80��5!      $��80��5"      $.��(pack://application:,,,/Images/folder.png��5#      5$      5%      �� 5'   
   $��1��6   $��10,10q�5(      .+�5)      ��  �� Orientation$ 
Horizontal=�6   $��	80,3,0,20q�5*      .+�5+      �� $��已加密文件个数：��6   $
��Bold"�5-      �� 5.      -   5        $ 	FolderNum��5.      $
��Bold"�5/      $��0��50      51      �� 53      $ 
Horizontal=�6   .+�54      �� $��文件路径：��6   $��Center=�55      $��80,0,0,0q�56      �� 57      -   5         ��Name$ File_Txt��57      $	��380��58      $��30��59      $
��10,0q�5:      $��Center=�5;      $
��Left=�5<      �� 5=      -   5         ��Name$ File_Btn��5=      $��70��5>      
�������$��选择文件夹��5@      5A      5B      �� 5C      -   5        	 ��Name$	 Encrypted_CB��5C      $$��加密文件是否设置密码��5D      
 d� 	IsChecked$

 TrueY�5E      $��Center=�5F      $��Center=�5G      5H      5J      5K      