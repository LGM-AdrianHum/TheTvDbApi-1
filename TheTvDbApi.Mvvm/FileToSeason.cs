using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using TheTvDbApi.Mvvm.Annotations;

namespace TheTvDbApi.Mvvm
{
    public class FileToSeason:IDictionary<string,List<FileInfo>>, INotifyPropertyChanged
    {
        //https://msdn.microsoft.com/en-us/library/system.collections.idictionary(v=vs.110).aspx
        
        
        public string SeasonKey { get; set; }
        public List<FileInfo> FileInfoList { get; set; } = new List<FileInfo>();
        public IEnumerator<KeyValuePair<string, List<FileInfo>>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(KeyValuePair<string, List<FileInfo>> item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(KeyValuePair<string, List<FileInfo>> item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(KeyValuePair<string, List<FileInfo>>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<string, List<FileInfo>> item)
        {
            throw new NotImplementedException();
        }

        public int Count { get; }
        public bool IsReadOnly { get; }
        public bool ContainsKey(string key)
        {
            throw new NotImplementedException();
        }

        public void Add(string key, List<FileInfo> value)
        {
            throw new NotImplementedException();
        }

        public bool Remove(string key)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(string key, out List<FileInfo> value)
        {
            throw new NotImplementedException();
        }

        public List<FileInfo> this[string key]
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public ICollection<string> Keys { get; }
        public ICollection<List<FileInfo>> Values { get; }

        private bool TryGetIndexOfKey(string seasonEpisodeKey, out int index)
        {
            //TODO
            //for (index = 0; index < ItemsInUse; index++)
            //{
            //    // If the key is found, return true (the index is also returned).
            //    if (items[index].Key.Equals(key)) return true;
            //}

            //// Key not found, return false (index should be ignored by the caller).
            index = -1;
            return false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}