namespace SqlDatabase
{
    partial class AdminForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            stugradbutton = new Button();
            sturiskbutton = new Button();
            studepcountbutton = new Button();
            InsertButton = new Button();
            StuNoClassButton = new Button();
            panel3 = new Panel();
            instcountbutton = new Button();
            panel2 = new Panel();
            label2 = new Label();
            label1 = new Label();
            Label = new Label();
            valueInput = new TextBox();
            columnInput = new TextBox();
            tableInput = new TextBox();
            searchButton = new Button();
            dataGridView1 = new DataGridView();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(35, 35, 35);
            panel1.Controls.Add(stugradbutton);
            panel1.Controls.Add(sturiskbutton);
            panel1.Controls.Add(studepcountbutton);
            panel1.Controls.Add(InsertButton);
            panel1.Controls.Add(StuNoClassButton);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(instcountbutton);
            panel1.Location = new Point(-6, -16);
            panel1.Name = "panel1";
            panel1.Size = new Size(245, 716);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // stugradbutton
            // 
            stugradbutton.BackColor = Color.FromArgb(60, 60, 60);
            stugradbutton.FlatAppearance.BorderSize = 0;
            stugradbutton.FlatStyle = FlatStyle.Flat;
            stugradbutton.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            stugradbutton.ForeColor = SystemColors.ControlLightLight;
            stugradbutton.Location = new Point(15, 538);
            stugradbutton.Margin = new Padding(0);
            stugradbutton.Name = "stugradbutton";
            stugradbutton.Size = new Size(221, 60);
            stugradbutton.TabIndex = 9;
            stugradbutton.Text = "View Student Graduation Progress";
            stugradbutton.UseVisualStyleBackColor = false;
            stugradbutton.Click += stugradbutton_Click;
            // 
            // sturiskbutton
            // 
            sturiskbutton.BackColor = Color.FromArgb(60, 60, 60);
            sturiskbutton.FlatAppearance.BorderSize = 0;
            sturiskbutton.FlatStyle = FlatStyle.Flat;
            sturiskbutton.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            sturiskbutton.ForeColor = SystemColors.ControlLightLight;
            sturiskbutton.Location = new Point(15, 441);
            sturiskbutton.Margin = new Padding(0);
            sturiskbutton.Name = "sturiskbutton";
            sturiskbutton.Size = new Size(221, 60);
            sturiskbutton.TabIndex = 8;
            sturiskbutton.Text = "View At GPA Risk Students";
            sturiskbutton.UseVisualStyleBackColor = false;
            sturiskbutton.Click += sturiskbutton_Click;
            // 
            // studepcountbutton
            // 
            studepcountbutton.BackColor = Color.FromArgb(60, 60, 60);
            studepcountbutton.FlatAppearance.BorderSize = 0;
            studepcountbutton.FlatStyle = FlatStyle.Flat;
            studepcountbutton.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            studepcountbutton.ForeColor = SystemColors.ControlLightLight;
            studepcountbutton.Location = new Point(15, 345);
            studepcountbutton.Margin = new Padding(0);
            studepcountbutton.Name = "studepcountbutton";
            studepcountbutton.Size = new Size(221, 60);
            studepcountbutton.TabIndex = 7;
            studepcountbutton.Text = "View Student Count Per Department";
            studepcountbutton.UseVisualStyleBackColor = false;
            studepcountbutton.Click += studepcountbutton_Click;
            // 
            // InsertButton
            // 
            InsertButton.BackColor = Color.FromArgb(90, 90, 90);
            InsertButton.FlatAppearance.BorderSize = 0;
            InsertButton.FlatStyle = FlatStyle.Flat;
            InsertButton.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            InsertButton.ForeColor = SystemColors.ControlLightLight;
            InsertButton.Location = new Point(15, 38);
            InsertButton.Margin = new Padding(0);
            InsertButton.Name = "InsertButton";
            InsertButton.Size = new Size(221, 60);
            InsertButton.TabIndex = 6;
            InsertButton.Text = "Insert Value";
            InsertButton.UseVisualStyleBackColor = false;
            InsertButton.Click += InsertButton_Click;
            // 
            // StuNoClassButton
            // 
            StuNoClassButton.BackColor = Color.FromArgb(60, 60, 60);
            StuNoClassButton.FlatAppearance.BorderSize = 0;
            StuNoClassButton.FlatStyle = FlatStyle.Flat;
            StuNoClassButton.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            StuNoClassButton.ForeColor = SystemColors.ControlLightLight;
            StuNoClassButton.Location = new Point(15, 248);
            StuNoClassButton.Margin = new Padding(0);
            StuNoClassButton.Name = "StuNoClassButton";
            StuNoClassButton.Size = new Size(221, 60);
            StuNoClassButton.TabIndex = 5;
            StuNoClassButton.Text = "View Students With No Classes";
            StuNoClassButton.UseVisualStyleBackColor = false;
            StuNoClassButton.Click += StuNoClassButton_Click;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Silver;
            panel3.Location = new Point(34, 123);
            panel3.Name = "panel3";
            panel3.Size = new Size(180, 1);
            panel3.TabIndex = 4;
            // 
            // instcountbutton
            // 
            instcountbutton.BackColor = Color.FromArgb(60, 60, 60);
            instcountbutton.FlatAppearance.BorderSize = 0;
            instcountbutton.FlatStyle = FlatStyle.Flat;
            instcountbutton.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            instcountbutton.ForeColor = SystemColors.ControlLightLight;
            instcountbutton.Location = new Point(15, 151);
            instcountbutton.Margin = new Padding(0);
            instcountbutton.Name = "instcountbutton";
            instcountbutton.Size = new Size(221, 60);
            instcountbutton.TabIndex = 0;
            instcountbutton.Text = "View Instructor's Course Counts";
            instcountbutton.UseVisualStyleBackColor = false;
            instcountbutton.Click += ViewInstructorCourses_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(50, 50, 50);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(Label);
            panel2.Controls.Add(valueInput);
            panel2.Controls.Add(columnInput);
            panel2.Controls.Add(tableInput);
            panel2.Controls.Add(searchButton);
            panel2.Location = new Point(239, -13);
            panel2.Name = "panel2";
            panel2.Size = new Size(1087, 121);
            panel2.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Verdana", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.Control;
            label2.Location = new Point(613, 35);
            label2.Name = "label2";
            label2.Size = new Size(67, 22);
            label2.TabIndex = 12;
            label2.Text = "Value";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Verdana", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(356, 35);
            label1.Name = "label1";
            label1.Size = new Size(86, 22);
            label1.TabIndex = 11;
            label1.Text = "Column";
            // 
            // Label
            // 
            Label.AutoSize = true;
            Label.Font = new Font("Verdana", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Label.ForeColor = SystemColors.Control;
            Label.Location = new Point(112, 35);
            Label.Name = "Label";
            Label.Size = new Size(65, 22);
            Label.TabIndex = 10;
            Label.Text = "Table";
            // 
            // valueInput
            // 
            valueInput.BackColor = Color.FromArgb(60, 60, 60);
            valueInput.BorderStyle = BorderStyle.FixedSingle;
            valueInput.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            valueInput.ForeColor = SystemColors.Control;
            valueInput.Location = new Point(540, 68);
            valueInput.Name = "valueInput";
            valueInput.Size = new Size(224, 26);
            valueInput.TabIndex = 9;
            // 
            // columnInput
            // 
            columnInput.BackColor = Color.FromArgb(60, 60, 60);
            columnInput.BorderStyle = BorderStyle.FixedSingle;
            columnInput.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            columnInput.ForeColor = SystemColors.Control;
            columnInput.Location = new Point(286, 68);
            columnInput.Name = "columnInput";
            columnInput.Size = new Size(224, 26);
            columnInput.TabIndex = 8;
            // 
            // tableInput
            // 
            tableInput.BackColor = Color.FromArgb(60, 60, 60);
            tableInput.BorderStyle = BorderStyle.FixedSingle;
            tableInput.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tableInput.ForeColor = SystemColors.Control;
            tableInput.Location = new Point(31, 68);
            tableInput.Name = "tableInput";
            tableInput.Size = new Size(224, 26);
            tableInput.TabIndex = 7;
            // 
            // searchButton
            // 
            searchButton.BackColor = Color.FromArgb(90, 90, 90);
            searchButton.FlatAppearance.BorderSize = 0;
            searchButton.FlatStyle = FlatStyle.Flat;
            searchButton.Font = new Font("Verdana", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            searchButton.ForeColor = SystemColors.ControlLightLight;
            searchButton.Location = new Point(788, 35);
            searchButton.Margin = new Padding(0);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(221, 60);
            searchButton.TabIndex = 6;
            searchButton.Text = "Search";
            searchButton.UseVisualStyleBackColor = false;
            searchButton.Click += searchButton_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(245, 114);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1010, 490);
            dataGridView1.TabIndex = 2;
            // 
            // AdminForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(18, 18, 18);
            ClientSize = new Size(1266, 609);
            Controls.Add(dataGridView1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            ForeColor = SystemColors.ActiveCaptionText;
            FormBorderStyle = FormBorderStyle.None;
            Name = "AdminForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Admin Panel";
            Load += AdminForm_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button instcountbutton;
        private Panel panel2;
        private Panel panel3;
        private Button StuNoClassButton;
        private Button searchButton;
        private Button InsertButton;
        private Button stugradbutton;
        private Button sturiskbutton;
        private Button studepcountbutton;
        private TextBox valueInput;
        private TextBox columnInput;
        private TextBox tableInput;
        private Label Label;
        private Label label2;
        private Label label1;
        private DataGridView dataGridView1;
    }
}