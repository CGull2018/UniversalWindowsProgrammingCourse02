﻿#pragma checksum "C:\Users\Gullickson\Documents\Rasmussen Classes\July2-Aug9\UniversalProgramming 2\CGullickson_M4_CourseProject\Course Project\App1\Faculty.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "BC6BFFBE3F00D02CF3849DD1D98D1B65"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace App1
{
    partial class Faculty : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // Faculty.xaml line 13
                {
                    this.image = (global::Windows.UI.Xaml.Controls.Image)(target);
                }
                break;
            case 3: // Faculty.xaml line 15
                {
                    this.hypLnkPage2 = (global::Windows.UI.Xaml.Controls.HyperlinkButton)(target);
                    ((global::Windows.UI.Xaml.Controls.HyperlinkButton)this.hypLnkPage2).Click += this.hypLnkPage2_Click;
                }
                break;
            case 4: // Faculty.xaml line 18
                {
                    this.txtBoxFooter = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 5: // Faculty.xaml line 21
                {
                    global::Windows.UI.Xaml.Controls.Image element5 = (global::Windows.UI.Xaml.Controls.Image)(target);
                    ((global::Windows.UI.Xaml.Controls.Image)element5).Loaded += this.Image_Loaded;
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}
