using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ISII
{
    public class Validaciones
    {
        public bool VerificarTamaño(string e)
        {
            if ((e.Trim().Count() >= 10 && e.Trim().Count() <= 10) || e.Trim().Count() == 10 || e.Trim().Count() == 8)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool VerificarNumero(string e)
        {
            try
            {
                Convert.ToDecimal(e);
                return true;
            }
            catch (Exception)
            {
                return false;
                //throw;
            }
        }
        public bool VerificarDecimal(string e)
        {
            try
            {
                Convert.ToDecimal(e);
                return true;
            }
            catch (Exception)
            {
                return false;
                //throw;
            }
        }
        public bool VerificarExistencia(string e)
        {
            if (e.Trim().Length == 0 || e == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool verificarTexto(string textoVerificar)
        {
            try
            {

                string regularExpression = @"^[a-zA-Z]+\s*[a-zA-Z]*\s*[a-zA-Z]*$";
                string input = textoVerificar;
                if (Regex.IsMatch(input, regularExpression))
                {
                    return true;

                }

                else
                {
                    return false;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool VerificarCedula(String ced)
        {
            int isNumeric;
            var total = 0;
            const int tamanoLongitudCedula = 10;
            int[] coeficientes = { 2, 1, 2, 1, 2, 1, 2, 1, 2 };
            const int numeroProvincias = 24;
            const int tercerDigito = 6;

            if (int.TryParse(ced, out isNumeric) && ced.Length == tamanoLongitudCedula)
            {
                var provincia = Convert.ToInt32(string.Concat(ced[0], ced[1], string.Empty));
                var digitoTres = Convert.ToInt32(ced[2] + string.Empty);
                if ((provincia > 0 && provincia <= numeroProvincias) && digitoTres < tercerDigito)
                {
                    var digitoVerificadorRecibido = Convert.ToInt32(ced[9] + string.Empty);
                    for (var k = 0; k < coeficientes.Length; k++)
                    {
                        var valor = Convert.ToInt32(coeficientes[k] + string.Empty) *
                            Convert.ToInt32(ced[k] + string.Empty);
                        total = valor >= 10 ? total + (valor - 9) : total + valor;
                    }
                    var digitoVerificadorObtenido = total >= 10 ? (total % 10) != 0 ?
                        10 - (total % 10) : (total % 10) : total;

                    return digitoVerificadorObtenido == digitoVerificadorRecibido;
                }

                return false;
            }

            return false;
        }

        public bool verificarRucSociedadPrivada(string ruc)
        {
            long isNumeric;
            const int tamanoLongitudRuc = 13;
            const int modulo = 11;
            const int tercerDigito = 9;
            int total = 0;
            const string establecimiento = "001";
            int[] coeficientes = { 4, 3, 2, 7, 6, 5, 4, 3, 2 };
            if (long.TryParse(ruc, out isNumeric) && ruc.Length.Equals(tamanoLongitudRuc))
            {
                var numeroProvincia =
                    Convert.ToInt32(string.Concat(ruc[0] + string.Empty, ruc[1] + string.Empty));
                var sociedadPublica =
                    Convert.ToInt32(ruc[2] + string.Empty);
                if ((numeroProvincia >= 1 && numeroProvincia <= 24)
                    && sociedadPublica == tercerDigito &&
                    ruc.Substring(10, 3) == establecimiento)
                {
                    var digitoVerificadorRecibido = Convert.ToInt32(ruc[9] + string.Empty);
                    for (var i = 0; i < coeficientes.Length; i++)
                    {
                        total =
                            total + (coeficientes[i] *
                            Convert.ToInt32(ruc[i] +
                            string.Empty));
                    }
                    var digitoVerificadorObtenido = (total % modulo) == 0 ?
                        0 : modulo - (total % modulo);
                    return digitoVerificadorRecibido == digitoVerificadorObtenido;
                }
                return false;
            }
            return false;

        }//fin de verificar RUC sociedad privada

        public bool verificarRucPersonaNatural(string ruc)
        {
            long isNumeric;
            const int tamanoLongitudRuc = 13;
            const string establecimiento = "001";
            if (long.TryParse(ruc, out isNumeric) && ruc.Length.Equals(tamanoLongitudRuc))
            {
                var numeroProvincia = Convert.ToInt32(string.Concat(ruc[0] + string.Empty, ruc[1] + string.Empty));
                var personaNatural = Convert.ToInt32(ruc[2] + string.Empty);
                if ((numeroProvincia >= 1 && numeroProvincia <= 24) && (personaNatural >= 0 && personaNatural < 6))
                {
                    return ruc.Substring(10, 3) == establecimiento && VerificarCedula(ruc.Substring(0, 10));
                }
                return false;
            }
            return false;
        }//fin de verificar ruc persona natural

        public bool verificarRucSociedadPublica(string ruc)
        {
            long isNumeric;
            const int tamanoLongitudRuc = 13;
            const int modulo = 11;
            const int tercerDigito = 6;
            var total = 0;
            const string establecimiento = "0001";
            int[] coeficientes = { 3, 2, 7, 6, 5, 4, 3, 2 };
            if (long.TryParse(ruc, out isNumeric) && ruc.Length.Equals(tamanoLongitudRuc))
            {
                var numeroProvincia = Convert.ToInt32(string.Concat(ruc[0] + string.Empty, ruc[1] + string.Empty));
                var sociedadPublica = Convert.ToInt32(ruc[2] + string.Empty);
                if ((numeroProvincia >= 1 && numeroProvincia <= 24)
                    && sociedadPublica == tercerDigito && ruc.Substring(9, 4) == establecimiento)
                {
                    var digitoVerificadorRecibido = Convert.ToInt32(ruc[8] + string.Empty);
                    for (var i = 0; i < coeficientes.Length; i++)
                    {
                        total = total + (coeficientes[i] * Convert.ToInt32(ruc[i] + string.Empty));
                    }
                    var digitoVerificadorObtenido = modulo - (total % modulo);
                    return digitoVerificadorRecibido == digitoVerificadorObtenido;
                }
                return false;
            }
            return false;


        }//fin de verificarRucSociedadPublica
        public bool VerificarNumeroPositvo(string e)
        {
            try
            {
                if (Convert.ToDecimal(e) >= 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {
                return false;
                //throw;
            }
        }
        public string parte1(string texto1)
        {
            try
            {
                if (texto1 == "")
                {
                    return texto1 = "001";
                }
                else
                {
                    if (Convert.ToInt16(texto1) <= 9)
                    {
                        return texto1 = "00" + Convert.ToInt32(texto1).ToString();
                    }
                    if (Convert.ToInt16(texto1) <= 99)
                    {
                        return texto1 = "0" + Convert.ToInt32(texto1).ToString();
                    }
                }
                return texto1;
            }
            catch (Exception)
            {
                return "";
            }
        }
        public string parte3(string texto1)
        {
            try
            {

                if (texto1 == "")
                {
                    return texto1 = "000000001";
                }
                else
                {
                    if (Convert.ToInt32(texto1) <= 9)
                    {
                        return texto1 = "00000000" + Convert.ToInt32(texto1).ToString();
                    }
                    if (Convert.ToInt32(texto1) <= 99)
                    {
                        return texto1 = "0000000" + Convert.ToInt32(texto1).ToString();
                    }
                    if (Convert.ToInt32(texto1) <= 999)
                    {
                        return texto1 = "000000" + Convert.ToInt32(texto1).ToString();
                    }
                    if (Convert.ToInt32(texto1) <= 9999)
                    {
                        return texto1 = "00000" + Convert.ToInt32(texto1).ToString();
                    }
                    if (Convert.ToInt32(texto1) <= 99999)
                    {
                        return texto1 = "0000" + Convert.ToInt32(texto1).ToString();
                    }
                    if (Convert.ToInt32(texto1) <= 999999)
                    {
                        return texto1 = "000" + Convert.ToInt32(texto1).ToString();
                    }
                    if (Convert.ToInt32(texto1) <= 9999999)
                    {
                        return texto1 = "00" + Convert.ToInt32(texto1).ToString();
                    }
                    if (Convert.ToInt32(texto1) <= 99999999)
                    {
                        return texto1 = "0" + Convert.ToInt32(texto1).ToString();
                    }
                }
                return texto1;
            }
            catch (Exception)
            {
                return "";
            }
        }

        public bool validarCorreo(String email)
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

    }

}
