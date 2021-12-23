using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace MedicalTests
{
    public partial class MedicalTestsForm : Form
    {
        public MedicalTestsForm()
        {
            InitializeComponent();
            comboBoxFormat.SelectedIndex = 0;
        }

        delegate string ProcessText(string text, int startNum);
        string fileContent = "";
        string filePath = "";

        private void buttonOpenFormatFolder_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(Environment.CurrentDirectory, @"FormatExamples\");
            Process.Start(path);
        }

        private void buttonProcess_Click(object sender, EventArgs e)
        {
            string format = comboBoxFormat.Text;
            switch (format) {
                case "Format1": ProcessTaskWithFormat(ProcessingMethods.ProcessFormat1); break;
                case "Format2": ProcessTaskWithFormat(ProcessingMethods.ProcessFormat2); break;
                case "Format3": ProcessTaskWithFormat(ProcessingMethods.ProcessFormat3); break;
            }
        }

        private void ProcessTaskWithFormat(ProcessText process) {
            bool isFileSelected = GetFileFromDialog();
            if (isFileSelected)
                ProcessTasks(fileContent, filePath, process);
        }

        private bool GetFileFromDialog() {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                        fileContent = reader.ReadToEnd();
                    return true;
                }
            }
            return false;
        }

        private void ProcessTasks(string text, string input, ProcessText processText) {
            string outputPath = input.Insert(input.Length-4, "_output");
            string result = processText(text, int.Parse(textBoxStartQuestionNumber.Text));
            File.WriteAllText(outputPath, result);
        }
    }
}
