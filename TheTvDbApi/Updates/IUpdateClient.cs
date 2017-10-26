//  _____ _        _____    ______ _      ___        _   
// |_   _| |      |_   _|   |  _  \ |    / _ \      (_)  
//   | | | |__   ___| |_   _| | | | |__ / /_\ \_ __  _   
//   | | | '_ \ / _ \ \ \ / / | | | '_ \|  _  | '_ \| |  
//   | | | | | |  __/ |\ V /| |/ /| |_) | | | | |_) | |_ 
//   \_/ |_| |_|\___\_/ \_/ |___/ |_.__/\_| |_/ .__/|_(_)
//                                            | |        
//                                            |_|        
// 
// Module   : TheTvDbApi/TheTvDbApi/IUpdateClient.cs
// Name     : Adrian Hum - adrianhum 
// Created  : 2017-10-27-7:19 AM
// Modified : 2017-10-27-7:23 AM

using System;
using TheTvDbApi.Updates.DataTypes;

namespace TheTvDbApi.Updates
{
    public interface IUpdateClient
    {
        UpdatedSeries[] Get(long epochFromTime, long epochToTime = -1);
        UpdatedSeries[] Get(DateTime fromTime, DateTime? toTime = null);
    }
}