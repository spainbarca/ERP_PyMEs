using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capa_Soporte
{
    public class ValidacionCampos
    {
        public void ValidarSoloNumeros(KeyPressEventArgs keyPress)
        {
            if (Char.IsDigit(keyPress.KeyChar))
            {
                keyPress.Handled = false;
            }
            else if (Char.IsSeparator(keyPress.KeyChar))
            {
                keyPress.Handled = false;
            }
            else if (Char.IsControl(keyPress.KeyChar))
            {
                keyPress.Handled = false;
            }
            else
            {
                keyPress.Handled = true;
                MessageBox.Show("¡Sólo se admiten números!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void ValidarSoloDecimales(TextBox sCadena, KeyPressEventArgs keyPress)
        {
            char signo_decimal = (char)46;

            if (keyPress.KeyChar == signo_decimal)
            {
                if (sCadena.Text.Length == 0 | sCadena.Text.LastIndexOf(signo_decimal) >= 0)
                {
                    keyPress.Handled = true; // Interceptamos la pulsación para que no permitirla.
                }
                else //Si hay caracteres continuamos las comprobaciones
                {
                    //Cambiamos la pulsación al separador decimal definido por el sistema 
                    keyPress.KeyChar = Convert.ToChar(System.Globalization.NumberFormatInfo.CurrentInfo.CurrencyDecimalSeparator);
                    keyPress.Handled = false; // No hacemos nada y dejamos que el sistema controle la pulsación de tecla
                }
                return;
            }
            else if (Char.IsNumber(keyPress.KeyChar))
            {
                keyPress.Handled = false;
            }
            else if (Char.IsControl(keyPress.KeyChar))
            {
                keyPress.Handled = false;
            }
            else
            {
                keyPress.Handled = true;
                MessageBox.Show("¡Sólo se admiten decimales!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void ValidarSoloLetras(KeyPressEventArgs keyPress)
        {
            if (Char.IsLetter(keyPress.KeyChar))
            {
                keyPress.Handled = false;
            }
            else if (Char.IsSeparator(keyPress.KeyChar))
            {
                keyPress.Handled = false;
            }
            else if (Char.IsControl(keyPress.KeyChar))
            {
                keyPress.Handled = false;
            }
            else
            {
                keyPress.Handled = true;
                MessageBox.Show("¡Sólo se admiten letras!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void ValidarSoloAlfanumericos(KeyPressEventArgs keyPress)
        {
            if (Char.IsLetter(keyPress.KeyChar))
            {
                keyPress.Handled = false;
            }
            else if (Char.IsDigit(keyPress.KeyChar))
            {
                keyPress.Handled = false;
            }
            else if (Char.IsControl(keyPress.KeyChar))
            {
                keyPress.Handled = false;
            }
            else
            {
                keyPress.Handled = true;
                MessageBox.Show("¡Sólo se admiten alfanuméricos!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void ValidarTextoEnriquecido(KeyPressEventArgs keyPress)
        {
            if (Char.IsLetterOrDigit(keyPress.KeyChar))
            {
                keyPress.Handled = false;
            }
            else if (Char.IsSeparator(keyPress.KeyChar))
            {
                keyPress.Handled = false;
            }
            else if (Char.IsPunctuation(keyPress.KeyChar))
            {
                keyPress.Handled = false;
            }
            else if (Char.IsControl(keyPress.KeyChar))
            {
                keyPress.Handled = false;
            }
            else
            {
                keyPress.Handled = true;
                MessageBox.Show("¡Caracter no válido!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void ValidarMascara(KeyPressEventArgs keyPress)
        {
            if (Char.IsWhiteSpace(keyPress.KeyChar))
            {
                keyPress.Handled = true;
                MessageBox.Show("¡Sólo se admiten espacios en blanco!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //public bool ValidarMaximoCaracteresDni(Persona persona)
        //{
        //    bool excedioValor = false;
        //    try
        //    {
        //        if (persona != null)
        //        {
        //            if (persona.Dni.Length > 8)
        //                excedioValor = true;
        //        }
        //        else
        //        {
        //            if (persona.Dni.Length <= 8)
        //                excedioValor = false;
        //        }
        //        return excedioValor;

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}
