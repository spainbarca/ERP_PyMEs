using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Capa_Soporte
{
    public class Datatables_tamañoAuto
    {
        public static void Multilinea(ref DataGridView List)
        {
            List.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells; //Redimensiona al tamaño del registro
            List.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; //encabezados en centro
            List.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft; //alineacion en el centro
            List.DefaultCellStyle.WrapMode = DataGridViewTriState.True; //ajustar a lineas subisguientes

            List.EnableHeadersVisualStyles = false;
            DataGridViewCellStyle styCabeceras = new DataGridViewCellStyle();
            styCabeceras.BackColor = Color.White;
            styCabeceras.ForeColor = Color.Black;
            styCabeceras.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            List.ColumnHeadersDefaultCellStyle = styCabeceras;
        }
    }
}
