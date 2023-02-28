namespace Calculator;

public partial class MenuThemes : ContentPage
{
    public MenuThemes()
    {
        InitializeComponent();
        ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;
             mergedDictionaries.Clear();
            mergedDictionaries.Add(new LightTheme());
 
    }

    void LightTheme(object sender, EventArgs e)
    {
        ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;
        if (mergedDictionaries != null)
        {
            mergedDictionaries.Clear();
            mergedDictionaries.Add(new LightTheme());
        }
    }

    void DarkTheme(object sender, EventArgs e)
    {
        ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;
        if (mergedDictionaries != null)
        {
            mergedDictionaries.Clear();
            mergedDictionaries.Add(new DarkTheme());
        }
    }

    void RedTheme(object sender, EventArgs e)
    {
        ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;
        if (mergedDictionaries != null)
        {
            mergedDictionaries.Clear();
            mergedDictionaries.Add(new GreenTheme());
        }
    }
    void PinkTheme(object sender, EventArgs e)
    {
        ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;
        if (mergedDictionaries != null)
        {
            mergedDictionaries.Clear();
            mergedDictionaries.Add(new PinkTheme());
        }
    }
}