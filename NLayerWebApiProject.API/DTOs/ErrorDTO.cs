using System.Collections.Generic;

namespace NLayerWebApiProject.API.DTOs
{
    public class ErrorDTO
    {
        public List<string> Errors { get; set; }
        public int StatusCode { get; set; }

        public ErrorDTO()
        {
            Errors = new List<string>();
        }
    }
}