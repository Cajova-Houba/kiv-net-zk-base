﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDbCore.Model
{
    public interface IExportableToHtml
    {
        string[] GetFieldNames();

        string[] GetFieldValues();
    }
}
