using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Text.RegularExpressions;

namespace DNA.Util
{
    public class CEP
    {
        public static void ConsultaOnline(string cep, ref string logradouro, ref string bairro, ref string cidade, ref string estado, ref string uf, ref string erro)
        {
            try
            {
                string Retorno = "";
                string MontaURL = "http://www.buscacep.correios.com.br/servicos/dnec/consultaLogradouroAction.do?Metodo=listaLogradouro&CEP=" + cep + "&TipoConsulta=cep";

                WebClient webClient = new WebClient();
                webClient.Encoding = System.Text.Encoding.GetEncoding("ISO-8859-1");

                Retorno = webClient.DownloadString(MontaURL);

                if (Retorno.IndexOf("<font color=\"black\">CEP NAO ENCONTRADO</font>") >= 0)
                {
                    //erro = "<b style=\"color:red\">CEP não localizado.</b>";
                    erro = "CEP não localizado.";
                }
                else
                {
                    logradouro = Regex.Match(Retorno, "<td width=\"268\" style=\"padding: 2px\">(.*)</td>").Groups[1].Value;
                    bairro = Regex.Matches(Retorno, "<td width=\"140\" style=\"padding: 2px\">(.*)</td>")[0].Groups[1].Value;
                    cidade = Regex.Matches(Retorno, "<td width=\"140\" style=\"padding: 2px\">(.*)</td>")[1].Groups[1].Value;
                    uf = Regex.Match(Retorno, "<td width=\"25\" style=\"padding: 2px\">(.*)</td>").Groups[1].Value;

                    if (uf.ToUpper().Trim().Equals("RJ"))
                    { estado = "RIO DE JANEIRO"; }
                    else if (uf.ToUpper().Trim().Equals("SP"))
                    { estado = "SÃO PAULO"; }
                    else if (uf.ToUpper().Trim().Equals("AC"))
                    { estado = "ACRE"; }
                    else if (uf.ToUpper().Trim().Equals("AL"))
                    { estado = "ALAGOAS"; }
                    else if (uf.ToUpper().Trim().Equals("AP"))
                    { estado = "AMAPÁ"; }
                    else if (uf.ToUpper().Trim().Equals("AM"))
                    { estado = "AMAZONAS"; }
                    else if (uf.ToUpper().Trim().Equals("BA"))
                    { estado = "BAHIA"; }
                    else if (uf.ToUpper().Trim().Equals("CE"))
                    { estado = "CEARÁ"; }
                    else if (uf.ToUpper().Trim().Equals("DF"))
                    { estado = "DISTRITO FEDERAL"; }
                    else if (uf.ToUpper().Trim().Equals("ES"))
                    { estado = "ESPÍRITO SANTO"; }
                    else if (uf.ToUpper().Trim().Equals("GO"))
                    { estado = "GOIÁS"; }
                    else if (uf.ToUpper().Trim().Equals("MA"))
                    { estado = "MARANHÃO"; }
                    else if (uf.ToUpper().Trim().Equals("MT"))
                    { estado = "MATO GROSSO"; }
                    else if (uf.ToUpper().Trim().Equals("MS"))
                    { estado = "MATO GROSSO DO SUL"; }
                    else if (uf.ToUpper().Trim().Equals("MG"))
                    { estado = "MINAS GERAIS"; }
                    else if (uf.ToUpper().Trim().Equals("PA"))
                    { estado = "PARÁ"; }
                    else if (uf.ToUpper().Trim().Equals("PB"))
                    { estado = "PARAÍBA"; }
                    else if (uf.ToUpper().Trim().Equals("PR"))
                    { estado = "PARANÁ"; }
                    else if (uf.ToUpper().Trim().Equals("PE"))
                    { estado = "PERNAMBUCO"; }
                    else if (uf.ToUpper().Trim().Equals("PI"))
                    { estado = "PIAUÍ"; }
                    else if (uf.ToUpper().Trim().Equals("RN"))
                    { estado = "RIO GRANDE DO NORTE"; }
                    else if (uf.ToUpper().Trim().Equals("RS"))
                    { estado = "RIO GRANDE DO SUL"; }
                    else if (uf.ToUpper().Trim().Equals("RO"))
                    { estado = "RONDÔNIA"; }
                    else if (uf.ToUpper().Trim().Equals("RR"))
                    { estado = "RORAIMA"; }
                    else if (uf.ToUpper().Trim().Equals("SC"))
                    { estado = "SANTA CATARINA"; }
                    else if (uf.ToUpper().Trim().Equals("SE"))
                    { estado = "SERGIPE"; }
                    else if (uf.ToUpper().Trim().Equals("TO"))
                    { estado = "TOCANTINS"; }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
