﻿#pragma checksum "..\..\ChonLopXoa.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9DA8C816D864DA183D9D3409F3D1D28DB496362A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using HSM2;
using MaterialDesignThemes.MahApps;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Transitions;
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


namespace HSM2 {
    
    
    /// <summary>
    /// ChonLopXoa
    /// </summary>
    public partial class ChonLopXoa : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\ChonLopXoa.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.ColorZone TitleBar;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\ChonLopXoa.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btThuNho;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\ChonLopXoa.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btDong;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\ChonLopXoa.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbLop;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\ChonLopXoa.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btOK;
        
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
            System.Uri resourceLocater = new System.Uri("/HSM2;component/chonlopxoa.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ChonLopXoa.xaml"
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
            this.TitleBar = ((MaterialDesignThemes.Wpf.ColorZone)(target));
            
            #line 23 "..\..\ChonLopXoa.xaml"
            this.TitleBar.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.TitleBar_OnMouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btThuNho = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\ChonLopXoa.xaml"
            this.btThuNho.Click += new System.Windows.RoutedEventHandler(this.btThuNho_Click);
            
            #line default
            #line hidden
            
            #line 38 "..\..\ChonLopXoa.xaml"
            this.btThuNho.MouseEnter += new System.Windows.Input.MouseEventHandler(this.btThuNho_MouseEnter);
            
            #line default
            #line hidden
            
            #line 38 "..\..\ChonLopXoa.xaml"
            this.btThuNho.MouseLeave += new System.Windows.Input.MouseEventHandler(this.btThuNho_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btDong = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\ChonLopXoa.xaml"
            this.btDong.Click += new System.Windows.RoutedEventHandler(this.btDong_Click);
            
            #line default
            #line hidden
            
            #line 41 "..\..\ChonLopXoa.xaml"
            this.btDong.MouseEnter += new System.Windows.Input.MouseEventHandler(this.btDong_MouseEnter);
            
            #line default
            #line hidden
            
            #line 41 "..\..\ChonLopXoa.xaml"
            this.btDong.MouseLeave += new System.Windows.Input.MouseEventHandler(this.btDong_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 4:
            this.cbLop = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.btOK = ((System.Windows.Controls.Button)(target));
            
            #line 70 "..\..\ChonLopXoa.xaml"
            this.btOK.Click += new System.Windows.RoutedEventHandler(this.btOK_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

