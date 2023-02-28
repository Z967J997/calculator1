using Calculator;
using System.Data;

namespace Calculator;

public partial class CalculatorMainPage : ContentPage
{
	public CalculatorMainPage()
	{
		InitializeComponent();
        ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;
        mergedDictionaries.Clear();
        mergedDictionaries.Add(new LightTheme());

          OnClear(this, null);
    }
    double count = 0;
    double compNumber=0;
    string secondOperator = "";
    bool comp = false;

    bool check=true;
    
    string Entry = "";
    bool mod;
    string thirdOperator = "";
    string brackets = "";
    int currentState = 1;
    string mathOperator="";
    double firstNumber, secondNumber,thirdnumber;
    string decimalFormat = "N0";
    double ParanthesisCal;


    void OnSelectNumber(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        string pressed = button.Text;
        CurrentCalculation.Text += pressed;

      Entry += pressed;
       
        if ((this.resultText.Text == "0" && pressed == "0")
            || (Entry.Length <= 1 && pressed != "0")
            || currentState < 0)
        { 
         
            
            this.resultText.Text = ""; 
            if (currentState < 0)
                currentState *= -1; 

        }

        if (pressed == "." && decimalFormat != "N2")
        {
            decimalFormat = "N2";
        }
        
        this.resultText.Text += pressed;
    }

    void OnSelectOperator(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        string pressed = button.Text;
     
     

        count = count + 1;
        if(count>1 && pressed== "×" && check )
        {

            compNumber = firstNumber;
            currentState = 1;
            comp = true;
        }
        if(count==1)
        {
            secondOperator = pressed;
        }

        LockNumberValue(resultText.Text);

        if (currentState !=1 &&  secondNumber!=0)
        {

            double result = Calculator.Calculate(firstNumber, secondNumber, mathOperator);

            this.resultText.Text = result.ToString();

            currentState = 1;
        }
        else
        {
            currentState = 2;
        }
        mathOperator = pressed;

        CurrentCalculation.Text += mathOperator;
    }

    private void LockNumberValue(string text)
    {
        double number;
        double x = firstNumber;
        double y = secondNumber;
        if (double.TryParse(text, out number))
        {
            if (currentState == 1)
            {
                firstNumber = number;
            }
           
            else
            {
                secondNumber = number;
            }

          Entry = string.Empty;
        }
    }

    void OnClear(object sender, EventArgs e)
    {
        firstNumber = 0;
        secondNumber = 0;
        count = 0;
        comp = false;

        check = true;
        secondOperator = "";


        currentState = 1;
        thirdnumber = 0;
        compNumber = 0;
        check = true;
        decimalFormat = "N0";
        this.resultText.Text = "0";
        Entry = string.Empty; 
        this.CurrentCalculation.Text= "";
    }

    void OnCalculate(object sender, EventArgs e)
    {
       
            
                
            LockNumberValue(resultText.Text);
            double result=0;
         
            if (!mod  )
            {
                 result = Calculator.Calculate(firstNumber, secondNumber, mathOperator);
            if (comp && compNumber!=0)
            {
                result=Calculator.Calculate(compNumber,result,secondOperator);
                comp=false;
            }

            }

            if (mod==true)
            {
                 result = Calculator.Calculate(firstNumber, secondNumber, "%");
            }
             this.resultText.Text = result.ToTrimmedString(decimalFormat);


            this.CurrentCalculation.Text += "=" + result.ToString();
            firstNumber = result;
             mod=false;
            secondNumber = 0;
            currentState = 1;
              Entry = string.Empty;
           count = 0;
         comp = false;

            check = true;
            secondOperator = "";




    }

    void OnNegative(object sender, EventArgs e)
    {
        if (currentState == 1)
        {
            secondNumber = -1;
            mathOperator = "×";
            currentState = 2;
            OnCalculate(this, null);
        }
    }

    void OnMod(object sender, EventArgs e)
    {
        if (currentState == 1)
        {
            LockNumberValue(resultText.Text);
            mod = true;
            CurrentCalculation.Text=resultText.Text+ "mod" ;
           currentState = 2;

        }



    }

    void OnPercentage(object sender, EventArgs e)
    {
        if (currentState == 1)
        {
            LockNumberValue(resultText.Text);
            decimalFormat = "N2";
            secondNumber = 0.01;
            mathOperator = "×";
            currentState = 2;
            OnCalculate(this, null);
        }

    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        check=false;
        Button button = (Button)sender;
        if (button.Text == "(")
        {
            check = true;

            if ( firstNumber!=0)
            {
                thirdnumber =double.Parse(resultText.Text);
                thirdOperator = mathOperator;
            
            };
            currentState = 1;
            CurrentCalculation.Text += "(";
          

        }
        else
        {


             
                LockNumberValue(resultText.Text);
            

            double result = Calculator.Calculate(firstNumber, secondNumber, mathOperator);
            if (thirdnumber != 0)
            {

                firstNumber = thirdnumber;
                secondNumber = result;
                mathOperator = thirdOperator;

                currentState = 2;
            }
            else
            {
                firstNumber = result;
                secondNumber = 0;
                currentState = 1;
            }
          //  check = false;
            this.resultText.Text = result.ToString();
            
            //thirdOperator = "";
            CurrentCalculation.Text += ')';
          
        }
    }



    void OnSquareRoot(object sender, EventArgs e)
    {
        var sq = Math.Sqrt(int.Parse(Entry));
        double result = Math.Round(Convert.ToDouble(sq),2);
        this.resultText.Text = result.ToString() ;
        currentState = -1;
        CurrentCalculation.Text = "Sqrt (" + Entry+")" +" = "+ sq.ToString();



    }

}




//if (check &&  currentState==-2 && thirdOperator=="")
//{
//    double result = Calculator.Calculate(firstNumber, secondNumber, mathOperator);
//    this.resultText.Text = result.ToString();
//    thirdnumber = result;


//}

// OnCalculate(this, null);
//    decimalFormat = "N2";
//   secondNumber = 0.01;
//  mathOperator = "×";


//else if(currentState==-4)
//{
//    firstNumber=number;
//}

//else if(currentState == 3)
//{
//    this.resultText.Text = ParanthesisCal.ToTrimmedString(decimalFormat);
//}
//this.resultText.Text = "";
// }
//            //if (currentState < -2)
////{
////    this.resultText.Text = "";
////    LockNumberValue(currentEntry);
////}

//if (currentState < 0  )
//    currentState *= -1;
//if (secondNumber == 0)
//    LockNumberValue(resultText.Text);

//if (thirdnumber != 0)
//{
//    ParanthesisCal = Calculator.Calculate(thirdnumber, ParanthesisCal, thirdOperator);
//}


//Calculator.Calculate(resultText.Text) ;
// resultText.Text = result.ToString();
//    if (mathOperator != null )
//    {
//        thirdnumber = double.Parse(resultText.Text);
//        thirdOperator = mathOperator.ToString();

//    }
//    else
//    {
//        this.resultText.Text = "";
//    }
//    currentState = -4;
//   // this.resultText.Text += currentEntry;
//    //LockNumberValue(currentEntry);
//}
//else
//    {

//        currentState = 3;

//        CurrentCalculation.Text += ')';
//        LockNumberValue(currentEntry);
//        double ParanthesisCal = Calculator.Calculate(firstNumber, secondNumber, mathOperator);
//        if (thirdnumber != 0)
//        {
//            ParanthesisCal = Calculator.Calculate(thirdnumber, ParanthesisCal, thirdOperator);
//        }
//        this.resultText.Text = ParanthesisCal.ToString();
//        firstNumber = ParanthesisCal;
//        secondNumber = 0;
//        currentState = -1;
//      Entry = string.Empty;
//        // resultText.Text = result.ToString();
//    }
