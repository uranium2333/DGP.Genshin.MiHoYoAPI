﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGP.Genshin.MiHoYoAPI
{
    /// <summary>
    /// 指示这个接口尚未经过测试
    /// 可能不会按预期工作
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class UnTestedAPIAttribute : Attribute
    {
    }
}