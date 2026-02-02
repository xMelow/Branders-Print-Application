namespace Branders.Domain;

public class Label
{
    public string Name { get; set; }
    public string PrintTSPL {  get; set; }
    public string DrawTSPL { get; set; }

    public Label(string name, string printTspl, string drawTspl)
    {
        Name = name;
        PrintTSPL = printTspl;
        DrawTSPL = drawTspl;
    }
}