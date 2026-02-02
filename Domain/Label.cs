namespace Branders.Domain;

public class Label
{
    public string PrintTSPL {  get; set; }
    public string DrawTSPL { get; set; }

    public Label(string data, string labelName)
    {
        DrawTSPL = GetDrawTSPL(data);
        PrintTSPL = GetPrintTSPL(labelName);
    }

    private string GetPrintTSPL(string labelName)
    {
        switch (labelName)
        {
            case "Sheet 1": 
                return "SIZE 110 mm, 110 mm\n GAP 2 mm, 0 mm\n REFERENCE 0,0\n SPEED 2\n DENSITY 10\n SET RIBBON ON\n SET PEEL OFF\n SET CUTTER OFF\n SET PARTIAL_CUTTER OFF\n SET TEAR ON\n SET REWIND OFF\n DIRECTION 0\n SHIFT 0,0\n OFFSET 0 mm";
            case "Sheet 2":
                return "SIZE 110 mm, 110 mm\n GAP 2 mm, 0 mm\n REFERENCE 0,0\n SPEED 2\n DENSITY 10\n SET RIBBON ON\n SET PEEL OFF\n SET CUTTER OFF\n SET PARTIAL_CUTTER OFF\n SET TEAR ON\n SET REWIND OFF\n DIRECTION 0\n SHIFT 0,0\n OFFSET 0 mm";
        }
        return "";
    }

    private string GetDrawTSPL(string data)
    {
        // different label layouts
        return "";
    }
}