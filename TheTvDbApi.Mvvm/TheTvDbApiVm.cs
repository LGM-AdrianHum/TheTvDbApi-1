using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
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

        public List<string> SeasonEpisodeStructure { get; set; }

        public void AssociateFileListWithSeasonEpisodeCollection(List<string> fileList)
        {
            //TODO: Check to see if the episode/season structure is loaded

            //foreach (var v in SeasonEpisodeStructure.SelectMany(x => x.Episode))
            {
                var seepKey = "GetFormatted S01E01";
                var v = SeasonEpisodeStructure.FirstOrDefault(x => x.Contains("S1") && x.Contains("E01"));
                //if(v!=null) 
                //if (FileToSeason[v] == null) FileToSeason[v] = new Collection();
                //FileToSeason[v]=FileInfo;

            }
        }
    }
}
