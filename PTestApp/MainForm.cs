using System.Text.Json;

namespace PTestApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var tests = ReadTests();

            foreach (var test in tests)
            {
                var panel = new Panel();
                panel.Size = new Size(200, 50);
                panel.BorderStyle = BorderStyle.FixedSingle;
                panel.Margin = new Padding(10);
                panel.Controls.Add(new Label() { Text = test.Name});
                panel.Click += (s, ev) =>
                {
                    var testForm = new TestForm(test);
                    testForm.ShowDialog();
                };

                flowLayoutPanel1.Controls.Add(panel);
                
            }

        }

        private List<Test> ReadTests()
        {
            var list = new List<Test>();

            // string folderPath = "Data";
            string folderPath = "..\\..\\..\\Data"; 

            string[] jsonFiles = Directory.GetFiles(folderPath, "*.json");

            foreach (string jsonFile in jsonFiles)
            {
                string content = File.ReadAllText(jsonFile);
                list.Add(JsonSerializer.Deserialize<Test>(content));
            }


            return list;
        }
    }
}
