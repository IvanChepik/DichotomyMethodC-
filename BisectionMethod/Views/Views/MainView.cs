using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Views.IViews;

namespace Views.Views
{
    public partial class MainView : Form, IMainView
    {
        private readonly ApplicationContext _context;

        public MainView(ApplicationContext context)
        {
            _context = context;
            InitializeComponent();
        }
      

        public new void Show()
        {
            _context.MainForm = this;
            base.Show();
        }

        public event Action Calculated;

        public string Expression => ExpressionTextBox.Text;

        public string BeginInterval => BeginIntervalTextBox.Text;

        public string EndInterval => EndIntervalTextBox.Text;

        public string ErrorExpression => ErrorTextBox.Text;

        public void ShowAnswer(string message, List<double> answerList, List<double> beginList, List<double> endList, List<double> functionList, int count)
        {
            AnswerLabel.Text = "x = " + message;
            InitAnswerView(count);
            for (var i = 0; i < count; i++)
            {
                AnswerGridView[0, i].Value = answerList[i];
                AnswerGridView[1, i].Value = beginList[i];
                AnswerGridView[2, i].Value = endList[i];
                AnswerGridView[3, i].Value = functionList[i];
            }

            if (answerList.Count > 1)
            {
                var graphic = new Graphic(answerList);
                graphic.Show();
            }
            else
            {
                MessageBox.Show("Алгоритм завершился за одну итерацию");
            }
        }

        public void ShowError(string message)
        {
            MessageBox.Show(message);
        }

        private void InitAnswerView(int count)
        {
            AnswerGridView.Visible = true;
            AnswerGridView.AllowUserToResizeColumns = false;
            AnswerGridView.AllowUserToResizeRows = false;
            //AnswerGridView.ColumnHeadersVisible = false;
            AnswerGridView.RowHeadersVisible = false;
            AnswerGridView.BorderStyle = BorderStyle.None;
            AnswerGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            AnswerGridView.AllowUserToAddRows = false;
            AnswerGridView.RowCount = count;
        }

        private void OnCalculated()
        {
            Calculated?.Invoke();
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            OnCalculated();
        }
    }
}
