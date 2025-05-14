namespace SqlDatabase
{
    partial class OwnerForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            LoadTableButton = new Button();
            TableDataOne = new DataGridView();
            TableOneInput = new TextBox();
            label1 = new Label();
            SaveTableChangesButton = new Button();
            CustomQueryInput = new TextBox();
            RunQueryButton = new Button();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)TableDataOne).BeginInit();
            SuspendLayout();
            // 
            // LoadTableButton
            // 
            LoadTableButton.Location = new Point(12, 106);
            LoadTableButton.Name = "LoadTableButton";
            LoadTableButton.Size = new Size(145, 42);
            LoadTableButton.TabIndex = 0;
            LoadTableButton.Text = "Load Table";
            LoadTableButton.UseVisualStyleBackColor = true;
            LoadTableButton.Click += LoadTableButton_Click;
            // 
            // TableDataOne
            // 
            TableDataOne.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            TableDataOne.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            TableDataOne.Location = new Point(12, 189);
            TableDataOne.Name = "TableDataOne";
            TableDataOne.RowHeadersWidth = 51;
            TableDataOne.Size = new Size(1318, 324);
            TableDataOne.TabIndex = 1;
            TableDataOne.CellContentClick += TableDataOne_CellContentClick;
            // 
            // TableOneInput
            // 
            TableOneInput.Location = new Point(88, 60);
            TableOneInput.Name = "TableOneInput";
            TableOneInput.Size = new Size(158, 27);
            TableOneInput.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(79, 7);
            label1.Name = "label1";
            label1.Size = new Size(181, 41);
            label1.TabIndex = 3;
            label1.Text = "Table Name:";
            // 
            // SaveTableChangesButton
            // 
            SaveTableChangesButton.Location = new Point(176, 106);
            SaveTableChangesButton.Name = "SaveTableChangesButton";
            SaveTableChangesButton.Size = new Size(145, 42);
            SaveTableChangesButton.TabIndex = 4;
            SaveTableChangesButton.Text = "Commit Changes";
            SaveTableChangesButton.UseVisualStyleBackColor = true;
            SaveTableChangesButton.Click += SaveTableChangesButton_Click;
            // 
            // CustomQueryInput
            // 
            CustomQueryInput.Location = new Point(346, 60);
            CustomQueryInput.Name = "CustomQueryInput";
            CustomQueryInput.Size = new Size(984, 27);
            CustomQueryInput.TabIndex = 5;
            // 
            // RunQueryButton
            // 
            RunQueryButton.Location = new Point(785, 106);
            RunQueryButton.Name = "RunQueryButton";
            RunQueryButton.Size = new Size(145, 42);
            RunQueryButton.TabIndex = 6;
            RunQueryButton.Text = "Execute Query";
            RunQueryButton.UseVisualStyleBackColor = true;
            RunQueryButton.Click += RunQueryButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(739, 7);
            label2.Name = "label2";
            label2.Size = new Size(248, 41);
            label2.TabIndex = 7;
            label2.Text = "Query To Execute";
            // 
            // OwnerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1342, 525);
            Controls.Add(label2);
            Controls.Add(RunQueryButton);
            Controls.Add(CustomQueryInput);
            Controls.Add(SaveTableChangesButton);
            Controls.Add(label1);
            Controls.Add(TableOneInput);
            Controls.Add(TableDataOne);
            Controls.Add(LoadTableButton);
            Name = "OwnerForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = " Owner Panel";
            ((System.ComponentModel.ISupportInitialize)TableDataOne).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button LoadTableButton;
        private DataGridView TableDataOne;
        private TextBox TableOneInput;
        private Label label1;
        private Button SaveTableChangesButton;
        private TextBox CustomQueryInput;
        private Button RunQueryButton;
        private Label label2;
    }
}
