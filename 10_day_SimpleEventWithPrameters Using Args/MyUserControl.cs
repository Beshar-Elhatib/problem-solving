using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleEventWithPrameters
{
    public partial class MyUserControl : UserControl
    {

        /*
         I have modified the Day 9 code and expanded the use of events to achieve the following benefits:

         Separation of business logic from the user interface:

         The UserControl performs the calculation only, while the Form is responsible for displaying the results.

         Code reusability:

         Any number of similar UserControls can be added without modifying the logic.

         High flexibility:

         Each instance can subscribe to the event in different ways, or pass additional data when needed.

         Adoption of Event-Driven Programming:

         The application responds to events rather than executing everything sequentially, making the code more organized and maintainable.
         */



        public class CalculationCompleteEventArgs : EventArgs
        {
            public int Results { get; }
            public int Val1 { get; }
            public int Val2 { get; }

            public CalculationCompleteEventArgs(int Results, int Val1, int Val2)
            {
                this.Results = Results;
                this.Val1 = Val1;
                this.Val2 = Val2;
            }
        }

        public event EventHandler<CalculationCompleteEventArgs> OnCalculationComplete;

        public void RaiseOnCalulationComplete(int Results, int Val1, int Val2)
        {
            RaiseOnCalulationComplete(new CalculationCompleteEventArgs(Results, Val1, Val2));
        }

        protected virtual void RaiseOnCalulationComplete(CalculationCompleteEventArgs e)
        {
            OnCalculationComplete?.Invoke(this, e);
        }




        public MyUserControl()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            
            int Val1,Val2;
            Val1 = Convert.ToInt32(txtNumber1.Text);
            Val2 = Convert.ToInt32(txtNumber2.Text);

            int Result = Val1  + Val2;
            lblResult.Text = Result.ToString();

            if (OnCalculationComplete != null)
                // Raise the event with a parameter
                RaiseOnCalulationComplete(Result, Val1, Val2);


        }
    }
}
