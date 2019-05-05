using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            BL_PageContent.CreatedBy = "Created By: Cody Gullickson";
            txtBoxFooter.Text = BL_PageContent.CreatedBy;

        }
        //Link Button
         private void hypLnkPage2_Click(Object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Faculty));
        }

        //Calculator process
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            ProcessCalc();
        }

        private void ProcessCalc()
        {
            Int32 Var1 = Convert.ToInt32(txtBoxInput1.Text) + Convert.ToInt32(txtBoxInput2.Text);
            txtBoxDisplay.Text = Convert.ToString(Var1);
        }




        //Button one call to class method
        public static string VarOutput1 { get; set; } //place property within the class
        async private void btnCourseName1_Click(object sender, RoutedEventArgs e)

        {
            BL_PageContent.Course1();
            txtBoxCourse.Text = BL_PageContent.VarOutput1;
            var dialog = new MessageDialog(BL_PageContent.VarOutput1);
            await dialog.ShowAsync();
        }

        //Button 2 Within main class
        public static string VarOutput2 { get; set; } //place property within the class
        async private void btnCourseName2_Click(object sender, RoutedEventArgs e)

        {
            VarOutput2 = null;

            string[] names = new string[3] { "CIS4793C", "DBI", "This course is database implementation strategies." };

            //string VarOutput;
            for (int i = 0; i < names.Length; i++)

            { VarOutput2 = VarOutput2 + names[i] + "  "; }
            

            txtBoxCourse.Text = VarOutput2;
            var dialog = new MessageDialog(VarOutput2);
            await dialog.ShowAsync();

        }


        public static string VarOutput3 { get; set; } //place property within the class
        async private void btnCourseName3_Click(object sender, RoutedEventArgs e)

        {
            VarOutput3 = null;

            string[] names = new string[3] { "CTS3302C", "CC1", "This course is fundamentals of cloud computing." };

            //string VarOutput;
            for (int i = 0; i < names.Length; i++)

            { VarOutput3 = VarOutput3 + names[i] + "  "; }


            txtBoxCourse.Text = VarOutput3;
            var dialog = new MessageDialog(VarOutput3);
            await dialog.ShowAsync();

        }

        private void Module03_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(UserAuth));
        }

        private void Module04_Click(Object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CheckList1));
        }
    }


    
}
