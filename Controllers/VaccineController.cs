using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CartaoDeVacinaAPI.data;
using Microsoft.AspNetCore.Mvc;

namespace CartaoDeVacinaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VaccineController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public VaccineController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
    }
}