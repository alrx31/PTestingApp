namespace PTestApp
{
    public partial class TestForm : Form
    {
        private Test test;
        private int res;
        private int questionNumber = 0;

        public TestForm(Test test)
        {
            InitializeComponent();
            this.test = test;
            this.BackColor = Color.AliceBlue;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void TestForm_Load(object sender, EventArgs e)
        {
            res = 0;
            QuestionLabel.Text = test.Name;
            NextButton.Click += NextButton_Click;
        }

        private void NextButton_Click(object? sender, EventArgs e)
        {
            UpdateQuestion();
            NextButton.Enabled = false;
        }

        private void UpdateQuestion()
        {
            var que = test.GetNextQuestion(questionNumber++);
            
            if(que is null)
            {
                EndTest();
                return;
            }
            
            QuestionLabel.Text = que.Question;
            FillAnswers(que.Answers);

        }

        private void FillAnswers(List<string> answs)
        {
            
            flowLayoutPanel1.Controls.Clear();
            foreach (var answ in answs)
            {
                var opt = new Panel();
                opt.Size = new Size(700, 50);
                opt.BackColor = Color.White;
                opt.BorderStyle = BorderStyle.FixedSingle;
                opt.Margin = new Padding(5);
                opt.BorderStyle = BorderStyle.FixedSingle;
                var label = new Label();
                label.Text = answ;
                label.AutoSize = true;
                label.AutoSize = false;
                label.Size = new Size(700, 50);

                var number = answs.IndexOf(answ);
                EventHandler clickdelegate = (s, ev) =>
                {
                    res += test.AnswerCost[number];
                    UpdateQuestion();
                };
                opt.Click += clickdelegate;
                label.Click += clickdelegate;

                label.Cursor = Cursors.Hand;
                opt.Cursor = Cursors.Hand;
                opt.Controls.Add(label);
                flowLayoutPanel1.Controls.Add(opt);
            }
        }

        

        private void EndTest()
        {
            QuestionLabel.Text = "Тест завершен";
            flowLayoutPanel1.Controls.Clear();

            var panel = new Panel();
            panel.Size = new Size(500,200);
            panel.AutoSize = true;
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.Margin = new Padding(10);
            panel.BackColor = Color.White;
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.Padding = new Padding(10);
            var label = new Label();
            label.Text = GetResult();
            label.AutoSize = false;
            label.Size = new Size(500, 200);
            panel.Controls.Add(label);
            flowLayoutPanel1.Controls.Add(panel);
            NextButton.Click -= NextButton_Click;
            NextButton.Click += (s,ev)=> {
                this.Close();
            };
        }


        private void NextButton_Click1(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public string GetResult()
        {
            foreach (var res in test.Results)
            {
                if (this.res >= res.From && this.res <= res.To)
                {
                    return res.Message;
                }
            }
            return "Результат не найден";
        }
    }
}
