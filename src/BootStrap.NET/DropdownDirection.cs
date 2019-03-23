﻿using System.ComponentModel;

namespace BootStrap.Net
{
    public enum DropdownDirection
    {
        Down,
        [Description("dropup")]
        Up,
        [Description("dropright")]
        Right,
        [Description("dropleft")]
        Left
    }
}
