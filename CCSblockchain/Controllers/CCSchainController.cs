using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Blockchain;
//using System.Web.Http;


namespace CCSblockchain.Controllers
{
    public class CCSchainController : Controller
    {
        List<Block> listBlocks = new List<Block>();
        BlockHandler obj = new BlockHandler();

        [Route("blocks")]
        [HttpGet]
        public IEnumerable<Block> GetAllBlocks()
        {                                            
            return obj.GetBlocks();
        }

        //[Route("mine")]
        //[HttpPost]
        //public

    }
}