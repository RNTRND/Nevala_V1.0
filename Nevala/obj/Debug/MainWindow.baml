   M S B A M L   `   `   `  ����A  =Nevala, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:NevalaNevala  5   	   5clr-namespace:Nevala.ViewModelsNevala.ViewModels  5   	       Nevala.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   l hXceed.Wpf.AvalonDock.Themes.VS2010, Version=2.0.2000.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4^ ZXceed.Wpf.AvalonDock, Version=2.0.2000.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f47ad,http://schemas.xceed.com/wpf/xaml/avalondock   5   	   myclr-namespace:Nevala   5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   0
viewmodelsclr-namespace:Nevala.ViewModels  5   	     � Title$  
MainWindow��5   	   $	��350��6   $	��558��6)    � DataContext 5	      %   Nevala.ViewModels.MainViewModel  5
   
   .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6$   ��  �� Path$ File.WindowLoaded� �� Mode$ TwoWay=�5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��6* �6   $	��350��6*   �� 5      $��5 �6   �� 5      $��4* �6   $	��100��6+   	 � RowDefinitions	 5   
   �� 5      $��18 �6   �� 5      $��25 �6   �� 5      $��1* �6   $��50��6(   �� 5      $��5 �6   �� 5      $��1* �6   $��50��6(   .+�5   
      Nevala.OpenFileDialog  -   5        
  Name$
 openFileDialog��5         Filter$ All Files (*.*)|*.*��64      Multiselect . 6Q   ]� 5    
   $��Stretch=�6   $��Stretch=�62   $��0��6N   $��3��6\   .+�5!      o� $��Stretch=�6   $	��Top=�61   $	��Top=�6I   $��0��6^   $��3��6k   .@�5"      m� $��_File��6   .@�5#      m� -   5        $��newMenuItem��5#      $
��_New��6V    m� Command 62   �� *File.NewCommand+ m� Icon 5$      �� 5%      $
��16px��6$   $/��)/Nevala;component/Images/ImageFileNew.png��62   $��Uniform=�6e   5'      m� 5(      -   5        $��openMenuItem��5(      $��_Open...��6X    63   �� *File.OpenCommand+ 5)      �� 5*      $
��16px��6$   $0��*/Nevala;component/Images/ImageFileOpen.png��62   $��Uniform=�6f   5,      �� 5-      m� 5.      -   5        $��saveMenuItem��5.      $��_Save��6X    63   �� *File.SaveCommand+ 5/      �� 50      $
��16px��6$   $0��*/Nevala;component/Images/ImageFileSave.png��62   $��Uniform=�6f   52      m� 53      -   5        $��saveAsMenuItem��53      $��Save _As...��6`    65   �� *File.SaveFileAsCommand+6`   m� 54      -   5        $��saveAllMenuItem��54      $��	Save A_ll��6^    66   �� *File.SaveAllCommand+ 55      �� 56      $
��16px��6$   $3��-/Nevala;component/Images/ImageFileSaveAll.png��62   $��Uniform=�6i   58      �� 59      m� 5:      -   5        $��closeMenuItem��5:      $��_Close��6Z    64   �� *File.CloseCommand+6Z   m� 5;      -   5        $��closeAllMenuItem��5;      $��
_Close All��6`    67   �� *File.CloseAllCommand+6`   �� 5<      m� 5=      -	   5        $��printMenuItem��5=      $��_Print File��6Z    64   �� *File.PrintCommand+6Z   �� 5>      m� 5?      -
   5        $��exitMenuItem��5?      $��E_xit��6X    63   �� *File.ExitCommand+6X   5@      m� 5A      $��_Edit��6   .@�5B      m� -   5        $��undoMenuItem��5B      $��_Undo��6X    63   �� *Edit.UndoCommand+ 5C      �� 5D      $
��16px��6$   $0��*/Nevala;component/Images/ImageEditUndo.png��62   $��Uniform=�6f   5F      m� 5G      -   5        $��redoMenuItem��5G      $��_Redo��6X    63   �� *Edit.RedoCommand+ 5H      �� 5I      $
��16px��6$   $0��*/Nevala;component/Images/ImageEditRedo.png��62   $��Uniform=�6f   5K      �� 5L      m� 5M      -   5        $��cutMenuItem��5M      $
��_Cut��6V    62   �� *Edit.CutCommand+ 5N      �� 5O      $
��16px��6$   $/��)/Nevala;component/Images/ImageEditCut.png��62   $��Uniform=�6e   5Q      m� 5R      -   5        $��copyMenuItem��5R      $��_Copy��6X    63   �� *Edit.CopyCommand+ 5S      �� 5T      $
��16px��6$   $0��*/Nevala;component/Images/ImageEditCopy.png��62   $��Uniform=�6f   5V      m� 5W      -   5        $��pasteMenuItem��5W      $��_Paste��6Z    64   �� *Edit.PasteCommand+ 5X      �� 5Y      $
��16px��6$   $1��+/Nevala;component/Images/ImageEditPaste.png��62   $��Uniform=�6g   5[      �� 5\      m� 5]      -   5        $��SelectLineMenuItem��5]      $��Select_Line��6d    69   �� *Edit.SelectLineCommand+6d   m� 5^      -   5        $��SelectAllMenuItem��5^      $��Select _All��6b    68   �� *Edit.SelectAllCommand+6b   m� 5_      -   5        $��ClearSelection��5_      $��Clear Selection��6[    65   �� *Edit.ClearCommand+6[   �� 5`      m� 5a      $��_Find and Replace��6   .@�5b      m� -   5        $��IncrementalSearchMenuItem��5b   #   $��_Incremental Search��6v    6D   �� *Edit.incrementalSearchCommand+6v   m� 5c      -   5        $��FindMenuItem��5c   #   $��_Find��6\    67   �� *Edit.FindCommand+6\   m� 5d      -   5        $��ReplaceMenuItem��5d   #   $��_Replace��6b    6:   �� *Edit.ReplaceCommand+6b   m� 5e      -   5        $��ReplaceInFilesMenuItem��5e   #   $��_Replace in Files��6p    6A   �� *Edit.ReplaceInFilesCommand+6p   5f      m� 5g      -   5        $��Go_toMenuItem��5g      $��_Go To��6Y    64   �� *Edit.GoToCommand+6Y   �� 5h      m� 5i      $��
_Bookmarks��6   .@�5j      m� -   5        $��ToggleBookmarkMenuItem��5j   #   $��_Toggle Bookmark��6i    6A   �� *Edit.ToggleBookmark+6i   m� 5k      -   5        $��PreviousBookmarkMenuItem��5k   #   $��_Previous Bookmark��6m    6C   �� *Edit.PreviousBookmark+6m   m� 5l      -   5        $��NextBookmarkMenuItem��5l   #   $��Next _Bookmark��6e    6?   �� *Edit.NextBookmark+6e   m� 5m      -   5        $��ClearBookmarksMenuItem��5m   #   $��_Clear Bookmarks��6i    6A   �� *Edit.ClearBookmarks+6i   5n      �� 5o      m� 5p      $��	_Advanced��6   .@�5q      m� -   5        $��MakeUpperCaseMenuItem��5q   #   $��_Make Upper Case��6o    6A   �� *Edit.MakeUpperCaseCommand+6o   m� 5r      -   5        $��MakeLowerCaseMenuItem��5r   #   $��_Make Lower Case��6o    6A   �� *Edit.MakeLowerCaseCommand+6o   5s      5t      m� 5u      $��_View��6   .@�5v      m� -   5        $��zoomIn��5v      $��Zoom In��6U    6-   �� *View.ZooomInCommand+6U   m� 5w      -   5        $��zoomOut��5w      $��Zoom Out��6V    6.   �� *View.ZoomOutCommand+6V   m� 5x      -    5        $��lineNumbersMenuItem��5x      $��Line Numbers��6f    6:   �� *View.LineNumbersCommand+6f   m� 5y      -!   5        $��wordWrapMenuItem��5y      $��	Word Wrap��6`    67   �� *View.WordWrapCommand+6`   m� 5z      -"   5        $
��fold��5z      $
��Fold��6P    6+   �� *View.FoldCommand+6P   m� 5{      -#   5        $��unfold��5{      $��Unfold��6T    6-   �� *View.UnFoldCommand+6T   m� 5|      -$   5        $��foldAll��5|      $��Fold All��6V    6.   �� *View.FoldAllCommand+6V   m� 5}      -%   5        $��	unfoldAll��5}      $��
Unfold All��6Z    60   �� *View.UnFoldAllCommand+6Z   5~      m� 5      $��	_Settings��6   .@�5�      m� -&   5        $��Preferences��5�      $��Preferences��63   m� 5�      -'   5        $
��Font��5�      $
��Font��6+   m� 5�      -(   5        $��Import��5�      $��Import��6-   m� 5�      -)   5        $��ShortcutWrapper��5�      $��Shortcut Wrapper��66   5�      m� 5�      $
��_Run��6   .@�5�      m� -*   5        $	��Run��5�      $	��Run��6*   m� 5�      -+   5        $��SendviaOutlook��5�      $��Send via Outlook��65   5�      m� 5�      $
��Help��6   .@�5�      m� -,   5        $��	PowerHelp��5�      $��
Power Help��60   m� 5�      --   5        $��About��5�      $��About��6,   m� 5�      -.   5        $��BahubaliHelp��5�      $��Bahubali Help��63   5�      5�      5�      ]� 5�   
   $��Stretch=�6   $��Stretch=�62   $��1��6N   $��3��6[   .+�5�      a� -/   5        $��	toolStrip��5�      $��Stretch=�6,   $	��Top=�6J   .+�5�      `� $��1��6   $��3��6+   .�5�      c� $
��25px��6    `� IsLocked . .@�5�      �� $
��23px��6!   $
��22px��6.   $	��0pxq�6<    � ToolTip$ New File (Ctrl+N)��5�   !   ��6=   �� *File.NewCommand+.��5�      �� .+�5�   "   �� $
��16px��6(   $/��)/Nevala;component/Images/ImageFileNew.png��66   $��Uniform=�6i   5�      5�      �� 5�      $
��23px��6!   $
��22px��6.   $	��0pxq�6<   $ Open File (Ctrl+O)��5�   "   ��6?   �� *File.OpenCommand+.��5�      �� .+�5�   "   �� $
��16px��6(   $0��*/Nevala;component/Images/ImageFileOpen.png��66   $��Uniform=�6j   5�      5�      �� 5�      $
��23px��6!   $
��22px��6.   $	��0pxq�6<   $ Save File (Ctrl+S)��5�   "   ��6?   �� *File.SaveCommand+.��5�      �� .+�5�   "   �� $
��16px��6(   $0��*/Nevala;component/Images/ImageFileSave.png��66   $��Uniform=�6j   5�      5�      �� 5�      $
��23px��6!   $
��22px��6.   $	��0pxq�6<   $# Save All Files (Ctrl+Shift+S)��5�   !   ��6I   �� *File.SaveAllCommand+.��5�      �� .+�5�   "   �� $
��16px��6(   $3��-/Nevala;component/Images/ImageFileSaveAll.png��66   $��Uniform=�6m   5�      5�      �� 5�      �� 5�      $
��23px��6!   $
��22px��6.   $	��0pxq�6<   $ Cut (Ctrl+X)��5�   !   ��68   �� *Edit.CutCommand+.��5�      �� .+�5�   "   �� $
��16px��6(   $/��)/Nevala;component/Images/ImageEditCut.png��66   $��Uniform=�6i   5�      5�      �� 5�      $
��23px��6!   $
��22px��6.   $	��0pxq�6<   $ Copy (Ctrl+C)��5�   "   ��6:   �� *Edit.CopyCommand+.��5�      �� .+�5�   "   �� $
��16px��6(   $0��*/Nevala;component/Images/ImageEditCopy.png��66   $��Uniform=�6j   5�      5�      �� 5�      $
��23px��6!   $
��22px��6.   $	��0pxq�6<   $ Paste (Ctrl+V)��5�   "   ��6;   �� *Edit.PasteCommand+.��5�      �� .+�5�   "   �� $
��16px��6(   $1��+/Nevala;component/Images/ImageEditPaste.png��66   $��Uniform=�6k   5�      5�      �� 5�      �� 5�      $
��23px��6!   $
��22px��6.   $	��0pxq�6<   $ Undo (Ctrl+Z)��5�   "   ��6:   �� *Edit.UndoCommand+.��5�      �� .+�5�   "   �� $
��16px��6(   $0��*/Nevala;component/Images/ImageEditUndo.png��66   $��Uniform=�6j   5�      5�      �� 5�      $
��23px��6!   $
��22px��6.   $	��0pxq�6<   $ Redo (Ctrl+Y)��5�   "   ��6:   �� *Edit.RedoCommand+.��5�      �� .+�5�   "   �� $
��16px��6(   $0��*/Nevala;component/Images/ImageEditRedo.png��66   $��Uniform=�6j   5�      5�      5�      5�      5�      5�      ]� 5�   
   $��Stretch=�6   $��Stretch=�62   $��2��6N   $��3��6\   $��1��6m   .+�5�      ]� $��Stretch=�6   $��Stretch=�66   $��Bottom=�6R   .+�5�      )  #Xceed.Wpf.AvalonDock.DockingManager  -0   5        $��	dockPanel��5�   $   $��3��65   $��0��6B    5�        5�      $ ActiveContentChanged��6)   . 5�         64   �� $" File.DockPanelContentChanged�$ TwoWay=�5�         Theme 5�      .  (Xceed.Wpf.AvalonDock.Themes.GenericTheme  5�         Layout. 5�      ,	  &Xceed.Wpf.AvalonDock.Layout.LayoutRoot	   	  	RootPanel. 5�      -
  'Xceed.Wpf.AvalonDock.Layout.LayoutPanel
  �  �Xceed.Wpf.AvalonDock.Layout.LayoutGroup`1[[Xceed.Wpf.AvalonDock.Layout.ILayoutPanelElement, Xceed.Wpf.AvalonDock, Version=2.0.2000.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4]]   Children. 5�      4  .Xceed.Wpf.AvalonDock.Layout.LayoutDocumentPane  -1   5        documentsRoot���  �Xceed.Wpf.AvalonDock.Layout.LayoutPositionableGroup`1[[Xceed.Wpf.AvalonDock.Layout.LayoutContent, Xceed.Wpf.AvalonDock, Version=2.0.2000.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4]]   IsMaximized . 5�   K   5�      5�      5�      5�      5�      �� 5�   
   $��1��6   $��2��6'   $��3��64   $��5��6E   $��Stretch=�6O   �� 5�   
   $��2��6   $��2��6%    �� TabStripPlacement$ Bottom=�62   .@�5�      �� $��File Explorer��6   .��5�      �� $
��Auto=�6   .��5�      � $��2��6   $��2��6+   $��3��68   .+�5�      R� -2   5         R�Name$ 
FolderView��5�   #   ��67   �� *Items+ 5�      (   "Nevala.DirectoryStructureViewModel  5�   "   ��5�      �� 5�   "    �� 
TargetType" Q�6(   .�5�   &   ��  �� Property �@Q�
IsExpanded �� Value 6C   �� *
IsExpanded+$ TwoWay=�5�   #   ��5      �� 5  "    �� ItemsSource 6;   �� *
Children+.R�5  &   ��  �� Orientation$ 
Horizontal=�61   .+�5  *   �� $��20��60   $��3q�6;   ��5  -   �� *Type+#   Nevala.HeaderToImageConverter   Instance �� 	Converter# Z �� 5  *   $��Center=�64   ��6O   �� *Name+ 5  *     5  .   $  PreviewMouseLeftButtonDown��6=   . 5	  2      6H   �� $ OpenOnClick�$ TwoWay=�5
  0   5  +   5  '   5  #   5     5     5     5     �� 5     $��Variable Explorer��6   5     5     �� 5  
   $��2��6   $��3��6'   $��5��65   $��Stretch=�6@   �� 5  
   $��3��6   $��4��6%   $ Bottom=�62   .@�5     �� $��Python��6   .��5     7  1System.Windows.Forms.Integration.WindowsFormsHost  -3   5          Name$
 host��5  #   $��3��61   6C   5#     �� 5$     $��IPython��6   .��5%     �� -4   5        $��IOutput��5%     $��Console��5&     $��3��5'     $��4��5(       �� AcceptsReturn  . ! �� 
AcceptsTab! . " �� TextWrapping$
" Wrap=�5+     5,     5-     5.     5/     