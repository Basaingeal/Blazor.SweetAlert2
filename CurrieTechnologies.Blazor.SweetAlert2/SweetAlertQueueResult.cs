﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CurrieTechnologies.Blazor.SweetAlert2
{
    public class SweetAlertQueueResult
    {
        public IEnumerable<string> Value { get; set; }
        public DismissReason Dismiss { get; set; }
    }
}
