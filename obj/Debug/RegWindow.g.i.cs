﻿#pragma checksum "..\..\RegWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "A234172CEB6BB21BC11C80715456269B61CD69654BB1ADD8FBE7D1853028807B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using KeyboardWriting;
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


namespace KeyboardWriting {
    
    
    /// <summary>
    /// RegWindow
    /// </summary>
    public partial class RegWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\RegWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbUsername;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\RegWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbSamplePhrase;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\RegWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbWrittenPhrase;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\RegWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnReadme;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\RegWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label1;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\RegWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label2;
        
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
            System.Uri resourceLocater = new System.Uri("/KeyboardWriting;component/regwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\RegWindow.xaml"
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
            this.tbUsername = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.tbSamplePhrase = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.tbWrittenPhrase = ((System.Windows.Controls.TextBox)(target));
            
            #line 16 "..\..\RegWindow.xaml"
            this.tbWrittenPhrase.KeyDown += new System.Windows.Input.KeyEventHandler(this.TbWrittenPhrase_KeyDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnReadme = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\RegWindow.xaml"
            this.btnReadme.Click += new System.Windows.RoutedEventHandler(this.BtnReadme_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.label1 = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.label2 = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

