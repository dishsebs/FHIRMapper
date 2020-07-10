using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;
using System.IO;

namespace FHIRMapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourceTypeController : ControllerBase
    {
        [HttpGet("[action]")]
        public IEnumerable<string> ResourceTypes()
        {

            FhirJsonParser fhirJsonParser = new FhirJsonParser();
            string line = string.Empty;

            using(StreamReader sr = new StreamReader(@"C:\fhir_sample_data\fhir_dstu2\Aaron697_Brekke496_2fa15bc7-8866-461a-9000-f739e425860a.json"))
            {
                line = sr.ReadToEnd();
            }

            var result = fhirJsonParser.Parse<Bundle>(line);
            var ResourceTypeLst = result.Entry.Select(x => x.Resource.TypeName).Distinct();

            return ResourceTypeLst;
        }
    }
}
