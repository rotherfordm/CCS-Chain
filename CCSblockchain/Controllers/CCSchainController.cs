using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Web.Mvc;

using CCSblockchain.Models;
using System.Web.Http;


namespace CCSblockchain.Controllers
{
    public class CCSchainController : ApiController
    {
        BlockHandler obj = new BlockHandler();

        [Route("api/blocks")]
        [HttpGet]
        public IHttpActionResult GetAllBlocks()
        {
            //return Ok(obj.blockChain); //TODO: fix this --
            return null; 
        }

        //[Route("mine")]
        //[HttpPost]
        //public

    }
}