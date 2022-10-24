using System.Security.Cryptography.X509Certificates;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Snotes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string fileName = @"C:\SnotesSaves\Tasks.json";
            string path = @"C:\SnotesSaves\";
            if(!Directory.Exists(path))
                Directory.CreateDirectory(path);

            try 
            {
                string jsonString = File.ReadAllText(fileName);
                string[] tasks = JsonSerializer.Deserialize<string[]>(jsonString);
                for(int i = tasks.Length-1; i >= 0; i--)
                {
                    checkedListBox1.Items.Insert(0, tasks[i]);
                }
            }
            catch
            {

            }
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "")
            {
                string note = textBox1.Text;
                textBox1.Text = "";
                if (note.Length < 40)
                    checkedListBox1.Items.Insert(0, note);
                else
                    checkedListBox1.Items.Insert(0, note.Substring(0, 39));
                SaveTasks();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(checkedListBox1.Items.Count > 0)
            {
                for(int i = checkedListBox1.Items.Count-1;i>=0;i--)
                {
                    if(checkedListBox1.GetItemChecked(i))
                    {
                        checkedListBox1.Items.Remove(checkedListBox1.Items[i]);
                    }
                }
                SaveTasks();
            }
        }
        public void SaveTasks()
        {
            string fileName = @"C:\SnotesSaves\Tasks.json";
            List<string> tasks = new List<string>();
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                tasks.Add(checkedListBox1.Items[i].ToString());
            }

            string jsonString = JsonSerializer.Serialize(tasks);
            File.WriteAllText(fileName, jsonString);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.Items.Count > 0)
            {
                for (int i = checkedListBox1.Items.Count - 1; i >= 0; i--)
                {
                    checkedListBox1.Items.Remove(checkedListBox1.Items[i]);
                }
                SaveTasks();
            }
        }
    }
}