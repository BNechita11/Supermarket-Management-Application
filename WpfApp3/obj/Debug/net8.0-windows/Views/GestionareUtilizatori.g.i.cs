﻿#pragma checksum "..\..\..\..\Views\GestionareUtilizatori.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "66317C7B5DECC5B5EFF5671808FAE1177029DA26"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace WpfApp3.Views {
    
    
    /// <summary>
    /// GestionareUtilizatori
    /// </summary>
    public partial class GestionareUtilizatori : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\..\Views\GestionareUtilizatori.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtUtilizatorId;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\..\Views\GestionareUtilizatori.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtNume;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\..\Views\GestionareUtilizatori.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtParola;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\Views\GestionareUtilizatori.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtTipUtilizator;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\..\Views\GestionareUtilizatori.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox chkIsActive;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.5.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WpfApp3;V1.0.0.0;component/views/gestionareutilizatori.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\GestionareUtilizatori.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.5.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.txtUtilizatorId = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.txtNume = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txtParola = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.txtTipUtilizator = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.chkIsActive = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 6:
            
            #line 24 "..\..\..\..\Views\GestionareUtilizatori.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnAdaugaUtilizator_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 25 "..\..\..\..\Views\GestionareUtilizatori.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnActualizeazaUtilizator_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 26 "..\..\..\..\Views\GestionareUtilizatori.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnStergeUtilizator_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 27 "..\..\..\..\Views\GestionareUtilizatori.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnAfiseazaUtilizatori_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

