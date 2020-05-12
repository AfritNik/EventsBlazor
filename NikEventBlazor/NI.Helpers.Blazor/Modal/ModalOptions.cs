using System;
using System.Collections.Generic;
using System.Text;

namespace NI.Helpers.Blazor.Modal
{
    public class ModalOptions
    {
        public string Position { get; set; }
        public string Style { get; set; }
        public bool? DisableBackgroundCancel { get; set; }
        public bool? ShowButton { get; set; } = true;
        public bool? ShowHeader { get; set; } = true;
        public bool? ShowCloseButton { get; set; } = true;
    }
}
