using System;
using System.IO;
using System.Windows.Forms;

namespace MedicalTests
{
    public partial class MedicalTestsForm : Form
    {
        delegate string ProcessText(string text, int startNum);
        public MedicalTestsForm()
        {
            InitializeComponent();
        }

        string fileContent = "";
        string filePath = "";

        private void ButtonProcessFormat1_Click(object sender, EventArgs e)
        {
            ProcessTaskWithFormat(ProcessingMethods.ProcessFormat1);
        }

        private void ButtonProcessFormat2_Click(object sender, EventArgs e)
        {
            ProcessTaskWithFormat(ProcessingMethods.ProcessFormat2);
        }

        private void ButtonProcessFormat3_Click(object sender, EventArgs e)
        {
            ProcessTaskWithFormat(ProcessingMethods.ProcessFormat3);
        }

        private void ProcessTaskWithFormat(ProcessText process) {
            bool isFileSelected = GetFileFromDialog();
            if (isFileSelected)
            {
                ProcessTasks(fileContent, filePath, process);
            }
        }

        private bool GetFileFromDialog() {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "C:\\Users\\nemyt\\Desktop";
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
