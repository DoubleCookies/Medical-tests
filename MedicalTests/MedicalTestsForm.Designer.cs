
namespace MedicalTests
{
    partial class MedicalTestsForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxStartQuestionNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonOpenFormatFolder = new System.Windows.Forms.Button();
            this.comboBoxFormat = new System.Windows.Forms.ComboBox();
            this.buttonProcess = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxStartQuestionNumber
            // 
            this.textBoxStartQuestionNumber.Location = new System.Drawing.Point(242, 162);
            this.textBoxStartQuestionNumber.Name = "textBoxStartQuestionNumber";
            this.textBoxStartQuestionNumber.Size = new System.Drawing.Size(144, 22);
            this.textBoxStartQuestionNumber.TabIndex = 1;
            this.textBoxStartQuestionNumber.Text = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(73, 165);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Start question number";
            // 
            // buttonOpenFormatFolder
            // 
            this.buttonOpenFormatFolder.Location = new System.Drawing.Point(76, 95);
            this.buttonOpenFormatFolder.Name = "buttonOpenFormatFolder";
            this.buttonOpenFormatFolder.Size = new System.Drawing.Size(145, 40);
            this.buttonOpenFormatFolder.TabIndex = 6;
            this.buttonOpenFormatFolder.Text = "Open Format Folder";
            this.buttonOpenFormatFolder.UseVisualStyleBackColor = true;
            this.buttonOpenFormatFolder.Click += new System.EventHandler(this.buttonOpenFormatFolder_Click);
            // 
            // comboBoxFormat
            // 
            this.comboBoxFormat.FormattingEnabled = true;
            this.comboBoxFormat.Items.AddRange(new object[] {
            "Format1",
            "Format2",
            "Format3"});
            this.comboBoxFormat.Location = new System.Drawing.Point(76, 38);
            this.comboBoxFormat.Name = "comboBoxFormat";
            this.comboBoxFormat.Size = new System.Drawing.Size(145, 24);
            this.comboBoxFormat.TabIndex = 7;
            // 
            // buttonProcess
            // 
            this.buttonProcess.Location = new System.Drawing.Point(242, 29);
            this.buttonProcess.Name = "buttonProcess";
            this.buttonProcess.Size = new System.Drawing.Size(144, 40);
            this.buttonProcess.TabIndex = 8;
            this.buttonProcess.Text = "Process";
            this.buttonProcess.UseVisualStyleBackColor = true;
            this.buttonProcess.Click += new System.EventHandler(this.buttonProcess_Click);
            // 
            // MedicalTestsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 216);
            this.Controls.Add(this.buttonProcess);
            this.Controls.Add(this.comboBoxFormat);
            this.Controls.Add(this.buttonOpenFormatFolder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxStartQuestionNumber);
            this.Name = "MedicalTestsForm";
            this.Text = "MedicalTests";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxStartQuestionNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonOpenFormatFolder;
        private System.Windows.Forms.ComboBox comboBoxFormat;
        private System.Windows.Forms.Button buttonProcess;
    }
}

