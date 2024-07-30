using System;
using System.Drawing;
using System.Windows.Forms;

namespace proyectoFinalPOE
{
    public static class Estilos
    {
        public static void ApplyButtonStyle(Button button)
        {
            button.BackColor = Color.FromArgb(0, 117, 214);
            button.FlatAppearance.BorderSize = 0;
            button.FlatStyle = FlatStyle.Flat;
            button.Font = new Font("Bahnschrift", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button.ForeColor = Color.White;
        }

        public static void ApplyButtonStyleSmallFont(Button button)
        {
            button.BackColor = Color.FromArgb(0, 117, 214);
            button.FlatAppearance.BorderSize = 0;
            button.FlatStyle = FlatStyle.Flat;
            button.Font = new Font("Bahnschrift", 10F, FontStyle.Bold, GraphicsUnit.Point, 0); // Smaller font size
            button.ForeColor = Color.White;
        }
    }
}
