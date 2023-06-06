using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Datos
{
    public class ClienteCon
    {
        private static ClienteCon instance = null;
        public static ClienteCon GetClienteCon
        {
            get
            {
                //Si no existe instancia se genera una nueva
                if (instance == null)
                {
                    instance = new ClienteCon();
                }
                return instance;
            }
        }

        private ClienteCon() { }


    }
}
