using System;
using System.Collections.Generic;
using System.Text;

namespace CurrieTechnologies.Blazor.SweetAlert2
{
    public class SweetAlertResult
    {
        public dynamic Value { get; set; }
        public SweetAlertService.DismissReason Dismiss { get; set; }
    }
}
