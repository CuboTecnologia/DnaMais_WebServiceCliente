using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;

namespace DNA.Negocios.Cadastral.WEB
{
    public class Listas
    {
        private DateTime DataBR = TimeZoneInfo.ConvertTime(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));

        public List<Entidades.Cadastral.Cidade> ListarCidadesPorIdUF(int idUF, string UF, int idCidade, string NomeCidade)
        {
            try
            {
                List<Entidades.Cadastral.Cidade> listRet = new List<Entidades.Cadastral.Cidade>();

                DataSet ds = new DataSet();

                Dados.Cadastral.WS.Listas neg = new Dados.Cadastral.WS.Listas();

                neg.Cidades(idUF, UF, idCidade, NomeCidade, ref ds);

                if (ds != null && ds.Tables.Count > 0)
                {
                    // Tabela 1 -> Resultado
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Entidades.Cadastral.Cidade cid = new Entidades.Cadastral.Cidade();

                        cid.UF.IdUF = int.Parse(dr["ID_UF"].ToString());
                        cid.UF.NomeUF = dr["UF"].ToString();
                        cid.Nome = dr["NOME_CIDADE"].ToString();
                        cid.IdCidade = int.Parse(dr["ID_CIDADE"].ToString());

                        listRet.Add(cid);
                    }

                    if (ds.Tables[0].Rows.Count == 0)
                    { return null; }
                    else
                    { return listRet; }
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
