﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsPractice.Command
{
    public interface ICommand
    {
        // do
        void Execute();

        // undo
        void CancelExecute();
    }
}
