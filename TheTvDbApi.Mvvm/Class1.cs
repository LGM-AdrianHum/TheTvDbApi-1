using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TheTvDbApi.Mvvm.Annotations;

namespace TheTvDbApi.Mvvm
{
    public class TheTvDbApiVm : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

         
        
        public void AssociateFileListWithSeasonEpisodeCollection(List<string> fileList)
        {
            
        }
    }

    public class FileToSeason
    {
        public string SeasonKey { get; set; } 
        public List<FileInfo> FileInfoList { get; set; }=new List<FileInfo>();
    }
    
}
