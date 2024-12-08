using System;
using System.Drawing;
using System.Windows.Forms;

public static class FormHelper
{
    private static Point _previousLocation;

    public static void saveLocation(Form form)
    {
        _previousLocation = form.Location;
    }

    public static void newLocation(Form form)
    {
        form.Location = _previousLocation;
    }
}
