using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

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
                opt.Size = new Size(200, 50);
                opt.BackColor = Color.White;
                opt.BorderStyle = BorderStyle.FixedSingle;
                opt.Margin = new Padding(5);
                var label = new Label();
                label.Text = answ;
                label.AutoSize = true;
                var number = answs.IndexOf(answ);
                EventHandler clickdelegate = (s, ev) =>
                {
                    res += test.AnswerCost[number];
                    UpdateQuestion();
                };
                opt.Click += clickdelegate;
                label.Click += clickdelegate;
                opt.Controls.Add(label);
                flowLayoutPanel1.Controls.Add(opt);
            }
        }

        

        private void EndTest()
        {
            QuestionLabel.Text = "Тест завершен";
            flowLayoutPanel1.Controls.Clear();

            var panel = new Panel();
            panel.Size = new Size(500,500);
            panel.AutoSize = true;
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.Margin = new Padding(10);
            var label = new Label();
            label.Text = GetResult();
            label.AutoSize = true;
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
