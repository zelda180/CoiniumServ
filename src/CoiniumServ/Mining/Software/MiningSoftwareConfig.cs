﻿#region License
// 
//     CoiniumServ - Crypto Currency Mining Pool Server Software
//     Copyright (C) 2013 - 2014, CoiniumServ Project - http://www.coinium.org
//     http://www.coiniumserv.com - https://github.com/CoiniumServ/CoiniumServ
// 
//     This software is dual-licensed: you can redistribute it and/or modify
//     it under the terms of the GNU General Public License as published by
//     the Free Software Foundation, either version 3 of the License, or
//     (at your option) any later version.
// 
//     This program is distributed in the hope that it will be useful,
//     but WITHOUT ANY WARRANTY; without even the implied warranty of
//     MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//     GNU General Public License for more details.
//    
//     For the terms of this license, see licenses/gpl_v3.txt.
// 
//     Alternatively, you can license this software under a commercial
//     license or white-label it as set out in licenses/commercial.txt.
// 
#endregion

using System;
using System.Collections.Generic;
using Serilog;

namespace CoiniumServ.Mining.Software
{
    public class MiningSoftwareConfig:IMiningSoftwareConfig
    {
        public string Name { get; private set; }
        public string Version { get; private set; }
        public IList<string> Platforms { get; private set; }
        public IList<string> Algorithms { get; private set; }
        public string Site { get; private set; }
        public IDictionary<string, string> Downloads { get; private set; }

        public bool Valid { get; private set; }

        public MiningSoftwareConfig(dynamic config)
        {
            try
            {
                Name = config.name;
                Version = config.version;
                Platforms = config.platforms;
                Algorithms = config.algorithms;
                Site = config.site;
                Downloads = new Dictionary<string, string>
                {
                    {"windows", config.download.windows},
                    {"linux", config.download.linux},
                    {"macos", config.download.macos},
                };

                Valid = true;
            }
            catch (Exception e)
            {
                Valid = false;
                Log.Logger.ForContext<MiningSoftwareConfig>().Error(e, "Error loading software configuration");
            }
        }
    }
}
