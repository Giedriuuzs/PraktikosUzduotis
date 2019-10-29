using System;
using System.Collections.Generic;

namespace Backend
{
    public partial class Comments
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public string Email { get; set; }
        public string Time { get; set; }
        public long? FkRecord { get; set; }

        public virtual Records FkRecordNavigation { get; set; }
    }
}
