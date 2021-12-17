using System;
using System.IO;
using System.Windows.Forms;

namespace MedicalTests
{
    public partial class MedicalTestsForm : Form
    {
        public MedicalTestsForm()
        {
            InitializeComponent();
        }

        string fileContent = "";
        string filePath = "";

        private void ButtonProcessFormat1_Click(object sender, EventArgs e)
        {
            bool isFileSelected = GetFileFromDialog();
            if (isFileSelected)
                ProcessTasks(fileContent, filePath);
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

        private void ProcessTasks(string text, string input) {
            string outputPath = input.Insert(input.Length-4, "_output");
            string result = ProcessingMethods.ProcessText(text, int.Parse(textBoxStartQuestionNumber.Text));
            File.WriteAllText(outputPath, result);
        }
        

        private void ButtonProcessFormat2_Click(object sender, EventArgs e)
        {
            bool isFileSelected = GetFileFromDialog();
            if (isFileSelected) {
                ProcessTasksOtherFormat(fileContent, filePath);
            }
        }

        private void ProcessTasksOtherFormat(string text, string input)
        {
            string outputPath = input.Insert(input.Length - 4, "_output");
            string result = ProcessingMethods.ProcessTextOtherFormat(text, int.Parse(textBoxStartQuestionNumber.Text));
            File.WriteAllText(outputPath, result);
        }

        private void ButtonProcessFormat3_Click(object sender, EventArgs e)
        {
            bool isFileSelected = GetFileFromDialog();
            if (isFileSelected) {
                ProcessTasksLastFormat(fileContent, filePath);
            }
        }

        private void ProcessTasksLastFormat(string text, string input)
        {
            string outputPath = input.Insert(input.Length - 4, "_output");
            string result = ProcessingMethods.ProcessTextLastFormat(text, int.Parse(textBoxStartQuestionNumber.Text));
            File.WriteAllText(outputPath, result);
        }
    }
}
