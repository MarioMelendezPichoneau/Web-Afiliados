using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIAfiliados.DATA;
using WebAPIAfiliados.Models;

namespace WebAPIAfiliados.Controllers
{
    public class AFLIADOSController : ApiController
    {
        // GET api/<controller>
        public List<AFILIADOS> Get()
        {
            return AfiliadosData.Listar();
        }

        // GET api/<controller>/5
        //public void Get(AFILIADOS oAfiliados)
        //{
        //    //return "value";

            


        //}

        // POST api/<controller>
        public bool Post([FromBody] AFILIADOS oAfiliados)
        {
            return AfiliadosData.Registrar(oAfiliados);
        }

        // PUT api/<controller>/5
        public bool Put([FromBody] AFILIADOS oAfiliados)
        {
            return AfiliadosData.Modificar(oAfiliados);
        }

        // DELETE api/<controller>/5
        public bool Delete(int id)
        {
            return AfiliadosData.Eliminar(id);
        }
    }
}
