using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SqlDatabase
{
    public partial class UserForm : Form
    {
        private string connectionString = "server=localhost;user=root;database=university;port=3306;password=;";

        public UserForm()
        {
            InitializeComponent();
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            string studentId = idInput.Text.Trim();

            if (string.IsNullOrEmpty(studentId))
            {
                MessageBox.Show("Please enter a valid student ID.");
                return;
            }

            // Check if student exists
            if (CheckIfStudentExists(studentId))
            {
                // Create and show the student info form
                ShowStudentClasses(studentId);
            }
            else
            {
                MessageBox.Show("Student ID not found.");
            }
        }

        private bool CheckIfStudentExists(string studentId)
        {
            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = $"SELECT COUNT(*) FROM Student WHERE StudentID = @StudentID";
                    var cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@StudentID", studentId);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking student: " + ex.Message);
                return false;
            }
        }

        private void ShowStudentClasses(string studentId)
        {
            Form studentInfoForm = new Form()
            {
                Text = "Student Information",
                BackColor = Color.FromArgb(30, 30, 30),
                ForeColor = Color.White,
                Width = 550,  // Adjusted width for the panel
                Height = 450, // Adjusted height for the panel
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterScreen
            };

            var panel = new FlowLayoutPanel()
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                Padding = new Padding(10)
            };

            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                    SELECT c.Title, d.Name AS Department, r.RoomID AS Building, i.FirstName AS Professor
                    FROM Enrollment e
                    JOIN Section s ON e.SectionID = s.SectionID
                    JOIN Course c ON s.Course = c.CRN
                    JOIN Department d ON c.DeptID = d.DeptID
                    JOIN Room r ON s.RoomID = r.RoomID
                    JOIN Instructor i ON s.InstructorID = i.InstructorID
                    WHERE e.StudentID = @StudentID";

                    var cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@StudentID", studentId);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        // Create the table layout for this specific class
                        var classInfoPanel = new TableLayoutPanel()
                        {
                            RowCount = 4,  // 4 rows for course, department, building, and professor
                            ColumnCount = 2,
                            Dock = DockStyle.Top,
                            Height = 120,
                            Width = 500,
                            AutoSize = true,
                            Margin = new Padding(0, 0, 0, 10)
                        };

                        // Create and style the labels
                        var courseText = new Label()
                        {
                            Text = $"Course: {reader["Title"]}",
                            Font = new Font("Arial", 12, FontStyle.Bold),
                            ForeColor = Color.LightBlue,
                            AutoSize = true,
                            Padding = new Padding(5)
                        };

                        var departmentText = new Label()
                        {
                            Text = $"Department: {reader["Department"]}",
                            Font = new Font("Arial", 10, FontStyle.Regular),
                            ForeColor = Color.White,
                            AutoSize = true,
                            Padding = new Padding(5)
                        };

                        var buildingText = new Label()
                        {
                            Text = $"Building: {reader["Building"]}",
                            Font = new Font("Arial", 10, FontStyle.Regular),
                            ForeColor = Color.White,
                            AutoSize = true,
                            Padding = new Padding(5)
                        };

                        var professorText = new Label()
                        {
                            Text = $"Professor: {reader["Professor"]}",
                            Font = new Font("Arial", 10, FontStyle.Regular),
                            ForeColor = Color.White,
                            AutoSize = true,
                            Padding = new Padding(5)
                        };

                        // Add labels to the table layout
                        classInfoPanel.Controls.Add(new Label() { Text = "Course:", Font = new Font("Arial", 10, FontStyle.Bold), ForeColor = Color.White });
                        classInfoPanel.Controls.Add(courseText);

                        classInfoPanel.Controls.Add(new Label() { Text = "Department:", Font = new Font("Arial", 10, FontStyle.Bold), ForeColor = Color.White });
                        classInfoPanel.Controls.Add(departmentText);

                        classInfoPanel.Controls.Add(new Label() { Text = "Building:", Font = new Font("Arial", 10, FontStyle.Bold), ForeColor = Color.White });
                        classInfoPanel.Controls.Add(buildingText);

                        classInfoPanel.Controls.Add(new Label() { Text = "Professor:", Font = new Font("Arial", 10, FontStyle.Bold), ForeColor = Color.White });
                        classInfoPanel.Controls.Add(professorText);

                        // Add the panel with class info to the flow layout panel
                        panel.Controls.Add(classInfoPanel);

                        // Add separator line (solid line) between class entries
                        var separatorPanel = new Panel()
                        {
                            Height = 2,  // Thickness of the separator line
                            Dock = DockStyle.Top,
                            BackColor = Color.Gray,  // Color of the separator line
                            Margin = new Padding(0, 10, 0, 10)  // Space between entries
                        };
                        panel.Controls.Add(separatorPanel); // Add the separator after the class info
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading classes: " + ex.Message);
            }

            studentInfoForm.Controls.Add(panel);
            studentInfoForm.ShowDialog();
        }

    }
}
