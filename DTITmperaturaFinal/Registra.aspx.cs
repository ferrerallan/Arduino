using CALogin;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TemperaturaDTI
{
    public partial class Registra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BOCALogin.setConexao("[famema.famema]");
            string t = Request["t"].ToString();

            string sql = "insert into sihosp.dti_temperatura( nro_temperatura ) values ("+t+") ";

            string ret = BDOracle.executaComandoCommit(sql);
            Response.Write(ret);
            Response.Flush();
        }
    }
}