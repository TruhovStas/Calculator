using Calculator.Utilities;
using System.Collections.ObjectModel;

namespace Calculator
{
    public partial class MainPage : ContentPage
    {
        // ObservableCollection to hold items for ListViews
        private ObservableCollection<string> leftListItems;
        private ObservableCollection<string> rightListItems;

        private Parser parser;

        public MainPage()
        {
            InitializeComponent();

            // Initialize the ObservableCollections
            leftListItems = new ObservableCollection<string>();
            rightListItems = new ObservableCollection<string>();

            // Set the ItemsSource for ListViews
            LeftListBox.ItemsSource = leftListItems;
            RightListBox.ItemsSource = rightListItems;

            parser = new Parser();
        }

        private void OnExecuteButtonClicked(object sender, EventArgs e)
        {
            try
            {
                // Get the input text
                string inputText = InputEntry.Text;

                if (!string.IsNullOrWhiteSpace(inputText))
                {
                    // Clear the input field
                    InputEntry.Text = string.Empty;

                    string? parsing_result = parser.Parse(inputText);

                    if (parsing_result == null)
                    {
                        OutputLabel.Text = $"Сохранено";

                        leftListItems.Clear();
                        rightListItems.Clear();

                        foreach (var variable in parser.VariableDictionary.GetAllVariables())
                        {
                            string variableDefinition = variable.Name + '=' + variable.Value;
                            leftListItems.Add(variableDefinition);
                        }

                        foreach (var function in parser.FunctionDictionary.GetAllFunctions())
                        {
                            string functionDefinition = function.Name + '(';
                            for (int i = 0; i < function.Parameters.Count; ++i)
                            {
                                functionDefinition += function.Parameters[i];
                                if (i != function.Parameters.Count - 1) functionDefinition += ",";
                            }
                            functionDefinition += ")=";
                            functionDefinition += function.Body;
                            rightListItems.Add(functionDefinition);
                        }
                    }
                    else
                    {
                        double result = Utilities.Calculator.SolveEquation(parsing_result);
                        OutputLabel.Text = result.ToString();
                    }
                }
                else
                {
                    OutputLabel.Text = "Введите выражение";
                }
            }
            catch(Exception ex) 
            {
                OutputLabel.Text = ex.Message;
            }
        }
    }
}