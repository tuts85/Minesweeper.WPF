   M S B A M L   `   `   `  ����J  FMinesweeper.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Minesweeper.WPFMinesweeper.WPF  5   	       Minesweeper.WPF.New_Game   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:Minesweeper.WPF     5   	     � Title$  Create a New Game��5   	   $	��240��6#   $	��300��60   
�������.��5	      � $��0,0,0,7q�6   .+�5   
   	� -   5         	�Name$ beginnerrdbtn��5      $��14(�6-    	� 	GroupName$ newGame��6;   $��Beginner��6O   $
��Left=�6b   $��	40,33,0,0q�6}   $	��Top=�6�   	� 5   
   -   5        $ intermrdbtn��5      $��14(�6,   $ newGame��6:   $��Intermediate��6N   $
��Left=�6e   $��	40,51,0,0q�6�   $	��Top=�6�   	� 5   
   -   5        $ advancedrdbtn��5      $��14(�6-   $ newGame��6;   $��Advanced��6O   $
��Left=�6b   $��	40,69,0,0q�6}   $	��Top=�6�   	� 5   
   -   5        $ customrdbtn��5      $��14(�6+   $ newGame��69   $��Custom (Rows x Columns)��6M   $
��Left=�6o   $��
40,102,0,0q�6�   $	��Top=�6�   �� 5   
   -   5         ��Name$ rowstxbx��5      $
��Left=�6$   $��23��6?   $��127,125,0,0q�6K    �� TextWrapping$
 Wrap=�6`   $�� ��6t   $	��Top=�6|   $��42��6�   �� 5   
   -   5        $ colstxbx��5      $
��Left=�6$   $��23��6?   $��177,125,0,0q�6K   $
 Wrap=�6`   $�� ��6t   $	��Top=�6|   $��42��6�   �� 5   
   -   5        $��OK��5      $
��Left=�6   $��141,169,0,0q�69   $	��Top=�6N   $��60��6f   $��25��6q   6}   �� 5   
   -   5        $��Cancel��5      $
��Left=�6"   $��206,169,0,0q�6=   $	��Top=�6R   $��60��6j   $��25��6u   6�   �� 5   
   -	   5         ��Name$ challengechbx��5      $��14(�6*   $��Challenge Mode��68   $
��Left=�6Q   $��
145,33,0,0q�6l   $	��Top=�6�   5      5      