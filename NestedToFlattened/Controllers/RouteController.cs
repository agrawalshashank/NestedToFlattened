using AutoMapper;
using Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NestedToFlattened.Dto;
using Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NestedToFlattened.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouteController : ControllerBase
    {
        private readonly IRouteService _routeService;
        private readonly IMapper _mapper;
        public RouteController(IRouteService routeService, IMapper mapper)
        {
            _routeService = routeService;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult FlattenedData(IEnumerable<RouteDto> routeDto)
        {
            var routeDetails = _mapper.Map<IEnumerable<Route>>(routeDto);
            return Ok(_routeService.FlattenedData(routeDetails));
        }
    }
}
