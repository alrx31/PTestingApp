using System.Text.Json;

namespace PTestApp
{
    public partial class MainForm : Form
    {
        private Dictionary<int, string> themes = new Dictionary<int, string> {
            {1, "Делегирование" },
            {2, "События" },
            {3, "Исключения" },
            {4, "Коллекции" },
            {5, "Потоки" },
            {6, "Работа с файлами" },
            {7, "Работа с сетью" }
        };

        public MainForm()
        {
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {

            ChoiseTestTheme();

            this.BackColor = Color.AliceBlue;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

        }

        private void ChoiseTestTheme()
        {
            flowLayoutPanel1.Controls.Clear();
            for (int i = 1; i <= 7; i++)
            {
                var index = i;
                var panel = new Panel();
                panel.Size = new Size(200, 50);
                panel.BorderStyle = BorderStyle.FixedSingle;
                panel.Margin = new Padding(10);
                panel.Padding = new Padding(10);
                panel.BackColor = Color.White;
                panel.BorderStyle = BorderStyle.FixedSingle;

                var label = new Label() { Text = $"{themes[index]}" };
                label.Click += (s, ev) =>
                {
                    var tests = ReadTests(index);
                    FillTests(tests);
                };
                label.AutoSize = false;
                label.Size = new Size(200, 50);
                label.Cursor = Cursors.Hand;
                panel.Cursor = Cursors.Hand;

                panel.Controls.Add(label);
                panel.Click += (s, ev) =>
                {
                    var tests = ReadTests(index);
                    FillTests(tests);
                };
                flowLayoutPanel1.Controls.Add(panel);
            }
        }

        private List<Test> ReadTests(int indx)
        {
            var list1 = new List<Test>();

            // string folderPath = "Data";
            string folderPath = "..\\..\\..\\Data";

            string[] jsonFiles = Directory.GetFiles(folderPath, $"{indx}*.json");


            foreach (string jsonFile in jsonFiles)
            {
                string content = File.ReadAllText(jsonFile);
                list1.Add(JsonSerializer.Deserialize<Test>(content));
            }


            return list1;
        }

        private void FillTests(List<Test> tests)
        {
            flowLayoutPanel1.Controls.Clear();
            foreach (var test in tests)
            {
                var panel = new Panel();
                panel.Size = new Size(200, 50);
                panel.BorderStyle = BorderStyle.FixedSingle;
                panel.Margin = new Padding(10);
                panel.BackColor = Color.White;
                panel.BorderStyle = BorderStyle.FixedSingle;
                var label = new Label() { Text = test.Name };
                label.AutoSize = false;
                label.Size = new Size(200, 50);

                label.Click += (s, ev) =>
                {
                    var testForm = new TestForm(test);
                    testForm.ShowDialog();
                };

                panel.Controls.Add(label);
                
                panel.Click += (s, ev) =>
                {
                    var testForm = new TestForm(test);
                    testForm.ShowDialog();
                };

                label.Cursor = Cursors.Hand;
                panel.Cursor = Cursors.Hand;

                flowLayoutPanel1.Controls.Add(panel);
            }
            this.backButton.Visible = true;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.backButton.Visible = false;
            ChoiseTestTheme();
        }
    }
}
