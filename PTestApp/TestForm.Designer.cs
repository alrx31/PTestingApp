namespace PTestApp
{
    partial class TestForm
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
            QuestionLabel = new Label();
            NextButton = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // QuestionLabel
            // 
            QuestionLabel.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            QuestionLabel.ForeColor = SystemColors.ActiveCaptionText;
            QuestionLabel.Location = new Point(24, 9);
            QuestionLabel.Name = "QuestionLabel";
            QuestionLabel.Size = new Size(764, 93);
            QuestionLabel.TabIndex = 0;
            QuestionLabel.Text = "label1";
            // 
            // NextButton
            // 
            NextButton.Location = new Point(466, 388);
            NextButton.Name = "NextButton";
            NextButton.Size = new Size(284, 38);
            NextButton.TabIndex = 1;
            NextButton.Text = "Next";
            NextButton.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Location = new Point(24, 120);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(764, 251);
            flowLayoutPanel1.TabIndex = 3;
            // 
            // TestForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(NextButton);
            Controls.Add(QuestionLabel);
            Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            Name = "TestForm";
            Text = "TestForm";
            Load += TestForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Label QuestionLabel;
        private Button NextButton;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}