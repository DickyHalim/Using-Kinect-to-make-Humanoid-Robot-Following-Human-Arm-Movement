﻿#pragma checksum "..\..\KinectSensorChooser.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "B78D95CD1362B3715140157744E04AA47BA93592"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Samples.Kinect.WpfViewers;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Microsoft.Samples.Kinect.WpfViewers {
    
    
    /// <summary>
    /// KinectSensorChooser
    /// </summary>
    public partial class KinectSensorChooser : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 31 "..\..\KinectSensorChooser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock MessageTextBlock;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\KinectSensorChooser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TellMeMore;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\KinectSensorChooser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Documents.Hyperlink TellMeMoreLink;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\KinectSensorChooser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button RetryButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Microsoft.Samples.Kinect.WpfViewers;component/kinectsensorchooser.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\KinectSensorChooser.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.MessageTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.TellMeMore = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.TellMeMoreLink = ((System.Windows.Documents.Hyperlink)(target));
            
            #line 34 "..\..\KinectSensorChooser.xaml"
            this.TellMeMoreLink.RequestNavigate += new System.Windows.Navigation.RequestNavigateEventHandler(this.TellMeMoreLinkRequestNavigate);
            
            #line default
            #line hidden
            return;
            case 4:
            this.RetryButton = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\KinectSensorChooser.xaml"
            this.RetryButton.Click += new System.Windows.RoutedEventHandler(this.RetryButtonClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

