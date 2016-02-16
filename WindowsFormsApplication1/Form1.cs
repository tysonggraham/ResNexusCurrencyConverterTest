using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace WindowsFormsApplication1
{
    /********************************************************************************
    * Form1
    *    This class initializes the form, a DatabaseConnection object, 
    *    a connection string, a DataSet Object, and the MaxRows to iterate through
    *    when retrieving data.
    ********************************************************************************/
    public partial class Form1 : Form
    {
        //Initializes the form and all of it's contents
        public Form1()
        {
            InitializeComponent();
        }

        //This will be used to connect to the CurrencyConversion Database
        DatabaseConnection objConnect;

        //The data won't go straight from the database to the form, rather it will be 
        //stored in this DataSet object and then transferred o the form.
        DataSet ds;

        //Tells the iterators when to stop looking for more data.
        int MaxRows;

        /********************************************************************************
        * Form1_Load()
        *    On-Load the form will try to establish a connection to the database
        *    'CurrencyConversion'. Once it has established a connection, it will fill
        *    the available input currency types and the output currency types. They will
        *    be labeled by their currency codes and put in combo boxes or drop-downs.
        ********************************************************************************/
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                objConnect = new DatabaseConnection();
                objConnect.connection_string = Properties.Settings.Default.CurrenciesConnectionString; ;

                //The SQLtest command can be found in settings. But for reference here it is:
                //SELECT * FROM Currencies
                objConnect.Sql = Properties.Settings.Default.SQLtest;

                //Get the data from the connection statement above. 
                ds = objConnect.GetConnection;

                //Find the stopping point for the iterators.
                MaxRows = ds.Tables[0].Rows.Count;

                //Fill the drop-downs with currency codes.
                FillInputCurrencyComboBox();
                FillOutputCurrencyComboBox();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        /********************************************************************************
        * FillInputCurrencyComboBox()
        *   Fills the InputCurrencyComboBox. This and the next function should really
        *   be turned into one function in the next version.
        ********************************************************************************/
        private void FillInputCurrencyComboBox()
        {
            inputCurrencyTypeSelect.Text = "Select Currency Code";
            DataRow dRowTemp;
            for (int i = 0; i < MaxRows; i++)
            {
                dRowTemp = ds.Tables[0].Rows[i];
                inputCurrencyTypeSelect.Items.Add(dRowTemp.ItemArray.GetValue(1).ToString());
            }
        }

        /********************************************************************************
        * FillOutputCurrencyComboBox()
        *   Fills the InputCurrencyComboBox. This and the previous function should really
        *   be turned into one function in the next version.
        ********************************************************************************/
        private void FillOutputCurrencyComboBox()
        {
            outputCurrencyTypeSelect.Text = "Select Currency Code";
            DataRow dRowTemp;
            for (int i = 0; i < MaxRows; i++)
            {
                dRowTemp = ds.Tables[0].Rows[i];
                outputCurrencyTypeSelect.Items.Add(dRowTemp.ItemArray.GetValue(1).ToString());
            }
        }

        /********************************************************************************
        * SubmitButton_Click()
        *   After the user clicks the submit button, this function sets the variables
        *   that need to be passed into the exchange rate and output exchange amount
        *   calculation. This function also calls the function that calculates the 
        *   output currency amount.
        ********************************************************************************/
        private void SubmitButton_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(inputCurrencyAmountLabel.Text) || inputCurrencyTypeSelect.SelectedItem == null || outputCurrencyTypeSelect.SelectedItem == null)
            {
                MessageBox.Show("Please fill all fields before clicking the submit button");
            }
            else
            {
                //Set variables to be passed into exchange rate calculation
                string inputCurrencyCode = inputCurrencyTypeSelect.SelectedItem.ToString();
                string outputCurrencyCode = outputCurrencyTypeSelect.SelectedItem.ToString();
                decimal inputCurrencyAmount = decimal.Parse(inputCurrencyAmountTextBox.Text);

                //Calculate the output currency amount
                CalculateOuputCurrencyAmount(inputCurrencyCode, outputCurrencyCode, inputCurrencyAmount);
            }
        }

        /********************************************************************************
        * CalculateOuputCurrencyAmount()
        *   Uses the next function to find both exchange rates entered in by the user
        *   Then uses those exchange rates and the input currency amount to calculate
        *   the output currency amount.
        *
        *   TODO: There are a few precision issues here. I need to make the precision
        *   a little higher so it will distinguish between things like the GBP and USD
        ********************************************************************************/
        private void CalculateOuputCurrencyAmount(string inputCurrencyCode, string outputCurrencyCode, decimal inputCurrencyAmount)
        {
            //Find the exchange rates entered in by the user.
            decimal inputExchangeRate = decimal.Parse(findExchangeRate(inputCurrencyCode));
            decimal outputExchangeRate = decimal.Parse(findExchangeRate(outputCurrencyCode));

            //Calculate the output currency amount.
            decimal newAmount = convertToNewCurrency(inputExchangeRate, outputExchangeRate, inputCurrencyAmount);

            //Return the output currency amount.
            outputCurrencyAmountTextBox.Text = newAmount.ToString();
        }

        /********************************************************************************
        * findExchangeRate()
        *   Takes a currency code, opens a connection with the CurrencyConversion 
        *   database, then queries it for an exchange rate. It then returns the first
        *   exchange rate it finds.
        ********************************************************************************/
        private string findExchangeRate(string currencyCode)
        {
            System.Data.SqlClient.SqlConnection tempConnection = new System.Data.SqlClient.SqlConnection(Properties.Settings.Default.CurrenciesConnectionString);
            tempConnection.Open();

            string exchangeRate;

            //Initialize our SqlCommand.
            SqlCommand command = new SqlCommand("SELECT ExchangeRate FROM Currencies WHERE CurrencyCode = \'" + currencyCode + "\'", tempConnection);

            //Set the SqlCommand
            command.CommandText = "SELECT ExchangeRate FROM Currencies WHERE CurrencyCode = \'" + currencyCode + "\'";

            //Execute the SqlCommand
            using (SqlDataReader reader = command.ExecuteReader())
            {
                //Grabs the exchange rates and puts them in a list. 
                var exchangeRateResults = new List<string>();
                while (reader.Read())
                {
                    var myString = reader["ExchangeRate"].ToString();

                    exchangeRateResults.Add(myString);
                }
                //Take the first exchange rate we find. We should only find one anyway. TODO: Optimize this to make sure we only get one result.
                exchangeRate = exchangeRateResults[0];
                reader.Close();
            }
            //TODO: Return an error if nothing is found. The DBA should know if his or her data is corrupt.
            return exchangeRate;
        }
        
        /********************************************************************************
        * convertToNewCurrency()
        *   Takes the inputExchangeRate, outputExchangeRate, and inputCurrencyAmount 
        *   and uses them to return the outputCurrencyAmount.
        ********************************************************************************/
        private decimal convertToNewCurrency(decimal inputExchangeRate, decimal outputExchangeRate, decimal inputCurrencyAmount)
        {
            decimal outputCurrencyAmount = inputCurrencyAmount / inputExchangeRate;
            outputCurrencyAmount *= outputExchangeRate;
            return outputCurrencyAmount;
        }
    }
}
