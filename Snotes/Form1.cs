using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Snotes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string fileName = "C:\\Users\\sveno\\OneDrive\\Desktop\\Projects\\Beginner Projects\\Snotes\\Tasks\\Tasks.json";
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
                string fileName = "C:\\Users\\sveno\\OneDrive\\Desktop\\Projects\\Beginner Projects\\Snotes\\Tasks\\Tasks.json";
                List<string> tasks = new List<string>();
                textBox1.Text = "";
                if (note.Length < 40)
                    checkedListBox1.Items.Insert(0, note);
                else
                    checkedListBox1.Items.Insert(0, note.Substring(0, 39));
                
                for(int i = 0; i<checkedListBox1.Items.Count; i++)
                {
                    tasks.Add(checkedListBox1.Items[i].ToString());
                }

                string jsonString = JsonSerializer.Serialize(tasks);
                File.WriteAllText(fileName, jsonString);

            }

        }
    }
}