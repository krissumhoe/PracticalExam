namespace PracticalExam
{
    public partial class MainPage : ContentPage
    {
        int status = 1;
        string? mathOp; // Operator
        double x, y; // X = First Number, Y = Second Number
        bool decimalChecker = false;

        public MainPage()
        {
            InitializeComponent();
            Clear(this, null);
        }

        void Clear(object sender, EventArgs e)
        {
            x = 0;
            y = 0;
            status = 1;
            this.result.Text = "0";
            decimalChecker = false;
        }
        void Delete(object sender, EventArgs e)
        {
            if (this.result.Text.Length < 2)
            {
                this.result.Text = "0";
                if (status == 1)
                {
                    x = 0;
                }
                else if (status == 2)
                {
                    y = 0;
                }
            }
            else
            {
                this.result.Text = this.result.Text.Substring(0, this.result.Text.Length - 1);
                if (status == 1)
                {
                    x = double.Parse(this.result.Text);
                }
                else if (status == 2)
                {
                    y = double.Parse(this.result.Text);
                }
            }
        }

        void DecimalSelect(object sender, EventArgs e)
        {
            if (!decimalChecker)
            {
                this.result.Text += ".";
                decimalChecker = true;
            }
        }

        void InputSelect(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string btnPressed = button.Text;

            if (this.result.Text == "0" || status < 0)
            {
                this.result.Text = string.Empty;
                if(status < 0)
                {
                    status *= -1;
                }
            }

                this.result.Text += btnPressed;

                double num;

                if (double.TryParse(this.result.Text, out num))
                {
                    if (decimalChecker)
                    {
                        num += 0.1;
                    }

                    this.result.Text = num.ToString("N0");
                    if (status == 1)
                    {
                        x = num;
                    }
                    else
                    {
                        y = num;
                    }
                }
        }

        void OperatorSelect(object sender, EventArgs e)
        {
            status = -2;
            Button button = (Button)sender;
            string btnPressed = button.Text;
            mathOp = btnPressed;
            decimalChecker = false;
        }

        void Calculate(object sender, EventArgs e)
        {
            if(status == 2)
            {
                double result = 0;

                switch (mathOp)
                {
                    case "+":
                        result = x + y;
                        break;
                    case "-":
                        result = x - y;
                        break;
                    case "X":
                        result = x * y;
                        break;
                    case "/":
                        result = x / y;
                        break;
                    default:
                        result = x;
                        break;
                }

                this.result.Text = result.ToString();
                x = result;
                status = -1;
                decimalChecker = false;
            }
        }
    }
}
