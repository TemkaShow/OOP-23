﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2.TypeAccount
{
    class StandardGameAccount : GameAccount
    {
        public override int CalculatePoints(int gameRating)
        {
            return gameRating;
        }
    }
}
