using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.IO;

namespace DNA.Util
{
    public class Log
    {
        /// <summary>
        /// Grava LOG no Disco
        /// </summary>
        /// <param name="mensagemErro">Mensagem de Erro</param>
        /// <param name="nomeMetodo">Nome do método que gerou o erro</param>
        /// <param name="nomeModulo">Nome do módulo que gerou o erro</param>
        public static void Save(string mensagemErro, string nomeMetodo, string nomeModulo, string CaminhoDiretorioLog)
        {
            DateTime DataBR = TimeZoneInfo.ConvertTime(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
            // Monta uma string com o diretório do arquivo de LOG.
            string strDir = CaminhoDiretorioLog + "\\" + System.Configuration.ConfigurationManager.AppSettings["DiretorioLog"];
            string strPath = strDir + "\\" + nomeModulo + "_" + DataBR.ToString("yyyyMMdd") + ".log";

            // Objeto responsável por escrever no arquivo de log.
            StreamWriter objWriter;

            // Caso o arquivo não exista, criá-o.
            if (!System.IO.File.Exists(strPath))
            {
                System.IO.Directory.CreateDirectory(strDir);
                objWriter = File.CreateText(strPath);
            }
            else
            {
                objWriter = new StreamWriter(strPath, true);
            }

            //Inicia a escrita no arquivo de log.
            objWriter.WriteLine();
            objWriter.WriteLine("------------------");

            // Nome do método.
            objWriter.WriteLine("Método: " + nomeMetodo);

            // Hora da gravação.
            objWriter.WriteLine("Hora da gravação do log: " + DataBR);

            // Detalhes do erro (p_objErro).
            objWriter.WriteLine("Detalhes do erro:");
            objWriter.WriteLine("    erro: " + mensagemErro);


            // Finaliza a escrita no arquivo de log.
            objWriter.WriteLine("------------------");
            objWriter.WriteLine();
            objWriter.Flush();
            objWriter.Close();
        }
    }
}
