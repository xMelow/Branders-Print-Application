namespace Branders.Domain;

public class Label
{
    public string TsplContent { get; set; }

    public Label(string tspl)
    {
        TsplContent = tspl;
    }
}