using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SqlDatabase
{
    public partial class AdminForm : Form
    {
        private string connectionString = "server=localhost;user=root;database=university;port=3306;password=;";
        MySqlDataAdapter adapter;
        DataTable dataTable;
        string currentTableName;

        private void StyleDataGridViewDark()
        {
            var grid = dataGridView1;

            // General dark background
            grid.BorderStyle = BorderStyle.None;
            grid.BackgroundColor = Color.FromArgb(30, 30, 30);
            grid.DefaultCellStyle.BackColor = Color.FromArgb(45, 45, 48);
            grid.DefaultCellStyle.ForeColor = Color.White;
            grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(75, 110, 175);
            grid.DefaultCellStyle.SelectionForeColor = Color.White;

            // Alternating row color for contrast
            grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(40, 40, 40);

            // Header styling
            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 122, 204);
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            // Row and column behavior
            grid.RowHeadersVisible = false;
            grid.ReadOnly = true;
            grid.AllowUserToDeleteRows = false;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToOrderColumns = false;
            grid.RowTemplate.Height = 30;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToResizeRows = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.GridColor = Color.DimGray;
            grid.DefaultCellStyle.Font = new Font("Segoe UI", 10);
        }

        public AdminForm()
        {
            InitializeComponent();
            StyleDataGridViewDark();
        }


        private void AdminForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ViewInstructorCourses_Click(object sender, EventArgs e)
        {
            string query = @"
                 SELECT  
                      CONCAT(Instructor.FirstName, ' ', Instructor.LastName) AS InstructorName, 
                      COUNT(Section.SectionID) AS CoursesTaught 
                    FROM Instructor 
                    JOIN Section ON Instructor.InstructorID = Section.InstructorID 
                    GROUP BY Instructor.InstructorID 
                 ORDER BY CoursesTaught DESC;
             ";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                { // connect to database, use query, simple stuff for every button
                    conn.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable resultTable = new DataTable();
                    adapter.Fill(resultTable);
                    dataGridView1.DataSource = resultTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data:\n" + ex.Message);
            }
        }

        private void StuNoClassButton_Click(object sender, EventArgs e)
        {
            string query = @"
                SELECT Student.StudentID, Student.FirstName, Student.LastName 
                FROM Student 
                LEFT JOIN Enrollment ON Student.StudentID = Enrollment.StudentID 
                WHERE Enrollment.StudentID IS NULL; 
             ";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable resultTable = new DataTable();
                    adapter.Fill(resultTable);
                    dataGridView1.DataSource = resultTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data:\n" + ex.Message);
            }
        }

        private void studepcountbutton_Click(object sender, EventArgs e)
        {
            string query = @"
                 SELECT Department.Name, COUNT(Student.StudentID) AS StudentCount 
                 FROM Department 
                 JOIN Student ON Student.MajorDeptID = Department.DeptID 
                 GROUP BY Department.DeptID 
                 ORDER BY StudentCount DESC; 
             ";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable resultTable = new DataTable();
                    adapter.Fill(resultTable);
                    dataGridView1.DataSource = resultTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data:\n" + ex.Message);
            }
        }

        private void sturiskbutton_Click(object sender, EventArgs e)
        {
            string query = @"
                 SELECT s.StudentID,  CONCAT(s.FirstName,' ',s.LastName) AS StudentName, 
                 ROUND(SUM( 
                     CASE e.Grade 
                       WHEN 'A'  THEN 4.00 
                       WHEN 'A-' THEN 3.70 
                       WHEN 'B+' THEN 3.30 
                       WHEN 'B'  THEN 3.00 
                       WHEN 'B-' THEN 2.70 
                       WHEN 'C+' THEN 2.30 
                       WHEN 'C'  THEN 2.00 
                       WHEN 'C-' THEN 1.70 
                       WHEN 'D'  THEN 1.00 
                       WHEN 'F'  THEN 0.00 
                     END 
                   ) / COUNT(e.Grade), 
                   2 
                 ) AS GPA 
                FROM Student AS s 
                JOIN Enrollment AS e ON e.StudentID = s.StudentID 
                GROUP BY s.StudentID 
                HAVING GPA < 2.0; 
             ";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable resultTable = new DataTable();
                    adapter.Fill(resultTable);
                    dataGridView1.DataSource = resultTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data:\n" + ex.Message);
            }
        }

        private void stugradbutton_Click(object sender, EventArgs e)
        {
            string query = @"
                 SELECT
                    s.StudentID,
                    CONCAT(s.FirstName, ' ', s.LastName) AS StudentName,
                    p.Name AS Program,
                    d.Name AS Department,
                    COUNT(DISTINCT e.SectionID) AS CoursesCompleted,
                    SUM(c.Credits) AS CreditsEarned,
                    (SELECT SUM(Credits) FROM Course WHERE DeptID = s.MajorDeptID) AS RequiredCredits,
                    CONCAT(ROUND(SUM(c.Credits) / 
                          (SELECT SUM(Credits) FROM Course WHERE DeptID = s.MajorDeptID) * 100, 1), 
                          '%') AS ProgPercentage
                FROM Student s
                JOIN Program p ON s.ProgramID = p.ProgramID
                JOIN Department d ON s.MajorDeptID = d.DeptID
                JOIN Enrollment e ON s.StudentID = e.StudentID
                JOIN Section sec ON e.SectionID = sec.SectionID
                JOIN Course c ON sec.Course = c.CRN
                WHERE e.Grade IS NOT NULL AND e.Grade != 'F'
                GROUP BY s.StudentID, StudentName, Program, Department
                ORDER BY ProgPercentage DESC; 
             ";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable resultTable = new DataTable();
                    adapter.Fill(resultTable);
                    dataGridView1.DataSource = resultTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data:\n" + ex.Message);
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            string tableName = tableInput.Text.Trim();
            string columnName = columnInput.Text.Trim();
            string searchValue = valueInput.Text.Trim();

            // Check if the table name is provided
            if (string.IsNullOrEmpty(tableName))
            {
                MessageBox.Show("Table name cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Create the command to call the stored procedure
                    using (MySqlCommand cmd = new MySqlCommand("SearchByValue", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Add parameters for the stored procedure
                        cmd.Parameters.AddWithValue("@in_table_name", tableName);
                        cmd.Parameters.AddWithValue("@in_column_name", columnName);
                        cmd.Parameters.AddWithValue("@in_search_value", searchValue);

                        // Create an adapter to fill the DataGridView
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        DataTable resultTable = new DataTable();
                        adapter.Fill(resultTable);

                        // If no results are found, show an error
                        if (resultTable.Rows.Count == 0)
                        {
                            MessageBox.Show("No results found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            dataGridView1.DataSource = resultTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error executing search:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        // Made this a function as the next was getting too long
        private void ShowInsertForm(string tableName, List<string> columns)
        {
            // build window format
            Form insertForm = new Form()
            {
                Text = $"Insert into {tableName}",
                BackColor = Color.FromArgb(30, 30, 30),
                ForeColor = Color.White,
                Size = new Size(400, 650),
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterScreen
            };
            // Ensures that rows dont overflow to catch that one potential bug
            var panel = new FlowLayoutPanel()
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                Padding = new Padding(10)
            };
            // columns
            Dictionary<string, TextBox> inputs = new Dictionary<string, TextBox>();

            foreach (var col in columns)
            {
                var label = new Label()
                {
                    Text = col,
                    ForeColor = Color.White,
                    Width = 300
                };
                var textbox = new TextBox()
                {
                    Width = 300,
                    BackColor = Color.FromArgb(45, 45, 45),
                    ForeColor = Color.White
                };

                panel.Controls.Add(label);
                panel.Controls.Add(textbox);
                inputs[col] = textbox;
            }
            // final insert button
            var submit = new Button()
            {
                Text = "Insert",
                Width = 100,
                BackColor = Color.FromArgb(60, 60, 60),
                ForeColor = Color.White
            };
            submit.Click += (s, e) =>
            { // time to actually insert finally
                try
                {
                    using (var conn = new MySqlConnection(connectionString))
                    {
                        conn.Open();
                        var columnList = string.Join(", ", inputs.Keys.Select(k => $"`{k}`")); // gonna be real, took this off stack overflow
                        var valueList = string.Join(", ", inputs.Keys.Select(k => $"@{k}"));

                        string insertSql = $"INSERT INTO `{tableName}` ({columnList}) VALUES ({valueList})";

                        var cmd = new MySqlCommand(insertSql, conn);

                        foreach (var pair in inputs)
                        {
                            cmd.Parameters.AddWithValue($"@{pair.Key}", pair.Value.Text);
                        }

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Data inserted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        insertForm.Close();
                    }
                }
                catch (Exception ex) 
                { 
                    MessageBox.Show("Insert failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            panel.Controls.Add(submit);
            insertForm.Controls.Add(panel);
            insertForm.ShowDialog();
        }

        // nightmare nightmare nightmare NIGHTMARE, i thought itd be fun to dynamically have more input boxes so that all you had to do was
        // insert a table name but oH GOD DAMN was this a rabbit hole to go down. I barely knew how this managed to work at the time
        // and now it is a mystery to all. TODO delete this message before submission
        private void InsertButton_Click(object sender, EventArgs e)
        {
            string tableName = Prompt.ShowDialog("Enter table name:", "Insert Into Table");

            if (string.IsNullOrEmpty(tableName))
                return;

            // Verify table exists
            using (var conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    var cmd = new MySqlCommand($"SHOW TABLES LIKE @table", conn);
                    cmd.Parameters.AddWithValue("@table", tableName);
                    var result = cmd.ExecuteScalar();
                    // confirm existing values
                    if (result == null)
                    {
                        MessageBox.Show("Table does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Get column names, ensure they survive
                    cmd = new MySqlCommand($"DESCRIBE `{tableName}`", conn);
                    var reader = cmd.ExecuteReader();

                    List<string> columns = new List<string>();
                    while (reader.Read())
                    {
                        string columnName = reader.GetString("Field");
                        string extra = reader.GetString("Extra");
                        if (!extra.ToLower().Contains("auto_increment")) // this little line took over an hour of debugging :D
                            columns.Add(columnName);
                    }

                    reader.Close();

                    ShowInsertForm(tableName, columns);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

    public static class Prompt
    {
        public static string ShowDialog(string text, string caption)
        {
            // Center form and auto sizeee 
            Form prompt = new Form()
            {
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen,
                AutoSize = true, // Potential error point?? if theres too many columns it may be wider than the screen
                AutoSizeMode = AutoSizeMode.GrowAndShrink, 
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                BackColor = Color.FromArgb(30, 30, 30),
                ForeColor = Color.White
            };

            // Fancy auto-sizing layout container so I dont have to literally count pixels
            var layout = new TableLayoutPanel()
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(10), // IMPORTANT or else theres no SPACING
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink
            };

            // column names
            Label textLabel = new Label()
            {
                Text = text,
                ForeColor = Color.White,
                AutoSize = true,
                Anchor = AnchorStyles.Left // Center?? Maybe?? 
            };

            // Inputs for the names whatever
            TextBox inputBox = new TextBox()
            {
                Width = 300, 
                BackColor = Color.FromArgb(45, 45, 45),
                ForeColor = Color.White,
                Anchor = AnchorStyles.Left
            };

            // Simple confirmation button,worked firsttry 
            Button confirmation = new Button()
            {
                Text = "OK",
                DialogResult = DialogResult.OK,
                Anchor = AnchorStyles.Right,
                BackColor = Color.FromArgb(60, 60, 60),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat 
            };

            // panels
            layout.Controls.Add(textLabel, 0, 0);
            layout.Controls.Add(inputBox, 0, 1);
            layout.Controls.Add(confirmation, 0, 2);

            // panel toform
            prompt.Controls.Add(layout);
            prompt.AcceptButton = confirmation;

            // give result
            var result = prompt.ShowDialog();
            return result == DialogResult.OK ? inputBox.Text : "";
        }
    }


}
