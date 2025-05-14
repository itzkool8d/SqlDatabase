using MySql.Data.MySqlClient;
using System.Data;

namespace SqlDatabase
{
    public partial class OwnerForm : Form
    {
        private string connectionString = "server=localhost;user=root;database=university;port=3306;password=;";
        MySqlDataAdapter adapter;
        DataTable dataTable;
        string currentTableName;
        private void StyleDataGridView()
        {
            var grid = TableDataOne;

            // General styling
            grid.BorderStyle = BorderStyle.None;
            grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            grid.DefaultCellStyle.SelectionBackColor = Color.DarkSlateBlue;
            grid.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            grid.BackgroundColor = Color.White;

            // Header style
            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // Font
            grid.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            // Row style
            grid.RowTemplate.Height = 30;
            grid.AllowUserToAddRows = false; // optional for a cleaner look
            grid.AllowUserToResizeRows = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        public OwnerForm()
        {
            InitializeComponent();
            StyleDataGridView();
        }

        private void LoadTableButton_Click(object sender, EventArgs e)
        {
            string tableName = TableOneInput.Text.Trim();

            if (string.IsNullOrEmpty(tableName))
            {
                MessageBox.Show("Please enter a table name.");
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = $"SELECT * FROM `{tableName}`";
                    adapter = new MySqlDataAdapter(query, conn);
                    MySqlCommandBuilder builder = new MySqlCommandBuilder(adapter);

                    dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    TableDataOne.DataSource = dataTable;

                    currentTableName = tableName; // Save current table name
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load table:\n" + ex.Message);
            }
        }

        private void SaveTableChangesButton_Click(object sender, EventArgs e)
        {
            if (adapter == null || dataTable == null)
            {
                MessageBox.Show("No table loaded.");
                return;
            }

            var result = MessageBox.Show(
                "Are you sure you want to save the changes to the database?",
                "Confirm Save",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result != DialogResult.Yes)
                return;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Re-attach the adapter to the connection and use a command builder
                    adapter.SelectCommand.Connection = conn;
                    MySqlCommandBuilder builder = new MySqlCommandBuilder(adapter);

                    builder.QuotePrefix = "`";
                    builder.QuoteSuffix = "`";
                    adapter.UpdateCommand = builder.GetUpdateCommand();
                    adapter.InsertCommand = builder.GetInsertCommand();
                    adapter.DeleteCommand = builder.GetDeleteCommand();

                    TableDataOne.EndEdit();
                    adapter.Update(dataTable);
                    MessageBox.Show("Changes saved successfully.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to save changes:\n" + ex.Message);
            }
        }

        private void RunQueryButton_Click(object sender, EventArgs e)
        {
            string query = CustomQueryInput.Text.Trim();

            if (string.IsNullOrEmpty(query))
            {
                MessageBox.Show("Please enter a SQL query.");
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    if (query.StartsWith("SELECT", StringComparison.OrdinalIgnoreCase) ||
                        query.StartsWith("SHOW", StringComparison.OrdinalIgnoreCase) ||
                        query.StartsWith("DESC", StringComparison.OrdinalIgnoreCase))
                    {
                        MySqlDataAdapter customAdapter = new MySqlDataAdapter(query, conn);
                        DataTable resultTable = new DataTable();
                        customAdapter.Fill(resultTable);
                        TableDataOne.DataSource = resultTable;
                        MessageBox.Show("Query executed and results loaded.");
                    }
                    else
                    {
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        int affectedRows = cmd.ExecuteNonQuery();
                        MessageBox.Show($"Query executed successfully. Rows affected: {affectedRows}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error executing query:\n" + ex.Message);
            }
        }

        private void TableDataOne_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
