using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Text.RegularExpressions;

namespace DNA.Util
{
    public class Format
    {

        public enum TypeString
        {
            Text,
            Numeric,
            CNPJ,
            CPF,
            Date,
            Int,
            CEP,
            Telephone,
            Currency
        }

        public static string FormatString(string Value, TypeString tType)
        {
            try
            {
                switch (tType)
                {
                    case TypeString.CNPJ:
                        return string.Format("{0}.{1}.{2}/{3}-{4}", Value.Substring(0, 2), Value.Substring(2, 3), Value.Substring(5, 3), Value.Substring(8, 4), Value.Substring(12, 2));

                    case TypeString.CPF:
                        return string.Format("{0}.{1}.{2}-{3}", Value.Substring(0, 3), Value.Substring(3, 3), Value.Substring(6, 3), Value.Substring(9, 2));

                    case TypeString.Date:
                        if (Convert.ToDateTime(Value) == Convert.ToDateTime("1/1/1900"))
                            return string.Empty;
                        else
                            return Convert.ToDateTime(Value).ToString("dd/MM/yyyy");

                    case TypeString.Numeric:
                        return Convert.ToDouble(Value).ToString("#,##0.00");

                    case TypeString.Int:
                        return Convert.ToInt64(Value).ToString("#,##0");

                    case TypeString.Text:
                        return Value;

                    case TypeString.CEP:
                        return string.Format("{0}.{1}-{2}", Value.Substring(0, 2), Value.Substring(2, 3), Value.Substring(5, 3));

                    case TypeString.Telephone:
                        Value = Value.Replace("-", "").Replace(" ", "").Replace(".", "");
                        return string.Format("{0}-{1}", Value.Substring(0, Value.Length - 4), Value.Substring(Value.Length - 4, 4));

                    case TypeString.Currency:
                        return Convert.ToDouble(Value).ToString("C");

                    default:
                        return Value;
                }

            }
            catch
            {
                return Value;
            }
        }

        public static void OcultaColunaEspecificaGrid(ref GridView oGrid, int NumeroColuna)
        {
            if (oGrid.Rows.Count > 0)
            {
                for (int i = 0; i < oGrid.Rows.Count; i++)
                {
                    oGrid.HeaderRow.Cells[NumeroColuna].Visible = false;
                    oGrid.Rows[i].Cells[NumeroColuna].Visible = false;
                }
            }
        }

        public static string RemoverAcentos(string inputString)
        {
            if ((inputString == "") || (inputString == null))
                return "";

            string normalizedString = inputString.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < normalizedString.Length; i++)
            {
                UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(normalizedString[i]);
                if (uc != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(normalizedString[i]);
                }
            }
            return (sb.ToString().Normalize(NormalizationForm.FormC));
        }

        public static string RemoverCaracteresEspeciais(string texto)
        {
            return texto.Replace(@"\u00e1", "á").Replace(@"\u00e0", "à").Replace(@"\u00e2", "â").
                         Replace(@"\u00e3", "ã").Replace(@"\u00e4", "ä").Replace(@"\u00c1", "Á").
                         Replace(@"\u00c0", "À").Replace(@"\u00c2", "Â").Replace(@"\u00c3", "Ã").
                         Replace(@"\u00c4", "Ä").Replace(@"\u00e9", "é").Replace(@"\u00e8", "è").
                         Replace(@"\u00ea", "ê").Replace(@"\u00ea", "ê").Replace(@"\u00c9", "É").
                         Replace(@"\u00c8", "È").Replace(@"\u00ca", "Ê").Replace(@"\u00cb", "Ë").
                         Replace(@"\u00ed", "í").Replace(@"\u00ec", "ì").Replace(@"\u00ee", "î").
                         Replace(@"\u00ef", "ï").Replace(@"\u00cd", "Í").Replace(@"\u00cc", "Ì").
                         Replace(@"\u00ce", "Î").Replace(@"\u00cf", "Ï").Replace(@"\u00f3", "ó").
                         Replace(@"\u00f2", "ò").Replace(@"\u00f4", "ô").Replace(@"\u00f5", "õ").
                         Replace(@"\u00f6", "ö").Replace(@"\u00d3", "Ó").Replace(@"\u00d2", "Ò").
                         Replace(@"\u00d4", "Ô").Replace(@"\u00d5", "Õ").Replace(@"\u00d6", "Ö").
                         Replace(@"\u00fa", "ú").Replace(@"\u00f9", "ù").Replace(@"\u00fb", "û").
                         Replace(@"\u00fc", "ü").Replace(@"\u00da", "Ú").Replace(@"\u00d9", "Ù").
                         Replace(@"\u00db", "Û").Replace(@"\u00e7", "ç").Replace(@"\u00c7", "Ç").
                         Replace(@"\u00f1", "ñ").Replace(@"\u00d1", "Ñ").Replace(@"\u0026", "&").
                         Replace(@"\u0027", "'");
        }

        // o metodo ValidaCPFCNPJ recebe dois parâmetros:
        // uma string contendo o cpf ou cnpj a ser validado
        // e um valor do tipo boolean, indicando se o método irá
        // considerar como válido um cpf ou cnpj em branco.
        // o retorno do método também é do tipo boolean:
        // (true = cpf ou cnpj válido; false = cpf ou cnpj inválido)
        public static bool ValidaCPFCNPJ(string cpfcnpj, bool vazio)
        {
            if (string.IsNullOrEmpty(cpfcnpj))
                return vazio;
            else
            {
                int[] d = new int[14];
                int[] v = new int[2];
                int j, i, soma;
                string Sequencia, SoNumero;

                SoNumero = Regex.Replace(cpfcnpj, "[^0-9]", string.Empty);

                //verificando se todos os numeros são iguais
                if (new string(SoNumero[0], SoNumero.Length) == SoNumero) return false;

                // se a quantidade de dígitos numérios for igual a 11
                // iremos verificar como CPF
                if (SoNumero.Length == 11)
                {
                    for (i = 0; i <= 10; i++) d[i] = Convert.ToInt32(SoNumero.Substring(i, 1));
                    for (i = 0; i <= 1; i++)
                    {
                        soma = 0;
                        for (j = 0; j <= 8 + i; j++) soma += d[j] * (10 + i - j);

                        v[i] = (soma * 10) % 11;
                        if (v[i] == 10) v[i] = 0;
                    }
                    return (v[0] == d[9] & v[1] == d[10]);
                }
                // se a quantidade de dígitos numérios for igual a 14
                // iremos verificar como CNPJ
                else if (SoNumero.Length == 14)
                {
                    Sequencia = "6543298765432";
                    for (i = 0; i <= 13; i++) d[i] = Convert.ToInt32(SoNumero.Substring(i, 1));
                    for (i = 0; i <= 1; i++)
                    {
                        soma = 0;
                        for (j = 0; j <= 11 + i; j++)
                            soma += d[j] * Convert.ToInt32(Sequencia.Substring(j + 1 - i, 1));

                        v[i] = (soma * 10) % 11;
                        if (v[i] == 10) v[i] = 0;
                    }
                    return (v[0] == d[12] & v[1] == d[13]);
                }
                // CPF ou CNPJ inválido se
                // a quantidade de dígitos numérios for diferente de 11 e 14
                else return false;
            }
        }
    }
}
