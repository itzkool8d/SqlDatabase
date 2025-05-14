namespace SqlDatabase
{
    partial class UserForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserForm));
            pictureBox1 = new PictureBox();
            Label = new Label();
            idInput = new TextBox();
            confirmButton = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(68, 30);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(117, 110);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // Label
            // 
            Label.AutoSize = true;
            Label.Font = new Font("Verdana", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Label.ForeColor = SystemColors.Control;
            Label.Location = new Point(36, 212);
            Label.Name = "Label";
            Label.Size = new Size(181, 22);
            Label.TabIndex = 11;
            Label.Text = "Enter Student ID";
            // 
            // idInput
            // 
            idInput.BackColor = Color.FromArgb(60, 60, 60);
            idInput.BorderStyle = BorderStyle.FixedSingle;
            idInput.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            idInput.ForeColor = SystemColors.Control;
            idInput.Location = new Point(12, 256);
            idInput.Name = "idInput";
            idInput.Size = new Size(224, 26);
            idInput.TabIndex = 12;
            // 
            // confirmButton
            // 
            confirmButton.BackColor = Color.FromArgb(90, 90, 90);
            confirmButton.FlatAppearance.BorderSize = 0;
            confirmButton.FlatStyle = FlatStyle.Flat;
            confirmButton.Font = new Font("Verdana", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            confirmButton.ForeColor = SystemColors.ControlLightLight;
            confirmButton.Location = new Point(15, 328);
            confirmButton.Margin = new Padding(0);
            confirmButton.Name = "confirmButton";
            confirmButton.Size = new Size(221, 60);
            confirmButton.TabIndex = 13;
            confirmButton.Text = "Confirm";
            confirmButton.UseVisualStyleBackColor = false;
            confirmButton.Click += this.confirmButton_Click;
            // 
            // UserForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(20, 20, 20);
            ClientSize = new Size(254, 441);
            Controls.Add(confirmButton);
            Controls.Add(idInput);
            Controls.Add(Label);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "UserForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label Label;
        private TextBox idInput;
        private Button confirmButton;
    }
}