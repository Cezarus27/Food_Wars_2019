   M S B A M L   `   `   `  ����D  @Food_Wars, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Food_Wars	Food_Wars  5   	       Food_Wars.ScoreWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Food_Wars     5   	     � WindowStyle$
  None=�5       � 
ResizeMode$ NoResize=�6-    � Cursor$ Arrow��6C    � WindowStartupLocation$ CenterScreen=�6R    � Topmost .  � Title$ ScoreWindow��5	   	   $	��400��6   $	��500��6*   .��5
      � ��5   
   �� 5       �� ImageSource$ img/ScoreWindow.png��6    � RowDefinitions 5   
   �� 5      $	��150 �6   �� 5      $	��150 �6   �� 5      $	��100 �6   .+�5   
   �� $��0��6   $��Wynik:��6   $	��100��5      $	��240��6   $��
10,25,0,25q�6)   $��Center=�5      $��Center=�64   $
��Left=�6V   $��Roboto)�5      
�������$��40(�67   �� 5   
   -   5         ��Name$ Score��5      $��0��6   $	��100��5      $	��240��6   $��248,25,8,25q�6)   $��Center=�5      $��Center=�64   $��Roboto)�5      
�������$��40(�6<   �� 5   
   $��1��6   $��Czas:��6   $	��100��5      $	��240��6   $��
10,25,0,25q�6)   $��Center=�5      $��Center=�64   $
��Left=�6V   $��Roboto)�5      
�������$��40(�67   �� 5   
   -   5        $
 Time��5      $��1��6   $	��100��5       $	��240��6   $��248,25,8,25q�6)   $��Center=�5!      $��Center=�64   $��Roboto)�5"      
�������$��40(�6<   �� 5#   
   -   5        $��2��5#      $��Dalej��6   $��50��5$      $	��200��6   $��Roboto)�5%      
�������$��30(�68      MyButton#��[  5&   &   ��5'      �� 5(      $ img/button.png��6   5+      5,      5-      