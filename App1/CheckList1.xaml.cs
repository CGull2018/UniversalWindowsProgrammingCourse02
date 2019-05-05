using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.Storage;
using System.Net.Http;
using Newtonsoft.Json;

using SQLite;
using SQLite.Net;
using SQLite.Net.Async;
using Microsoft.WindowsAzure.MobileServices.Sync;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Microsoft.WindowsAzure.MobileServices;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CheckList1 : Page
    {
        public CheckList1()
        {
            this.InitializeComponent();
        }
        public class TodoItem // creat a TodoItem data object
        {
            public string Id { get; set; }
            public string Text { get; set; }
            public bool Complete { get; set; }

        }
        private IMobileServiceSyncTable<TodoItem> todoGetTable = App.AzureMobileService.GetSyncTable<TodoItem>();

        IMobileServiceTable<TodoItem> todoTable = App.AzureMobileService.GetTable<TodoItem>();
        private async Task InitLocalStoreAsync()
        {
            if (!App.AzureMobileService.SyncContext.IsInitialized)
            {
                var store = new MobileServiceSQLiteStore("Rasmussen.db");
                store.DefineTable<TodoItem>();
                await App.AzureMobileService.SyncContext.InitializeAsync(store);
            }
            await SyncAsync();
        }

        private async Task SyncAsync()
        {
            await App.AzureMobileService.SyncContext.PushAsync();
            await todoGetTable.PullAsync("TodoItem", todoGetTable.CreateQuery());
        }

        public object items { get; private set; }

        private async void button_Click(object sender, RoutedEventArgs e)
        {
            TodoItem item = new TodoItem();
            item.Text = textBox.Text;
            item.Complete = false;
            todoTable.InsertAsync(item);

            MessageDialog message = new MessageDialog("New Item Inserted: " + item.Text);
            message.ShowAsync();


            String itemEntered = "Item Inserted: " + item.Text + " Item Status is: ? " + item.Complete;
            outputBox.Text = itemEntered;

        }
        private async void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            InitLocalStoreAsync();

            await RefreshTodoItems();
        }

        private async void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            InitLocalStoreAsync();

            await DeleteTodoItems();
        }
        private async Task RefreshTodoItems()
        {
            MobileServiceInvalidOperationException exception = null;
            try
            {

                List<TodoItem> items = await todoTable.Where(todoItem => todoItem.Complete == false).ToListAsync();
                foreach (var value in items)
                {

                    MessageDialog dialog = new MessageDialog("User Task: " + value.Text);
                    await dialog.ShowAsync();
                }
                    removeButton.Background = new SolidColorBrush(Windows.UI.Colors.LightBlue);
                    removeButton.IsEnabled = true;
                    outputBox.Text = "Would you like to remove this item item? ";
            }
            catch (MobileServiceInvalidOperationException e)
            {
                exception = e;
            }

            if (exception != null)
            {
                await new MessageDialog(exception.Message, "Error loading items").ShowAsync();
            }

        }
        private async Task DeleteTodoItems()
        {

            List<TodoItem> items = await todoTable.Where(todoItem => todoItem.Complete == false).ToListAsync();
            var remove = txtBoxRemove.Text;
            foreach (var value in items.ToList())
            {

                if (remove == value.Text)
                {
                    outputBox.Text = "Item for removal matches list item: ";
                    items.Remove(value);
                    await todoGetTable.DeleteAsync(value);
                }

                else
                {
                    outputBox.Text = "No Matches found: Please refresh the list to REMOVE another item";
                    break;
                }
            }

                
                removeButton.Background = new SolidColorBrush(Windows.UI.Colors.White);
                removeButton.IsEnabled = false;

        }

        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }


    }
}
