   M S B A M L   `   `   `  ���� ^  ZMicrosoft.Samples.Kinect.WpfViewers, Version=0.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:Microsoft.Samples.Kinect.WpfViewers#Microsoft.Samples.Kinect.WpfViewers  @    :Microsoft.Samples.Kinect.WpfViewers.KinectDiagnosticViewer   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @kt1clr-namespace:Microsoft.Samples.Kinect.WpfViewers     @d2http://schemas.microsoft.com/expression/blend/2008     .��� -   $��
LayoutRoot��
���   �  � ColumnDefinitions  �� $
��Auto ��� $��2* ��� $��1* ��� $
��.05* � � RowDefinitions �� $��* ��� $
��Auto ��� $
��Auto �.+�� $��0��$��3��$��2��
���   �
�������$��14(�.+�9� -   $��Settings�� 9� ExpandDirection$
 Down=�
���   �$��Stretch=����   �� $
��Auto ��� $��* ��� $
��Auto �.+��� 
����İ�$��0��.��_KinectSensor�� -   $��status��
����ح�$��Center=�$��1������ *Status+ � ToolTip �� *Sensor.UniqueKinectId+�� $��Right=�
����İ�$��10(�$��40��$
��Wrap=�$��2��$��	120,0,0,0q�(click for settings)� -   $��
colorPanel��$��1��$��0��$	��960��$
��1280�� �� $
��Auto ��� $��* ��� $
��Auto �.+�(� $��1��.��� .+�;   5Microsoft.Samples.Kinect.WpfViewers.KinectColorViewer  -     Name$ colorViewer��5   /Microsoft.Samples.Kinect.WpfViewers.ImageViewer   CollectFrameRate . �� .+�>   8Microsoft.Samples.Kinect.WpfViewers.KinectSkeletonViewer  -     Name$! KinectSkeletonViewerOnColor��   	ImageType$ Color=�����  �� ElementName$ colorViewer��	 �� Path$	 ActualWidth����� $ colorViewer��$	 ActualHeight��� 
 �� Orientation$
 Vertical=�
�������$��1��$
��Left=�$��Bottom=�.+��� $��24(����� $ colorViewer��$	 	FrameRate��� $��14(�FPS;   5Microsoft.Samples.Kinect.WpfViewers.KinectAudioViewer  -     Name$ kinectAudioViewer��$��Stretch=�$��Stretch=�$��1��$��1��$��3��� -   $��
depthPanel��$��2��$��0��.+�� $��4��$	��480��$	��640��.+�(� .��� .+�;   5Microsoft.Samples.Kinect.WpfViewers.KinectDepthViewer  -	     Name$ KinectDepthViewer�� . �� .+�  -
   $! KinectSkeletonViewerOnDepth��   	ShowBones .    
ShowJoints .    
ShowCenter . $ Depth=����� $ KinectDepthViewer��$	 ActualWidth����� $ KinectDepthViewer��$	 ActualHeight��� $
 Vertical=�
�������$
��Left=�$��Bottom=�.+��� $��24(����� $ KinectDepthViewer��$	 	FrameRate��� $��14(�FPS