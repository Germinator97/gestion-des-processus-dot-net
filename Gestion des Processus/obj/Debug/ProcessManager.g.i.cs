﻿#pragma checksum "..\..\ProcessManager.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "F0F613AEF9DA78EA0E7DF729287C0A724FCED59D"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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


namespace Gestion_des_Processus {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 22 "..\..\ProcessManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem visibilite;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\ProcessManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas contenu;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\ProcessManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView processusBallons;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\ProcessManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView processusPremiers;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\ProcessManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label nbreBallons;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\ProcessManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label nbrePremiers;
        
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
            System.Uri resourceLocater = new System.Uri("/Gestion des Processus;component/processmanager.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ProcessManager.xaml"
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
            
            #line 5 "..\..\ProcessManager.xaml"
            ((Gestion_des_Processus.MainWindow)(target)).Closed += new System.EventHandler(this.Manager_Closed);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 9 "..\..\ProcessManager.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Ballon_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 10 "..\..\ProcessManager.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Premiers_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 13 "..\..\ProcessManager.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.ballon_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 14 "..\..\ProcessManager.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.premier_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 15 "..\..\ProcessManager.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.dernierProcessus_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 16 "..\..\ProcessManager.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.dernierBallon_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 17 "..\..\ProcessManager.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.dernierPremier_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 18 "..\..\ProcessManager.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.tousBallons_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 19 "..\..\ProcessManager.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.tousPremiers_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 20 "..\..\ProcessManager.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.tousProcessus_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.visibilite = ((System.Windows.Controls.MenuItem)(target));
            
            #line 22 "..\..\ProcessManager.xaml"
            this.visibilite.Click += new System.Windows.RoutedEventHandler(this.masquerVisible_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 23 "..\..\ProcessManager.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.quitter_Click);
            
            #line default
            #line hidden
            return;
            case 14:
            
            #line 24 "..\..\ProcessManager.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.aide_Click);
            
            #line default
            #line hidden
            return;
            case 15:
            this.contenu = ((System.Windows.Controls.Canvas)(target));
            return;
            case 16:
            this.processusBallons = ((System.Windows.Controls.ListView)(target));
            return;
            case 17:
            this.processusPremiers = ((System.Windows.Controls.ListView)(target));
            return;
            case 18:
            this.nbreBallons = ((System.Windows.Controls.Label)(target));
            return;
            case 19:
            this.nbrePremiers = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

