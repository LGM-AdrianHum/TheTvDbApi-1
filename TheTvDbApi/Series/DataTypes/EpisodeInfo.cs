//  _____ _        _____    ______ _      ___        _   
// |_   _| |      |_   _|   |  _  \ |    / _ \      (_)  
//   | | | |__   ___| |_   _| | | | |__ / /_\ \_ __  _   
//   | | | '_ \ / _ \ \ \ / / | | | '_ \|  _  | '_ \| |  
//   | | | | | |  __/ |\ V /| |/ /| |_) | | | | |_) | |_ 
//   \_/ |_| |_|\___\_/ \_/ |___/ |_.__/\_| |_/ .__/|_(_)
//                                            | |        
//                                            |_|        
// File: TheTvDbApi/TheTvDbApi/EpisodeInfo.cs
// User: Adrian Hum/
// 
// Created:  2017-10-28 9:08 AM
// Modified: 2017-10-28 9:09 AM

//2017-10-28: Changed AiredEpisodeNumber and DvdEpisodeNumber to decimal (See Quantum Leap, 72248)
namespace TheTvDbApi.Series.DataTypes
{
    public class EpisodeInfo
    {
        public int AbsoluteNumber { get; set; }
        public decimal AiredEpisodeNumber { get; set; }
        public int AiredSeason { get; set; }
        public decimal DvdEpisodeNumber { get; set; }
        public int DvdSeason { get; set; }
        public string EpisodeName { get; set; }
        public int Id { get; set; }
        public string Overview { get; set; }
        public override string ToString()
        {
            return $"S{AiredSeason:00}E{AiredEpisodeNumber:00} - {EpisodeName} ({Id})";
        }
    }
}