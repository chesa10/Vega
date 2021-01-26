using System.Threading;
using System;
using System.Collections;
using System.Net;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vega.Controllers.Resources;
using Vega.Models;
using Vega.Persistence;

namespace Vega.Controllers
{
    public class FeaturesController : Controller
    {
        private readonly VegaDbContext context;
        private readonly IMapper mapper;

        public FeaturesController(VegaDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }

        [HttpGet("/api/features/")]
        public async Task<IEnumerable<KeyValuePairResource>> GetFeatures()
        {
            var feature = await this.context.Features.ToListAsync();
            return mapper.Map<List<Feature>, List<KeyValuePairResource>>(feature);
        }

    }
}