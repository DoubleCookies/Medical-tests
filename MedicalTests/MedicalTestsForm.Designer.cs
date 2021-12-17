
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
            this.buttomProcessFormat1 = new System.Windows.Forms.Button();
            this.textBoxStartQuestionNumber = new System.Windows.Forms.TextBox();
            this.buttomProcessFormat2 = new System.Windows.Forms.Button();
            this.buttomProcessFormat4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttomProcessFormat1
            // 
            this.buttomProcessFormat1.Location = new System.Drawing.Point(131, 21);
            this.buttomProcessFormat1.Name = "buttomProcessFormat1";
            this.buttomProcessFormat1.Size = new System.Drawing.Size(191, 40);
            this.buttomProcessFormat1.TabIndex = 0;
            this.buttomProcessFormat1.Text = "Process Format1";
            this.buttomProcessFormat1.UseVisualStyleBackColor = true;
            this.buttomProcessFormat1.Click += new System.EventHandler(this.ButtonProcessFormat1_Click);
            // 
            // textBoxStartQuestionNumber
            // 
            this.textBoxStartQuestionNumber.Location = new System.Drawing.Point(242, 184);
            this.textBoxStartQuestionNumber.Name = "textBoxStartQuestionNumber";
            this.textBoxStartQuestionNumber.Size = new System.Drawing.Size(144, 22);
            this.textBoxStartQuestionNumber.TabIndex = 1;
            this.textBoxStartQuestionNumber.Text = "1";
            // 
            // buttomProcessFormat2
            // 
            this.buttomProcessFormat2.Location = new System.Drawing.Point(131, 67);
            this.buttomProcessFormat2.Name = "buttomProcessFormat2";
            this.buttomProcessFormat2.Size = new System.Drawing.Size(191, 40);
            this.buttomProcessFormat2.TabIndex = 3;
            this.buttomProcessFormat2.Text = "Process Format2";
            this.buttomProcessFormat2.UseVisualStyleBackColor = true;
            this.buttomProcessFormat2.Click += new System.EventHandler(this.ButtonProcessFormat2_Click);
            // 
            // buttomProcessFormat4
            // 
            this.buttomProcessFormat4.Location = new System.Drawing.Point(131, 113);
            this.buttomProcessFormat4.Name = "buttomProcessFormat4";
            this.buttomProcessFormat4.Size = new System.Drawing.Size(191, 40);
            this.buttomProcessFormat4.TabIndex = 4;
            this.buttomProcessFormat4.Text = "Process Format3";
            this.buttomProcessFormat4.UseVisualStyleBackColor = true;
            this.buttomProcessFormat4.Click += new System.EventHandler(this.ButtonProcessFormat3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(73, 187);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Start question number";
            // 
            // MedicalTestsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 228);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttomProcessFormat4);
            this.Controls.Add(this.buttomProcessFormat2);
            this.Controls.Add(this.textBoxStartQuestionNumber);
            this.Controls.Add(this.buttomProcessFormat1);
            this.Name = "MedicalTestsForm";
            this.Text = "MedicalTests";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttomProcessFormat1;
        private System.Windows.Forms.TextBox textBoxStartQuestionNumber;
        private System.Windows.Forms.Button buttomProcessFormat2;
        private System.Windows.Forms.Button buttomProcessFormat4;
        private System.Windows.Forms.Label label1;
    }
}

