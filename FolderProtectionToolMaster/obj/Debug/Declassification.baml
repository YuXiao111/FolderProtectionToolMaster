   M S B A M L   `   `   `  ����U  QFolderProtectionToolMaster, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:FolderProtectionToolMasterFolderProtectionToolMaster  5   	   1    +FolderProtectionToolMaster.Declassification   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   :local(clr-namespace:FolderProtectionToolMaster     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � 
ResizeMode$ NoResize=�5	   	    � Title$ 文件解密-密码输入��5
   	   $	��160��5   	   $	��320��5   	   .��5      �  � RowDefinitions 5   
   �� 5      �� 5      .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��Center=�5      $��Center=�5      .+�5      �� $��输入密码：��6   $��60��5      $��Center=�5      G� 5      -   5         G�Name$ Password_Txt��5      $	��200��5      $��30��5      $
��10,0q�5      $��Center=�5      $
��Left=�5      5      �� 5   
   -   5         ��Name$ Encrypted_Btn��5      $��2��5       $	��160��5!      $��30��5"      $��提交��5#      
�������5%      5&      5'      