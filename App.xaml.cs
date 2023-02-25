namespace Calculator;

public partial class App : Application
{ 

    public App( )
	{
        NavigationPage navigation = new NavigationPage(new CalculatorMainPage());
        MainPage = navigation;
        InitializeComponent();
       // HistoryVM = historyVM;
    }
}
