using Blend.IT.CrossCutting.FluentValidator;
using System.Collections.Generic;

namespace Blend.IT.Tests.Util
{
    public class ResponseMvc
    {
        public bool sucess { get; set; }
        public List<Notification> errors { get; set; }
    }
}
