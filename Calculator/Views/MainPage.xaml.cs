using Microsoft.Maui.Controls;
using System;
using System.Collections.ObjectModel;

namespace Calculator
{
    public partial class MainPage : ContentPage
    {
        // ObservableCollection to hold items for ListViews
        private ObservableCollection<string> leftListItems;
        private ObservableCollection<string> rightListItems;

        public MainPage()
        {
            InitializeComponent();

            // Initialize the ObservableCollections
            leftListItems = new ObservableCollection<string>();
            rightListItems = new ObservableCollection<string>();

            // Set the ItemsSource for ListViews
            LeftListBox.ItemsSource = leftListItems;
            RightListBox.ItemsSource = rightListItems;
        }

        private void OnExecuteButtonClicked(object sender, EventArgs e)
        {
            // Get the input text
            string inputText = InputEntry.Text;

            if (!string.IsNullOrWhiteSpace(inputText))
            {
                // Add the input text to both ListViews
                leftListItems.Add(inputText);
                rightListItems.Add(inputText);

                OutputLabel.Text = $"Вы ввели: {inputText}";

                // Clear the input field
                InputEntry.Text = string.Empty;
            }
            else
            {
                OutputLabel.Text = "Введите выражение";
            }
        }
    }
}