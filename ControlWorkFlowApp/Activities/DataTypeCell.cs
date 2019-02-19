﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ControlWorkFlowApp
{
    public sealed class DataTypeCell : DataGridViewComboBoxCell
    {
        public void OnDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            this.DataSource = new List<DataType>(this.DataSource as List<DataType>)
            {
                DataType.CreateInstance(this.Value.ToString())
            };
            e.ThrowException = false;
        }
    }
}
