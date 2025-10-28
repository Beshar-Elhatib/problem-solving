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

    /*
                 In this part of the project, I implemented the concept of Events in C#, with the goal
                of separating the execution logic from the user interface and achieving dynamic interaction
                within the application.

            I first started by defining a custom event within a separate class that represents a specific
                operation (such as a calculation or data manipulation).
            This event is used to notify other parts of the program when the operation is completed, with 
                the ability to pass additional data (such as a user ID or the result of the calculation).

            Next, I bound this event to the Windows Form so that:

            The operation is triggered when a button is pressed inside the form.

            The form receives the event after the operation completes, and executes specific code (such as 
                displaying a message to the user or updating a UI element).

            In this way, the application follows the Event-Driven Programming model, which makes the code more 
                organized, modular, and reusable, while keeping the business logic separate from the user interface.
     
     */
    public partial class MyUserControl : UserControl
    {

        // Define a custom event handler delegate with parameters
        public event Action<int> OnCalculationComplete;
        // Create a protected method to raise the event with a parameter
        protected virtual void CalculationComplete(int PersonID)
        {
            Action<int> handler = OnCalculationComplete;
            if (handler != null)
            {
                handler(PersonID); // Raise the event with the parameter
            }
        }

        public MyUserControl()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            int Result =  Convert.ToInt32 ( txtNumber1.Text) + Convert.ToInt32(txtNumber2.Text);
            lblResult.Text = Result.ToString();

            if (OnCalculationComplete != null)
                // Raise the event with a parameter
                CalculationComplete(Result);

        }
    }
}
